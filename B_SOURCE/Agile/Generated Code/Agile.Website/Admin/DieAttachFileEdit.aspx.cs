﻿
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

public partial class DieAttachFileEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DieAttachFileEdit.aspx?{0}", DieAttachFileDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DieAttachFileEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "DieAttachFile.aspx");
		FormUtil.SetDefaultMode(FormView1, "DieAttachFileId");
	}
}

