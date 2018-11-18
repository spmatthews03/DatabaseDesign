﻿using Corkboard.API.Helpers;
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
    public partial class ViewPushpin : Page
    {
        public ViewPushpin(IPage previousPage, Pushpin pushpin, User currentUser)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.pushpin = pushpin;
            this.currentUser = currentUser;
            GetCorkboard();
            SetTitle();
            SetImage();
            SetLikes();
            DisplayComments();
            DisplayDescription();
            DisplayTags();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            previousPage.MainWindow.Navigate(previousPage.Self);
        }

        private void FollowButton_Click(object sender, RoutedEventArgs e)
        {
            var owner = UserHelper.GetUserByEmail(pushpin.Owner_Email);
            ViewCorkboardHelper.FollowUser(owner, currentUser);
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

        private API.Models.Corkboard corkboard;
        private IPage previousPage;
        private Pushpin pushpin;
        private User currentUser;

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
            DescriptionBlock.Text = pushpin.Description;
        }

        private void DisplayTags()
        {
            TagsBlock.Text = pushpin.Tags.Aggregate((x, y) => $"{x}, {y}");
        }

        private void GetCorkboard()
        {
            corkboard = PushpinHelper.GetCorkboardPushpinIsOn(pushpin);
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

        #endregion
    }
}
