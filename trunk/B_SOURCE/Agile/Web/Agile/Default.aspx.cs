using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Web.UI;

namespace Agile
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PercentItem item1 = new PercentItem { Color = "blue", Count=10};
            PercentItem item2 = new PercentItem { Color = "red", Count = 20 };

            percent1.Items.Add(item1);
            percent1.Items.Add(item2);

        }
    }
}