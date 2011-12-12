
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

public partial class ResolutionsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ResolutionsEdit.aspx?{0}", ResolutionsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ResolutionsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Resolutions.aspx");
		FormUtil.SetDefaultMode(FormView1, "ResolutionsId");
	}
	protected void GridViewDieRequest1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest1.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
}


