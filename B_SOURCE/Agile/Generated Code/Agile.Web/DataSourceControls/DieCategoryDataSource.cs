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
	/// Represents the DataRepository.DieCategoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DieCategoryDataSourceDesigner))]
	public class DieCategoryDataSource : ProviderDataSource<DieCategory, DieCategoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategoryDataSource class.
		/// </summary>
		public DieCategoryDataSource() : base(new DieCategoryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DieCategoryDataSourceView used by the DieCategoryDataSource.
		/// </summary>
		protected DieCategoryDataSourceView DieCategoryView
		{
			get { return ( View as DieCategoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DieCategoryDataSource control invokes to retrieve data.
		/// </summary>
		public DieCategorySelectMethod SelectMethod
		{
			get
			{
				DieCategorySelectMethod selectMethod = DieCategorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DieCategorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DieCategoryDataSourceView class that is to be
		/// used by the DieCategoryDataSource.
		/// </summary>
		/// <returns>An instance of the DieCategoryDataSourceView class.</returns>
		protected override BaseDataSourceView<DieCategory, DieCategoryKey> GetNewDataSourceView()
		{
			return new DieCategoryDataSourceView(this, DefaultViewName);
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
	/// Supports the DieCategoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DieCategoryDataSourceView : ProviderDataSourceView<DieCategory, DieCategoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DieCategoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DieCategoryDataSourceView(DieCategoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DieCategoryDataSource DieCategoryOwner
		{
			get { return Owner as DieCategoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DieCategorySelectMethod SelectMethod
		{
			get { return DieCategoryOwner.SelectMethod; }
			set { DieCategoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DieCategoryService DieCategoryProvider
		{
			get { return Provider as DieCategoryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DieCategory> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DieCategory> results = null;
			DieCategory item;
			count = 0;
			
			System.Int32 _dieCategoryId;

			switch ( SelectMethod )
			{
				case DieCategorySelectMethod.Get:
					DieCategoryKey entityKey  = new DieCategoryKey();
					entityKey.Load(values);
					item = DieCategoryProvider.Get(entityKey);
					results = new TList<DieCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DieCategorySelectMethod.GetAll:
                    results = DieCategoryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DieCategorySelectMethod.GetPaged:
					results = DieCategoryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DieCategorySelectMethod.Find:
					if ( FilterParameters != null )
						results = DieCategoryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DieCategoryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DieCategorySelectMethod.GetByDieCategoryId:
					_dieCategoryId = ( values["DieCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DieCategoryId"], typeof(System.Int32)) : (int)0;
					item = DieCategoryProvider.GetByDieCategoryId(_dieCategoryId);
					results = new TList<DieCategory>();
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
			if ( SelectMethod == DieCategorySelectMethod.Get || SelectMethod == DieCategorySelectMethod.GetByDieCategoryId )
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
				DieCategory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DieCategoryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DieCategory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DieCategoryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DieCategoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DieCategoryDataSource class.
	/// </summary>
	public class DieCategoryDataSourceDesigner : ProviderDataSourceDesigner<DieCategory, DieCategoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the DieCategoryDataSourceDesigner class.
		/// </summary>
		public DieCategoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieCategorySelectMethod SelectMethod
		{
			get { return ((DieCategoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DieCategoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DieCategoryDataSourceActionList

	/// <summary>
	/// Supports the DieCategoryDataSourceDesigner class.
	/// </summary>
	internal class DieCategoryDataSourceActionList : DesignerActionList
	{
		private DieCategoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DieCategoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DieCategoryDataSourceActionList(DieCategoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieCategorySelectMethod SelectMethod
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

	#endregion DieCategoryDataSourceActionList
	
	#endregion DieCategoryDataSourceDesigner
	
	#region DieCategorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DieCategoryDataSource.SelectMethod property.
	/// </summary>
	public enum DieCategorySelectMethod
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
		/// Represents the GetByDieCategoryId method.
		/// </summary>
		GetByDieCategoryId
	}
	
	#endregion DieCategorySelectMethod

	#region DieCategoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryFilter : SqlFilter<DieCategoryColumn>
	{
	}
	
	#endregion DieCategoryFilter

	#region DieCategoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryExpressionBuilder : SqlExpressionBuilder<DieCategoryColumn>
	{
	}
	
	#endregion DieCategoryExpressionBuilder	

	#region DieCategoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DieCategoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryProperty : ChildEntityProperty<DieCategoryChildEntityTypes>
	{
	}
	
	#endregion DieCategoryProperty
}

