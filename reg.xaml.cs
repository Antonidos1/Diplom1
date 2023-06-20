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
            try {
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
             catch {
                MessageBox.Show("Неверные данные");
                    }
            }

        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            Email_box.Text = "Email";
        }

        private void Enter_text(object sender, MouseButtonEventArgs e)
        {
            if (Email_box.Text == "Email")
            {
                Email_box.Text = " ";
            
            }
        }

        private void enter(object sender, MouseEventArgs e)
        {
            if (Email_box.Text == "Email")
            {
                Email_box.Text = " ";

            }
        }

        private void load_age(object sender, RoutedEventArgs e)
        {
            Age_box.Text = "Возраст";
        }

        private void enter_age(object sender, MouseEventArgs e)
        {
            if (Age_box.Text == "Возраст")
            {
                Age_box.Text = " ";

            }
        }

        private void load_name(object sender, RoutedEventArgs e)
        {
            FirstName_Box.Text = "Имя";
        }

        private void enter_name(object sender, MouseEventArgs e)
        {
            if (FirstName_Box.Text == "Имя")
            {
                FirstName_Box.Text = " ";
            }
        }

        private void load_lastname(object sender, RoutedEventArgs e)
        {
            LastName_box.Text = "Фамилия";
        }

        private void enter_lastname(object sender, MouseEventArgs e)
        {
            if (LastName_box.Text == "Фамилия")
            {
                LastName_box.Text = " "; 
            }
        }

        private void load_login(object sender, RoutedEventArgs e)
        {
            reg_log.Text = "Логин";
        }

        private void enter_log(object sender, MouseEventArgs e)
        {
            if (reg_log.Text == "Логин")
            {
                reg_log.Text = " ";
            }
        }

        private void load_pas(object sender, RoutedEventArgs e)
        {
            reg_passw.Text = "Пароль";
        }

        private void enter_pas(object sender, MouseEventArgs e)
        {
            if (reg_passw.Text == "Пароль")
            {
                reg_passw.Text = " ";
            }
        }
    }
}
