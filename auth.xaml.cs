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
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Window
    {
        public auth()
        {
            InitializeComponent();
        }

        private void Button_reg(object sender, RoutedEventArgs e)
        {
            reg RegWindow = new reg();
            RegWindow.Owner = this;
            RegWindow.Show();
        }

        private void Button_enter(object sender, RoutedEventArgs e)
        {
            enter EnterWindow = new enter();
            EnterWindow.Owner = this;
            EnterWindow.Show();
        }
    }
}
