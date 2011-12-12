	

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
	/// An component type implementation of the 'tblMileStole' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class MileStoleService : Agile.Services.MileStoleServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the MileStoleService class.
		/// </summary>
		public MileStoleService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
