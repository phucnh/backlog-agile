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
	/// This class is the base class for any <see cref="DieHistoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieHistoryProviderBaseCore : EntityProviderBase<Agile.Entities.DieHistory, Agile.Entities.DieHistoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.DieHistoryKey key)
		{
			return Delete(transactionManager, key.DieHistoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieHistoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dieHistoryId)
		{
			return Delete(null, _dieHistoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieHistoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dieHistoryId);		
		
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
		public override Agile.Entities.DieHistory Get(TransactionManager transactionManager, Agile.Entities.DieHistoryKey key, int start, int pageLength)
		{
			return GetByDieHistoryId(transactionManager, key.DieHistoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDIEHistory index.
		/// </summary>
		/// <param name="_dieHistoryId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		public Agile.Entities.DieHistory GetByDieHistoryId(System.Int32 _dieHistoryId)
		{
			int count = -1;
			return GetByDieHistoryId(null,_dieHistoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEHistory index.
		/// </summary>
		/// <param name="_dieHistoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		public Agile.Entities.DieHistory GetByDieHistoryId(System.Int32 _dieHistoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieHistoryId(null, _dieHistoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieHistoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		public Agile.Entities.DieHistory GetByDieHistoryId(TransactionManager transactionManager, System.Int32 _dieHistoryId)
		{
			int count = -1;
			return GetByDieHistoryId(transactionManager, _dieHistoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieHistoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		public Agile.Entities.DieHistory GetByDieHistoryId(TransactionManager transactionManager, System.Int32 _dieHistoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieHistoryId(transactionManager, _dieHistoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEHistory index.
		/// </summary>
		/// <param name="_dieHistoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		public Agile.Entities.DieHistory GetByDieHistoryId(System.Int32 _dieHistoryId, int start, int pageLength, out int count)
		{
			return GetByDieHistoryId(null, _dieHistoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEHistory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieHistoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieHistory"/> class.</returns>
		public abstract Agile.Entities.DieHistory GetByDieHistoryId(TransactionManager transactionManager, System.Int32 _dieHistoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DieHistory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DieHistory&gt;"/></returns>
		public static TList<DieHistory> Fill(IDataReader reader, TList<DieHistory> rows, int start, int pageLength)
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
				
				Agile.Entities.DieHistory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DieHistory")
					.Append("|").Append((System.Int32)reader[((int)DieHistoryColumn.DieHistoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DieHistory>(
					key.ToString(), // EntityTrackingKey
					"DieHistory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.DieHistory();
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
					c.DieHistoryId = (System.Int32)reader[((int)DieHistoryColumn.DieHistoryId - 1)];
					c.DieRequestId = (System.Int32)reader[((int)DieHistoryColumn.DieRequestId - 1)];
					c.DieDateSubmit = (System.DateTime)reader[((int)DieHistoryColumn.DieDateSubmit - 1)];
					c.DieStatus = (System.Int16)reader[((int)DieHistoryColumn.DieStatus - 1)];
					c.DieHistoryNote = (reader.IsDBNull(((int)DieHistoryColumn.DieHistoryNote - 1)))?null:(System.String)reader[((int)DieHistoryColumn.DieHistoryNote - 1)];
					c.DieHistoryNoteJp = (reader.IsDBNull(((int)DieHistoryColumn.DieHistoryNoteJp - 1)))?null:(System.String)reader[((int)DieHistoryColumn.DieHistoryNoteJp - 1)];
					c.ReleaseId = (reader.IsDBNull(((int)DieHistoryColumn.ReleaseId - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.ReleaseId - 1)];
					c.UserId = (reader.IsDBNull(((int)DieHistoryColumn.UserId - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.UserId - 1)];
					c.Owner = (reader.IsDBNull(((int)DieHistoryColumn.Owner - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.Owner - 1)];
					c.LastUserUpdate = (reader.IsDBNull(((int)DieHistoryColumn.LastUserUpdate - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.LastUserUpdate - 1)];
					c.LastTimeUpdate = (reader.IsDBNull(((int)DieHistoryColumn.LastTimeUpdate - 1)))?null:(System.DateTime?)reader[((int)DieHistoryColumn.LastTimeUpdate - 1)];
					c.ActionTypeId = (reader.IsDBNull(((int)DieHistoryColumn.ActionTypeId - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.ActionTypeId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieHistory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieHistory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.DieHistory entity)
		{
			if (!reader.Read()) return;
			
			entity.DieHistoryId = (System.Int32)reader[((int)DieHistoryColumn.DieHistoryId - 1)];
			entity.DieRequestId = (System.Int32)reader[((int)DieHistoryColumn.DieRequestId - 1)];
			entity.DieDateSubmit = (System.DateTime)reader[((int)DieHistoryColumn.DieDateSubmit - 1)];
			entity.DieStatus = (System.Int16)reader[((int)DieHistoryColumn.DieStatus - 1)];
			entity.DieHistoryNote = (reader.IsDBNull(((int)DieHistoryColumn.DieHistoryNote - 1)))?null:(System.String)reader[((int)DieHistoryColumn.DieHistoryNote - 1)];
			entity.DieHistoryNoteJp = (reader.IsDBNull(((int)DieHistoryColumn.DieHistoryNoteJp - 1)))?null:(System.String)reader[((int)DieHistoryColumn.DieHistoryNoteJp - 1)];
			entity.ReleaseId = (reader.IsDBNull(((int)DieHistoryColumn.ReleaseId - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.ReleaseId - 1)];
			entity.UserId = (reader.IsDBNull(((int)DieHistoryColumn.UserId - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.UserId - 1)];
			entity.Owner = (reader.IsDBNull(((int)DieHistoryColumn.Owner - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.Owner - 1)];
			entity.LastUserUpdate = (reader.IsDBNull(((int)DieHistoryColumn.LastUserUpdate - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.LastUserUpdate - 1)];
			entity.LastTimeUpdate = (reader.IsDBNull(((int)DieHistoryColumn.LastTimeUpdate - 1)))?null:(System.DateTime?)reader[((int)DieHistoryColumn.LastTimeUpdate - 1)];
			entity.ActionTypeId = (reader.IsDBNull(((int)DieHistoryColumn.ActionTypeId - 1)))?null:(System.Int32?)reader[((int)DieHistoryColumn.ActionTypeId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieHistory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieHistory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.DieHistory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieHistoryId = (System.Int32)dataRow["DIEHistoryID"];
			entity.DieRequestId = (System.Int32)dataRow["DIERequestID"];
			entity.DieDateSubmit = (System.DateTime)dataRow["DIEDateSubmit"];
			entity.DieStatus = (System.Int16)dataRow["DIEStatus"];
			entity.DieHistoryNote = Convert.IsDBNull(dataRow["DIEHistoryNote"]) ? null : (System.String)dataRow["DIEHistoryNote"];
			entity.DieHistoryNoteJp = Convert.IsDBNull(dataRow["DIEHistoryNoteJP"]) ? null : (System.String)dataRow["DIEHistoryNoteJP"];
			entity.ReleaseId = Convert.IsDBNull(dataRow["ReleaseID"]) ? null : (System.Int32?)dataRow["ReleaseID"];
			entity.UserId = Convert.IsDBNull(dataRow["UserID"]) ? null : (System.Int32?)dataRow["UserID"];
			entity.Owner = Convert.IsDBNull(dataRow["Owner"]) ? null : (System.Int32?)dataRow["Owner"];
			entity.LastUserUpdate = Convert.IsDBNull(dataRow["LastUserUpdate"]) ? null : (System.Int32?)dataRow["LastUserUpdate"];
			entity.LastTimeUpdate = Convert.IsDBNull(dataRow["LastTimeUpdate"]) ? null : (System.DateTime?)dataRow["LastTimeUpdate"];
			entity.ActionTypeId = Convert.IsDBNull(dataRow["ActionTypeID"]) ? null : (System.Int32?)dataRow["ActionTypeID"];
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
		/// <param name="entity">The <see cref="Agile.Entities.DieHistory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.DieHistory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.DieHistory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the Agile.Entities.DieHistory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.DieHistory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.DieHistory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.DieHistory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region DieHistoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.DieHistory</c>
	///</summary>
	public enum DieHistoryChildEntityTypes
	{
	}
	
	#endregion DieHistoryChildEntityTypes
	
	#region DieHistoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DieHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieHistoryFilterBuilder : SqlFilterBuilder<DieHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieHistoryFilterBuilder class.
		/// </summary>
		public DieHistoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieHistoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieHistoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieHistoryFilterBuilder
	
	#region DieHistoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DieHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieHistory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieHistoryParameterBuilder : ParameterizedSqlFilterBuilder<DieHistoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieHistoryParameterBuilder class.
		/// </summary>
		public DieHistoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieHistoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieHistoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieHistoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieHistoryParameterBuilder
	
	#region DieHistorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DieHistoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieHistory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DieHistorySortBuilder : SqlSortBuilder<DieHistoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieHistorySqlSortBuilder class.
		/// </summary>
		public DieHistorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DieHistorySortBuilder
	
} // end namespace
