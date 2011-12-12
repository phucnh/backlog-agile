
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

public partial class DieRequestEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DieRequestEdit.aspx?{0}", DieRequestDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DieRequestEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "DieRequest.aspx");
		FormUtil.SetDefaultMode(FormView1, "DieRequestId");
	}
	protected void GridViewDieAttachFile1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieAttachFileId={0}", GridViewDieAttachFile1.SelectedDataKey.Values[0]);
		Response.Redirect("DieAttachFileEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewDieRequest2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DieRequestId={0}", GridViewDieRequest2.SelectedDataKey.Values[0]);
		Response.Redirect("DieRequestEdit.aspx?" + urlParams, true);		
	}	
}


