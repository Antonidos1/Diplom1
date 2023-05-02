using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diplom1
{
    /// <summary>
    /// Логика взаимодействия для enter.xaml
    /// </summary>
    public partial class enter : Window
    {
        public enter()
        {
            InitializeComponent();
        }

        private void enter_main_button(object sender, RoutedEventArgs e)
        {

            String login = enter_log.Text;
            int password = Convert.ToInt32(enter_pass.Text);

            
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                //  var users = bd.UsersPasswds.FromSqlRaw($@"SELECT * FROM users_passwd WHERE password = {password} AND login = '{login}';").All();
                bool users = bd.UsersPasswds.Any(UsersPasswd => UsersPasswd.Login == $@"{login}" && UsersPasswd.Password == password); // Проверяем логин/пароль
                
                if (users)
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

            //Закрываем старые
            Close();
        



        }
    }
}
