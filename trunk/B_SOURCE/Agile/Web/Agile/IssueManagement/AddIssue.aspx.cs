using System;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

using Agile.Entities;
using Agile.Services;
using Agile.Web.UI;

namespace Agile.IssueManagement
{
    public partial class AddIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormUtil.RedirectAfterInsertUpdate(FormView1, "AddIssue.aspx?{0}", DieRequestDataSource);
            FormUtil.RedirectAfterAddNew(FormView1, "AddIssue.aspx");
            FormUtil.RedirectAfterCancel(FormView1, "~/Share/Home.aspx");
            FormUtil.SetDefaultMode(FormView1, "DieRequestId");

            if (FormView1.CurrentMode == FormViewMode.Edit)
            {
                RadComboBox dataDieStatus = (RadComboBox) Agile.Common.Ultility.GetControl(this, "dataDieStatus");
                if (dataDieStatus != null) dataDieStatus.Enabled = true;
            }
        }

        protected void DieRequestDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //e.InputParameters.Add("DieTag", "");
            e.InputParameters.Add("UserId", Agile.Common.Ultility.GetCurrentUserId());
            e.InputParameters.Add("CodeBy", Agile.Common.Ultility.GetCurrentUserId());
            //e.InputParameters.Add("Owner", Agile.Common.Ultility.GetCurrentUserId());
            e.InputParameters.Add("UpdateTime", DateTime.Now.ToString());
            e.InputParameters.Add("LastUserUpdate", Agile.Common.Ultility.GetCurrentUserId());
            //e.InputParameters.Add("CompletedReleaseId", "");
            //e.InputParameters.Add("ParentDie", "");
            //e.InputParameters.Add("LastUserUpdate", DateTime.Now.ToString());
        }

        protected void DieRequestDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            RadUpload radAttachFile = (RadUpload)FormView1.FindControl("RadAttachFile");

            if (radAttachFile == null) return;

            DieRequest dieRequest = (DieRequest)e.ReturnValue;

            if (dieRequest == null) return;

            foreach (UploadedFile uploadFile in radAttachFile.UploadedFiles)
            {
                DieAttachFile attachFile = new DieAttachFile();

                attachFile.DieRequestId = Convert.ToInt32(dieRequest.DieRequestId);
                attachFile.DieFileName = uploadFile.FileName;
                attachFile.DieFileUrl = radAttachFile.TargetFolder + uploadFile.FileName;

                DieAttachFileService attachFileService = new DieAttachFileService();

                attachFileService.Insert(attachFile);
            }
        }

        protected void DieRequestDataSource_AfterUpdated(object sender, Web.Data.LinkedDataSourceEventArgs e)
        {
            e.InputParameters.Add("UpdateTime", DateTime.Now.ToString());
            e.InputParameters.Add("LastUserUpdate", Agile.Common.Ultility.GetCurrentUserId());
        }

        //TODO: Write add function
    }
}