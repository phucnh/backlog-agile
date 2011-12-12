using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Entities;
using Agile.Services;

namespace Agile.UserManagement.Controls
{
    public partial class UserList : System.Web.UI.UserControl
    {
        private int projectId;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}