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
	/// Represents the DataRepository.DieTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DieTypeDataSourceDesigner))]
	public class DieTypeDataSource : ProviderDataSource<DieType, DieTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeDataSource class.
		/// </summary>
		public DieTypeDataSource() : base(new DieTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DieTypeDataSourceView used by the DieTypeDataSource.
		/// </summary>
		protected DieTypeDataSourceView DieTypeView
		{
			get { return ( View as DieTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DieTypeDataSource control invokes to retrieve data.
		/// </summary>
		public DieTypeSelectMethod SelectMethod
		{
			get
			{
				DieTypeSelectMethod selectMethod = DieTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DieTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DieTypeDataSourceView class that is to be
		/// used by the DieTypeDataSource.
		/// </summary>
		/// <returns>An instance of the DieTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<DieType, DieTypeKey> GetNewDataSourceView()
		{
			return new DieTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the DieTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DieTypeDataSourceView : ProviderDataSourceView<DieType, DieTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DieTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DieTypeDataSourceView(DieTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DieTypeDataSource DieTypeOwner
		{
			get { return Owner as DieTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DieTypeSelectMethod SelectMethod
		{
			get { return DieTypeOwner.SelectMethod; }
			set { DieTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DieTypeService DieTypeProvider
		{
			get { return Provider as DieTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DieType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DieType> results = null;
			DieType item;
			count = 0;
			
			System.Int32 _dieTypeId;

			switch ( SelectMethod )
			{
				case DieTypeSelectMethod.Get:
					DieTypeKey entityKey  = new DieTypeKey();
					entityKey.Load(values);
					item = DieTypeProvider.Get(entityKey);
					results = new TList<DieType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DieTypeSelectMethod.GetAll:
                    results = DieTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DieTypeSelectMethod.GetPaged:
					results = DieTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DieTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = DieTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DieTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DieTypeSelectMethod.GetByDieTypeId:
					_dieTypeId = ( values["DieTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DieTypeId"], typeof(System.Int32)) : (int)0;
					item = DieTypeProvider.GetByDieTypeId(_dieTypeId);
					results = new TList<DieType>();
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
			if ( SelectMethod == DieTypeSelectMethod.Get || SelectMethod == DieTypeSelectMethod.GetByDieTypeId )
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
				DieType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DieTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DieType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DieTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DieTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DieTypeDataSource class.
	/// </summary>
	public class DieTypeDataSourceDesigner : ProviderDataSourceDesigner<DieType, DieTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the DieTypeDataSourceDesigner class.
		/// </summary>
		public DieTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieTypeSelectMethod SelectMethod
		{
			get { return ((DieTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DieTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DieTypeDataSourceActionList

	/// <summary>
	/// Supports the DieTypeDataSourceDesigner class.
	/// </summary>
	internal class DieTypeDataSourceActionList : DesignerActionList
	{
		private DieTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DieTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DieTypeDataSourceActionList(DieTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieTypeSelectMethod SelectMethod
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

	#endregion DieTypeDataSourceActionList
	
	#endregion DieTypeDataSourceDesigner
	
	#region DieTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DieTypeDataSource.SelectMethod property.
	/// </summary>
	public enum DieTypeSelectMethod
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
		/// Represents the GetByDieTypeId method.
		/// </summary>
		GetByDieTypeId
	}
	
	#endregion DieTypeSelectMethod

	#region DieTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeFilter : SqlFilter<DieTypeColumn>
	{
	}
	
	#endregion DieTypeFilter

	#region DieTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeExpressionBuilder : SqlExpressionBuilder<DieTypeColumn>
	{
	}
	
	#endregion DieTypeExpressionBuilder	

	#region DieTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DieTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeProperty : ChildEntityProperty<DieTypeChildEntityTypes>
	{
	}
	
	#endregion DieTypeProperty
}

