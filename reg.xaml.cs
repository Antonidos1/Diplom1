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
            int password = Convert.ToInt32(reg_passw.Text);

            //Зарегестрироваться
           using(DiplomBdContext bd = new DiplomBdContext())
            {
                UsersPasswd userPass = new UsersPasswd { StatusCode = 2, Password = password, Login = login};

                bd.UsersPasswds.AddRange(userPass);
                bd.SaveChanges();
            }
          // Закрыть окно после успешной регистрации
          Close();
        }


    }
}
