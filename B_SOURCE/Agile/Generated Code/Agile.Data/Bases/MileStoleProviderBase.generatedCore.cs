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
	/// This class is the base class for any <see cref="MileStoleProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MileStoleProviderBaseCore : EntityProviderBase<Agile.Entities.MileStole, Agile.Entities.MileStoleKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.MileStoleKey key)
		{
			return Delete(transactionManager, key.MileStoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_mileStoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _mileStoleId)
		{
			return Delete(null, _mileStoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mileStoleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _mileStoleId);		
		
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
		public override Agile.Entities.MileStole Get(TransactionManager transactionManager, Agile.Entities.MileStoleKey key, int start, int pageLength)
		{
			return GetByMileStoleId(transactionManager, key.MileStoleId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblMileStole index.
		/// </summary>
		/// <param name="_mileStoleId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.MileStole"/> class.</returns>
		public Agile.Entities.MileStole GetByMileStoleId(System.Int32 _mileStoleId)
		{
			int count = -1;
			return GetByMileStoleId(null,_mileStoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblMileStole index.
		/// </summary>
		/// <param name="_mileStoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.MileStole"/> class.</returns>
		public Agile.Entities.MileStole GetByMileStoleId(System.Int32 _mileStoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByMileStoleId(null, _mileStoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblMileStole index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mileStoleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.MileStole"/> class.</returns>
		public Agile.Entities.MileStole GetByMileStoleId(TransactionManager transactionManager, System.Int32 _mileStoleId)
		{
			int count = -1;
			return GetByMileStoleId(transactionManager, _mileStoleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblMileStole index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mileStoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.MileStole"/> class.</returns>
		public Agile.Entities.MileStole GetByMileStoleId(TransactionManager transactionManager, System.Int32 _mileStoleId, int start, int pageLength)
		{
			int count = -1;
			return GetByMileStoleId(transactionManager, _mileStoleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblMileStole index.
		/// </summary>
		/// <param name="_mileStoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.MileStole"/> class.</returns>
		public Agile.Entities.MileStole GetByMileStoleId(System.Int32 _mileStoleId, int start, int pageLength, out int count)
		{
			return GetByMileStoleId(null, _mileStoleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblMileStole index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_mileStoleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.MileStole"/> class.</returns>
		public abstract Agile.Entities.MileStole GetByMileStoleId(TransactionManager transactionManager, System.Int32 _mileStoleId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MileStole&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MileStole&gt;"/></returns>
		public static TList<MileStole> Fill(IDataReader reader, TList<MileStole> rows, int start, int pageLength)
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
				
				Agile.Entities.MileStole c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MileStole")
					.Append("|").Append((System.Int32)reader[((int)MileStoleColumn.MileStoleId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MileStole>(
					key.ToString(), // EntityTrackingKey
					"MileStole",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.MileStole();
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
					c.MileStoleId = (System.Int32)reader[((int)MileStoleColumn.MileStoleId - 1)];
					c.MileStoleName = (reader.IsDBNull(((int)MileStoleColumn.MileStoleName - 1)))?null:(System.String)reader[((int)MileStoleColumn.MileStoleName - 1)];
					c.OriginalDueDate = (reader.IsDBNull(((int)MileStoleColumn.OriginalDueDate - 1)))?null:(System.DateTime?)reader[((int)MileStoleColumn.OriginalDueDate - 1)];
					c.RevisedDueDate = (reader.IsDBNull(((int)MileStoleColumn.RevisedDueDate - 1)))?null:(System.DateTime?)reader[((int)MileStoleColumn.RevisedDueDate - 1)];
					c.CompleteDate = (reader.IsDBNull(((int)MileStoleColumn.CompleteDate - 1)))?null:(System.DateTime?)reader[((int)MileStoleColumn.CompleteDate - 1)];
					c.Progress = (reader.IsDBNull(((int)MileStoleColumn.Progress - 1)))?null:(System.Double?)reader[((int)MileStoleColumn.Progress - 1)];
					c.ProjectId = (reader.IsDBNull(((int)MileStoleColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)MileStoleColumn.ProjectId - 1)];
					c.Enabled = (reader.IsDBNull(((int)MileStoleColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)MileStoleColumn.Enabled - 1)];
					c.MileStoleOrder = (reader.IsDBNull(((int)MileStoleColumn.MileStoleOrder - 1)))?null:(System.Int32?)reader[((int)MileStoleColumn.MileStoleOrder - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.MileStole"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.MileStole"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.MileStole entity)
		{
			if (!reader.Read()) return;
			
			entity.MileStoleId = (System.Int32)reader[((int)MileStoleColumn.MileStoleId - 1)];
			entity.MileStoleName = (reader.IsDBNull(((int)MileStoleColumn.MileStoleName - 1)))?null:(System.String)reader[((int)MileStoleColumn.MileStoleName - 1)];
			entity.OriginalDueDate = (reader.IsDBNull(((int)MileStoleColumn.OriginalDueDate - 1)))?null:(System.DateTime?)reader[((int)MileStoleColumn.OriginalDueDate - 1)];
			entity.RevisedDueDate = (reader.IsDBNull(((int)MileStoleColumn.RevisedDueDate - 1)))?null:(System.DateTime?)reader[((int)MileStoleColumn.RevisedDueDate - 1)];
			entity.CompleteDate = (reader.IsDBNull(((int)MileStoleColumn.CompleteDate - 1)))?null:(System.DateTime?)reader[((int)MileStoleColumn.CompleteDate - 1)];
			entity.Progress = (reader.IsDBNull(((int)MileStoleColumn.Progress - 1)))?null:(System.Double?)reader[((int)MileStoleColumn.Progress - 1)];
			entity.ProjectId = (reader.IsDBNull(((int)MileStoleColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)MileStoleColumn.ProjectId - 1)];
			entity.Enabled = (reader.IsDBNull(((int)MileStoleColumn.Enabled - 1)))?null:(System.Boolean?)reader[((int)MileStoleColumn.Enabled - 1)];
			entity.MileStoleOrder = (reader.IsDBNull(((int)MileStoleColumn.MileStoleOrder - 1)))?null:(System.Int32?)reader[((int)MileStoleColumn.MileStoleOrder - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.MileStole"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.MileStole"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.MileStole entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MileStoleId = (System.Int32)dataRow["MileStoleID"];
			entity.MileStoleName = Convert.IsDBNull(dataRow["MileStoleName"]) ? null : (System.String)dataRow["MileStoleName"];
			entity.OriginalDueDate = Convert.IsDBNull(dataRow["OriginalDueDate"]) ? null : (System.DateTime?)dataRow["OriginalDueDate"];
			entity.RevisedDueDate = Convert.IsDBNull(dataRow["RevisedDueDate"]) ? null : (System.DateTime?)dataRow["RevisedDueDate"];
			entity.CompleteDate = Convert.IsDBNull(dataRow["CompleteDate"]) ? null : (System.DateTime?)dataRow["CompleteDate"];
			entity.Progress = Convert.IsDBNull(dataRow["Progress"]) ? null : (System.Double?)dataRow["Progress"];
			entity.ProjectId = Convert.IsDBNull(dataRow["ProjectID"]) ? null : (System.Int32?)dataRow["ProjectID"];
			entity.Enabled = Convert.IsDBNull(dataRow["Enabled"]) ? null : (System.Boolean?)dataRow["Enabled"];
			entity.MileStoleOrder = Convert.IsDBNull(dataRow["MileStoleOrder"]) ? null : (System.Int32?)dataRow["MileStoleOrder"];
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
		/// <param name="entity">The <see cref="Agile.Entities.MileStole"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.MileStole Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.MileStole entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByMileStoleId methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByMilestoneId(transactionManager, entity.MileStoleId);

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
		/// Deep Save the entire object graph of the Agile.Entities.MileStole object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.MileStole instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.MileStole Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.MileStole entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.MilestoneIdSource != null)
						{
							child.MilestoneId = child.MilestoneIdSource.MileStoleId;
						}
						else
						{
							child.MilestoneId = entity.MileStoleId;
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
	
	#region MileStoleChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.MileStole</c>
	///</summary>
	public enum MileStoleChildEntityTypes
	{

		///<summary>
		/// Collection of <c>MileStole</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion MileStoleChildEntityTypes
	
	#region MileStoleFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MileStoleColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MileStole"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MileStoleFilterBuilder : SqlFilterBuilder<MileStoleColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MileStoleFilterBuilder class.
		/// </summary>
		public MileStoleFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MileStoleFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MileStoleFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MileStoleFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MileStoleFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MileStoleFilterBuilder
	
	#region MileStoleParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MileStoleColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MileStole"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MileStoleParameterBuilder : ParameterizedSqlFilterBuilder<MileStoleColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MileStoleParameterBuilder class.
		/// </summary>
		public MileStoleParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MileStoleParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MileStoleParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MileStoleParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MileStoleParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MileStoleParameterBuilder
	
	#region MileStoleSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MileStoleColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MileStole"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MileStoleSortBuilder : SqlSortBuilder<MileStoleColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MileStoleSqlSortBuilder class.
		/// </summary>
		public MileStoleSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MileStoleSortBuilder
	
} // end namespace
