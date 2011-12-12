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
	/// This class is the base class for any <see cref="PriorityDieRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PriorityDieRequestProviderBaseCore : EntityProviderBase<Agile.Entities.PriorityDieRequest, Agile.Entities.PriorityDieRequestKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.PriorityDieRequestKey key)
		{
			return Delete(transactionManager, key.PriorityDieRequestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_priorityDieRequestId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _priorityDieRequestId)
		{
			return Delete(null, _priorityDieRequestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _priorityDieRequestId);		
		
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
		public override Agile.Entities.PriorityDieRequest Get(TransactionManager transactionManager, Agile.Entities.PriorityDieRequestKey key, int start, int pageLength)
		{
			return GetByPriorityDieRequestId(transactionManager, key.PriorityDieRequestId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblPriorityDIERequest index.
		/// </summary>
		/// <param name="_priorityDieRequestId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.PriorityDieRequest"/> class.</returns>
		public Agile.Entities.PriorityDieRequest GetByPriorityDieRequestId(System.Int32 _priorityDieRequestId)
		{
			int count = -1;
			return GetByPriorityDieRequestId(null,_priorityDieRequestId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPriorityDIERequest index.
		/// </summary>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.PriorityDieRequest"/> class.</returns>
		public Agile.Entities.PriorityDieRequest GetByPriorityDieRequestId(System.Int32 _priorityDieRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriorityDieRequestId(null, _priorityDieRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPriorityDIERequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.PriorityDieRequest"/> class.</returns>
		public Agile.Entities.PriorityDieRequest GetByPriorityDieRequestId(TransactionManager transactionManager, System.Int32 _priorityDieRequestId)
		{
			int count = -1;
			return GetByPriorityDieRequestId(transactionManager, _priorityDieRequestId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPriorityDIERequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.PriorityDieRequest"/> class.</returns>
		public Agile.Entities.PriorityDieRequest GetByPriorityDieRequestId(TransactionManager transactionManager, System.Int32 _priorityDieRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriorityDieRequestId(transactionManager, _priorityDieRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPriorityDIERequest index.
		/// </summary>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.PriorityDieRequest"/> class.</returns>
		public Agile.Entities.PriorityDieRequest GetByPriorityDieRequestId(System.Int32 _priorityDieRequestId, int start, int pageLength, out int count)
		{
			return GetByPriorityDieRequestId(null, _priorityDieRequestId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPriorityDIERequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.PriorityDieRequest"/> class.</returns>
		public abstract Agile.Entities.PriorityDieRequest GetByPriorityDieRequestId(TransactionManager transactionManager, System.Int32 _priorityDieRequestId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;PriorityDieRequest&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;PriorityDieRequest&gt;"/></returns>
		public static TList<PriorityDieRequest> Fill(IDataReader reader, TList<PriorityDieRequest> rows, int start, int pageLength)
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
				
				Agile.Entities.PriorityDieRequest c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("PriorityDieRequest")
					.Append("|").Append((System.Int32)reader[((int)PriorityDieRequestColumn.PriorityDieRequestId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<PriorityDieRequest>(
					key.ToString(), // EntityTrackingKey
					"PriorityDieRequest",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.PriorityDieRequest();
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
					c.PriorityDieRequestId = (System.Int32)reader[((int)PriorityDieRequestColumn.PriorityDieRequestId - 1)];
					c.PriorityDieRequestName = (reader.IsDBNull(((int)PriorityDieRequestColumn.PriorityDieRequestName - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.PriorityDieRequestName - 1)];
					c.PriorityDieRequestDescription = (reader.IsDBNull(((int)PriorityDieRequestColumn.PriorityDieRequestDescription - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.PriorityDieRequestDescription - 1)];
					c.Color = (reader.IsDBNull(((int)PriorityDieRequestColumn.Color - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.Color - 1)];
					c.ColorName = (reader.IsDBNull(((int)PriorityDieRequestColumn.ColorName - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.ColorName - 1)];
					c.PriorityDieRequestOrder = (reader.IsDBNull(((int)PriorityDieRequestColumn.PriorityDieRequestOrder - 1)))?null:(System.Int32?)reader[((int)PriorityDieRequestColumn.PriorityDieRequestOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.PriorityDieRequest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.PriorityDieRequest"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.PriorityDieRequest entity)
		{
			if (!reader.Read()) return;
			
			entity.PriorityDieRequestId = (System.Int32)reader[((int)PriorityDieRequestColumn.PriorityDieRequestId - 1)];
			entity.PriorityDieRequestName = (reader.IsDBNull(((int)PriorityDieRequestColumn.PriorityDieRequestName - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.PriorityDieRequestName - 1)];
			entity.PriorityDieRequestDescription = (reader.IsDBNull(((int)PriorityDieRequestColumn.PriorityDieRequestDescription - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.PriorityDieRequestDescription - 1)];
			entity.Color = (reader.IsDBNull(((int)PriorityDieRequestColumn.Color - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.Color - 1)];
			entity.ColorName = (reader.IsDBNull(((int)PriorityDieRequestColumn.ColorName - 1)))?null:(System.String)reader[((int)PriorityDieRequestColumn.ColorName - 1)];
			entity.PriorityDieRequestOrder = (reader.IsDBNull(((int)PriorityDieRequestColumn.PriorityDieRequestOrder - 1)))?null:(System.Int32?)reader[((int)PriorityDieRequestColumn.PriorityDieRequestOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.PriorityDieRequest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.PriorityDieRequest"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.PriorityDieRequest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PriorityDieRequestId = (System.Int32)dataRow["PriorityDIERequestID"];
			entity.PriorityDieRequestName = Convert.IsDBNull(dataRow["PriorityDIERequestName"]) ? null : (System.String)dataRow["PriorityDIERequestName"];
			entity.PriorityDieRequestDescription = Convert.IsDBNull(dataRow["PriorityDIERequestDescription"]) ? null : (System.String)dataRow["PriorityDIERequestDescription"];
			entity.Color = Convert.IsDBNull(dataRow["Color"]) ? null : (System.String)dataRow["Color"];
			entity.ColorName = Convert.IsDBNull(dataRow["ColorName"]) ? null : (System.String)dataRow["ColorName"];
			entity.PriorityDieRequestOrder = Convert.IsDBNull(dataRow["PriorityDIERequestOrder"]) ? null : (System.Int32?)dataRow["PriorityDIERequestOrder"];
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
		/// <param name="entity">The <see cref="Agile.Entities.PriorityDieRequest"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.PriorityDieRequest Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.PriorityDieRequest entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByPriorityDieRequestId methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByPriorityDieRequestId(transactionManager, entity.PriorityDieRequestId);

				if (deep && entity.DieRequestCollection.Count > 0)
				{
					deepHandles.Add("DieRequestCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DieRequest>) DataRepository.DieRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.DieRequestCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
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
		/// Deep Save the entire object graph of the Agile.Entities.PriorityDieRequest object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.PriorityDieRequest instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.PriorityDieRequest Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.PriorityDieRequest entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<DieRequest>
				if (CanDeepSave(entity.DieRequestCollection, "List<DieRequest>|DieRequestCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieRequest child in entity.DieRequestCollection)
					{
						if(child.PriorityDieRequestIdSource != null)
						{
							child.PriorityDieRequestId = child.PriorityDieRequestIdSource.PriorityDieRequestId;
						}
						else
						{
							child.PriorityDieRequestId = entity.PriorityDieRequestId;
						}

					}

					if (entity.DieRequestCollection.Count > 0 || entity.DieRequestCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DieRequestProvider.Save(transactionManager, entity.DieRequestCollection);
						
						deepHandles.Add("DieRequestCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DieRequest >) DataRepository.DieRequestProvider.DeepSave,
							new object[] { transactionManager, entity.DieRequestCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
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
	
	#region PriorityDieRequestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.PriorityDieRequest</c>
	///</summary>
	public enum PriorityDieRequestChildEntityTypes
	{

		///<summary>
		/// Collection of <c>PriorityDieRequest</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion PriorityDieRequestChildEntityTypes
	
	#region PriorityDieRequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PriorityDieRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestFilterBuilder : SqlFilterBuilder<PriorityDieRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestFilterBuilder class.
		/// </summary>
		public PriorityDieRequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PriorityDieRequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PriorityDieRequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PriorityDieRequestFilterBuilder
	
	#region PriorityDieRequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PriorityDieRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PriorityDieRequestParameterBuilder : ParameterizedSqlFilterBuilder<PriorityDieRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestParameterBuilder class.
		/// </summary>
		public PriorityDieRequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PriorityDieRequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PriorityDieRequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PriorityDieRequestParameterBuilder
	
	#region PriorityDieRequestSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PriorityDieRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PriorityDieRequest"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PriorityDieRequestSortBuilder : SqlSortBuilder<PriorityDieRequestColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PriorityDieRequestSqlSortBuilder class.
		/// </summary>
		public PriorityDieRequestSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PriorityDieRequestSortBuilder
	
} // end namespace
