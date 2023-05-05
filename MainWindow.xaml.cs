using Microsoft.EntityFrameworkCore;
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
            using (DiplomBdContext bd = new DiplomBdContext())
            {

                if (All_City_check.IsChecked == false && All_Indust_check.IsChecked == false)
                {
                    String? Select_city = city_box.SelectedItem.ToString();
                    String? Select_indust = industry_box.SelectedItem.ToString();

                        // Получить код отрасли по имени
                        var List_indust = bd.OrgsCodes.Where(OrgCode => OrgCode.CodeName == Select_indust).ToList();
                        foreach (OrgCode code in List_indust)
                        {
                            IndItem_box.Clear();
                            int? ind_list = code.Orgcode;
                            IndItem_box.Text += ind_list;


                        }
                        // Вывести орги определенного города и отрасли
                        int Indust_code = Convert.ToInt32(IndItem_box.Text);
                        var List_city = bd.Organizations.Where(Organization => Organization.City == Select_city && Organization.OrgCodes == Indust_code).ToList();
                        city_list.Items.Clear();
                        foreach (Organization org in List_city)
                        {
                            city_list.Items.Add(org.OrgName);
                        }

                    
                }
                if (All_City_check.IsChecked == true && All_Indust_check.IsChecked == false)
                {
                    String? Select_indust = industry_box.SelectedItem.ToString();
                    

                        // Получить код отрасли по имени
                        var List_indust = bd.OrgsCodes.Where(OrgCode => OrgCode.CodeName == Select_indust).ToList();
                        foreach (OrgCode code in List_indust)
                        {
                            IndItem_box.Clear();
                            int? ind_list = code.Orgcode;
                            IndItem_box.Text += ind_list;


                        }
                        int Indust_code = Convert.ToInt32(IndItem_box.Text);
                        var AllCity = bd.Organizations.Where(Organization => Organization.OrgCodes == Indust_code).ToList();
                        city_list.Items.Clear();
                        foreach (Organization org in AllCity)
                        {
                            city_list.Items.Add(org.OrgName);
                        }
                    
                }
                if (All_Indust_check.IsChecked == true && All_City_check.IsChecked == false)
                {
                    String? Select_city = city_box.SelectedItem.ToString();
                    var AllIndust = bd.Organizations.Where(Organization => Organization.City == Select_city).ToList();
                    city_list.Items.Clear();
                    foreach (Organization o in AllIndust)
                    {
                        city_list.Items.Add(o.OrgName);
                    }

                }
                if (All_Indust_check.IsChecked == true && All_City_check.IsChecked == true)
                {
                    var All = bd.Organizations.Select(Organization => Organization.OrgName).ToList();
                    city_list.Items.Clear();
                    foreach (var i in All)
                    {
                        city_list.Items.Add(i);
                    }
                }
            }
        }


        private void MoreInfo(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void AddInfo(object sender, SelectionChangedEventArgs e)
        {
            /*
            String? OrgInf = city_list.SelectedItem.ToString();
          //  MessageBox.Show(OrgInf);

            
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var More_info = bd.Organizations.Where(Organization => Organization.OrgName == OrgInf).ToList();
                foreach (Organization inf in More_info)
                {
                    Org_id.Clear();
                    int? OrgId = inf.OrgId;
                    Org_id.Text += OrgId;
                    //AddInfo_list.Items.Add(inf.OrgId);
                }
                int OID = Convert.ToInt32(Org_id.Text);
                var AddInfo = bd.Addinfos.Where(addinfo => addinfo.OrgId == OID).ToList();
                AddInfo_list.Items.Clear();
                foreach (addinfo str_inf in AddInfo)
                {
                    AddInfo_list.Items.Add(str_inf.MoreInfo);
                }

            }
            */
        
        }

        private void Company_addres(object sender, SelectionChangedEventArgs e)
        {
            /*
            String? addres = AddInfo_list.SelectedItem.ToString();

            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var AddresInfo = bd.Addinfos.Where(addinfo => addinfo.MoreInfo == addres).ToList();
                foreach (addinfo adrs in AddresInfo)
                {
                    MessageBox.Show(adrs.Addres);
                }

            }
            */
        }

        private void test(object sender, MouseButtonEventArgs e)
        {
            
            String? addres = AddInfo_list.SelectedItem.ToString();

            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var AddresInfo = bd.Addinfos.Where(addinfo => addinfo.MoreInfo == addres).ToList();
                foreach (addinfo adrs in AddresInfo)
                {
                    MessageBox.Show(adrs.Addres);
                    
                }

            }
            
        }

        private void MoreInfo_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            String? OrgInf = city_list.SelectedItem.ToString();
            //  MessageBox.Show(OrgInf);


            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var More_info = bd.Organizations.Where(Organization => Organization.OrgName == OrgInf).ToList();
                foreach (Organization inf in More_info)
                {
                    Org_id.Clear();
                    int? OrgId = inf.OrgId;
                    Org_id.Text += OrgId;
                    //AddInfo_list.Items.Add(inf.OrgId);
                }
                int OID = Convert.ToInt32(Org_id.Text);
                var AddInfo = bd.Addinfos.Where(addinfo => addinfo.OrgId == OID).ToList();
                AddInfo_list.Items.Clear();
                foreach (addinfo str_inf in AddInfo)
                {
                    AddInfo_list.Items.Add(str_inf.MoreInfo);
                }

            }
        }

        private void Check_City(object sender, RoutedEventArgs e)
        {
            /*
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                int Indust_code = Convert.ToInt32(IndItem_box.Text);
                var AllCity = bd.Organizations.Where(Organization => Organization.OrgCodes == Indust_code).ToList();
                city_list.Items.Clear();
                foreach (Organization org in AllCity)
                {
                    city_list.Items.Add(org.OrgName);
                }
            }
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            city_list.Items.Clear();
            AddInfo_list.Items.Clear();
        }

        private void Docks_info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Для получения дополнительной информации о компании дважды нажмите на ее название \n2. Для получения адреса огранизации нажмите дважды на дополнительную информацию");
        }

        private void Check_training(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var TrainingTrue = bd.Organizations.Where(Organization => Organization.TrainingStatus == 2).ToList();
                city_list.Items.Clear();
                foreach (Organization o in TrainingTrue)
                {
                    city_list.Items.Add(o.OrgName);
                }
            }
        }

        private void Check_distant(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var DistantTrue = bd.Organizations.Where(Organization => Organization.DistantCode == 2).ToList();
                city_list.Items.Clear();
                foreach (Organization o in DistantTrue)
                {
                    city_list.Items.Add(o.OrgName);
                }
            }
        }

        private void Uncheck_training(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var TrainingTrue = bd.Organizations.Where(Organization => Organization.TrainingStatus == 1).ToList();
                city_list.Items.Clear();
                foreach (Organization o in TrainingTrue)
                {
                    city_list.Items.Add(o.OrgName);
                }
            }
        }

        private void Uncheck_distant(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var DistantTrue = bd.Organizations.Where(Organization => Organization.DistantCode == 1).ToList();
                city_list.Items.Clear();
                foreach (Organization o in DistantTrue)
                {
                    city_list.Items.Add(o.OrgName);
                }
            }
        }

        private void Rec_click(object sender, RoutedEventArgs e)
        {
        
            SubRec subRec = new SubRec();
            subRec.Owner = this;
            subRec.Show();
        }

       

        private void AddFavor_click(object sender, RoutedEventArgs e)
        {
            String? SelectOrg = Convert.ToString(city_list.SelectedItem);
            String? path = "E:\\Diplom\\Diplom1\\Log.txt";
            StringReader Reader = new StringReader(path);
            int Userid = Convert.ToInt32(Reader.Read());
            if (SelectOrg != null)
            {

                using (DiplomBdContext bd = new DiplomBdContext())
                {
                    var AddFavor = bd.Organizations.Where(o => o.OrgName == SelectOrg).ToList();
                    foreach (Organization or in AddFavor)
                    {
                        int OrgID = or.OrgId;
                        AddFunction af = new AddFunction { OrgID = OrgID, UserId = Userid, Favor = Userid + OrgID };
                        bd.Addfunctions.AddRange(af);
                        bd.SaveChanges();
                        
                    }
                }
                MessageBox.Show($@"Компания '{SelectOrg}' добавлена в избранное");
            }
            else MessageBox.Show("Выберите компанию");
        }

        private void VievFavor_click(object sender, RoutedEventArgs e)
        {
            String? SelectOrg = Convert.ToString(city_list.SelectedItem);
            String? path = "E:\\Diplom\\Diplom1\\Log.txt";
            StringReader Reader = new StringReader(path);
            int Userid = Convert.ToInt32(Reader.Read());
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                var VievFavor = bd.Addfunctions.Where(a => a.Favor == Userid + a.OrgID).ToList();
                foreach (AddFunction af in VievFavor)
                {
                    int? OrgCode = af.OrgID;

                    var FavorOrg = bd.Organizations.Where(o => o.OrgId == OrgCode);
                    foreach (Organization o in FavorOrg)
                    {
                        String? favor = o.OrgName;
                        MessageBox.Show($@"Компании в избранном: {favor}");
                    }
                }
            }
        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            auth auth = new auth();
            auth.Show();
            Close();
        }
    }
}
