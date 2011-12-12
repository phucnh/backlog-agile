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
	/// Represents the DataRepository.PriorityDieRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PriorityDieRequestDataSourceDesigner))]
	public class PriorityDieRequestDataSource : ProviderDataSource<PriorityDieRequest, PriorityDieRequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestDataSource class.
		/// </summary>
		public PriorityDieRequestDataSource() : base(new PriorityDieRequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PriorityDieRequestDataSourceView used by the PriorityDieRequestDataSource.
		/// </summary>
		protected PriorityDieRequestDataSourceView PriorityDieRequestView
		{
			get { return ( View as PriorityDieRequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PriorityDieRequestDataSource control invokes to retrieve data.
		/// </summary>
		public PriorityDieRequestSelectMethod SelectMethod
		{
			get
			{
				PriorityDieRequestSelectMethod selectMethod = PriorityDieRequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PriorityDieRequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PriorityDieRequestDataSourceView class that is to be
		/// used by the PriorityDieRequestDataSource.
		/// </summary>
		/// <returns>An instance of the PriorityDieRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<PriorityDieRequest, PriorityDieRequestKey> GetNewDataSourceView()
		{
			return new PriorityDieRequestDataSourceView(this, DefaultViewName);
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
	/// Supports the PriorityDieRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PriorityDieRequestDataSourceView : ProviderDataSourceView<PriorityDieRequest, PriorityDieRequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PriorityDieRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PriorityDieRequestDataSourceView(PriorityDieRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PriorityDieRequestDataSource PriorityDieRequestOwner
		{
			get { return Owner as PriorityDieRequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PriorityDieRequestSelectMethod SelectMethod
		{
			get { return PriorityDieRequestOwner.SelectMethod; }
			set { PriorityDieRequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PriorityDieRequestService PriorityDieRequestProvider
		{
			get { return Provider as PriorityDieRequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PriorityDieRequest> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PriorityDieRequest> results = null;
			PriorityDieRequest item;
			count = 0;
			
			System.Int32 _priorityDieRequestId;

			switch ( SelectMethod )
			{
				case PriorityDieRequestSelectMethod.Get:
					PriorityDieRequestKey entityKey  = new PriorityDieRequestKey();
					entityKey.Load(values);
					item = PriorityDieRequestProvider.Get(entityKey);
					results = new TList<PriorityDieRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PriorityDieRequestSelectMethod.GetAll:
                    results = PriorityDieRequestProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case PriorityDieRequestSelectMethod.GetPaged:
					results = PriorityDieRequestProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PriorityDieRequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = PriorityDieRequestProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PriorityDieRequestProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PriorityDieRequestSelectMethod.GetByPriorityDieRequestId:
					_priorityDieRequestId = ( values["PriorityDieRequestId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["PriorityDieRequestId"], typeof(System.Int32)) : (int)0;
					item = PriorityDieRequestProvider.GetByPriorityDieRequestId(_priorityDieRequestId);
					results = new TList<PriorityDieRequest>();
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
			if ( SelectMethod == PriorityDieRequestSelectMethod.Get || SelectMethod == PriorityDieRequestSelectMethod.GetByPriorityDieRequestId )
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
				PriorityDieRequest entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					PriorityDieRequestProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PriorityDieRequest> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			PriorityDieRequestProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PriorityDieRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PriorityDieRequestDataSource class.
	/// </summary>
	public class PriorityDieRequestDataSourceDesigner : ProviderDataSourceDesigner<PriorityDieRequest, PriorityDieRequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestDataSourceDesigner class.
		/// </summary>
		public PriorityDieRequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PriorityDieRequestSelectMethod SelectMethod
		{
			get { return ((PriorityDieRequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PriorityDieRequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PriorityDieRequestDataSourceActionList

	/// <summary>
	/// Supports the PriorityDieRequestDataSourceDesigner class.
	/// </summary>
	internal class PriorityDieRequestDataSourceActionList : DesignerActionList
	{
		private PriorityDieRequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PriorityDieRequestDataSourceActionList(PriorityDieRequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PriorityDieRequestSelectMethod SelectMethod
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

	#endregion PriorityDieRequestDataSourceActionList
	
	#endregion PriorityDieRequestDataSourceDesigner
	
	#region PriorityDieRequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PriorityDieRequestDataSource.SelectMethod property.
	/// </summary>
	public enum PriorityDieRequestSelectMethod
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
		/// Represents the GetByPriorityDieRequestId method.
		/// </summary>
		GetByPriorityDieRequestId
	}
	
	#endregion PriorityDieRequestSelectMethod

	#region PriorityDieRequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestFilter : SqlFilter<PriorityDieRequestColumn>
	{
	}
	
	#endregion PriorityDieRequestFilter

	#region PriorityDieRequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestExpressionBuilder : SqlExpressionBuilder<PriorityDieRequestColumn>
	{
	}
	
	#endregion PriorityDieRequestExpressionBuilder	

	#region PriorityDieRequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PriorityDieRequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestProperty : ChildEntityProperty<PriorityDieRequestChildEntityTypes>
	{
	}
	
	#endregion PriorityDieRequestProperty
}

