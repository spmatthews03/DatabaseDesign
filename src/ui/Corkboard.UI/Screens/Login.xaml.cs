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
        public Login()
        {
            InitializeComponent();
        }

        #region focus events

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text.Equals("Email"))
            {
                EmailBox.Text = string.Empty;
            }
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                EmailBox.Text = "Email";
            }
        }

        private void PinBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PinBox.Text.Equals("Pin"))
            {
                PinBox.Text = string.Empty;
            }
        }

        private void PinBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PinBox.Text))
            {
                PinBox.Text = "Pin";
            }
        }

        #endregion

        #region click events

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == null || !new EmailAddressAttribute().IsValid(EmailBox.Text))
            {
                CreatePopup("Invalid email. Close this window to update your email.");
                return;
            }

            if (!ValidateCredentials(EmailBox.Text, PinBox.Text))
            {
                CreatePopup("Invalid credentials. Close this window to update your credentials.");
                return;
            }
        }

        #endregion

        #region private

        private void CreatePopup(string message)
        {
            var popup = new Error(message);
            popup.ShowDialog();
        }

        private bool ValidateCredentials(string email, string pin)
        {
            return true;
        }

        #endregion
    }
}
