
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

}


