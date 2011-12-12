#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Agile.Entities;
using Agile.Data;

#endregion

namespace Agile.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ActionTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ActionTypeProviderBaseCore : EntityProviderBase<Agile.Entities.ActionType, Agile.Entities.ActionTypeKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.ActionTypeKey key)
		{
			return Delete(transactionManager, key.ActionTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_actionTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _actionTypeId)
		{
			return Delete(null, _actionTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _actionTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Agile.Entities.ActionType Get(TransactionManager transactionManager, Agile.Entities.ActionTypeKey key, int start, int pageLength)
		{
			return GetByActionTypeId(transactionManager, key.ActionTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblActionType index.
		/// </summary>
		/// <param name="_actionTypeId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.ActionType"/> class.</returns>
		public Agile.Entities.ActionType GetByActionTypeId(System.Int32 _actionTypeId)
		{
			int count = -1;
			return GetByActionTypeId(null,_actionTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblActionType index.
		/// </summary>
		/// <param name="_actionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.ActionType"/> class.</returns>
		public Agile.Entities.ActionType GetByActionTypeId(System.Int32 _actionTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByActionTypeId(null, _actionTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblActionType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.ActionType"/> class.</returns>
		public Agile.Entities.ActionType GetByActionTypeId(TransactionManager transactionManager, System.Int32 _actionTypeId)
		{
			int count = -1;
			return GetByActionTypeId(transactionManager, _actionTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblActionType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.ActionType"/> class.</returns>
		public Agile.Entities.ActionType GetByActionTypeId(TransactionManager transactionManager, System.Int32 _actionTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByActionTypeId(transactionManager, _actionTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblActionType index.
		/// </summary>
		/// <param name="_actionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.ActionType"/> class.</returns>
		public Agile.Entities.ActionType GetByActionTypeId(System.Int32 _actionTypeId, int start, int pageLength, out int count)
		{
			return GetByActionTypeId(null, _actionTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblActionType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_actionTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.ActionType"/> class.</returns>
		public abstract Agile.Entities.ActionType GetByActionTypeId(TransactionManager transactionManager, System.Int32 _actionTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ActionType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ActionType&gt;"/></returns>
		public static TList<ActionType> Fill(IDataReader reader, TList<ActionType> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Agile.Entities.ActionType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ActionType")
					.Append("|").Append((System.Int32)reader[((int)ActionTypeColumn.ActionTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ActionType>(
					key.ToString(), // EntityTrackingKey
					"ActionType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.ActionType();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.ActionTypeId = (System.Int32)reader[((int)ActionTypeColumn.ActionTypeId - 1)];
					c.ActionTypeName = (reader.IsDBNull(((int)ActionTypeColumn.ActionTypeName - 1)))?null:(System.String)reader[((int)ActionTypeColumn.ActionTypeName - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.ActionType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.ActionType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.ActionType entity)
		{
			if (!reader.Read()) return;
			
			entity.ActionTypeId = (System.Int32)reader[((int)ActionTypeColumn.ActionTypeId - 1)];
			entity.ActionTypeName = (reader.IsDBNull(((int)ActionTypeColumn.ActionTypeName - 1)))?null:(System.String)reader[((int)ActionTypeColumn.ActionTypeName - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.ActionType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.ActionType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.ActionType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ActionTypeId = (System.Int32)dataRow["ActionTypeID"];
			entity.ActionTypeName = Convert.IsDBNull(dataRow["ActionTypeName"]) ? null : (System.String)dataRow["ActionTypeName"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Agile.Entities.ActionType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.ActionType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.ActionType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Agile.Entities.ActionType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.ActionType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.ActionType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.ActionType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region ActionTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.ActionType</c>
	///</summary>
	public enum ActionTypeChildEntityTypes
	{
	}
	
	#endregion ActionTypeChildEntityTypes
	
	#region ActionTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ActionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeFilterBuilder : SqlFilterBuilder<ActionTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilterBuilder class.
		/// </summary>
		public ActionTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionTypeFilterBuilder
	
	#region ActionTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ActionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ActionTypeParameterBuilder : ParameterizedSqlFilterBuilder<ActionTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeParameterBuilder class.
		/// </summary>
		public ActionTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ActionTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ActionTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ActionTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ActionTypeParameterBuilder
	
	#region ActionTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ActionTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ActionType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ActionTypeSortBuilder : SqlSortBuilder<ActionTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ActionTypeSqlSortBuilder class.
		/// </summary>
		public ActionTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ActionTypeSortBuilder
	
} // end namespace
