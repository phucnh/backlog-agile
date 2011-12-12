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
	/// Represents the DataRepository.DieAttachFileProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DieAttachFileDataSourceDesigner))]
	public class DieAttachFileDataSource : ProviderDataSource<DieAttachFile, DieAttachFileKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileDataSource class.
		/// </summary>
		public DieAttachFileDataSource() : base(new DieAttachFileService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DieAttachFileDataSourceView used by the DieAttachFileDataSource.
		/// </summary>
		protected DieAttachFileDataSourceView DieAttachFileView
		{
			get { return ( View as DieAttachFileDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DieAttachFileDataSource control invokes to retrieve data.
		/// </summary>
		public DieAttachFileSelectMethod SelectMethod
		{
			get
			{
				DieAttachFileSelectMethod selectMethod = DieAttachFileSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DieAttachFileSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DieAttachFileDataSourceView class that is to be
		/// used by the DieAttachFileDataSource.
		/// </summary>
		/// <returns>An instance of the DieAttachFileDataSourceView class.</returns>
		protected override BaseDataSourceView<DieAttachFile, DieAttachFileKey> GetNewDataSourceView()
		{
			return new DieAttachFileDataSourceView(this, DefaultViewName);
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
	/// Supports the DieAttachFileDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DieAttachFileDataSourceView : ProviderDataSourceView<DieAttachFile, DieAttachFileKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DieAttachFileDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DieAttachFileDataSourceView(DieAttachFileDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DieAttachFileDataSource DieAttachFileOwner
		{
			get { return Owner as DieAttachFileDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DieAttachFileSelectMethod SelectMethod
		{
			get { return DieAttachFileOwner.SelectMethod; }
			set { DieAttachFileOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DieAttachFileService DieAttachFileProvider
		{
			get { return Provider as DieAttachFileService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DieAttachFile> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DieAttachFile> results = null;
			DieAttachFile item;
			count = 0;
			
			System.Int32 _dieAttachFileId;
			System.Int32 _dieRequestId;

			switch ( SelectMethod )
			{
				case DieAttachFileSelectMethod.Get:
					DieAttachFileKey entityKey  = new DieAttachFileKey();
					entityKey.Load(values);
					item = DieAttachFileProvider.Get(entityKey);
					results = new TList<DieAttachFile>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DieAttachFileSelectMethod.GetAll:
                    results = DieAttachFileProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DieAttachFileSelectMethod.GetPaged:
					results = DieAttachFileProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DieAttachFileSelectMethod.Find:
					if ( FilterParameters != null )
						results = DieAttachFileProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DieAttachFileProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DieAttachFileSelectMethod.GetByDieAttachFileId:
					_dieAttachFileId = ( values["DieAttachFileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DieAttachFileId"], typeof(System.Int32)) : (int)0;
					item = DieAttachFileProvider.GetByDieAttachFileId(_dieAttachFileId);
					results = new TList<DieAttachFile>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DieAttachFileSelectMethod.GetByDieRequestId:
					_dieRequestId = ( values["DieRequestId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DieRequestId"], typeof(System.Int32)) : (int)0;
					results = DieAttachFileProvider.GetByDieRequestId(_dieRequestId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DieAttachFileSelectMethod.Get || SelectMethod == DieAttachFileSelectMethod.GetByDieAttachFileId )
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
				DieAttachFile entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DieAttachFileProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DieAttachFile> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DieAttachFileProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DieAttachFileDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DieAttachFileDataSource class.
	/// </summary>
	public class DieAttachFileDataSourceDesigner : ProviderDataSourceDesigner<DieAttachFile, DieAttachFileKey>
	{
		/// <summary>
		/// Initializes a new instance of the DieAttachFileDataSourceDesigner class.
		/// </summary>
		public DieAttachFileDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieAttachFileSelectMethod SelectMethod
		{
			get { return ((DieAttachFileDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DieAttachFileDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DieAttachFileDataSourceActionList

	/// <summary>
	/// Supports the DieAttachFileDataSourceDesigner class.
	/// </summary>
	internal class DieAttachFileDataSourceActionList : DesignerActionList
	{
		private DieAttachFileDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DieAttachFileDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DieAttachFileDataSourceActionList(DieAttachFileDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DieAttachFileSelectMethod SelectMethod
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

	#endregion DieAttachFileDataSourceActionList
	
	#endregion DieAttachFileDataSourceDesigner
	
	#region DieAttachFileSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DieAttachFileDataSource.SelectMethod property.
	/// </summary>
	public enum DieAttachFileSelectMethod
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
		/// Represents the GetByDieAttachFileId method.
		/// </summary>
		GetByDieAttachFileId,
		/// <summary>
		/// Represents the GetByDieRequestId method.
		/// </summary>
		GetByDieRequestId
	}
	
	#endregion DieAttachFileSelectMethod

	#region DieAttachFileFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileFilter : SqlFilter<DieAttachFileColumn>
	{
	}
	
	#endregion DieAttachFileFilter

	#region DieAttachFileExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileExpressionBuilder : SqlExpressionBuilder<DieAttachFileColumn>
	{
	}
	
	#endregion DieAttachFileExpressionBuilder	

	#region DieAttachFileProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DieAttachFileChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileProperty : ChildEntityProperty<DieAttachFileChildEntityTypes>
	{
	}
	
	#endregion DieAttachFileProperty
}

