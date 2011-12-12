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
	/// Represents the DataRepository.ResolutionsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ResolutionsDataSourceDesigner))]
	public class ResolutionsDataSource : ProviderDataSource<Resolutions, ResolutionsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResolutionsDataSource class.
		/// </summary>
		public ResolutionsDataSource() : base(new ResolutionsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ResolutionsDataSourceView used by the ResolutionsDataSource.
		/// </summary>
		protected ResolutionsDataSourceView ResolutionsView
		{
			get { return ( View as ResolutionsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ResolutionsDataSource control invokes to retrieve data.
		/// </summary>
		public ResolutionsSelectMethod SelectMethod
		{
			get
			{
				ResolutionsSelectMethod selectMethod = ResolutionsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ResolutionsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ResolutionsDataSourceView class that is to be
		/// used by the ResolutionsDataSource.
		/// </summary>
		/// <returns>An instance of the ResolutionsDataSourceView class.</returns>
		protected override BaseDataSourceView<Resolutions, ResolutionsKey> GetNewDataSourceView()
		{
			return new ResolutionsDataSourceView(this, DefaultViewName);
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
	/// Supports the ResolutionsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ResolutionsDataSourceView : ProviderDataSourceView<Resolutions, ResolutionsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResolutionsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ResolutionsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ResolutionsDataSourceView(ResolutionsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ResolutionsDataSource ResolutionsOwner
		{
			get { return Owner as ResolutionsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ResolutionsSelectMethod SelectMethod
		{
			get { return ResolutionsOwner.SelectMethod; }
			set { ResolutionsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ResolutionsService ResolutionsProvider
		{
			get { return Provider as ResolutionsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Resolutions> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Resolutions> results = null;
			Resolutions item;
			count = 0;
			
			System.Int32 _resolutionsId;

			switch ( SelectMethod )
			{
				case ResolutionsSelectMethod.Get:
					ResolutionsKey entityKey  = new ResolutionsKey();
					entityKey.Load(values);
					item = ResolutionsProvider.Get(entityKey);
					results = new TList<Resolutions>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ResolutionsSelectMethod.GetAll:
                    results = ResolutionsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ResolutionsSelectMethod.GetPaged:
					results = ResolutionsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ResolutionsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ResolutionsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ResolutionsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ResolutionsSelectMethod.GetByResolutionsId:
					_resolutionsId = ( values["ResolutionsId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ResolutionsId"], typeof(System.Int32)) : (int)0;
					item = ResolutionsProvider.GetByResolutionsId(_resolutionsId);
					results = new TList<Resolutions>();
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
			if ( SelectMethod == ResolutionsSelectMethod.Get || SelectMethod == ResolutionsSelectMethod.GetByResolutionsId )
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
				Resolutions entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ResolutionsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Resolutions> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ResolutionsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ResolutionsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ResolutionsDataSource class.
	/// </summary>
	public class ResolutionsDataSourceDesigner : ProviderDataSourceDesigner<Resolutions, ResolutionsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ResolutionsDataSourceDesigner class.
		/// </summary>
		public ResolutionsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResolutionsSelectMethod SelectMethod
		{
			get { return ((ResolutionsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ResolutionsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ResolutionsDataSourceActionList

	/// <summary>
	/// Supports the ResolutionsDataSourceDesigner class.
	/// </summary>
	internal class ResolutionsDataSourceActionList : DesignerActionList
	{
		private ResolutionsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ResolutionsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ResolutionsDataSourceActionList(ResolutionsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResolutionsSelectMethod SelectMethod
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

	#endregion ResolutionsDataSourceActionList
	
	#endregion ResolutionsDataSourceDesigner
	
	#region ResolutionsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ResolutionsDataSource.SelectMethod property.
	/// </summary>
	public enum ResolutionsSelectMethod
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
		/// Represents the GetByResolutionsId method.
		/// </summary>
		GetByResolutionsId
	}
	
	#endregion ResolutionsSelectMethod

	#region ResolutionsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Resolutions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResolutionsFilter : SqlFilter<ResolutionsColumn>
	{
	}
	
	#endregion ResolutionsFilter

	#region ResolutionsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Resolutions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResolutionsExpressionBuilder : SqlExpressionBuilder<ResolutionsColumn>
	{
	}
	
	#endregion ResolutionsExpressionBuilder	

	#region ResolutionsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ResolutionsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Resolutions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResolutionsProperty : ChildEntityProperty<ResolutionsChildEntityTypes>
	{
	}
	
	#endregion ResolutionsProperty
}

