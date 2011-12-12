using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Agile.Web.Data;

namespace Agile.IssueManagement.Controls
{
    public partial class DieList : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AddParameter();
        }

        /// <summary>
        /// Gets the session value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string GetSessionValue(string key)
        {
            if (Session[key] != null)
                return Session[key].ToString();

            return string.Empty;
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        public void AddParameter()
        {
            string dieName = Request.QueryString["DieName"];

            string project = GetSessionValue("Project");
            string status = GetSessionValue("Status");
            string category = GetSessionValue("Category");
            string mileStone = GetSessionValue("MileStone");

            CustomParameter conditionParameter = new CustomParameter();
            conditionParameter.Name = "WhereClause";
            conditionParameter.ConvertEmptyStringToNull = false;

            StringBuilder whereClause = new StringBuilder(string.Empty);

            //if (!string.IsNullOrEmpty(dieName))
            whereClause.Append(string.Format("DieName like '%{0}%'",dieName));
            if (!string.IsNullOrEmpty(project))
                whereClause.AppendFormat(" and ProjectId = '{0}'",project);
            if( !string.IsNullOrEmpty(status))
                whereClause.AppendFormat(" and DieStatus = '{0}'", status);
            if (!string.IsNullOrEmpty(category))
                whereClause.AppendFormat(" and DieCategoryId = '{0}'", category);
            if (!string.IsNullOrEmpty(mileStone))
                whereClause.AppendFormat(" and MileStoneId = '{0}'", mileStone);

            conditionParameter.Value = whereClause.ToString();

            DieRequestDataSource.Parameters.Clear();
            DieRequestDataSource.Parameters.Add(conditionParameter);
            DieRequestDataSource.DataBind();
        }

        protected void grvDieRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddParameter();
        }

        // TODO: Write find function
    }
}