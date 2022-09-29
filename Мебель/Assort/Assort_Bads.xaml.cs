using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Мебель.Assort
{
    /// <summary>
    /// Логика взаимодействия для Assort_Bads.xaml
    /// </summary>
    public partial class Assort_Bads : UserControl
    {
        public string Meb_Name { get; set; }
        public string Meb_Desc { get; set; }
        public string Meb_Prices { get; set; }
        public int Meb_Count { get; set; }

        //  public Dictionary<int, string> Meb_Prices = new Dictionary<int, string>();

        public Assort_Bads()
        {
            InitializeComponent();
        }

        private void AddElementToBAsket(object sender, RoutedEventArgs e)//Событие при добавлении в корзину
        {
            Adapter.AddelementToBasket(new BusketFood(this));
        }

        public Assort_Bads(string imgUrl, string name, string desc, string price)
            {
        
            Meb_Prices = price;
            InitializeComponent();
            MebDis.Text = desc;//Изменили контент обьекта TextBlock, отвечающий за описание
            MebName.Content = name;//Изменили контент обьекта label отвечающий за описание
            Meb_Name = name;//Указали название

            var image = new Image();// Cоздали обьект картинки
            BitmapImage bitmap = new BitmapImage();//Создали обьект BitMap
            bitmap.BeginInit();//Инициализировали обьект BitMap
            bitmap.UriSource = new Uri(imgUrl, UriKind.Absolute);// Загрузили картинку в bitmap по ссылке
            bitmap.EndInit();//Завершили процусс инициализации элемента
            MebImg.Source = bitmap;//Задали картинке мебели картинку из Bitmap 


            //if (Meb_Count == 0) Meb_Count = 1;

            var text = new TextBlock();
            var runPrice = new Run($"{price} ₽");
            runPrice.FontSize = 20;
            text.Inlines.Add(new Bold(runPrice));
            
            Meb_PricesXAM.Content = text;
            
        }
      /*private void CountMinus(object sender, MouseButtonEventArgs e)
        {
            int count = int.Parse(FoodCount.Content.ToString());
            if (count == 1)
            {
                Meb_Count = count;
                return;
            }
            count--;
            FoodCount.Content = count;
            Meb_Count = count;

        }

        private void CountPlus(object sender, MouseButtonEventArgs e)
        {
            int count = int.Parse(FoodCount.Content.ToString());
            if (count == 10)
            {
                Meb_Count = count;
                return;
            }
            count++;
            FoodCount.Content = count;
            Meb_Count = count;
        }*/
    }
}
