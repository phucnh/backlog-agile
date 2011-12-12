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
	/// This class is the base class for any <see cref="DieAttachFileProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieAttachFileProviderBaseCore : EntityProviderBase<Agile.Entities.DieAttachFile, Agile.Entities.DieAttachFileKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.DieAttachFileKey key)
		{
			return Delete(transactionManager, key.DieAttachFileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieAttachFileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dieAttachFileId)
		{
			return Delete(null, _dieAttachFileId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieAttachFileId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dieAttachFileId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIEAttachFile_tblDIERequest key.
		///		FK_tblDIEAttachFile_tblDIERequest Description: 
		/// </summary>
		/// <param name="_dieRequestId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieAttachFile objects.</returns>
		public TList<DieAttachFile> GetByDieRequestId(System.Int32 _dieRequestId)
		{
			int count = -1;
			return GetByDieRequestId(_dieRequestId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIEAttachFile_tblDIERequest key.
		///		FK_tblDIEAttachFile_tblDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieAttachFile objects.</returns>
		/// <remarks></remarks>
		public TList<DieAttachFile> GetByDieRequestId(TransactionManager transactionManager, System.Int32 _dieRequestId)
		{
			int count = -1;
			return GetByDieRequestId(transactionManager, _dieRequestId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIEAttachFile_tblDIERequest key.
		///		FK_tblDIEAttachFile_tblDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieAttachFile objects.</returns>
		public TList<DieAttachFile> GetByDieRequestId(TransactionManager transactionManager, System.Int32 _dieRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieRequestId(transactionManager, _dieRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIEAttachFile_tblDIERequest key.
		///		fkTblDieAttachFileTblDieRequest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieRequestId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieAttachFile objects.</returns>
		public TList<DieAttachFile> GetByDieRequestId(System.Int32 _dieRequestId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDieRequestId(null, _dieRequestId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIEAttachFile_tblDIERequest key.
		///		fkTblDieAttachFileTblDieRequest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieRequestId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieAttachFile objects.</returns>
		public TList<DieAttachFile> GetByDieRequestId(System.Int32 _dieRequestId, int start, int pageLength,out int count)
		{
			return GetByDieRequestId(null, _dieRequestId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIEAttachFile_tblDIERequest key.
		///		FK_tblDIEAttachFile_tblDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieAttachFile objects.</returns>
		public abstract TList<DieAttachFile> GetByDieRequestId(TransactionManager transactionManager, System.Int32 _dieRequestId, int start, int pageLength, out int count);
		
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
		public override Agile.Entities.DieAttachFile Get(TransactionManager transactionManager, Agile.Entities.DieAttachFileKey key, int start, int pageLength)
		{
			return GetByDieAttachFileId(transactionManager, key.DieAttachFileId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDIEAttachFile index.
		/// </summary>
		/// <param name="_dieAttachFileId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieAttachFile"/> class.</returns>
		public Agile.Entities.DieAttachFile GetByDieAttachFileId(System.Int32 _dieAttachFileId)
		{
			int count = -1;
			return GetByDieAttachFileId(null,_dieAttachFileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEAttachFile index.
		/// </summary>
		/// <param name="_dieAttachFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieAttachFile"/> class.</returns>
		public Agile.Entities.DieAttachFile GetByDieAttachFileId(System.Int32 _dieAttachFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieAttachFileId(null, _dieAttachFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEAttachFile index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieAttachFileId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieAttachFile"/> class.</returns>
		public Agile.Entities.DieAttachFile GetByDieAttachFileId(TransactionManager transactionManager, System.Int32 _dieAttachFileId)
		{
			int count = -1;
			return GetByDieAttachFileId(transactionManager, _dieAttachFileId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEAttachFile index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieAttachFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieAttachFile"/> class.</returns>
		public Agile.Entities.DieAttachFile GetByDieAttachFileId(TransactionManager transactionManager, System.Int32 _dieAttachFileId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieAttachFileId(transactionManager, _dieAttachFileId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEAttachFile index.
		/// </summary>
		/// <param name="_dieAttachFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieAttachFile"/> class.</returns>
		public Agile.Entities.DieAttachFile GetByDieAttachFileId(System.Int32 _dieAttachFileId, int start, int pageLength, out int count)
		{
			return GetByDieAttachFileId(null, _dieAttachFileId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIEAttachFile index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieAttachFileId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieAttachFile"/> class.</returns>
		public abstract Agile.Entities.DieAttachFile GetByDieAttachFileId(TransactionManager transactionManager, System.Int32 _dieAttachFileId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DieAttachFile&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DieAttachFile&gt;"/></returns>
		public static TList<DieAttachFile> Fill(IDataReader reader, TList<DieAttachFile> rows, int start, int pageLength)
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
				
				Agile.Entities.DieAttachFile c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DieAttachFile")
					.Append("|").Append((System.Int32)reader[((int)DieAttachFileColumn.DieAttachFileId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DieAttachFile>(
					key.ToString(), // EntityTrackingKey
					"DieAttachFile",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.DieAttachFile();
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
					c.DieAttachFileId = (System.Int32)reader[((int)DieAttachFileColumn.DieAttachFileId - 1)];
					c.DieRequestId = (System.Int32)reader[((int)DieAttachFileColumn.DieRequestId - 1)];
					c.DieFileName = (System.String)reader[((int)DieAttachFileColumn.DieFileName - 1)];
					c.DieFileUrl = (reader.IsDBNull(((int)DieAttachFileColumn.DieFileUrl - 1)))?null:(System.String)reader[((int)DieAttachFileColumn.DieFileUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieAttachFile"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieAttachFile"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.DieAttachFile entity)
		{
			if (!reader.Read()) return;
			
			entity.DieAttachFileId = (System.Int32)reader[((int)DieAttachFileColumn.DieAttachFileId - 1)];
			entity.DieRequestId = (System.Int32)reader[((int)DieAttachFileColumn.DieRequestId - 1)];
			entity.DieFileName = (System.String)reader[((int)DieAttachFileColumn.DieFileName - 1)];
			entity.DieFileUrl = (reader.IsDBNull(((int)DieAttachFileColumn.DieFileUrl - 1)))?null:(System.String)reader[((int)DieAttachFileColumn.DieFileUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieAttachFile"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieAttachFile"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.DieAttachFile entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieAttachFileId = (System.Int32)dataRow["DIEAttachFileID"];
			entity.DieRequestId = (System.Int32)dataRow["DIERequestID"];
			entity.DieFileName = (System.String)dataRow["DIEFileName"];
			entity.DieFileUrl = Convert.IsDBNull(dataRow["DIEFileUrl"]) ? null : (System.String)dataRow["DIEFileUrl"];
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
		/// <param name="entity">The <see cref="Agile.Entities.DieAttachFile"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.DieAttachFile Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.DieAttachFile entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DieRequestIdSource	
			if (CanDeepLoad(entity, "DieRequest|DieRequestIdSource", deepLoadType, innerList) 
				&& entity.DieRequestIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.DieRequestId;
				DieRequest tmpEntity = EntityManager.LocateEntity<DieRequest>(EntityLocator.ConstructKeyFromPkItems(typeof(DieRequest), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DieRequestIdSource = tmpEntity;
				else
					entity.DieRequestIdSource = DataRepository.DieRequestProvider.GetByDieRequestId(transactionManager, entity.DieRequestId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DieRequestIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DieRequestProvider.DeepLoad(transactionManager, entity.DieRequestIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DieRequestIdSource
			
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
		/// Deep Save the entire object graph of the Agile.Entities.DieAttachFile object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.DieAttachFile instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.DieAttachFile Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.DieAttachFile entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DieRequestIdSource
			if (CanDeepSave(entity, "DieRequest|DieRequestIdSource", deepSaveType, innerList) 
				&& entity.DieRequestIdSource != null)
			{
				DataRepository.DieRequestProvider.Save(transactionManager, entity.DieRequestIdSource);
				entity.DieRequestId = entity.DieRequestIdSource.DieRequestId;
			}
			#endregion 
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
	
	#region DieAttachFileChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.DieAttachFile</c>
	///</summary>
	public enum DieAttachFileChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>DieRequest</c> at DieRequestIdSource
		///</summary>
		[ChildEntityType(typeof(DieRequest))]
		DieRequest,
		}
	
	#endregion DieAttachFileChildEntityTypes
	
	#region DieAttachFileFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DieAttachFileColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileFilterBuilder : SqlFilterBuilder<DieAttachFileColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileFilterBuilder class.
		/// </summary>
		public DieAttachFileFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieAttachFileFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieAttachFileFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieAttachFileFilterBuilder
	
	#region DieAttachFileParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DieAttachFileColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieAttachFileParameterBuilder : ParameterizedSqlFilterBuilder<DieAttachFileColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileParameterBuilder class.
		/// </summary>
		public DieAttachFileParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieAttachFileParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieAttachFileParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieAttachFileParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieAttachFileParameterBuilder
	
	#region DieAttachFileSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DieAttachFileColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieAttachFile"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DieAttachFileSortBuilder : SqlSortBuilder<DieAttachFileColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieAttachFileSqlSortBuilder class.
		/// </summary>
		public DieAttachFileSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DieAttachFileSortBuilder
	
} // end namespace
