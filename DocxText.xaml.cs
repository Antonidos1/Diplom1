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
using System.Windows.Shapes;

namespace Diplom1
{
    /// <summary>
    /// Логика взаимодействия для DocxText.xaml
    /// </summary>
    public partial class DocxText : Window
    {
        public DocxText()
        {
            InitializeComponent();
        }

       

     

        private void DocText(object sender, RoutedEventArgs e)
        {
            string fileName = "E:\\Diplom\\Diplom1\\docx.txt";
            StreamReader rdr = new StreamReader(fileName, Encoding.Default);
            TextDoc.Text += rdr.ReadToEnd();
        }
    }
}
