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

namespace NASA_app_Gruncl
{
    /// <summary>
    /// Interakční logika pro SpaceObjectPage.xaml
    /// </summary>
    public partial class SpaceObjectPage : Page
    {
        public SpaceObjectPage(SpaceObject choosenObject)
        {
            InitializeComponent();
            DataContext = choosenObject;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
