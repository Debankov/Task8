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

namespace HealthHere.Frames
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        ViewModel _currentUser = new ViewModel();


        public UserPage()
        {
            InitializeComponent();

            GridUserName.DataContext= _currentUser;

        }
        
        class CurrentUser
        {
        
        }
 
    }
}
