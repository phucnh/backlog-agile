	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
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
	/// An component type implementation of the 'tblDIEAttachFile' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class DieAttachFileService : Agile.Services.DieAttachFileServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the DieAttachFileService class.
		/// </summary>
		public DieAttachFileService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
