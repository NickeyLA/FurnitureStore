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

namespace Мебель
{
    /// <summary>
    /// Логика взаимодействия для BusketElement.xaml
    /// </summary>
    public partial class BusketElement : UserControl
    {
        BusketFood basketElement;
        BusketWindow basket;

        public BusketElement(BusketFood basketElement, BusketWindow basket)
        {
            InitializeComponent();

            this.basket = basket;//сохранили обьект BusketWindow
            this.basketElement = basketElement;//созранили элемент Busket_Meb
            
            BasketElement_Prise.Content = basketElement.Meb_Prices + " p";//изменили контент обьекта отвечающего за цену
            BasketElement_name.Text = basketElement.Meb_Name;//изменили контент обьекта отвечающего за название
            BasketElement_Desc.Content = basketElement.Meb_Desc;//изменили контент обьекта отвечающего за описание
            BasketElement_count.Content = basketElement.Meb_Count;//изменили контент обьекта отвечающего за количество

        }

        private void RemoveBascetElement(object sender, RoutedEventArgs e)
        {
            Adapter.RemoveElementToBasket(basketElement);
            basket.FillBusket();
        }
    }
}
