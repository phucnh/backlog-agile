#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using Agile.Entities;
using Agile.Data;
using Agile.Data.Bases;
using Agile.Services;
#endregion

namespace Agile.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.HomeDieRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(HomeDieRequestDataSourceDesigner))]
	public class HomeDieRequestDataSource : ReadOnlyDataSource<HomeDieRequest>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestDataSource class.
		/// </summary>
		public HomeDieRequestDataSource() : base(new HomeDieRequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the HomeDieRequestDataSourceView used by the HomeDieRequestDataSource.
		/// </summary>
		protected HomeDieRequestDataSourceView HomeDieRequestView
		{
			get { return ( View as HomeDieRequestDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the HomeDieRequestDataSourceView class that is to be
		/// used by the HomeDieRequestDataSource.
		/// </summary>
		/// <returns>An instance of the HomeDieRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<HomeDieRequest, Object> GetNewDataSourceView()
		{
			return new HomeDieRequestDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the HomeDieRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class HomeDieRequestDataSourceView : ReadOnlyDataSourceView<HomeDieRequest>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the HomeDieRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public HomeDieRequestDataSourceView(HomeDieRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal HomeDieRequestDataSource HomeDieRequestOwner
		{
			get { return Owner as HomeDieRequestDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal HomeDieRequestService HomeDieRequestProvider
		{
			get { return Provider as HomeDieRequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region HomeDieRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the HomeDieRequestDataSource class.
	/// </summary>
	public class HomeDieRequestDataSourceDesigner : ReadOnlyDataSourceDesigner<HomeDieRequest>
	{
	}

	#endregion HomeDieRequestDataSourceDesigner

	#region HomeDieRequestFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HomeDieRequestFilter : SqlFilter<HomeDieRequestColumn>
	{
	}

	#endregion HomeDieRequestFilter

	#region HomeDieRequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HomeDieRequestExpressionBuilder : SqlExpressionBuilder<HomeDieRequestColumn>
	{
	}
	
	#endregion HomeDieRequestExpressionBuilder		
}

