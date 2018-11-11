using Corkboard.UI.Models;
using Corkboard.UI.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login(MainWindow window)
        {
            InitializeComponent();
            MainWindow = window;
        }

        private MainWindow MainWindow { get; set; }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text;
            var pin = PinBox.Text;
            if (email == null || !new EmailAddressAttribute().IsValid(email))
            {
                CreatePopup("Invalid email. Close this window to update your email.");
                return;
            }

            var user = Authenticate(email, pin);
            if (user == null)
            {
                CreatePopup("Invalid credentials. Close this window to update your credentials.");
                return;
            }

            MainWindow.Navigate(new Home(MainWindow, user));
        }

        private void PageGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Click(sender, e);
            }
        }

        #region focus events

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text.Equals("Email"))
            {
                EmailBox.Text = string.Empty;
            }

            EmailBlock.Visibility = Visibility.Visible;
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                EmailBox.Text = "Email";
                EmailBlock.Visibility = Visibility.Hidden;
            }
        }

        private void PinBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PinBox.Text.Equals("Pin"))
            {
                PinBox.Text = string.Empty;
            }

            PinBlock.Visibility = Visibility.Visible;
        }

        private void PinBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PinBox.Text))
            {
                PinBox.Text = "Pin";
                PinBlock.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region private

        private User Authenticate(string email, string pin)
        {
            // call api to validate user, expect api to return all user details
            var exists = true;
            if (!exists)
            {
                return null;
            }

            return new User
            {
                Email = "test@test.com",
                Name = "Testing Longlastname",
                Pin = 1234
            };
        }

        private void CreatePopup(string message)
        {
            var popup = new Error(message);
            popup.ShowDialog();
        }

        #endregion
    }
}
