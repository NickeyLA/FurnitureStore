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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMeb();
        }

        public UserControl[]
            BadElements,
            TablesElements,
            OpenBasketElements,
            CabinetsElements,
            ChairsElements,
            ChestsElements,
            SofasElements;

        private void LoadMeb()
        {
            BadElements = Adapter.GetMebElements("Bad");
            TablesElements = Adapter.GetMebElements("Tables");
            OpenBasketElements = Adapter.GetMebElements("Busket");
            CabinetsElements = Adapter.GetMebElements("Cabinets");
            ChairsElements = Adapter.GetMebElements("Chairs");
            ChestsElements = Adapter.GetMebElements("Chests");
        }

        private void OpenBasket(object sender, RoutedEventArgs e)
        {
            BusketWindow window = new BusketWindow(this);
            window.ShowDialog();
        }

        private void Assort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadBadPage(object sender, RoutedEventArgs e)
        {
            MenuTitle.Content = "Кровати";
            Asso.Columns = 4;
            Asso.Children.Clear();
            if (BadElements != null)
            {
                foreach (var item in BadElements)
                {
                    Asso.Children.Add(item);
                }
            }
        }

        private void LoadTablesPage(object sender, RoutedEventArgs e)
        {
            MenuTitle.Content = "Столы";
            Asso.Columns = 4;
            Asso.Children.Clear();
            if (TablesElements != null)
            {
                foreach (var item in TablesElements)
                {
                    Asso.Children.Add(item);
                }
            }
        }

        private void LoadCabinetsPage(object sender, RoutedEventArgs e)
        {
            MenuTitle.Content = "Шкафы";
            Asso.Columns = 4;
            Asso.Children.Clear();
            if (CabinetsElements != null)
            {
                foreach (var item in CabinetsElements)
                {
                    Asso.Children.Add(item);
                }
            }
        }

        private void LoadChairsPage(object sender, RoutedEventArgs e)
        {
            MenuTitle.Content = "Кресла";
            Asso.Columns = 4;
            Asso.Children.Clear();
            if (ChairsElements != null)
            {
                foreach (var item in ChairsElements)
                {
                    Asso.Children.Add(item);
                }
            }
        }

        private void LoadChestsPage(object sender, RoutedEventArgs e)
        {
            MenuTitle.Content = "Комоды";
            Asso.Columns = 4;
            Asso.Children.Clear();
            if (ChestsElements != null)
            {
                foreach (var item in ChestsElements)
                {
                    Asso.Children.Add(item);
                }
            }
        }
    }
}
