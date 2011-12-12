﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using Agile.Entities;
using Agile.Data;
using Agile.Data.Bases;
using Agile.Services;
#endregion

namespace Agile.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ReleaseProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ReleaseDataSourceDesigner))]
	public class ReleaseDataSource : ProviderDataSource<Release, ReleaseKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseDataSource class.
		/// </summary>
		public ReleaseDataSource() : base(new ReleaseService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ReleaseDataSourceView used by the ReleaseDataSource.
		/// </summary>
		protected ReleaseDataSourceView ReleaseView
		{
			get { return ( View as ReleaseDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ReleaseDataSource control invokes to retrieve data.
		/// </summary>
		public ReleaseSelectMethod SelectMethod
		{
			get
			{
				ReleaseSelectMethod selectMethod = ReleaseSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ReleaseSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ReleaseDataSourceView class that is to be
		/// used by the ReleaseDataSource.
		/// </summary>
		/// <returns>An instance of the ReleaseDataSourceView class.</returns>
		protected override BaseDataSourceView<Release, ReleaseKey> GetNewDataSourceView()
		{
			return new ReleaseDataSourceView(this, DefaultViewName);
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
	/// Supports the ReleaseDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ReleaseDataSourceView : ProviderDataSourceView<Release, ReleaseKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ReleaseDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ReleaseDataSourceView(ReleaseDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ReleaseDataSource ReleaseOwner
		{
			get { return Owner as ReleaseDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ReleaseSelectMethod SelectMethod
		{
			get { return ReleaseOwner.SelectMethod; }
			set { ReleaseOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ReleaseService ReleaseProvider
		{
			get { return Provider as ReleaseService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Release> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Release> results = null;
			Release item;
			count = 0;
			
			System.Int32 _releaseId;

			switch ( SelectMethod )
			{
				case ReleaseSelectMethod.Get:
					ReleaseKey entityKey  = new ReleaseKey();
					entityKey.Load(values);
					item = ReleaseProvider.Get(entityKey);
					results = new TList<Release>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ReleaseSelectMethod.GetAll:
                    results = ReleaseProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ReleaseSelectMethod.GetPaged:
					results = ReleaseProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ReleaseSelectMethod.Find:
					if ( FilterParameters != null )
						results = ReleaseProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ReleaseProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ReleaseSelectMethod.GetByReleaseId:
					_releaseId = ( values["ReleaseId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ReleaseId"], typeof(System.Int32)) : (int)0;
					item = ReleaseProvider.GetByReleaseId(_releaseId);
					results = new TList<Release>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == ReleaseSelectMethod.Get || SelectMethod == ReleaseSelectMethod.GetByReleaseId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Release entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ReleaseProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<Release> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ReleaseProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ReleaseDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ReleaseDataSource class.
	/// </summary>
	public class ReleaseDataSourceDesigner : ProviderDataSourceDesigner<Release, ReleaseKey>
	{
		/// <summary>
		/// Initializes a new instance of the ReleaseDataSourceDesigner class.
		/// </summary>
		public ReleaseDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ReleaseSelectMethod SelectMethod
		{
			get { return ((ReleaseDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new ReleaseDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ReleaseDataSourceActionList

	/// <summary>
	/// Supports the ReleaseDataSourceDesigner class.
	/// </summary>
	internal class ReleaseDataSourceActionList : DesignerActionList
	{
		private ReleaseDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ReleaseDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ReleaseDataSourceActionList(ReleaseDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ReleaseSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion ReleaseDataSourceActionList
	
	#endregion ReleaseDataSourceDesigner
	
	#region ReleaseSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ReleaseDataSource.SelectMethod property.
	/// </summary>
	public enum ReleaseSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByReleaseId method.
		/// </summary>
		GetByReleaseId
	}
	
	#endregion ReleaseSelectMethod

	#region ReleaseFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseFilter : SqlFilter<ReleaseColumn>
	{
	}
	
	#endregion ReleaseFilter

	#region ReleaseExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseExpressionBuilder : SqlExpressionBuilder<ReleaseColumn>
	{
	}
	
	#endregion ReleaseExpressionBuilder	

	#region ReleaseProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ReleaseChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseProperty : ChildEntityProperty<ReleaseChildEntityTypes>
	{
	}
	
	#endregion ReleaseProperty
}

