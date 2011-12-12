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
	/// Represents the DataRepository.DieRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DieRequestDataSourceDesigner))]
	public class DieRequestDataSource : ProviderDataSource<DieRequest, DieRequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestDataSource class.
		/// </summary>
		public DieRequestDataSource() : base(new DieRequestService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DieRequestDataSourceView used by the DieRequestDataSource.
		/// </summary>
		protected DieRequestDataSourceView DieRequestView
		{
			get { return ( View as DieRequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DieRequestDataSource control invokes to retrieve data.
		/// </summary>
		public DieRequestSelectMethod SelectMethod
		{
			get
			{
				DieRequestSelectMethod selectMethod = DieRequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DieRequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DieRequestDataSourceView class that is to be
		/// used by the DieRequestDataSource.
		/// </summary>
		/// <returns>An instance of the DieRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<DieRequest, DieRequestKey> GetNewDataSourceView()
		{
			return new DieRequestDataSourceView(this, DefaultViewName);
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
	/// Supports the DieRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DieRequestDataSourceView : ProviderDataSourceView<DieRequest, DieRequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DieRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DieRequestDataSourceView(DieRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DieRequestDataSource DieRequestOwner
		{
			get { return Owner as DieRequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DieRequestSelectMethod SelectMethod
		{
			get { return DieRequestOwner.SelectMethod; }
			set { DieRequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DieRequestService DieRequestProvider
		{
			get { return Provider as DieRequestService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DieRequest> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DieRequest> results = null;
			DieRequest item;
			count = 0;
			
			System.Int32 _dieRequestId;
			System.Int32? _dieCategoryId_nullable;
			System.Int32? _parentDie_nullable;
			System.Int32? _dieStatus_nullable;
			System.Int32? _dieTypeId_nullable;
			System.Int32? _milestoneId_nullable;
			System.Int32? _priorityDieRequestId_nullable;
			System.Int32? _projectId_nullable;
			System.Int32? _completedReleaseId_nullable;
			System.Int32? _resolutionsId_nullable;
			System.Int32? _userId_nullable;
			System.Int32? _codeBy_nullable;
			System.Int32? _owner_nullable;
			System.Int32? _lastUserUpdate_nullable;

			switch ( SelectMethod )
			{
				case DieRequestSelectMethod.Get:
					DieRequestKey entityKey  = new DieRequestKey();
					entityKey.Load(values);
					item = DieRequestProvider.Get(entityKey);
					results = new TList<DieRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DieRequestSelectMethod.GetAll:
                    results = DieRequestProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DieRequestSelectMethod.GetPaged:
					results = DieRequestProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DieRequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = DieRequestProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DieRequestProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DieRequestSelectMethod.GetByDieRequestId:
					_dieRequestId = ( values["DieRequestId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DieRequestId"], typeof(System.Int32)) : (int)0;
					item = DieRequestProvider.GetByDieRequestId(_dieRequestId);
					results = new TList<DieRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DieRequestSelectMethod.GetByDieCategoryId:
					_dieCategoryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DieCategoryId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByDieCategoryId(_dieCategoryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByParentDie:
					_parentDie_nullable = (System.Int32?) EntityUtil.ChangeType(values["ParentDie"], typeof(System.Int32?));
					results = DieRequestProvider.GetByParentDie(_parentDie_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByDieStatus:
					_dieStatus_nullable = (System.Int32?) EntityUtil.ChangeType(values["DieStatus"], typeof(System.Int32?));
					results = DieRequestProvider.GetByDieStatus(_dieStatus_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByDieTypeId:
					_dieTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DieTypeId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByDieTypeId(_dieTypeId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByMilestoneId:
					_milestoneId_nullable = (System.Int32?) EntityUtil.ChangeType(values["MilestoneId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByMilestoneId(_milestoneId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByPriorityDieRequestId:
					_priorityDieRequestId_nullable = (System.Int32?) EntityUtil.ChangeType(values["PriorityDieRequestId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByPriorityDieRequestId(_priorityDieRequestId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByProjectId:
					_projectId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ProjectId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByProjectId(_projectId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByCompletedReleaseId:
					_completedReleaseId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CompletedReleaseId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByCompletedReleaseId(_completedReleaseId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByResolutionsId:
					_resolutionsId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ResolutionsId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByResolutionsId(_resolutionsId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByUserId:
					_userId_nullable = (System.Int32?) EntityUtil.ChangeType(values["UserId"], typeof(System.Int32?));
					results = DieRequestProvider.GetByUserId(_userId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByCodeBy:
					_codeBy_nullable = (System.Int32?) EntityUtil.ChangeType(values["CodeBy"], typeof(System.Int32?));
					results = DieRequestProvider.GetByCodeBy(_codeBy_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByOwner:
					_owner_nullable = (System.Int32?) EntityUtil.ChangeType(values["Owner"], typeof(System.Int32?));
					results = DieRequestProvider.GetByOwner(_owner_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DieRequestSelectMethod.GetByLastUserUpdate:
					_lastUserUpdate_nullable = (System.Int32?) EntityUtil.ChangeType(values["LastUserUpdate"], typeof(System.Int32?));
					results = DieRequestProvider.GetByLastUserUpdate(_lastUserUpdate_nullable, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == DieRequestSelectMethod.Get || SelectMethod == DieRequestSelectMethod.GetByDieRequestId )
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
				DieRequest entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DieRequestProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DieRequest> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DieRequestProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DieRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DieRequestDataSource class.
	/// </summary>
	public class DieRequestDataSourceDesigner : ProviderDataSourceDesigner<DieRequest, DieRequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the DieRequestDataSourceDesigner class.
		/// </summary>
		public DieRequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieRequestSelectMethod SelectMethod
		{
			get { return ((DieRequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DieRequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DieRequestDataSourceActionList

	/// <summary>
	/// Supports the DieRequestDataSourceDesigner class.
	/// </summary>
	internal class DieRequestDataSourceActionList : DesignerActionList
	{
		private DieRequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DieRequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DieRequestDataSourceActionList(DieRequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieRequestSelectMethod SelectMethod
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

	#endregion DieRequestDataSourceActionList
	
	#endregion DieRequestDataSourceDesigner
	
	#region DieRequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DieRequestDataSource.SelectMethod property.
	/// </summary>
	public enum DieRequestSelectMethod
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
		/// Represents the GetByDieRequestId method.
		/// </summary>
		GetByDieRequestId,
		/// <summary>
		/// Represents the GetByDieCategoryId method.
		/// </summary>
		GetByDieCategoryId,
		/// <summary>
		/// Represents the GetByParentDie method.
		/// </summary>
		GetByParentDie,
		/// <summary>
		/// Represents the GetByDieStatus method.
		/// </summary>
		GetByDieStatus,
		/// <summary>
		/// Represents the GetByDieTypeId method.
		/// </summary>
		GetByDieTypeId,
		/// <summary>
		/// Represents the GetByMilestoneId method.
		/// </summary>
		GetByMilestoneId,
		/// <summary>
		/// Represents the GetByPriorityDieRequestId method.
		/// </summary>
		GetByPriorityDieRequestId,
		/// <summary>
		/// Represents the GetByProjectId method.
		/// </summary>
		GetByProjectId,
		/// <summary>
		/// Represents the GetByCompletedReleaseId method.
		/// </summary>
		GetByCompletedReleaseId,
		/// <summary>
		/// Represents the GetByResolutionsId method.
		/// </summary>
		GetByResolutionsId,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByCodeBy method.
		/// </summary>
		GetByCodeBy,
		/// <summary>
		/// Represents the GetByOwner method.
		/// </summary>
		GetByOwner,
		/// <summary>
		/// Represents the GetByLastUserUpdate method.
		/// </summary>
		GetByLastUserUpdate
	}
	
	#endregion DieRequestSelectMethod

	#region DieRequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestFilter : SqlFilter<DieRequestColumn>
	{
	}
	
	#endregion DieRequestFilter

	#region DieRequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestExpressionBuilder : SqlExpressionBuilder<DieRequestColumn>
	{
	}
	
	#endregion DieRequestExpressionBuilder	

	#region DieRequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DieRequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestProperty : ChildEntityProperty<DieRequestChildEntityTypes>
	{
	}
	
	#endregion DieRequestProperty
}

