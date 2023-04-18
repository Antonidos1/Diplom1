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
            main1 Main1Window = new main1();
            Main1Window.Show();
            



        }
    }
}
