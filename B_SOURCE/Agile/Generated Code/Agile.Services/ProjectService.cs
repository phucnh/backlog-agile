﻿	

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
	/// An component type implementation of the 'tblProject' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ProjectService : Agile.Services.ProjectServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ProjectService class.
		/// </summary>
		public ProjectService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
