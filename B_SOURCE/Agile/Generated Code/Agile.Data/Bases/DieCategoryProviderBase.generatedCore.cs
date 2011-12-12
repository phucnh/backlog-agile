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
	/// This class is the base class for any <see cref="DieCategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieCategoryProviderBaseCore : EntityProviderBase<Agile.Entities.DieCategory, Agile.Entities.DieCategoryKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.DieCategoryKey key)
		{
			return Delete(transactionManager, key.DieCategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieCategoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dieCategoryId)
		{
			return Delete(null, _dieCategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dieCategoryId);		
		
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
		public override Agile.Entities.DieCategory Get(TransactionManager transactionManager, Agile.Entities.DieCategoryKey key, int start, int pageLength)
		{
			return GetByDieCategoryId(transactionManager, key.DieCategoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDIECategory index.
		/// </summary>
		/// <param name="_dieCategoryId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieCategory"/> class.</returns>
		public Agile.Entities.DieCategory GetByDieCategoryId(System.Int32 _dieCategoryId)
		{
			int count = -1;
			return GetByDieCategoryId(null,_dieCategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIECategory index.
		/// </summary>
		/// <param name="_dieCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieCategory"/> class.</returns>
		public Agile.Entities.DieCategory GetByDieCategoryId(System.Int32 _dieCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieCategoryId(null, _dieCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIECategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieCategory"/> class.</returns>
		public Agile.Entities.DieCategory GetByDieCategoryId(TransactionManager transactionManager, System.Int32 _dieCategoryId)
		{
			int count = -1;
			return GetByDieCategoryId(transactionManager, _dieCategoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIECategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieCategory"/> class.</returns>
		public Agile.Entities.DieCategory GetByDieCategoryId(TransactionManager transactionManager, System.Int32 _dieCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieCategoryId(transactionManager, _dieCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIECategory index.
		/// </summary>
		/// <param name="_dieCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieCategory"/> class.</returns>
		public Agile.Entities.DieCategory GetByDieCategoryId(System.Int32 _dieCategoryId, int start, int pageLength, out int count)
		{
			return GetByDieCategoryId(null, _dieCategoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIECategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieCategory"/> class.</returns>
		public abstract Agile.Entities.DieCategory GetByDieCategoryId(TransactionManager transactionManager, System.Int32 _dieCategoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DieCategory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DieCategory&gt;"/></returns>
		public static TList<DieCategory> Fill(IDataReader reader, TList<DieCategory> rows, int start, int pageLength)
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
				
				Agile.Entities.DieCategory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DieCategory")
					.Append("|").Append((System.Int32)reader[((int)DieCategoryColumn.DieCategoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DieCategory>(
					key.ToString(), // EntityTrackingKey
					"DieCategory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.DieCategory();
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
					c.DieCategoryId = (System.Int32)reader[((int)DieCategoryColumn.DieCategoryId - 1)];
					c.DieCategoryName = (reader.IsDBNull(((int)DieCategoryColumn.DieCategoryName - 1)))?null:(System.String)reader[((int)DieCategoryColumn.DieCategoryName - 1)];
					c.DeiCategoryDescription = (reader.IsDBNull(((int)DieCategoryColumn.DeiCategoryDescription - 1)))?null:(System.String)reader[((int)DieCategoryColumn.DeiCategoryDescription - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieCategory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieCategory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.DieCategory entity)
		{
			if (!reader.Read()) return;
			
			entity.DieCategoryId = (System.Int32)reader[((int)DieCategoryColumn.DieCategoryId - 1)];
			entity.DieCategoryName = (reader.IsDBNull(((int)DieCategoryColumn.DieCategoryName - 1)))?null:(System.String)reader[((int)DieCategoryColumn.DieCategoryName - 1)];
			entity.DeiCategoryDescription = (reader.IsDBNull(((int)DieCategoryColumn.DeiCategoryDescription - 1)))?null:(System.String)reader[((int)DieCategoryColumn.DeiCategoryDescription - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieCategory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieCategory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.DieCategory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieCategoryId = (System.Int32)dataRow["DIECategoryID"];
			entity.DieCategoryName = Convert.IsDBNull(dataRow["DIECategoryName"]) ? null : (System.String)dataRow["DIECategoryName"];
			entity.DeiCategoryDescription = Convert.IsDBNull(dataRow["DEICategoryDescription"]) ? null : (System.String)dataRow["DEICategoryDescription"];
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
		/// <param name="entity">The <see cref="Agile.Entities.DieCategory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.DieCategory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.DieCategory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDieCategoryId methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByDieCategoryId(transactionManager, entity.DieCategoryId);

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
		/// Deep Save the entire object graph of the Agile.Entities.DieCategory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.DieCategory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.DieCategory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.DieCategory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.DieCategoryIdSource != null)
						{
							child.DieCategoryId = child.DieCategoryIdSource.DieCategoryId;
						}
						else
						{
							child.DieCategoryId = entity.DieCategoryId;
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
	
	#region DieCategoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.DieCategory</c>
	///</summary>
	public enum DieCategoryChildEntityTypes
	{

		///<summary>
		/// Collection of <c>DieCategory</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion DieCategoryChildEntityTypes
	
	#region DieCategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DieCategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryFilterBuilder : SqlFilterBuilder<DieCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategoryFilterBuilder class.
		/// </summary>
		public DieCategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieCategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieCategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieCategoryFilterBuilder
	
	#region DieCategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DieCategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieCategoryParameterBuilder : ParameterizedSqlFilterBuilder<DieCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategoryParameterBuilder class.
		/// </summary>
		public DieCategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieCategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieCategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieCategoryParameterBuilder
	
	#region DieCategorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DieCategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieCategory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DieCategorySortBuilder : SqlSortBuilder<DieCategoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieCategorySqlSortBuilder class.
		/// </summary>
		public DieCategorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DieCategorySortBuilder
	
} // end namespace
