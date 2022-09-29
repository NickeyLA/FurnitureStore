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
using System.Windows.Shapes;

namespace Мебель
{
    /// <summary>
    /// Логика взаимодействия для BusketWindow.xaml
    /// </summary>
    public partial class BusketWindow : Window
    {
        private Window mainWindow;
        public BusketWindow()
        {
            InitializeComponent();
        }
        public BusketWindow(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
            FillBusket();
        }
        public void FillBusket()
        {
            BasketElements.Children.Clear();
            foreach (var item in Adapter.BusketElements)
            {
                BusketElement busketElemet = new BusketElement(item, this);
                BasketElements.Children.Add(busketElemet);
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            Adapter.OnBasketUpdate -= FillBusket;
            base.OnClosed(e);
        }

        private void Zak(object sender, RoutedEventArgs e)
        {
            Assort.Zakaz zak = new Assort.Zakaz();
            zak.ShowDialog();

        }
    }
}
