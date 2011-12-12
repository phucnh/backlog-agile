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
	/// This class is the base class for any <see cref="DieTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieTypeProviderBaseCore : EntityProviderBase<Agile.Entities.DieType, Agile.Entities.DieTypeKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.DieTypeKey key)
		{
			return Delete(transactionManager, key.DieTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dieTypeId)
		{
			return Delete(null, _dieTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dieTypeId);		
		
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
		public override Agile.Entities.DieType Get(TransactionManager transactionManager, Agile.Entities.DieTypeKey key, int start, int pageLength)
		{
			return GetByDieTypeId(transactionManager, key.DieTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDIEType index.
		/// </summary>
		/// <param name="_dieTypeId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieType"/> class.</returns>
		public Agile.Entities.DieType GetByDieTypeId(System.Int32 _dieTypeId)
		{
			int count = -1;
			return GetByDieTypeId(null,_dieTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEType index.
		/// </summary>
		/// <param name="_dieTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieType"/> class.</returns>
		public Agile.Entities.DieType GetByDieTypeId(System.Int32 _dieTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieTypeId(null, _dieTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieType"/> class.</returns>
		public Agile.Entities.DieType GetByDieTypeId(TransactionManager transactionManager, System.Int32 _dieTypeId)
		{
			int count = -1;
			return GetByDieTypeId(transactionManager, _dieTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieType"/> class.</returns>
		public Agile.Entities.DieType GetByDieTypeId(TransactionManager transactionManager, System.Int32 _dieTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieTypeId(transactionManager, _dieTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEType index.
		/// </summary>
		/// <param name="_dieTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieType"/> class.</returns>
		public Agile.Entities.DieType GetByDieTypeId(System.Int32 _dieTypeId, int start, int pageLength, out int count)
		{
			return GetByDieTypeId(null, _dieTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieType"/> class.</returns>
		public abstract Agile.Entities.DieType GetByDieTypeId(TransactionManager transactionManager, System.Int32 _dieTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DieType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DieType&gt;"/></returns>
		public static TList<DieType> Fill(IDataReader reader, TList<DieType> rows, int start, int pageLength)
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
				
				Agile.Entities.DieType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DieType")
					.Append("|").Append((System.Int32)reader[((int)DieTypeColumn.DieTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DieType>(
					key.ToString(), // EntityTrackingKey
					"DieType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.DieType();
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
					c.DieTypeId = (System.Int32)reader[((int)DieTypeColumn.DieTypeId - 1)];
					c.Initial = (reader.IsDBNull(((int)DieTypeColumn.Initial - 1)))?null:(System.String)reader[((int)DieTypeColumn.Initial - 1)];
					c.DieTypeName = (reader.IsDBNull(((int)DieTypeColumn.DieTypeName - 1)))?null:(System.String)reader[((int)DieTypeColumn.DieTypeName - 1)];
					c.Description = (reader.IsDBNull(((int)DieTypeColumn.Description - 1)))?null:(System.String)reader[((int)DieTypeColumn.Description - 1)];
					c.IsDefault = (reader.IsDBNull(((int)DieTypeColumn.IsDefault - 1)))?null:(System.Boolean?)reader[((int)DieTypeColumn.IsDefault - 1)];
					c.Selected = (reader.IsDBNull(((int)DieTypeColumn.Selected - 1)))?null:(System.Boolean?)reader[((int)DieTypeColumn.Selected - 1)];
					c.Active = (reader.IsDBNull(((int)DieTypeColumn.Active - 1)))?null:(System.Boolean?)reader[((int)DieTypeColumn.Active - 1)];
					c.Order = (reader.IsDBNull(((int)DieTypeColumn.Order - 1)))?null:(System.Int32?)reader[((int)DieTypeColumn.Order - 1)];
					c.ProjectId = (reader.IsDBNull(((int)DieTypeColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)DieTypeColumn.ProjectId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.DieType entity)
		{
			if (!reader.Read()) return;
			
			entity.DieTypeId = (System.Int32)reader[((int)DieTypeColumn.DieTypeId - 1)];
			entity.Initial = (reader.IsDBNull(((int)DieTypeColumn.Initial - 1)))?null:(System.String)reader[((int)DieTypeColumn.Initial - 1)];
			entity.DieTypeName = (reader.IsDBNull(((int)DieTypeColumn.DieTypeName - 1)))?null:(System.String)reader[((int)DieTypeColumn.DieTypeName - 1)];
			entity.Description = (reader.IsDBNull(((int)DieTypeColumn.Description - 1)))?null:(System.String)reader[((int)DieTypeColumn.Description - 1)];
			entity.IsDefault = (reader.IsDBNull(((int)DieTypeColumn.IsDefault - 1)))?null:(System.Boolean?)reader[((int)DieTypeColumn.IsDefault - 1)];
			entity.Selected = (reader.IsDBNull(((int)DieTypeColumn.Selected - 1)))?null:(System.Boolean?)reader[((int)DieTypeColumn.Selected - 1)];
			entity.Active = (reader.IsDBNull(((int)DieTypeColumn.Active - 1)))?null:(System.Boolean?)reader[((int)DieTypeColumn.Active - 1)];
			entity.Order = (reader.IsDBNull(((int)DieTypeColumn.Order - 1)))?null:(System.Int32?)reader[((int)DieTypeColumn.Order - 1)];
			entity.ProjectId = (reader.IsDBNull(((int)DieTypeColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)DieTypeColumn.ProjectId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.DieType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieTypeId = (System.Int32)dataRow["DIETypeID"];
			entity.Initial = Convert.IsDBNull(dataRow["Initial"]) ? null : (System.String)dataRow["Initial"];
			entity.DieTypeName = Convert.IsDBNull(dataRow["DIETypeName"]) ? null : (System.String)dataRow["DIETypeName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.IsDefault = Convert.IsDBNull(dataRow["IsDefault"]) ? null : (System.Boolean?)dataRow["IsDefault"];
			entity.Selected = Convert.IsDBNull(dataRow["Selected"]) ? null : (System.Boolean?)dataRow["Selected"];
			entity.Active = Convert.IsDBNull(dataRow["Active"]) ? null : (System.Boolean?)dataRow["Active"];
			entity.Order = Convert.IsDBNull(dataRow["Order"]) ? null : (System.Int32?)dataRow["Order"];
			entity.ProjectId = Convert.IsDBNull(dataRow["ProjectID"]) ? null : (System.Int32?)dataRow["ProjectID"];
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
		/// <param name="entity">The <see cref="Agile.Entities.DieType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.DieType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.DieType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDieTypeId methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByDieTypeId(transactionManager, entity.DieTypeId);

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
		/// Deep Save the entire object graph of the Agile.Entities.DieType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.DieType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.DieType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.DieType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.DieTypeIdSource != null)
						{
							child.DieTypeId = child.DieTypeIdSource.DieTypeId;
						}
						else
						{
							child.DieTypeId = entity.DieTypeId;
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
	
	#region DieTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.DieType</c>
	///</summary>
	public enum DieTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>DieType</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion DieTypeChildEntityTypes
	
	#region DieTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DieTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeFilterBuilder : SqlFilterBuilder<DieTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeFilterBuilder class.
		/// </summary>
		public DieTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieTypeFilterBuilder
	
	#region DieTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DieTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieTypeParameterBuilder : ParameterizedSqlFilterBuilder<DieTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeParameterBuilder class.
		/// </summary>
		public DieTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieTypeParameterBuilder
	
	#region DieTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DieTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DieTypeSortBuilder : SqlSortBuilder<DieTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieTypeSqlSortBuilder class.
		/// </summary>
		public DieTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DieTypeSortBuilder
	
} // end namespace
