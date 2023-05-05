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
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void Main_click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this;
            mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var Recomend_list = bd.Addfunctions.Select(adf => adf.Recommend).ToList();
                foreach (var recomend in Recomend_list)
                {
                    MessageBox.Show(recomend);
                }
            }
        }

        private void Favor_click(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var Favor_list = bd.Addfunctions.Select(adf => adf.Favor).ToList();
                foreach (var favor in Favor_list)
                {

                    MessageBox.Show(Convert.ToString(favor));
                }
            }
        }

        private void Doc_click(object sender, RoutedEventArgs e)
        {

        }

        private void UserPas_click(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var UserPas_list = bd.UsersPasswds.Where(usep => usep.StatusCode == 2).ToList();
                foreach (UsersPasswd up in UserPas_list)
                {
                    MessageBox.Show($@"Логин пользователя {up.Login} Пароль пользователя {up.Password}\n");
                }
            }
        }

        private void Info_click(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var User_list = bd.Users.Where(us => us.StatusCode == 2).ToList();
                foreach (User us in User_list)
                {
                    MessageBox.Show($@"Имя {us.Firstname} Фамилия {us.Lastname} Email {us.Email} Возраст {us.Age}\n");
                }
            }
        }

        private void Bd_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
