using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void find_city(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {

                var city = bd.Organizations.Select(Organization => Organization.City).Distinct().ToList(); //Вывод уникальных городов
                foreach (var item in city)
                {
                    city_box.Items.Add(item);
                }

            }
        }

        private void find_indust(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {

                var indust = bd.OrgsCodes.Select(OrgCode => OrgCode.CodeName).Distinct().ToList(); //Вывод отраслей
                foreach (var item2 in indust)
                {
                    industry_box.Items.Add(item2);
                }

            }
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            String? Select_city = city_box.SelectedItem.ToString();
            String? Select_indust = industry_box.SelectedItem.ToString();
           

            using (DiplomBdContext bd = new DiplomBdContext())
            {
                
                var List_indust = bd.OrgsCodes.Where(OrgCode => OrgCode.CodeName == Select_indust).ToList();
                foreach (OrgCode code in List_indust)
                {
                    IndItem_box.Clear();
                    int? ind_list = code.Orgcode;
                    IndItem_box.Text += ind_list;
                    
                    
                }
                
                int Indust_code = Convert.ToInt32(IndItem_box.Text);
                var List_city = bd.Organizations.Where(Organization => Organization.City == Select_city && Organization.OrgCodes == Indust_code).ToList();
                city_list.Items.Clear();
                foreach(Organization org in List_city)
                {   
                    city_list.Items.Add(org.OrgName);
                }
                
            }

        }
    }
}
