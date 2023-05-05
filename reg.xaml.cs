using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Diplom1
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void reg_auth_button(object sender, RoutedEventArgs e)
        {
            String login = reg_log.Text;
            String FirstName = FirstName_Box.Text;
            String LastName = LastName_box.Text;
            String Email = Email_box.Text;
            int? Age = Convert.ToInt32(Age_box.Text);
            int? password = Convert.ToInt32(reg_passw.Text);
            

            if (login != null && FirstName != null && LastName != null && Email != null && Age != null && password != null)
            {
                //Зарегестрироваться
                using (DiplomBdContext bd = new DiplomBdContext())
                {
                    //Добавляем логи/пароль
                    UsersPasswd userPass = new UsersPasswd { StatusCode = 2, Password = password, Login = login };

                    bd.UsersPasswds.AddRange(userPass);
                    bd.SaveChanges();

                    //Добавляем остальные данные
                    User adduser = new User { StatusCode = 2, Firstname = FirstName, Lastname = LastName, Email = Email, Age = Age };

                    bd.Users.AddRange(adduser);
                    bd.SaveChanges();

                 
                }
                // Закрыть окно после успешной регистрации
                MessageBox.Show("Регистрация выполнена");
                Close();
            }
            else MessageBox.Show("Введите все данные для регистарции");
        }


    }
}
