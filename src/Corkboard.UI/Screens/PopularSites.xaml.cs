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

namespace Corkboard.UI.Screens
{
    /// <summary>
    /// Interaction logic for PopularSites.xaml
    /// </summary>
    public partial class PopularSites : Page
    {
        public PopularSites(Home previousPage)
        {
            InitializeComponent();
            homePage = previousPage;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            homePage.MainWindow.Navigate(homePage);
        }

        #region private

        private Home homePage;

        #endregion
    }
}
