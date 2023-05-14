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
using System.Windows.Shapes;

namespace Diplom1
{
    /// <summary>
    /// Логика взаимодействия для OrgBD.xaml
    /// </summary>
    public partial class OrgBD : Window
    {
        public OrgBD()
        {
            InitializeComponent();
        }

        private void OrgList(object sender, RoutedEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                OrgGrid.ItemsSource = bd.Organizations.ToList();
            }
        }

        private void EditBD(object sender, DataGridCellEditEndingEventArgs e)
        {
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                Organization o = e.Row.Item as Organization;
                bd.Organizations.Update(o);
                bd.SaveChanges();
            }
        }

       
    }
}
