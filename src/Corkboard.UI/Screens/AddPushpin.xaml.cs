using Corkboard.API.Helpers.PageHelpers;
using Corkboard.UI.Popups;
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
    /// Interaction logic for AddPushpin.xaml
    /// </summary>
    public partial class AddPushpin : Page
    {
        public AddPushpin(MainWindow window, ViewCorkboard previousPage)
        {
            InitializeComponent();
            MainWindow = window;
            PreviousPage = previousPage;
            SetTitle();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newPushpin = ValidatePushpin();
            if (newPushpin == null)
            {
                CreatePopup("Invalid pushpin information supplied.");
                return;
            }

            if (!AddPushpinHelper.IsValidFileType(newPushpin.Url))
            {
                CreatePopup("Invalid url. Please check format and extension type. Supported types - jpg png gif");
                return;
            }

            AddPushpinHelper.AddPushpin(PreviousPage.Owner, PreviousPage.Corkboard.Title, newPushpin);
            MainWindow.Navigate(PreviousPage);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Navigate(PreviousPage);
        }

        public MainWindow MainWindow { get; private set; }

        #region event focus

        private void DescriptionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text.Equals("Description"))
            {
                DescriptionBox.Text = string.Empty;
            }

            DescriptionBlock.Visibility = Visibility.Visible;
        }

        private void DescriptionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionBox.Text))
            {
                DescriptionBox.Text = "Description";
                DescriptionBlock.Visibility = Visibility.Hidden;
            }
        }

        private void TagsBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TagsBox.Text.Equals("Tags - Comma Separated"))
            {
                TagsBox.Text = string.Empty;
            }

            TagsBlock.Visibility = Visibility.Visible;
        }

        private void TagsBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TagsBox.Text.Equals(string.Empty))
            {
                TagsBox.Text = "Tags - Comma Separated";
                TagsBlock.Visibility = Visibility.Hidden;
            }
        }

        private void UrlBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UrlBox.Text.Equals("Url"))
            {
                UrlBox.Text = string.Empty;
            }

            UrlBlock.Visibility = Visibility.Visible;
        }

        private void UrlBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UrlBox.Text.Equals(string.Empty))
            {
                UrlBox.Text = "Url";
                UrlBlock.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region private

        private ViewCorkboard PreviousPage { get; set; }

        private void CreatePopup(string message)
        {
            var popup = new Error(message);
            popup.ShowDialog();
        }

        private List<string> ParseTags(string tags)
        {
            var tagList = new List<string>();
            if (string.IsNullOrEmpty(tags))
            {
                return tagList;
            }

            var split = tags.Split(',');
            foreach (var tag in split)
            {
                tagList.Add(tag.Trim());
            }

            return tagList;
        }

        private void SetTitle()
        {
            TitleBlock.Text += PreviousPage.Corkboard.Title;
        }

        private API.Models.Pushpin ValidatePushpin()
        {
            var url = UrlBox.Text;
            var description = DescriptionBox.Text;
            var tags = TagsBox.Text;

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(description))
            {
                return null;
            }

            return new API.Models.Pushpin
            {
                Description = description,
                Tags = ParseTags(tags),
                Url = url
            };
        }

        #endregion
    }
}
