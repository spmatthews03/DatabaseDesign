using Corkboard.API.Helpers;
using Corkboard.API.Helpers.PageHelpers;
using Corkboard.API.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Corkboard.UI.Screens
{
    /// <summary>
    /// Interaction logic for ViewCorkboard.xaml
    /// </summary>
    public partial class ViewCorkboard : Page
    {
        public ViewCorkboard(IPage previousPage, User owner, User viewer, string title)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            Owner = owner;
            this.viewer = viewer;
            GetCorkboard(title);
            SetTitle();
            SetSwitchButton();
            SetWatch();
        }

        public API.Models.Corkboard Corkboard { get; private set; }
        public User Owner { get; private set; }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            previousPage.MainWindow.Navigate(previousPage.Self);
        }

        private void FollowButton_Click(object sender, RoutedEventArgs e)
        {
            if (FollowButton.Content.Equals("Follow"))
            {
                ViewCorkboardHelper.FollowUser(Owner, viewer);
            }

            if (FollowButton.Content.Equals("Unfollow"))
            {
                ViewCorkboardHelper.UnfollowUser(Owner, viewer);
            }

            SetSwitchButton_Follow();
        }

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SwitchButton.Content.Equals("Add PushPin"))
            {
                previousPage.MainWindow.Navigate(new AddPushpin(previousPage.MainWindow, this));
            }

            if (SwitchButton.Content.Equals("Watch"))
            {
                ViewCorkboardHelper.WatchCorkboard(Owner, viewer, Corkboard.Title);
                Corkboard.Watchers.Add(viewer);
                SetWatch();
            }

            if (SwitchButton.Content.Equals("Unwatch"))
            {
                ViewCorkboardHelper.UnwatchCorkboard(Owner, viewer, Corkboard.Title);
                Corkboard.Watchers.Remove(viewer);
                SetWatch();
            }

            SetSwitchButton();
        }

        #region private

        private IPage previousPage;
        private User viewer;

        private void GetCorkboard(string title)
        {
            Corkboard = CorkboardHelper.GetCorkboard(Owner, title);
            PushpinView.SelectionMode = SelectionMode.Single;

            foreach (var pin in Corkboard.Pushpins)
            {
                PushpinView.Items.Add(new { Url = pin.Url });
            }
        }

        private void SetTitle()
        {
            TitleBlock.Text = $"{Corkboard.Title} by {Owner.Name} - {Corkboard.Category} - Latest update: {Corkboard.LastUpdate}";
        }

        private void SetWatch()
        {
            var watchers = Corkboard.Watchers;
            if (watchers.Count == 0)
            {
                WatcherBlock.Text = "No one is watching this corkboard. Be the first!";
            }
            else if (watchers.Count == 1)
            {
                WatcherBlock.Text = "This corkboard has 1 watcher.";
            }
            else
            {
                WatcherBlock.Text = $"This corkboard has {Corkboard.Watchers.Count} watchers.";
            }
        }

        private void SetSwitchButton()
        {
            if (Owner.Name.Equals(viewer.Name))
            {
                SwitchButton.Content = "Add PushPin";
            }
            else if (!Corkboard.IsPrivate)
            {
                var alreadyWatching = Corkboard.Watchers.Contains(viewer);
                if (alreadyWatching)
                {
                    SwitchButton.Content = "Unwatch";
                }
                else
                {
                    SwitchButton.Content = "Watch";
                }
            }
        }

        private void SetSwitchButton_Follow()
        {
            if (UserHelper.GetUserFollowersEmails(Owner.Email).Contains(viewer.Email))
            {
                FollowButton.Content = "Unfollow";
            }
            else
            {
                FollowButton.Content = "Follow";
            }
        }

        #endregion
    }
}
