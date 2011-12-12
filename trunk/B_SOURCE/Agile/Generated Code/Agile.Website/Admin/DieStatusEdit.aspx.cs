
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

public partial class DieStatusEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DieStatusEdit.aspx?{0}", DieStatusDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DieStatusEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "DieStatus.aspx");
		FormUtil.SetDefaultMode(FormView1, "DieStatus");
	}
	protected void GridViewDieRequest1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest1.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
}


