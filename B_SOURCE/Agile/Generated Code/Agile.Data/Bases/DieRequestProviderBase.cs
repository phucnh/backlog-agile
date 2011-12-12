#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using Agile.Entities;
using Agile.Data;

#endregion

namespace Agile.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="DieRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieRequestProviderBase : DieRequestProviderBaseCore
	{
	} // end class
} // end namespace
