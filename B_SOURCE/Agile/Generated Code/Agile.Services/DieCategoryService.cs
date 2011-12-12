

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Data;

using Agile.Entities;
using Agile.Entities.Validation;

using Agile.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace Agile.Services
{
    /// <summary>
    /// An component type implementation of the 'tblDIECategory' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class DieCategoryService : Agile.Services.DieCategoryServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the DieCategoryService class.
        /// </summary>
        public DieCategoryService()
            : base()
        {
        }
        #endregion Constructors

        /// <summary>
        /// Gets the die request percent.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns></returns>
        public IDictionary<string, int> GetDieRequestPercent(int categoryId)
        {
            DieCategory category = GetByDieCategoryId(categoryId);

            if (category == null) return null;

            Dictionary<string, int> diePercent = new Dictionary<string, int>();

            DieRequestService requestService = new DieRequestService();

            int completeCount = 0;
            int dieCompleteCount = requestService.GetTotalItems("DIEStatus = 4 AND DIECategoryID = " + categoryId, out completeCount);

            int categoryDIECount = 0;
            int dieRequestCount = requestService.GetTotalItems("DIECategoryID = " + categoryId,out categoryDIECount);

            if (categoryDIECount == 0) return null;

            diePercent.Add("Complete", completeCount);
            diePercent.Add("Category", categoryDIECount - completeCount);

            return diePercent;
        }

    }//End Class

} // end namespace
