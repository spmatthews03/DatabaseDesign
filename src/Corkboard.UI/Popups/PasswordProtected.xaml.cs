using Corkboard.API.Helpers;
using Corkboard.UI.Screens;
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
using System.Windows.Shapes;

namespace Corkboard.UI.Popups
{
    /// <summary>
    /// Interaction logic for PasswordProtected.xaml
    /// </summary>
    public partial class PasswordProtected : Window
    {
        /// <summary>
        /// Represents a password protected popup for a corkboard.
        /// </summary>
        public PasswordProtected(string title, string ownerEmail)
        {
            InitializeComponent();
            this.ownerEmail = ownerEmail;
            this.title = title;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var isViewable = ValidatePassword(PasswordBox.Text);
            if (!isViewable)
            {
                this.DialogResult = false;
                return;
            }

            this.DialogResult = true;
            Close();
        }

        #region focus events

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text.Equals("Password"))
            {
                PasswordBox.Text = string.Empty;
            }

            PasswordBlock.Visibility = Visibility.Visible;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text.Equals(string.Empty))
            {
                PasswordBox.Text = "Password";
                PasswordBlock.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region private

        private string ownerEmail;
        private string title;

        private bool ValidatePassword(string password)
        {
            return CorkboardHelper.CanViewCorkboard(title, ownerEmail, password);
        }

        #endregion
    }
}
