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
            PreviousPage = previousPage;
            SetTitle();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateUrl(UrlBox.Text))
            {
                return;
            }
            // validate pushpin
            // add to database
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

        private void SetTitle()
        {
            TitleBlock.Text += PreviousPage.Corkboard.Title;
        }

        private bool ValidateUrl(string url)
        {
            // check file extensions .jpg .png .gif
            // check url is correct
            // if failed, show error box, return false
            var error = new Error("Invalid url. Please check format and extension type. Supported types - jpg png gif");
            error.ShowDialog();
            return false;
        }

        #endregion
    }
}
