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
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : Window
    {
        public Error(string message, string title = "Invalid input given.")
        {
            InitializeComponent();
            SetTitle(title);
            SetMessage(message);
        }

        #region private

        private void SetMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message", "Message given to the error popup was null or empty.");
            }

            ErrorMessage.Text = message;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                Title = "Invalid input given.";
            }
            else
            {
                Title = title;
            }
        }

        #endregion
    }
}
