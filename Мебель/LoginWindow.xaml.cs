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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MainWindow mainWindow = new MainWindow();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OpenRegisrationWindow(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow(this);
            registration.ShowDialog();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text != null && LoginField.Text != "" && PasswordField.Text != null && PasswordField.Text != "")
            {
                if (Adapter.Login(LoginField.Text, PasswordField.Text, out string message))
                {
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }   
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!mainWindow.IsActive)
                mainWindow.Close();
            base.OnClosed(e);
        }
        
    }
}
