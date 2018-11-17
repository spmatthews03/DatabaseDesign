using Corkboard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corkboard.API.Helpers.PageHelpers
{
    public static class AddPushpinHelper
    {
        /// <summary>
        /// Adds a pushpin to the corkboard. 
        /// </summary>
        /// <param name="owner">User adding the pushpin.</param>
        /// <param name="pushpin">Pushpin to add.</param>
        public static void AddPushpin(User owner, Pushpin pushpin)
        {
            DatabaseHelper.ExecuteQuery($"INSERT INTO `PushPin` (`title`, `date_time`, `owner_email`, `url`, `description`) " +
                $"VALUES ('{pushpin.Title}', '{pushpin.DateTime}', '{owner.Email}', '{pushpin.Url}', '{pushpin.Description}');");
        }

        /// <summary>
        /// Validates the file type. jpg png and gif at a minimum.
        /// </summary>
        /// <param name="url">Url of the file.</param>
        /// <returns>Returns true for a supported type, false otherwise.</returns>
        public static bool IsValidFileType(string url)
        {
            var acceptableFileTypes = new string[] { "jpg", "png", "gif" };
            var fileExtension = url.Split('.').Last();

            return acceptableFileTypes.Contains(fileExtension);
        }
    }
}
