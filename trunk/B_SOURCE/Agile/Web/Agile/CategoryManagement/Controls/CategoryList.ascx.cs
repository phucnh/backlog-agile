using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Entities;
using Agile.Services;
using Agile.Web.UI;

namespace Agile.CategoryManagement.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        private static string INSERT_COMMAND = "Insert";
        private static string CANCEL_COMMAND = "Cancel";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnInsert_Click(object sender, EventArgs e)
        {
            livCategoryList.ShowInsertItem();
            livCategoryList.FindControl("lbtnInsert").Visible = false;
        }

        protected void livCategoryList_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            if (e.CommandName == INSERT_COMMAND)
            {

            }
            else if (e.CommandName == CANCEL_COMMAND) 
            {
            }
        }

        protected void livCategoryList_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType != Telerik.Web.UI.RadListViewItemType.DataItem) return;

            Panel pnlPercent = (Panel)e.Item.FindControl("pnlPercent");
            if (pnlPercent == null) return;

            Telerik.Web.UI.RadListViewDataItem dataItem = (Telerik.Web.UI.RadListViewDataItem)e.Item;
            DieCategory category = (DieCategory)dataItem.DataItem;

            DieCategoryService categoryService = new DieCategoryService();
            Dictionary<string, int> percents = (Dictionary<string, int>)categoryService.GetDieRequestPercent(category.DieCategoryId);

            if (percents == null) return;

            PercentControl percentControl = new PercentControl();
            percentControl.ID = "PercentControl" + category.DieCategoryId.ToString();
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

    }
}