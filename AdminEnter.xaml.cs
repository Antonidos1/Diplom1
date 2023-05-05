using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminEnter.xaml
    /// </summary>
    public partial class AdminEnter : Window
    {
        public AdminEnter()
        {
            InitializeComponent();
        }

        private void AdminEnter_click(object sender, RoutedEventArgs e)
        {
            String? AdminLogin = Admin_login.Text.ToString();
            int? AdminPass = Convert.ToInt32(Admin_pass.Text.ToString());
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                bool Admin = bd.UsersPasswds.Any(UsersPasswd => UsersPasswd.StatusCode == 1 && UsersPasswd.Login == $@"{AdminLogin}" && UsersPasswd.Password == AdminPass); // Проверяем логин/пароль
               
                if (Admin)
                {
                  
                    MainWindow mainwin = new MainWindow();
                    mainwin.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль");
                    auth AuthWin = new auth();
                    AuthWin.Show();
                }

            }
            Close();
        }
    }
}
