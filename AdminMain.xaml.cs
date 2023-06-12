using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var Favor_list = bd.Addfunctions.Select(adf => adf.OrgID).Distinct().ToList();
                foreach (var favor in Favor_list)
                {
                    string fv = $@"id компании:{favor}\n";
                    MessageBox.Show(Convert.ToString(fv));
                }
            }
        }

        private void Doc_click(object sender, RoutedEventArgs e)
        {
            String path = "E:\\Diplom\\Diplom1\\docx.txt";
            Process.Start("notepad.exe", path);
        }

        private void UserPas_click(object sender, RoutedEventArgs e)
        {
            UserPaswdBD pasBD = new UserPaswdBD();
            pasBD.Owner = this;
            pasBD.Show();
        }

        private void Info_click(object sender, RoutedEventArgs e)
        {
            UserBD userBD = new UserBD();
            userBD.Owner = this;
            userBD.Show();
        }

        private void Bd_click(object sender, RoutedEventArgs e)
        {
            OrgBD orgBD = new OrgBD();
            orgBD.Owner = this;
            orgBD.Show();
        }
    }
}
