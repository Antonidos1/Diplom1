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
using System.IO;
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
            String path = "E:\\Diplom\\Diplom1\\Log.txt";



            using (DiplomBdContext bd = new DiplomBdContext())
            {
                
                bool users = bd.UsersPasswds.Any(UsersPasswd => UsersPasswd.StatusCode == 2 && UsersPasswd.Login == $@"{login}" && UsersPasswd.Password == password); // Проверяем логин/пароль
                
                if (users)
                {
                    var LogUser = bd.UsersPasswds.Where(u => u.Login == login && u.Password == password).ToList();
                    var FileStream = File.Open(path, FileMode.Open); 
                    FileStream.SetLength(0);
                    FileStream.Close();
                    foreach (UsersPasswd up in LogUser)
                    {
                        int userID = up.UserId;
                        StreamWriter sw = new StreamWriter(path);
                       
                        sw.WriteLine(userID);
                        sw.Close();
                    }

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
