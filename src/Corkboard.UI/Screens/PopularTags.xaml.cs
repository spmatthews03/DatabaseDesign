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
    /// Interaction logic for PopularTags.xaml
    /// </summary>
    public partial class PopularTags : Page
    {
        public PopularTags(Home previousPage)
        {
            InitializeComponent();
            HomePage = previousPage;
            DisplayTags();
        }

        public Home HomePage { get; private set; }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage.MainWindow.Navigate(HomePage);
        }

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

        private void DisplayTags()
        {
            var view = new GridView();
            TagView.View = view;
            view.Columns.Add(CreateGridColumn("Tag", 211.333));
            view.Columns.Add(CreateGridColumn("Pushpins", 211.333));
            view.Columns.Add(CreateGridColumn("Unique Corkboards", 211.333, "UniqueCorkboards"));

            var tags = PopularTagsHelper.GetPopularTags();
            TagView.ItemsSource = tags;
        }

        #endregion
    }
}
