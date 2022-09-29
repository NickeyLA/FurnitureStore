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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        LoginWindow LoginWindow;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        public RegistrationWindow(LoginWindow loginWindow)
        {
            this.LoginWindow = loginWindow;
            InitializeComponent();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text != null && LoginField.Text != "" && PasswordField.Text != null && PasswordField.Text != "")
            {
                if (Adapter.Registration(LoginField.Text, PasswordField.Text, out string message))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }
    }
}
