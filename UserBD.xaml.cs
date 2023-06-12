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

namespace Diplom1
{
    /// <summary>
    /// Логика взаимодействия для UserBD.xaml
    /// </summary>
    public partial class UserBD : Window
    {
        public UserBD()
        {
            InitializeComponent();
        }

        private void UserList(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                UserGrid.ItemsSource = bd.Users.ToList();
            }
        }
    }
}
