#region Using Directives
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
	/// Represents the DataRepository.DieStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DieStatusDataSourceDesigner))]
	public class DieStatusDataSource : ProviderDataSource<DieStatus, DieStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusDataSource class.
		/// </summary>
		public DieStatusDataSource() : base(new DieStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DieStatusDataSourceView used by the DieStatusDataSource.
		/// </summary>
		protected DieStatusDataSourceView DieStatusView
		{
			get { return ( View as DieStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DieStatusDataSource control invokes to retrieve data.
		/// </summary>
		public DieStatusSelectMethod SelectMethod
		{
			get
			{
				DieStatusSelectMethod selectMethod = DieStatusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DieStatusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DieStatusDataSourceView class that is to be
		/// used by the DieStatusDataSource.
		/// </summary>
		/// <returns>An instance of the DieStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<DieStatus, DieStatusKey> GetNewDataSourceView()
		{
			return new DieStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the DieStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DieStatusDataSourceView : ProviderDataSourceView<DieStatus, DieStatusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DieStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DieStatusDataSourceView(DieStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DieStatusDataSource DieStatusOwner
		{
			get { return Owner as DieStatusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DieStatusSelectMethod SelectMethod
		{
			get { return DieStatusOwner.SelectMethod; }
			set { DieStatusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DieStatusService DieStatusProvider
		{
			get { return Provider as DieStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DieStatus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DieStatus> results = null;
			DieStatus item;
			count = 0;
			
			System.Int32 _dieStatus;

			switch ( SelectMethod )
			{
				case DieStatusSelectMethod.Get:
					DieStatusKey entityKey  = new DieStatusKey();
					entityKey.Load(values);
					item = DieStatusProvider.Get(entityKey);
					results = new TList<DieStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DieStatusSelectMethod.GetAll:
                    results = DieStatusProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DieStatusSelectMethod.GetPaged:
					results = DieStatusProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DieStatusSelectMethod.Find:
					if ( FilterParameters != null )
						results = DieStatusProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DieStatusProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DieStatusSelectMethod.GetByDieStatus:
					_dieStatus = ( values["DieStatus"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DieStatus"], typeof(System.Int32)) : (int)0;
					item = DieStatusProvider.GetByDieStatus(_dieStatus);
					results = new TList<DieStatus>();
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
			if ( SelectMethod == DieStatusSelectMethod.Get || SelectMethod == DieStatusSelectMethod.GetByDieStatus )
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
				DieStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DieStatusProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DieStatus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DieStatusProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DieStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DieStatusDataSource class.
	/// </summary>
	public class DieStatusDataSourceDesigner : ProviderDataSourceDesigner<DieStatus, DieStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the DieStatusDataSourceDesigner class.
		/// </summary>
		public DieStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieStatusSelectMethod SelectMethod
		{
			get { return ((DieStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DieStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DieStatusDataSourceActionList

	/// <summary>
	/// Supports the DieStatusDataSourceDesigner class.
	/// </summary>
	internal class DieStatusDataSourceActionList : DesignerActionList
	{
		private DieStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DieStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DieStatusDataSourceActionList(DieStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieStatusSelectMethod SelectMethod
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

	#endregion DieStatusDataSourceActionList
	
	#endregion DieStatusDataSourceDesigner
	
	#region DieStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DieStatusDataSource.SelectMethod property.
	/// </summary>
	public enum DieStatusSelectMethod
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
		/// Represents the GetByDieStatus method.
		/// </summary>
		GetByDieStatus
	}
	
	#endregion DieStatusSelectMethod

	#region DieStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusFilter : SqlFilter<DieStatusColumn>
	{
	}
	
	#endregion DieStatusFilter

	#region DieStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusExpressionBuilder : SqlExpressionBuilder<DieStatusColumn>
	{
	}
	
	#endregion DieStatusExpressionBuilder	

	#region DieStatusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DieStatusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusProperty : ChildEntityProperty<DieStatusChildEntityTypes>
	{
	}
	
	#endregion DieStatusProperty
}

