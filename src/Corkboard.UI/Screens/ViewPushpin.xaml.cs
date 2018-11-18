using Corkboard.API.Models;
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
    /// Interaction logic for ViewPushpin.xaml
    /// </summary>
    public partial class ViewPushpin : Page
    {
        public ViewPushpin(IPage previousPage, Pushpin pushpin)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.pushpin = pushpin;
            SetTitle();
            SetImage();
            SetLikes();
            DisplayComments();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            previousPage.MainWindow.Navigate(previousPage.Self);
        }

        private void FollowButton_Click(object sender, RoutedEventArgs e)
        {
            // follow user
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            // like/unlike pushpin
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            // post comment
        }

        #region private

        private IPage previousPage;
        private Pushpin pushpin;

        private void DisplayComments()
        {

        }

        private void SetImage()
        {
            image.Source = new BitmapImage(new Uri(pushpin.Url));
        }

        private void SetLikes()
        {

        }

        private void SetTitle()
        {

        }

        #endregion
    }
}
