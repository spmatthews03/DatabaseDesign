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
    /// Interaction logic for PopularTags.xaml
    /// </summary>
    public partial class PopularTags : Page
    {
        public PopularTags(Home previousPage)
        {
            InitializeComponent();
            HomePage = previousPage;
        }

        public Home HomePage { get; private set; }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage.MainWindow.Navigate(HomePage);
        }
    }
}
