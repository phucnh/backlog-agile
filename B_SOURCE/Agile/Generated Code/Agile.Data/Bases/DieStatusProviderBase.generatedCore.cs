﻿#region Using directives

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
	/// This class is the base class for any <see cref="DieStatusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieStatusProviderBaseCore : EntityProviderBase<Agile.Entities.DieStatus, Agile.Entities.DieStatusKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.DieStatusKey key)
		{
			return Delete(transactionManager, key.DieStatus);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieStatus">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dieStatus)
		{
			return Delete(null, _dieStatus);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dieStatus);		
		
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
		public override Agile.Entities.DieStatus Get(TransactionManager transactionManager, Agile.Entities.DieStatusKey key, int start, int pageLength)
		{
			return GetByDieStatus(transactionManager, key.DieStatus, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDIEStatus index.
		/// </summary>
		/// <param name="_dieStatus"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieStatus"/> class.</returns>
		public Agile.Entities.DieStatus GetByDieStatus(System.Int32 _dieStatus)
		{
			int count = -1;
			return GetByDieStatus(null,_dieStatus, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEStatus index.
		/// </summary>
		/// <param name="_dieStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieStatus"/> class.</returns>
		public Agile.Entities.DieStatus GetByDieStatus(System.Int32 _dieStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByDieStatus(null, _dieStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieStatus"/> class.</returns>
		public Agile.Entities.DieStatus GetByDieStatus(TransactionManager transactionManager, System.Int32 _dieStatus)
		{
			int count = -1;
			return GetByDieStatus(transactionManager, _dieStatus, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieStatus"/> class.</returns>
		public Agile.Entities.DieStatus GetByDieStatus(TransactionManager transactionManager, System.Int32 _dieStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByDieStatus(transactionManager, _dieStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEStatus index.
		/// </summary>
		/// <param name="_dieStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieStatus"/> class.</returns>
		public Agile.Entities.DieStatus GetByDieStatus(System.Int32 _dieStatus, int start, int pageLength, out int count)
		{
			return GetByDieStatus(null, _dieStatus, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieStatus"/> class.</returns>
		public abstract Agile.Entities.DieStatus GetByDieStatus(TransactionManager transactionManager, System.Int32 _dieStatus, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DieStatus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DieStatus&gt;"/></returns>
		public static TList<DieStatus> Fill(IDataReader reader, TList<DieStatus> rows, int start, int pageLength)
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
				
				Agile.Entities.DieStatus c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DieStatus")
					.Append("|").Append((System.Int32)reader[((int)DieStatusColumn.DieStatus - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DieStatus>(
					key.ToString(), // EntityTrackingKey
					"DieStatus",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.DieStatus();
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
					c.DieStatus = (System.Int32)reader[((int)DieStatusColumn.DieStatus - 1)];
					c.DieNameStatus = (reader.IsDBNull(((int)DieStatusColumn.DieNameStatus - 1)))?null:(System.String)reader[((int)DieStatusColumn.DieNameStatus - 1)];
					c.Order = (reader.IsDBNull(((int)DieStatusColumn.Order - 1)))?null:(System.Int32?)reader[((int)DieStatusColumn.Order - 1)];
					c.Visible = (reader.IsDBNull(((int)DieStatusColumn.Visible - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.Visible - 1)];
					c.Selected = (reader.IsDBNull(((int)DieStatusColumn.Selected - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.Selected - 1)];
					c.IsDefault = (reader.IsDBNull(((int)DieStatusColumn.IsDefault - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.IsDefault - 1)];
					c.IconLink = (reader.IsDBNull(((int)DieStatusColumn.IconLink - 1)))?null:(System.String)reader[((int)DieStatusColumn.IconLink - 1)];
					c.IsCompleted = (reader.IsDBNull(((int)DieStatusColumn.IsCompleted - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.IsCompleted - 1)];
					c.Color = (reader.IsDBNull(((int)DieStatusColumn.Color - 1)))?null:(System.String)reader[((int)DieStatusColumn.Color - 1)];
					c.ColorName = (reader.IsDBNull(((int)DieStatusColumn.ColorName - 1)))?null:(System.String)reader[((int)DieStatusColumn.ColorName - 1)];
					c.ProjectId = (reader.IsDBNull(((int)DieStatusColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)DieStatusColumn.ProjectId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieStatus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieStatus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.DieStatus entity)
		{
			if (!reader.Read()) return;
			
			entity.DieStatus = (System.Int32)reader[((int)DieStatusColumn.DieStatus - 1)];
			entity.DieNameStatus = (reader.IsDBNull(((int)DieStatusColumn.DieNameStatus - 1)))?null:(System.String)reader[((int)DieStatusColumn.DieNameStatus - 1)];
			entity.Order = (reader.IsDBNull(((int)DieStatusColumn.Order - 1)))?null:(System.Int32?)reader[((int)DieStatusColumn.Order - 1)];
			entity.Visible = (reader.IsDBNull(((int)DieStatusColumn.Visible - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.Visible - 1)];
			entity.Selected = (reader.IsDBNull(((int)DieStatusColumn.Selected - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.Selected - 1)];
			entity.IsDefault = (reader.IsDBNull(((int)DieStatusColumn.IsDefault - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.IsDefault - 1)];
			entity.IconLink = (reader.IsDBNull(((int)DieStatusColumn.IconLink - 1)))?null:(System.String)reader[((int)DieStatusColumn.IconLink - 1)];
			entity.IsCompleted = (reader.IsDBNull(((int)DieStatusColumn.IsCompleted - 1)))?null:(System.Boolean?)reader[((int)DieStatusColumn.IsCompleted - 1)];
			entity.Color = (reader.IsDBNull(((int)DieStatusColumn.Color - 1)))?null:(System.String)reader[((int)DieStatusColumn.Color - 1)];
			entity.ColorName = (reader.IsDBNull(((int)DieStatusColumn.ColorName - 1)))?null:(System.String)reader[((int)DieStatusColumn.ColorName - 1)];
			entity.ProjectId = (reader.IsDBNull(((int)DieStatusColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)DieStatusColumn.ProjectId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieStatus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieStatus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.DieStatus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieStatus = (System.Int32)dataRow["DIEStatus"];
			entity.DieNameStatus = Convert.IsDBNull(dataRow["DIENameStatus"]) ? null : (System.String)dataRow["DIENameStatus"];
			entity.Order = Convert.IsDBNull(dataRow["Order"]) ? null : (System.Int32?)dataRow["Order"];
			entity.Visible = Convert.IsDBNull(dataRow["Visible"]) ? null : (System.Boolean?)dataRow["Visible"];
			entity.Selected = Convert.IsDBNull(dataRow["Selected"]) ? null : (System.Boolean?)dataRow["Selected"];
			entity.IsDefault = Convert.IsDBNull(dataRow["IsDefault"]) ? null : (System.Boolean?)dataRow["IsDefault"];
			entity.IconLink = Convert.IsDBNull(dataRow["IconLink"]) ? null : (System.String)dataRow["IconLink"];
			entity.IsCompleted = Convert.IsDBNull(dataRow["IsCompleted"]) ? null : (System.Boolean?)dataRow["IsCompleted"];
			entity.Color = Convert.IsDBNull(dataRow["Color"]) ? null : (System.String)dataRow["Color"];
			entity.ColorName = Convert.IsDBNull(dataRow["ColorName"]) ? null : (System.String)dataRow["ColorName"];
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
		/// <param name="entity">The <see cref="Agile.Entities.DieStatus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.DieStatus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.DieStatus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDieStatus methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByDieStatus(transactionManager, entity.DieStatus);

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
		/// Deep Save the entire object graph of the Agile.Entities.DieStatus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.DieStatus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.DieStatus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.DieStatus entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.DieStatusSource != null)
						{
							child.DieStatus = child.DieStatusSource.DieStatus;
						}
						else
						{
							child.DieStatus = entity.DieStatus;
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
	
	#region DieStatusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.DieStatus</c>
	///</summary>
	public enum DieStatusChildEntityTypes
	{

		///<summary>
		/// Collection of <c>DieStatus</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion DieStatusChildEntityTypes
	
	#region DieStatusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DieStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusFilterBuilder : SqlFilterBuilder<DieStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusFilterBuilder class.
		/// </summary>
		public DieStatusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieStatusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieStatusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieStatusFilterBuilder
	
	#region DieStatusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DieStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieStatusParameterBuilder : ParameterizedSqlFilterBuilder<DieStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusParameterBuilder class.
		/// </summary>
		public DieStatusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieStatusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieStatusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieStatusParameterBuilder
	
	#region DieStatusSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DieStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieStatus"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DieStatusSortBuilder : SqlSortBuilder<DieStatusColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieStatusSqlSortBuilder class.
		/// </summary>
		public DieStatusSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DieStatusSortBuilder
	
} // end namespace
