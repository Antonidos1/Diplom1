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
using System.IO;

namespace Diplom1
{
    /// <summary>
    /// Логика взаимодействия для SubRec.xaml
    /// </summary>
    public partial class SubRec : Window
    {
        public SubRec()
        {
            InitializeComponent();
        }

        private void Sub_click(object sender, RoutedEventArgs e)
        {
           
            String? path = "E:\\Diplom\\Diplom1\\Log.txt";
            using (DiplomBdContext bd = new DiplomBdContext())
            {
                String? Recomed = Rec_text.Text.ToString();
                StringReader Reader = new StringReader(path);
                int Userid = Convert.ToInt32(Reader.Read());

                
                AddFunction addFunction = new AddFunction { UserId = Userid, Recommend = Recomed};

                bd.Addfunctions.AddRange(addFunction);
                bd.SaveChanges();
                MessageBox.Show("Рекомендация отправлена");
                
            }
        }
    }
}
