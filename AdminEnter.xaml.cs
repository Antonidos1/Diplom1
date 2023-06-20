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
                  
                    AdminMain adminwin = new AdminMain();
                    adminwin.Show();
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

        private void admin_log(object sender, RoutedEventArgs e)
        {
            Admin_login.Text = "Логин";
        }

        private void Admin_pas(object sender, RoutedEventArgs e)
        {
            Admin_pass.Text = "Пароль";
        }

        private void enter_pas(object sender, MouseEventArgs e)
        {
            if (Admin_pass.Text == "Пароль")
            {
                Admin_pass.Text = " ";
            }
        }

        private void Enter_log(object sender, MouseEventArgs e)
        {
            if (Admin_login.Text == "Логин")
            {
                Admin_login.Text = " ";
            }
        }
    }
}
