using Corkboard.API.Helpers;
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
    /// Interaction logic for AddCorkboard.xaml
    /// </summary>
    public partial class AddCorkboard : Page
    {
        public AddCorkboard(Home previousPage)
        {
            InitializeComponent();
            PreviousPage = previousPage;
            PopulateCategoryDropdown();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousPage.MainWindow.Navigate(PreviousPage);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var newCorkboard = ValidateCorkboard();
            if (newCorkboard == null)
            {
                CreatePopup("Invalid corkboard information supplied.");
                return;
            }

            var alreadyExists = AddCorkboardHelper.CheckCorkboardExists(PreviousPage.User, newCorkboard.Title);
            if (alreadyExists)
            {
                CreatePopup("Corkboard already exists with that title from this user.");
                return;
            }

            AddCorkboardHelper.AddCorkboard(PreviousPage.User, newCorkboard);
            PreviousPage.MainWindow.Navigate(new ViewCorkboard(PreviousPage, PreviousPage.User, PreviousPage.User));
        }

        private void VisibilityButton_Private_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
        }

        private void VisibilityButton_Private_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Hidden;
        }

        #region focus events

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text.Equals("Enter the password for the new Corkboard"))
            {
                PasswordBox.Text = string.Empty;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text.Equals(string.Empty))
            {
                PasswordBox.Text = "Enter the password for the new Corkboard";
            }
        }

        private void TitleBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text.Equals("Title"))
            {
                TitleBox.Text = string.Empty;
            }
        }

        private void TitleBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text.Equals(string.Empty))
            {
                TitleBox.Text = "Title";
            }
        }

        #endregion

        #region private

        private Home PreviousPage { get; set; }

        private void CreatePopup(string message)
        {
            var popup = new Error(message);
            popup.ShowDialog();
        }

        private void PopulateCategoryDropdown()
        {
            var categories = AddCorkboardHelper.GetCategories();
            CategoryComboBox.ItemsSource = categories;
        }

        private API.Models.Corkboard ValidateCorkboard()
        {
            var title = TitleBox.Text;
            var category = CategoryComboBox.Text;
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(category))
            {
                return null;
            }

            if (VisibilityButton_Private.IsChecked != null && VisibilityButton_Private.IsChecked == true)
            {
                var password = PasswordBox.Text;
                if (string.IsNullOrEmpty(password))
                {
                    return null;
                }

                return new API.Models.Corkboard
                {
                    Category = category,
                    IsPrivate = true,
                    Owner = PreviousPage.User,
                    Title = title
                };
            }

            return new API.Models.Corkboard
            {
                Category = category,
                IsPrivate = false,
                Owner = PreviousPage.User,
                Title = title
            };
        }

        #endregion
    }
}
