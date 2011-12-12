using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Services;
using Agile.Entities;

namespace Agile.Share
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string findString = Request.QueryString["DieName"];

            if (!string.IsNullOrEmpty(findString))
                txtSearchIssue.Text = findString;
        }

        protected void btnSearchIssue_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/IssueManagement/FindIssue.aspx?DieName="+ txtSearchIssue.Text);
        }

    }
}