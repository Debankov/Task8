using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
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

namespace HealthHere.Frames
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private user _currentUser = new user();

        public Registration()
        {
            InitializeComponent();

            DataContext = _currentUser;
        }

        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            userLogin.ToolTip = null;
            userPassword.ToolTip = null;

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


            var users = HealthHereEntities.GetContext().user.ToList();
            foreach( var user in users )
            {
                if (user.login == _currentUser.login)
                {
                    Errors.AppendLine("Пользователь с таким логином уже существует");
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            if (Errors.Length > 0)
                return;

            _currentUser.password = GetHash(userPassword.Password);
            _currentUser.is_stuff = false;

            if (_currentUser.user_id == 0)
                HealthHereEntities.GetContext().user.Add(_currentUser);

            try
            {
                HealthHereEntities.GetContext().SaveChanges();
                ViewModel.MainFrame.GoBack();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }

        }
    }
}
