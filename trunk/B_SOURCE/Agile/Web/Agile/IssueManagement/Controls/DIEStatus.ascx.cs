using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Services;
using Agile.Entities;
using Agile.Web.UI;

namespace Agile.IssueManagement.Controls
{
    public partial class DIEStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPercentControl();
        }

        /// <summary>
        /// Binds the percent control.
        /// </summary>
        private void BindPercentControl()
        {
            DieStatusService statusService = new DieStatusService();

            Dictionary<string,int> percents = 
                (Dictionary<string,int>) statusService.GetDIECompletePercent();

            if (percents == null) return;

            PercentControl percentControl = new PercentControl();
            percentControl.ID = "PercentStatus";
            percentControl.ShowRatio = true;
            percentControl.ItemHeight = "13px";

            string[] backGround = { "Images/complete_background.jpg", "Images/not_complete_backhground.jpg" };
            int count = 0;

            foreach (string name in percents.Keys)
            {
                percentControl.Items.Add(new PercentItem { ItemName = name, Count = percents[name], BackGroundImage = backGround[count] });
                count++;
            }

            pnlPercent.Controls.Add(percentControl);
        }

        /// <summary>
        /// Handles the ItemDataBound event of the rptDIEStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptDIEStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item) return;

            DieStatus status = (DieStatus)e.Item.DataItem;
            if (status == null) return;

            DieStatusService statusService = new DieStatusService();
            int dieCount = statusService.GetDIEStatusCount(status.DieStatus);

            Literal litCountDIE = e.Item.FindControl("litCountDIE") as Literal;
            litCountDIE.Text = "(" + dieCount.ToString() + ")";
        }
    }
}