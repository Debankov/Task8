using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

namespace HealthHere.Frames
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        int errorAuth = 0;
        private user _currentUser = new user();


        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        public Login()
        {
            InitializeComponent();

            DataContext = _currentUser;
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.login))
            {
                userLogin.ToolTip = "Введите логин";
                Errors.AppendLine("Введите логин");
                MessageBox.Show("Введите Логин");
            }
            if (string.IsNullOrWhiteSpace(userPassword.Password))
            {
                userPassword.ToolTip = "Введите пароль";
                Errors.AppendLine("Введите пароль");
                MessageBox.Show("Введите Пароль");
            }
            if (Errors.Length > 0)
                return;

            

            bool valid = false;
            bool is_stuff = false;
            var users = HealthHereEntities.GetContext().user.ToList();
            DateTime UnclockAuthTime = new DateTime();

            foreach (var user in users)
            {

                if (_currentUser.login == user.login && GetHash(userPassword.Password) == user.password)
                {
                    valid = true;
                    is_stuff = (bool)user.is_stuff;
                    ViewModel.user_id = user.user_id;
                    ViewModel.is_stuff = is_stuff; 
                    ViewModel.MainFrame.Navigate(new UserPage());
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.UserText.Text = "Профиль";
                } 
            }

            if (!valid)
            {
                errorAuth++;

                if (errorAuth <= 3)
                {
                    MessageBox.Show("Неверный логин/пароль " + errorAuth.ToString());
                }
                else
                {

                    UnclockAuthTime = DateTime.Now.AddMinutes(1);
                    LoginButton.IsEnabled = false;
                    MessageBox.Show("Вход заблокирован до " + UnclockAuthTime.ToShortTimeString());

                    Thread.Sleep(30 * 1000);
                    errorAuth = 0;
                    LoginButton.IsEnabled = true;
                }
            }
            else
            {
                ViewModel.MainFrame.Navigate(new UserPage());
                HealthHereEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var order = HealthHereEntities.GetContext().order.ToList();
                var user = HealthHereEntities.GetContext().user.Where(u => u.user_id == ViewModel.user_id).ToList();
                
                foreach(var currentOrder in order)
                {
                    if(currentOrder == null)
                    {
                        currentOrder.user_id= ViewModel.user_id;
                    }
                    foreach(var currentUser in user)
                    {
                        currentUser.last_online = DateTime.Now;
                    }
                    try
                    {
                        HealthHereEntities.GetContext().SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
           
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MainFrame.Navigate(new Registration());
        }

    }
}
