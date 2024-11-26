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
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.spaceObjects.Clear();
            MainViewModel.GetColl();
        }

        private void AsteroidList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AsteroidList.SelectedItem != null)
            {
                var spaceObjectPage = new SpaceObjectPage(MainViewModel.spaceObjects[AsteroidList.SelectedIndex]);
                (Application.Current.MainWindow as MainWindow)?.MainFrame.Navigate(spaceObjectPage);
            }
            AsteroidList.SelectedItem = null;
        }

        private void API_Button_Click(object sender, RoutedEventArgs e)
        {
            var apiWindow = new APIWindow();
            apiWindow.Show();
        }
    }
}
