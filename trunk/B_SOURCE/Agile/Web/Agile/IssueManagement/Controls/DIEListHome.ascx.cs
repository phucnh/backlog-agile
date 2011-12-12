using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Web;
using Agile.Web.UI;
using Agile.Entities;
using Agile.Services;

namespace Agile.IssueManagement.Controls
{
    public partial class DIEListHome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewHelper helper = new GridViewHelper(this.grvDieRequest, false);
            helper.Is_Sortable = false;
            helper.RegisterGroup("DIESubmitDateOnly", true, true);
            helper.CssClass = "home_group_row";
            helper.ApplyGroupSort();
        }

        //protected TList<DieRequest> GetDIERequests()
        //{
        //    DieRequestService requestService = new DieRequestService();
        //    TList<DieRequest> requestList = requestService.GetAll();

        //    return requestList;
        //}
    }
}