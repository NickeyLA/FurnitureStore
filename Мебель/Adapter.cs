using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;

namespace Мебель
{
    public static class Adapter
    {   
        public static User ActiveUser;
        public static string Pri;
        private static MySqlConnection DBConnector = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=assort");
        public static OnListUpdate OnBasketUpdate;
        public static bool ListIsNotNull { get { return FoodsToBuy.Count != 0; } }
        public static BusketFood[] BusketElements { get { return FoodsToBuy.ToArray(); } }
        public delegate void OnListUpdate();                
        private static List<BusketFood> FoodsToBuy = new List<BusketFood>();

        public static BusketFood[] GetServerFoodForBusket()
        {
            DBConnector.Open();
            string sql = $"SELECT * FROM `busket` WHERE user_id = '{ActiveUser.id}'";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            DataTable temp = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(temp);
            var foods = new List<BusketFood>();
            foreach (DataRow item in temp.Rows)
            {
                BusketFood meb = new BusketFood()
                {
                    id = (uint)item.Field<int>(0),
                    userid = (uint)item.Field<int>(1),
                    Meb_Name = item.Field<string>(2),
                    Meb_Desc = item.Field<string>(3),
                    Meb_Prices = (string)item.Field<string>(4),
                    Meb_Count = (int)item.Field<int>(5)
                };
                foods.Add(meb);
            }
            DBConnector.Close();
            return foods.ToArray();
        }

        public static void AddToDBPhoneNumber(string Phone)
        {
           // "INSERT INTO `phone`(`id`, `user_id`, `phoneNum`) VALUES([value - 1],[value-2],[value-3])"
            DBConnector.Open();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `phone`(`id`, `user_id`, `phoneNum`) VALUES (null, '{ActiveUser.id}', '{Phone}')", DBConnector);
            command.ExecuteNonQuery();
            DBConnector.Close();
        }

        public static void AddelementToBasket(BusketFood busketFood)
        {
            FoodsToBuy.Add(busketFood);
            UpdateBasketDB(false, busketFood);
            OnBasketUpdate?.Invoke();
        }
        public static void AddelementToBasket(BusketFood[] busketFood)
        {
            FoodsToBuy.Clear();
            foreach (var item in busketFood)
            {
                FoodsToBuy.Add(item);
            }
            OnBasketUpdate?.Invoke();
        }
        public static void RemoveElementToBasket(BusketFood busketFood)
        {
            FoodsToBuy.Remove(busketFood);
            UpdateBasketDB(true, busketFood);
            OnBasketUpdate?.Invoke();
        }
        public static void LoadSeverBasket()
        {
            AddelementToBasket(GetServerFoodForBusket());
        }
        public static MEB[] GetFoodListFromDB()
        {
            List<MEB> foods = new List<MEB>();
            DBConnector.Open();
            string sql = $"Select * from 'mebel'";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            DataTable temp = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(temp);
            foreach (DataRow item in temp.Rows)
            {
                var food = new MEB()
                {
                    id = item.Field<uint>(0),   
                    name = item.Field<string>(1),
                    description = item.Field<string>(2),
                    imgUrl = item.Field<string>(3),
                    type = item.Field<string>(4),
                    price = item.Field<int>(5),
                };
                foods.Add(food);
            }
            DBConnector.Close();
            return foods.ToArray();
        }
        
        private static void UpdateBasketDB(bool deleted, BusketFood food)
        {
            DBConnector.Open();
            string sql = "";
            if (deleted)
            {
                sql = $"DELETE FROM `busket` WHERE id = '{food.id}'";
            }
            else
            {
                sql = $"INSERT INTO `busket`(`id`, `user_id`, `meb_name`, `meb_desk`, `meb_price`, `meb_count`) VALUES (null, '{ActiveUser.id}', '{food.Meb_Name}', '{food.Meb_Desc}', '{food.Meb_Prices}', '{food.Meb_Count}')";
            }
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Close();
            DBConnector.Close();
            AddelementToBasket(GetServerFoodForBusket());
        }
        public static int GetAllPrice()
        {
            int price = 0;
            foreach (var item in FoodsToBuy)
            {
               // price += item.Meb_Prices * item.Meb_Count;
            }
            return (int)price;
        }
        public static bool Login(string login, string password, out string Message)
        {
            bool respowns;
            DBConnector.Open();
            string sql = $"SELECT * FROM `users` WHERE login = '{login}' AND password = '{password}' ";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                Message = "Вход выполнен успешно";
                ActiveUser = new User
                {
                    id = rdr.GetUInt32("id"),
                    login = rdr.GetString("login"),
                    password = rdr.GetString("password"),
                };
                respowns = true;
            }
            else
            {
                Message = "Пароль или логин введены не правильно";
                respowns = false;
            }
            DBConnector.Close();
            if(respowns)
            Adapter.LoadSeverBasket();
            return respowns;
        }
        public static bool Registration(string login, string password, out string Message)
        {
            bool respowns;
            DBConnector.Open();
            string sql = $"SELECT * FROM `users` WHERE login = '{login}' ";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                Message = "Такой логин уже занят";
                respowns = false;
            }
            else
            {
                MySqlCommand command2 = new MySqlCommand($"INSERT INTO `users`(`id`, `login`, `password`) VALUES (null, '{login}','{password}')", DBConnector);
                rdr.Close();
                command2.ExecuteNonQuery();
                Message = "Регистрация успешна!";
                respowns = true;
            }
            DBConnector.Close();
            return respowns;
        }
        public static UserControl[] GetMebElements(string type)
        {
            
            List<UserControl> MebElements = new List<UserControl>();
            string sql = $"SELECT * FROM `mebel` WHERE type = '{type}'";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
                DataTable temp = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(temp);
                foreach (DataRow item in temp.Rows)
                {
                string Pri = item.Field<string>(5);
                var meb = new Assort.Assort_Bads(item.Field<string>(3), item.Field<string>(1), item.Field<string>(2), item.Field<string>(5));
                MebElements.Add(meb);
                }
            DBConnector.Close();
            return MebElements.ToArray();
        }
    }
}
 