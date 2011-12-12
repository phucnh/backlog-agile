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
	/// Represents the DataRepository.ActionTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ActionTypeDataSourceDesigner))]
	public class ActionTypeDataSource : ProviderDataSource<ActionType, ActionTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeDataSource class.
		/// </summary>
		public ActionTypeDataSource() : base(new ActionTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ActionTypeDataSourceView used by the ActionTypeDataSource.
		/// </summary>
		protected ActionTypeDataSourceView ActionTypeView
		{
			get { return ( View as ActionTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ActionTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ActionTypeSelectMethod SelectMethod
		{
			get
			{
				ActionTypeSelectMethod selectMethod = ActionTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ActionTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ActionTypeDataSourceView class that is to be
		/// used by the ActionTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ActionTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ActionType, ActionTypeKey> GetNewDataSourceView()
		{
			return new ActionTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ActionTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ActionTypeDataSourceView : ProviderDataSourceView<ActionType, ActionTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ActionTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ActionTypeDataSourceView(ActionTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ActionTypeDataSource ActionTypeOwner
		{
			get { return Owner as ActionTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ActionTypeSelectMethod SelectMethod
		{
			get { return ActionTypeOwner.SelectMethod; }
			set { ActionTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ActionTypeService ActionTypeProvider
		{
			get { return Provider as ActionTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ActionType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ActionType> results = null;
			ActionType item;
			count = 0;
			
			System.Int32 _actionTypeId;

			switch ( SelectMethod )
			{
				case ActionTypeSelectMethod.Get:
					ActionTypeKey entityKey  = new ActionTypeKey();
					entityKey.Load(values);
					item = ActionTypeProvider.Get(entityKey);
					results = new TList<ActionType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ActionTypeSelectMethod.GetAll:
                    results = ActionTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ActionTypeSelectMethod.GetPaged:
					results = ActionTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ActionTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ActionTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ActionTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ActionTypeSelectMethod.GetByActionTypeId:
					_actionTypeId = ( values["ActionTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ActionTypeId"], typeof(System.Int32)) : (int)0;
					item = ActionTypeProvider.GetByActionTypeId(_actionTypeId);
					results = new TList<ActionType>();
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
			if ( SelectMethod == ActionTypeSelectMethod.Get || SelectMethod == ActionTypeSelectMethod.GetByActionTypeId )
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
				ActionType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ActionTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ActionType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ActionTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ActionTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ActionTypeDataSource class.
	/// </summary>
	public class ActionTypeDataSourceDesigner : ProviderDataSourceDesigner<ActionType, ActionTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ActionTypeDataSourceDesigner class.
		/// </summary>
		public ActionTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ActionTypeSelectMethod SelectMethod
		{
			get { return ((ActionTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ActionTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ActionTypeDataSourceActionList

	/// <summary>
	/// Supports the ActionTypeDataSourceDesigner class.
	/// </summary>
	internal class ActionTypeDataSourceActionList : DesignerActionList
	{
		private ActionTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ActionTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ActionTypeDataSourceActionList(ActionTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ActionTypeSelectMethod SelectMethod
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

	#endregion ActionTypeDataSourceActionList
	
	#endregion ActionTypeDataSourceDesigner
	
	#region ActionTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ActionTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ActionTypeSelectMethod
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
		/// Represents the GetByActionTypeId method.
		/// </summary>
		GetByActionTypeId
	}
	
	#endregion ActionTypeSelectMethod

	#region ActionTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeFilter : SqlFilter<ActionTypeColumn>
	{
	}
	
	#endregion ActionTypeFilter

	#region ActionTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeExpressionBuilder : SqlExpressionBuilder<ActionTypeColumn>
	{
	}
	
	#endregion ActionTypeExpressionBuilder	

	#region ActionTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ActionTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeProperty : ChildEntityProperty<ActionTypeChildEntityTypes>
	{
	}
	
	#endregion ActionTypeProperty
}

