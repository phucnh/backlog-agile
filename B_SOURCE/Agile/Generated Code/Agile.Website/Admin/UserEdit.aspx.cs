
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Agile.Web.UI;
#endregion

public partial class UserEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UserEdit.aspx?{0}", UserDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UserEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "User.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserId");
	}
	protected void GridViewDieRequest1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest1.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewDieRequest2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest2.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewDieRequest3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest3.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewDieRequest4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest4.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
}


