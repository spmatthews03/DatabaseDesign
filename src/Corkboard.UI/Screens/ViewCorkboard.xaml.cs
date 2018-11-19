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

        private void GetCorkboard(string title)
        {
            Corkboard = CorkboardHelper.GetCorkboard(Owner, title);
            // TODO - populate ui (pushpin images)
            PushpinView.SelectionMode = SelectionMode.Single;
            var view = new GridView();
            PushpinView.View = view;
            view.Columns.Add(CreateGridColumn("PushPins", 740));

            foreach (var pin in Corkboard.Pushpins)
            {
                var image = new Image();
                image.Source = new BitmapImage(new System.Uri(pin.Url));
                PushpinView.Items.Add(new { Image = new BitmapImage(new System.Uri(pin.Url)) });
            }

            //PushpinView.ItemsSource = new Bullshit[]
            //{
            //    new Bullshit{Title = "Shit", ImageData = new BitmapImage(new System.Uri("https://s3.caradvice.com.au/wp-content/uploads/2017/03/17-Lamborghini-Phillip-Island-March-008.jpg")) },
            //    new Bullshit{Title = "Fuck", ImageData = new BitmapImage(new System.Uri("https://s3.caradvice.com.au/wp-content/uploads/2017/03/17-Lamborghini-Phillip-Island-March-008.jpg")) }
            //};

            //var bitmap = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("https://s3.caradvice.com.au/wp-content/uploads/2017/03/17-Lamborghini-Phillip-Island-March-008.jpg"));
            //image.Source = bitmap;
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
            if (Owner.Followers.Contains(viewer))
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

    public class Bullshit
    {
        private string _Title;
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        private BitmapImage _ImageData;
        public BitmapImage ImageData
        {
            get { return this._ImageData; }
            set { this._ImageData = value; }
        }
    }
}
