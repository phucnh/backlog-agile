	

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
	/// An component type implementation of the 'tblDIEType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class DieTypeService : Agile.Services.DieTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the DieTypeService class.
		/// </summary>
		public DieTypeService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
