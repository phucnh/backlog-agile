using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Entities;

namespace Agile.IssueManagement
{
    public partial class FindIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowConditionalSelected();
        }

        private void ShowConditionalSelected()
        {
            if (Session["Status"] == null || string.IsNullOrEmpty(Session["Status"].ToString()))
                lbtnStatusAll.CssClass = "link_selected";
            else
                lbtnStatusAll.CssClass = "";

            if (Session["Category"] == null || string.IsNullOrEmpty(Session["Category"].ToString()))
                lbtnCategoryAll.CssClass = "link_selected";
            else
                lbtnCategoryAll.CssClass = "";

            if (Session["MileStone"] == null || string.IsNullOrEmpty(Session["MileStone"].ToString()))
                lbtnMileStoneAll.CssClass = "link_selected";
            else
                lbtnMileStoneAll.CssClass = "";
        }

        protected void ddlProject_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Session["Project"] = ddlProject.SelectedValue;
            ucIssueList.AddParameter();
        }

        protected void rptDieStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["Status"] == null || string.IsNullOrEmpty(Session["Status"].ToString()))
                return;

            if (e.Item.ItemType != ListItemType.Item && 
                e.Item.ItemType != ListItemType.AlternatingItem) 
                return;

            DieStatus status = (DieStatus)e.Item.DataItem;

            if (status == null) return;

            LinkButton lbtnStatusName = (LinkButton) e.Item.FindControl("lbtnStatusName");

            if (Session["Status"].ToString() == status.DieStatus.ToString())
                lbtnStatusName.CssClass = "link_selected";
        }

        protected void rptDieCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Session["Category"] = e.CommandArgument;
            }
            ShowConditionalSelected();
            ucIssueList.AddParameter();
            this.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Session["MileStone"] = e.CommandArgument;
            }
            ShowConditionalSelected();
            ucIssueList.AddParameter();
            this.DataBind();
        }

        protected void rptDieStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Filter")
            {
                Session["Status"] = e.CommandArgument;
            }
            ShowConditionalSelected();
            ucIssueList.AddParameter();
            this.DataBind();
        }

        protected void lbtnStatusName_Click(object source, EventArgs e)
        {
            //LinkButton lbtnStatusName = (LinkButton)source;
            //lbtnStatusName.CssClass = "link_selected";

            //this.DataBind();
        }

        protected void rptDieCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["Category"] == null || string.IsNullOrEmpty(Session["Category"].ToString()))
                return;

            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            DieCategory category = (DieCategory)e.Item.DataItem;

            if (category == null) return;

            LinkButton lbtnCategoryName = (LinkButton) e.Item.FindControl("lbtnCategoryName");

            if (Session["Category"].ToString() == category.DieCategoryId.ToString())
                lbtnCategoryName.CssClass = "link_selected";
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["MileStone"] == null || string.IsNullOrEmpty(Session["MileStone"].ToString()))
                return;

            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            MileStole mileStone = (MileStole)e.Item.DataItem;

            if (mileStone == null) return;

            LinkButton lbtnMileStoneName = (LinkButton) e.Item.FindControl("lbtnMileStoneName");

            if (Session["MileStone"].ToString() == mileStone.MileStoleId.ToString())
                lbtnMileStoneName.CssClass = "link_selected";
        }

        protected void lbtnStatusAll_Click(object sender, EventArgs e)
        {
            Session["Status"] = string.Empty;
            ucIssueList.AddParameter();
            ShowConditionalSelected();
            this.DataBind();
        }

        protected void lbtnCategoryAll_Click(object sender, EventArgs e)
        {
            Session["Category"] = string.Empty;
            ucIssueList.AddParameter();
            ShowConditionalSelected();
            this.DataBind();
        }

        protected void lbtnMileStoneAll_Click(object sender, EventArgs e)
        {
            Session["MileStone"] = string.Empty;
            ucIssueList.AddParameter();
            ShowConditionalSelected();
            this.DataBind();
        }
    }
}