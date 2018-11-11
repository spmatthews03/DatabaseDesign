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
    public partial class SearchPushpin : Page
    {
        public SearchPushpin(Home previousPage, string searchText)
        {
            InitializeComponent();
            PreviousPage = previousPage;
            DisplayResults(searchText);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousPage.MainWindow.Navigate(PreviousPage);
        }

        #region private

        private Home PreviousPage { get; set; }

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
            // call api
            // display results in listview
            var view = new GridView();
            SearchResultsView.View = view;
            view.Columns.Add(CreateGridColumn("Description", 243.667));
            view.Columns.Add(CreateGridColumn("Corkboard", 243.667));
            view.Columns.Add(CreateGridColumn("Owner", 243.667));

            // call api
            // add result from api
            //SearchResultsView.ItemsSource = from api;
        }

        #endregion
    }
}
