using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.Security;

namespace Agile.Common
{
    /// <summary>
    /// Ultility class for web application
    /// </summary>
    public class Ultility
    {

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns></returns>
        public static MembershipUser GetCurrentUser()
        {
            return Membership.GetUser();
        }

        /// <summary>
        /// Gets the current user id.
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentUserId()
        {
            MembershipUser user = GetCurrentUser();

            if (user != null) return Convert.ToInt32(user.ProviderUserKey);

            return 0;
        }

        /// <summary>
        /// Gets the control in specific page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="controlID">The control ID.</param>
        /// <returns></returns>
        public static Control GetControl(Page page, String controlID)
        {
            System.Collections.Generic.IList<Control> foundControl = Agile.Web.UI.FormUtil.GetControls(page, controlID);
            if (foundControl.Count != 0)
            {
                return foundControl[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the time string between before and now.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static String GetTimeStringNow(DateTime? dateTime)
        {
            if (!dateTime.HasValue) return string.Empty;

            return GetTimeStringNow(dateTime.Value);
        }

        /// <summary>
        /// Gets the time string between before and now.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static String GetTimeStringNow(DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return string.Empty;

            return GetTimeString(dateTime, DateTime.Now);
        }

        /// <summary>
        /// Gets the time string between 2 DateTime object.
        /// </summary>
        /// <param name="before">The before.</param>
        /// <param name="after">The after.</param>
        /// <returns></returns>
        public static String GetTimeString(DateTime before, DateTime after)
        {
            string timeString = string.Empty;

            if (before == null || after == null) return string.Empty;
            if (before > after) return string.Empty;

            TimeSpan different = after.Subtract(before);

            if (different.TotalSeconds < 60)
            {
                timeString = string.Format("{0} seconds ago.", different.Seconds);
            }
            else if (different.TotalMinutes < 60)
            {
                timeString = string.Format("{0} minutes ago.", different.Minutes);
            }
            else if (different.TotalHours < 24)
            {
                timeString = string.Format("{0} hours ago.", different.Hours);
            }
            if (different.TotalDays < 5)
            {
                timeString = string.Format("{0} days ago.", different.Days);
            }
            else
                timeString = before.ToString();

            return timeString;
        }
    }
}