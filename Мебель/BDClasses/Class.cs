using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мебель
{
    public class BusketFood
    {
        public uint id { get; set; }//Поле отвечающее за id 
        public uint userid { get; set; }   // поле отвечающее за id мебели
        public string Meb_Name { get; set; }// Поле отвечающее за название мебели
        public string Meb_Desc { get; set; }//Поле отвечающее за описание мебели
        public string Meb_Prices { get; set; }//============Поле отвечающее за цену мебели
        public int Meb_Count { get; set; }//Поле отвечающее за количество мебели
    
        public BusketFood()
        {

        }

        public BusketFood(Assort.Assort_Bads element)//конструктор принимающий обьект класса Assort_Bads
        {
            Meb_Name = element.Meb_Name;
            Meb_Desc = element.Meb_Desc;

           Meb_Prices = element.Meb_Prices;
           Meb_Count = 1;
  
        }
    }
}
