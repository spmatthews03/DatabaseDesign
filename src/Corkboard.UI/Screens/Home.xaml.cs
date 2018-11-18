using Corkboard.API.Helpers;
using Corkboard.API.Helpers.PageHelpers;
using Corkboard.API.Models;
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
    public partial class Home : Page, IPage
    {
        public Home(MainWindow window, User user)
        {
            InitializeComponent();
            MainWindow = window;
            User = user;
            DisplayUserInformation();
            DisplayRecentCorkboardUpdates();
            DisplayMyCorkboards();
        }

        public MainWindow MainWindow { get; private set; }
        public User User { get; private set; }
        public Page Self => this;

        private void CreateCorkboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new AddCorkboard(this));
        }

        private void PopularTagsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new PopularTags(this));
        }

        private void PopularSites_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new PopularSites(this));
        }

        private void PushpinSearchButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new SearchPushpin(this, SearchBox.Text));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(new CorkboardStats(this));
        }

        private void NavigateToCorkboard(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                return;
            }

            var view = sender as ListView;
            var properties = ConvertSelectedItem(view.SelectedItem);

            if (view.Name.Equals("UpdatesView"))
            {
                var owner = UserHelper.GetUserByEmail(properties["Email"]);
                MainWindow.Navigate(new ViewCorkboard(this, owner, User, properties["Title"]));
            }
            else
            {
                MainWindow.Navigate(new ViewCorkboard(this, User, User, properties["Title"]));
            }

            view.SelectedItem = null;
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

        private GridViewColumn CreateGridColumn(string value, double width, string newBinding = null)
        {
            newBinding = newBinding ?? value;
            return new GridViewColumn
            {
                Header = value,
                DisplayMemberBinding = new Binding(newBinding),
                Width = width
            };
        }

        private void DisplayMyCorkboards()
        {
            MyCorkboardView.SelectionMode = SelectionMode.Single;
            var view = new GridView();
            MyCorkboardView.View = view;
            view.Columns.Add(CreateGridColumn("Title", 309));
            view.Columns.Add(CreateGridColumn("Pushpins", 309));

            var corkboards = CorkboardHelper.GetUserPublicCorkboards(User);
            foreach (var board in corkboards)
            {
                MyCorkboardView.Items.Add(new { Title = board.Title, Pushpins = board.Pushpins.Count });
            }
        }

        private void DisplayRecentCorkboardUpdates()
        {
            UpdatesView.SelectionMode = SelectionMode.Single;
            var view = new GridView();
            UpdatesView.View = view;
            view.Columns.Add(CreateGridColumn("Title", 206));
            view.Columns.Add(CreateGridColumn("Owner", 206));
            view.Columns.Add(CreateGridColumn("Last PushPin Update Time", 188, "LastUpdate"));
            view.Columns.Add(CreateGridColumn("Email", 0));

            var corkboards = HomeHelper.GetRecentlyUpdatedCorkboards(User);
            foreach (var board in corkboards)
            {
                UpdatesView.Items.Add(new { Title = board.Title, Owner = board.Owner.Name, LastUpdate = board.LastUpdate, Email = board.Owner.Email });
            }
        }

        private void DisplayUserInformation()
        {
            NameBox.Text = $"Welcome {User.Name}";
        }

        private Dictionary<string, string> ConvertSelectedItem(object item)
        {
            var properties = item.GetType().GetProperties();
            var dictionary = new Dictionary<string, string>();
            foreach (var prop in properties)
            {
                dictionary.Add(prop.Name, prop.GetValue(item, null).ToString());
            }

            return dictionary;
        }

        #endregion
    }
}
