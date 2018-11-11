using Corkboard.UI.Models;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home(MainWindow window, User user)
        {
            InitializeComponent();
            MainWindow = window;
            User = user;
            DisplayUserInformation();
        }

        public MainWindow MainWindow { get; private set; }

        private void CreateCorkboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new AddCorkboard(this));
        }

        private void PushpinSearchButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new SearchPushpin(this, SearchBox.Text));
        }

        #region focus events

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Equals("Search descriptions, tags, and categories."))
            {
                SearchBox.Text = string.Empty;
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Search descriptions, tags, and categories.";
            }
        }

        #endregion

        #region private
        private User User { get; set; }

        private void DisplayUserInformation()
        {
            NameBox.Text = $"Welcome {User.Name}";
        }

        #endregion
    }
}
