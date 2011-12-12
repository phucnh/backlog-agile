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
	/// This class is the base class for any <see cref="ReleaseProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ReleaseProviderBaseCore : EntityProviderBase<Agile.Entities.Release, Agile.Entities.ReleaseKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.ReleaseKey key)
		{
			return Delete(transactionManager, key.ReleaseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_releaseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _releaseId)
		{
			return Delete(null, _releaseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_releaseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _releaseId);		
		
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
		public override Agile.Entities.Release Get(TransactionManager transactionManager, Agile.Entities.ReleaseKey key, int start, int pageLength)
		{
			return GetByReleaseId(transactionManager, key.ReleaseId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblRelease index.
		/// </summary>
		/// <param name="_releaseId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Release"/> class.</returns>
		public Agile.Entities.Release GetByReleaseId(System.Int32 _releaseId)
		{
			int count = -1;
			return GetByReleaseId(null,_releaseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblRelease index.
		/// </summary>
		/// <param name="_releaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Release"/> class.</returns>
		public Agile.Entities.Release GetByReleaseId(System.Int32 _releaseId, int start, int pageLength)
		{
			int count = -1;
			return GetByReleaseId(null, _releaseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblRelease index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_releaseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Release"/> class.</returns>
		public Agile.Entities.Release GetByReleaseId(TransactionManager transactionManager, System.Int32 _releaseId)
		{
			int count = -1;
			return GetByReleaseId(transactionManager, _releaseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblRelease index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_releaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Release"/> class.</returns>
		public Agile.Entities.Release GetByReleaseId(TransactionManager transactionManager, System.Int32 _releaseId, int start, int pageLength)
		{
			int count = -1;
			return GetByReleaseId(transactionManager, _releaseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblRelease index.
		/// </summary>
		/// <param name="_releaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Release"/> class.</returns>
		public Agile.Entities.Release GetByReleaseId(System.Int32 _releaseId, int start, int pageLength, out int count)
		{
			return GetByReleaseId(null, _releaseId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblRelease index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_releaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Release"/> class.</returns>
		public abstract Agile.Entities.Release GetByReleaseId(TransactionManager transactionManager, System.Int32 _releaseId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Release&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Release&gt;"/></returns>
		public static TList<Release> Fill(IDataReader reader, TList<Release> rows, int start, int pageLength)
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
				
				Agile.Entities.Release c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Release")
					.Append("|").Append((System.Int32)reader[((int)ReleaseColumn.ReleaseId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Release>(
					key.ToString(), // EntityTrackingKey
					"Release",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.Release();
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
					c.ReleaseId = (System.Int32)reader[((int)ReleaseColumn.ReleaseId - 1)];
					c.ProjectId = (System.Int32)reader[((int)ReleaseColumn.ProjectId - 1)];
					c.ReleaseDate = (System.DateTime)reader[((int)ReleaseColumn.ReleaseDate - 1)];
					c.ReleaseName = (reader.IsDBNull(((int)ReleaseColumn.ReleaseName - 1)))?null:(System.String)reader[((int)ReleaseColumn.ReleaseName - 1)];
					c.ReleaseNote = (reader.IsDBNull(((int)ReleaseColumn.ReleaseNote - 1)))?null:(System.String)reader[((int)ReleaseColumn.ReleaseNote - 1)];
					c.Active = (reader.IsDBNull(((int)ReleaseColumn.Active - 1)))?null:(System.Boolean?)reader[((int)ReleaseColumn.Active - 1)];
					c.UserId = (reader.IsDBNull(((int)ReleaseColumn.UserId - 1)))?null:(System.Int32?)reader[((int)ReleaseColumn.UserId - 1)];
					c.LastUserUpdate = (reader.IsDBNull(((int)ReleaseColumn.LastUserUpdate - 1)))?null:(System.Int32?)reader[((int)ReleaseColumn.LastUserUpdate - 1)];
					c.LastDateUpdate = (reader.IsDBNull(((int)ReleaseColumn.LastDateUpdate - 1)))?null:(System.DateTime?)reader[((int)ReleaseColumn.LastDateUpdate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.Release"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.Release"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.Release entity)
		{
			if (!reader.Read()) return;
			
			entity.ReleaseId = (System.Int32)reader[((int)ReleaseColumn.ReleaseId - 1)];
			entity.ProjectId = (System.Int32)reader[((int)ReleaseColumn.ProjectId - 1)];
			entity.ReleaseDate = (System.DateTime)reader[((int)ReleaseColumn.ReleaseDate - 1)];
			entity.ReleaseName = (reader.IsDBNull(((int)ReleaseColumn.ReleaseName - 1)))?null:(System.String)reader[((int)ReleaseColumn.ReleaseName - 1)];
			entity.ReleaseNote = (reader.IsDBNull(((int)ReleaseColumn.ReleaseNote - 1)))?null:(System.String)reader[((int)ReleaseColumn.ReleaseNote - 1)];
			entity.Active = (reader.IsDBNull(((int)ReleaseColumn.Active - 1)))?null:(System.Boolean?)reader[((int)ReleaseColumn.Active - 1)];
			entity.UserId = (reader.IsDBNull(((int)ReleaseColumn.UserId - 1)))?null:(System.Int32?)reader[((int)ReleaseColumn.UserId - 1)];
			entity.LastUserUpdate = (reader.IsDBNull(((int)ReleaseColumn.LastUserUpdate - 1)))?null:(System.Int32?)reader[((int)ReleaseColumn.LastUserUpdate - 1)];
			entity.LastDateUpdate = (reader.IsDBNull(((int)ReleaseColumn.LastDateUpdate - 1)))?null:(System.DateTime?)reader[((int)ReleaseColumn.LastDateUpdate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.Release"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.Release"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.Release entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ReleaseId = (System.Int32)dataRow["ReleaseID"];
			entity.ProjectId = (System.Int32)dataRow["ProjectID"];
			entity.ReleaseDate = (System.DateTime)dataRow["ReleaseDate"];
			entity.ReleaseName = Convert.IsDBNull(dataRow["ReleaseName"]) ? null : (System.String)dataRow["ReleaseName"];
			entity.ReleaseNote = Convert.IsDBNull(dataRow["ReleaseNote"]) ? null : (System.String)dataRow["ReleaseNote"];
			entity.Active = Convert.IsDBNull(dataRow["Active"]) ? null : (System.Boolean?)dataRow["Active"];
			entity.UserId = Convert.IsDBNull(dataRow["UserID"]) ? null : (System.Int32?)dataRow["UserID"];
			entity.LastUserUpdate = Convert.IsDBNull(dataRow["LastUserUpdate"]) ? null : (System.Int32?)dataRow["LastUserUpdate"];
			entity.LastDateUpdate = Convert.IsDBNull(dataRow["LastDateUpdate"]) ? null : (System.DateTime?)dataRow["LastDateUpdate"];
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
		/// <param name="entity">The <see cref="Agile.Entities.Release"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.Release Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.Release entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByReleaseId methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByCompletedReleaseId(transactionManager, entity.ReleaseId);

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
		/// Deep Save the entire object graph of the Agile.Entities.Release object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.Release instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.Release Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.Release entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.CompletedReleaseIdSource != null)
						{
							child.CompletedReleaseId = child.CompletedReleaseIdSource.ReleaseId;
						}
						else
						{
							child.CompletedReleaseId = entity.ReleaseId;
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
	
	#region ReleaseChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.Release</c>
	///</summary>
	public enum ReleaseChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Release</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion ReleaseChildEntityTypes
	
	#region ReleaseFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ReleaseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseFilterBuilder : SqlFilterBuilder<ReleaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseFilterBuilder class.
		/// </summary>
		public ReleaseFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReleaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReleaseFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReleaseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReleaseFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReleaseFilterBuilder
	
	#region ReleaseParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ReleaseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ReleaseParameterBuilder : ParameterizedSqlFilterBuilder<ReleaseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseParameterBuilder class.
		/// </summary>
		public ReleaseParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ReleaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ReleaseParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ReleaseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ReleaseParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ReleaseParameterBuilder
	
	#region ReleaseSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ReleaseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Release"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ReleaseSortBuilder : SqlSortBuilder<ReleaseColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReleaseSqlSortBuilder class.
		/// </summary>
		public ReleaseSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ReleaseSortBuilder
	
} // end namespace
