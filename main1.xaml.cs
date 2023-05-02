using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для main1.xaml
    /// </summary>
    public partial class main1 : Window
    {
        public main1()
        {
            InitializeComponent();
        }

        private void select_button(object sender, RoutedEventArgs e)
        {
         
            String city = City_list.SelectedItem.ToString();
            String industry = Industry_list.SelectedItem.ToString();    

            
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                // var search = bd.Organizations.Select(Organization => Or)
                var search = bd.Organizations.FromSqlRaw($@"SELECT * FROM organization WHERE city = {city} AND org_code = '{industry}';").ToList();
            }

                Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }

        private void Find_City(object sender, ContextMenuEventArgs e)
        {
            /*
              using (DiplomBdContext bd = new DiplomBdContext())
              {

                //Organization org = bd.Organizations.Find();
               City_list.ItemsSource = bd.Organizations.Select(Organization => Organization.City);

                String city = bd.Organizations.Select(Organization => Organization.City).ToString();

                City_list.Text = city;
            }
            */
        }

        private void city(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {

                var city = bd.Organizations.Select(Organization => Organization.City).Distinct().ToList(); //Вывод уникальных городов
                foreach (var item in city)
                {
                    City_list.Items.Add(item);
                }
                
            }
        }

        private void industry(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {

                var indust = bd.OrgsCodes.Select(OrgCode => OrgCode.CodeName).Distinct().ToList(); //Вывод отраслей
                foreach (var item2 in indust)
                {
                    Industry_list.Items.Add(item2);
                }
                
            }
        }
    }
}
