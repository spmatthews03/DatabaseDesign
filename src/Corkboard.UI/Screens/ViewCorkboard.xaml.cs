﻿using Corkboard.API.Helpers;
using Corkboard.API.Helpers.PageHelpers;
using Corkboard.API.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Corkboard.UI.Screens
{
    /// <summary>
    /// Interaction logic for ViewCorkboard.xaml
    /// </summary>
    public partial class ViewCorkboard : Page, IPage
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
            SetSwitchButton_Follow();
            SetWatch();
        }

        public API.Models.Corkboard Corkboard { get; private set; }
        public MainWindow MainWindow => previousPage.MainWindow;
        public User Owner { get; private set; }
        public Page Self => this;

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

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var image = sender as Image;
            var imageContext = image.DataContext;
            var pushpin = ConvertToPushpin(imageContext);
            previousPage.MainWindow.Navigate(new ViewPushpin(this, pushpin));
        }

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SwitchButton.Content.Equals("Add PushPin"))
            {
                previousPage.MainWindow.Navigate(new AddPushpin(previousPage.MainWindow, this));
                GetCorkboard(Corkboard.Title);
            }

            if (SwitchButton.Content.Equals("Watch"))
            {
                ViewCorkboardHelper.WatchCorkboard(Owner, viewer, Corkboard.Title);
                SetWatch();
            }

            if (SwitchButton.Content.Equals("Unwatch"))
            {
                ViewCorkboardHelper.UnwatchCorkboard(Owner, viewer, Corkboard.Title);
                SetWatch();
            }

            SetSwitchButton();
        }

        #region private

        private IPage previousPage;
        private User viewer;

        private Pushpin ConvertToPushpin(object context)
        {
            var properties = context.GetType().GetProperties();
            var pushpin = properties.FirstOrDefault(x => x.Name.Equals("Pushpin"));
            return pushpin.GetValue(context, null) as Pushpin;
        }

        private void GetCorkboard(string title)
        {
            Corkboard = CorkboardHelper.GetCorkboard(Owner, title);
            PushpinView.SelectionMode = SelectionMode.Single;

            PushpinView.Items.Clear();
            foreach (var pin in Corkboard.Pushpins)
            {
                var item = new { Url = pin.Url, Pushpin = pin };
                PushpinView.Items.Add(item);
            }
        }

        private void SetTitle()
        {
            var lastUpdate = Corkboard.GetLatestCorkboardUpdate().ToShortDateString();
            if (lastUpdate.Equals(DateTime.MinValue.ToShortDateString()))
            {
                lastUpdate = "Never updated.";
            }

            TitleBlock.Text = $"{Corkboard.Title} by {Owner.Name} - {Corkboard.Category} - Latest update: {lastUpdate}";
        }

        private void SetWatch()
        {
            var watchers = CorkboardHelper.GetCorkboardWatchers(Corkboard);

            if (Owner.Email.Equals(viewer.Email))
            {
                WatcherBlock.Visibility = Visibility.Hidden;
            }
            else
            {
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
                    WatcherBlock.Text = $"This corkboard has {watchers.Count} watchers.";
                }
            }          
        }

        private void SetSwitchButton()
        {
            if (Owner.Email.Equals(viewer.Email))
            {
                SwitchButton.Content = "Add PushPin";
            }
            else if (!Corkboard.IsPrivate)
            {
                var alreadyWatching = CorkboardHelper.GetCorkboardWatchers(Corkboard).Exists(x => x.Email.Equals(viewer.Email));
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
            if (Owner.Email.Equals(viewer.Email))
            {
                FollowButton.Visibility = Visibility.Hidden;
            }

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
