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
        /// <param name="previousPage">Page that created this window.</param>
        public PasswordProtected(Home previousPage)
        {
            InitializeComponent();
            PreviousPage = previousPage;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var isViewable = ValidatePassword(PasswordBox.Text);
            if (!isViewable)
            {
                return;
            }

            // pass success state to previous page
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

        private Page PreviousPage { get; set; }

        private bool ValidatePassword(string password)
        {
            return false;
        }

        #endregion
    }
}
