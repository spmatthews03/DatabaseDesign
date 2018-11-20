using Corkboard.API.Helpers;
using Corkboard.API.Helpers.PageHelpers;
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
    public partial class ViewPushpin : Page, IPage
    {
        public ViewPushpin(IPage previousPage, Pushpin pushpin)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.pushpin = pushpin;
            GetCorkboard();
            GetPushpinComments();
            GetPushpinLikes();
            GetPushpinTags();
            SetTitle();
            SetImage();
            SetLikes();
            DisplayComments();
            DisplayDescription();
            DisplayTags();
        }

        public MainWindow MainWindow => previousPage.MainWindow;
        public Page Self => this;

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            previousPage.MainWindow.Navigate(previousPage.Self);
        }

        private void FollowButton_Click(object sender, RoutedEventArgs e)
        {
            var owner = UserHelper.GetUserByEmail(pushpin.Owner_Email);
            if (FollowButton.Content.Equals("Follow"))
            {
                ViewCorkboardHelper.FollowUser(owner, MainWindow.User);
            }

            if (FollowButton.Content.Equals("Unfollow"))
            {
                ViewCorkboardHelper.UnfollowUser(owner, MainWindow.User);
            }

            SetSwitchButton_Follow(owner);
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            if (LikeButton.Content.Equals("Like"))
            {
                PushpinHelper.LikePushpin(pushpin, MainWindow.User);
                pushpin.Likes.Add(MainWindow.User);
            }

            if (LikeButton.Content.Equals("Unlike"))
            {
                PushpinHelper.UnlikePushpin(pushpin, MainWindow.User);
                pushpin.Likes.Remove(MainWindow.User);
            }

            SetLikes();
            SetSwitchButton_Like();
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            var text = new TextRange(CommentBox.Document.ContentStart, CommentBox.Document.ContentEnd).Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            PushpinHelper.AddComment(pushpin, MainWindow.User, text);
        }

        private void ViewCorkboardButton_Click(object sender, RoutedEventArgs e)
        {
            var owner = UserHelper.GetUserByEmail(pushpin.Owner_Email);
            var corkboard = PushpinHelper.GetCorkboardPushpinIsOn(pushpin);
            MainWindow.Navigate(new ViewCorkboard(this, owner, MainWindow.User, corkboard.Title));
        }

        #region private

        private API.Models.Corkboard corkboard;
        private IPage previousPage;
        private Pushpin pushpin;

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

        private void DisplayComments()
        {
            CommentsView.SelectionMode = SelectionMode.Single;
            var view = new GridView();
            CommentsView.View = view;
            view.Columns.Add(CreateGridColumn("User", 170));
            view.Columns.Add(CreateGridColumn("Comment", 170));
            
            foreach (var comment in pushpin.Comments)
            {
                CommentsView.Items.Add(new { User = comment.User, Comment = comment.Value });
            }
        }

        private void DisplayDescription()
        {
            DescriptionBlock.Text = $"Description - {pushpin.Description}";
        }

        private void DisplayTags()
        {
            if (pushpin.Tags.Count != 0)
            {
                TagsBlock.Text = $"Tags - {pushpin.Tags.Aggregate((x, y) => $"{x}, {y}")}";
            }
        }

        private void GetCorkboard()
        {
            corkboard = PushpinHelper.GetCorkboardPushpinIsOn(pushpin);
        }

        private void GetPushpinComments()
        {
            pushpin.Comments = PushpinHelper.GetCommentsForPushpin(pushpin.Title, pushpin.DateTime, pushpin.Owner_Email, pushpin.Url);
        }

        private void GetPushpinLikes()
        {
            pushpin.Likes = PushpinHelper.GetLikesForPushpin(pushpin.Title, pushpin.DateTime, pushpin.Owner_Email, pushpin.Url);
        }

        private void GetPushpinTags()
        {
            pushpin.Tags = PushpinHelper.GetTagsForPushpin(pushpin.Title, pushpin.DateTime, pushpin.Owner_Email, pushpin.Url);
        }

        private void SetImage()
        {
            image.Source = new BitmapImage(new Uri(pushpin.Url));
        }

        private void SetLikes()
        {
            var builder = new StringBuilder();
            foreach (var liker in pushpin.Likes)
            {
                if (builder.ToString().Length > 100)
                {
                    builder.Append("and more.");
                }

                if (!string.IsNullOrEmpty(builder.ToString()))
                {
                    builder.Append(", ");
                }

                builder.Append($"{liker.Name}");
            }

            LikesBlock.Text = $"Liked by: {builder}";
        }

        private void SetTitle()
        {
            // TODO - hyperlink to corkboard
            TitleBlock.Text = $"{pushpin.Title} - {pushpin.DateTime}";
        }

        private void SetSwitchButton_Follow(User owner)
        {
            if (owner.Equals(MainWindow.User))
            {
                FollowButton.Visibility = Visibility.Hidden;
            }

            if (UserHelper.GetUserFollowersEmails(owner.Email).Contains(MainWindow.User.Email))
            {
                FollowButton.Content = "Unfollow";
            }
            else
            {
                FollowButton.Content = "Follow";
            }
        }

        private void SetSwitchButton_Like()
        {
            if (pushpin.Likes.Contains(MainWindow.User))
            {
                LikeButton.Content = "Unlike";
            }
            else
            {
                LikeButton.Content = "Like";
            }
        }

        #endregion
    }
}
