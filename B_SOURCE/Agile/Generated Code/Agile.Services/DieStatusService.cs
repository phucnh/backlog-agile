

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
    /// An component type implementation of the 'tblDIEStatus' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class DieStatusService : Agile.Services.DieStatusServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the DieStatusService class.
        /// </summary>
        public DieStatusService()
            : base()
        {
        }
        #endregion Constructors

        /// <summary>
        /// Count the DIE request by status.
        /// </summary>
        /// <param name="statusId">The status id.</param>
        /// <returns></returns>
        public int GetDIEStatusCount(int statusId)
        {
            DieRequestService requestService = new DieRequestService();
            TList<DieRequest> requestList = requestService.GetByDieStatus(statusId);

            if (requestList == null) return 0;

            return requestList.Count;
        }

        /// <summary>
        /// Gets the DIE request complete percent.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, int> GetDIECompletePercent()
        {
            Dictionary<string, int> diePercent = new Dictionary<string, int>();

            DieRequestService requestService = new DieRequestService();

            int completeCount = 0;
            int dieCompleteCount = requestService.GetTotalItems("DIEStatus = 4", out completeCount); //CompleteId = 4

            int dieRequestCount = (requestService.GetAll() == null) ? 0 : requestService.GetAll().Count;

            if (dieRequestCount == 0) return null;

            diePercent.Add("Complete", completeCount);
            diePercent.Add("Not Complete", dieRequestCount - completeCount);

            return diePercent;
        }

    }//End Class

} // end namespace
