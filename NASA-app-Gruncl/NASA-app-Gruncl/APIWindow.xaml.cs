using System;
using System.IO;
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

namespace NASA_app_Gruncl
{
    /// <summary>
    /// Interakční logika pro APIWindow.xaml
    /// </summary>
    public partial class APIWindow : Window
    {
        public APIWindow()
        {
            InitializeComponent();
        }

        private void Set_Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("../../../Api.txt", ApiTextBox.Text);
            Close();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
