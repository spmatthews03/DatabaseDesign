using Corkboard.API.Helpers;
using Corkboard.API.Helpers.PageHelpers;
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
    /// Interaction logic for SearchPushpin.xaml
    /// </summary>
    public partial class SearchPushpin : Page, IPage
    {
        public SearchPushpin(Home previousPage, string searchText)
        {
            InitializeComponent();
            PreviousPage = previousPage;
            DisplayResults(searchText);
        }

        public MainWindow MainWindow => PreviousPage.MainWindow;
        public Page Self => this;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousPage.MainWindow.Navigate(PreviousPage);
        }

        private void SearchResultsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                return;
            }

            var view = sender as ListView;
            var properties = ConvertSelectedItem(view.SelectedItem);
            var pushpin = PushpinHelper.GetPushpin(properties["Title"], properties["OwnerEmail"], properties["Url"], properties["DateTime"]);
            PreviousPage.MainWindow.Navigate(new ViewPushpin(this, pushpin));
        }

        #region private

        private Home PreviousPage { get; set; }

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

        private void DisplayResults(string search)
        {
            var view = new GridView();
            SearchResultsView.View = view;
            view.Columns.Add(CreateGridColumn("Description", 243.667));
            view.Columns.Add(CreateGridColumn("Corkboard", 243.667));
            view.Columns.Add(CreateGridColumn("Owner", 243.667));

            var results = SearchPushpinHelper.GetResults(search);
            SearchResultsView.ItemsSource = results;
        }

        #endregion
    }
}
