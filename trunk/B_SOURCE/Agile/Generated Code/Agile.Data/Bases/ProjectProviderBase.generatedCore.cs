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
	/// This class is the base class for any <see cref="ProjectProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProjectProviderBaseCore : EntityProviderBase<Agile.Entities.Project, Agile.Entities.ProjectKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.ProjectKey key)
		{
			return Delete(transactionManager, key.ProjectId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_projectId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _projectId)
		{
			return Delete(null, _projectId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _projectId);		
		
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
		public override Agile.Entities.Project Get(TransactionManager transactionManager, Agile.Entities.ProjectKey key, int start, int pageLength)
		{
			return GetByProjectId(transactionManager, key.ProjectId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblProject index.
		/// </summary>
		/// <param name="_projectId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Project"/> class.</returns>
		public Agile.Entities.Project GetByProjectId(System.Int32 _projectId)
		{
			int count = -1;
			return GetByProjectId(null,_projectId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblProject index.
		/// </summary>
		/// <param name="_projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Project"/> class.</returns>
		public Agile.Entities.Project GetByProjectId(System.Int32 _projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(null, _projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblProject index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Project"/> class.</returns>
		public Agile.Entities.Project GetByProjectId(TransactionManager transactionManager, System.Int32 _projectId)
		{
			int count = -1;
			return GetByProjectId(transactionManager, _projectId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblProject index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Project"/> class.</returns>
		public Agile.Entities.Project GetByProjectId(TransactionManager transactionManager, System.Int32 _projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(transactionManager, _projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblProject index.
		/// </summary>
		/// <param name="_projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Project"/> class.</returns>
		public Agile.Entities.Project GetByProjectId(System.Int32 _projectId, int start, int pageLength, out int count)
		{
			return GetByProjectId(null, _projectId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblProject index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.Project"/> class.</returns>
		public abstract Agile.Entities.Project GetByProjectId(TransactionManager transactionManager, System.Int32 _projectId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Project&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Project&gt;"/></returns>
		public static TList<Project> Fill(IDataReader reader, TList<Project> rows, int start, int pageLength)
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
				
				Agile.Entities.Project c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Project")
					.Append("|").Append((System.Int32)reader[((int)ProjectColumn.ProjectId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Project>(
					key.ToString(), // EntityTrackingKey
					"Project",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.Project();
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
					c.ProjectId = (System.Int32)reader[((int)ProjectColumn.ProjectId - 1)];
					c.ProjectName = (reader.IsDBNull(((int)ProjectColumn.ProjectName - 1)))?null:(System.String)reader[((int)ProjectColumn.ProjectName - 1)];
					c.StartDate = (System.DateTime)reader[((int)ProjectColumn.StartDate - 1)];
					c.Deadline = (System.DateTime)reader[((int)ProjectColumn.Deadline - 1)];
					c.Description = (reader.IsDBNull(((int)ProjectColumn.Description - 1)))?null:(System.String)reader[((int)ProjectColumn.Description - 1)];
					c.Active = (reader.IsDBNull(((int)ProjectColumn.Active - 1)))?null:(System.Boolean?)reader[((int)ProjectColumn.Active - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.Project"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.Project"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.Project entity)
		{
			if (!reader.Read()) return;
			
			entity.ProjectId = (System.Int32)reader[((int)ProjectColumn.ProjectId - 1)];
			entity.ProjectName = (reader.IsDBNull(((int)ProjectColumn.ProjectName - 1)))?null:(System.String)reader[((int)ProjectColumn.ProjectName - 1)];
			entity.StartDate = (System.DateTime)reader[((int)ProjectColumn.StartDate - 1)];
			entity.Deadline = (System.DateTime)reader[((int)ProjectColumn.Deadline - 1)];
			entity.Description = (reader.IsDBNull(((int)ProjectColumn.Description - 1)))?null:(System.String)reader[((int)ProjectColumn.Description - 1)];
			entity.Active = (reader.IsDBNull(((int)ProjectColumn.Active - 1)))?null:(System.Boolean?)reader[((int)ProjectColumn.Active - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.Project"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.Project"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.Project entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProjectId = (System.Int32)dataRow["ProjectID"];
			entity.ProjectName = Convert.IsDBNull(dataRow["ProjectName"]) ? null : (System.String)dataRow["ProjectName"];
			entity.StartDate = (System.DateTime)dataRow["StartDate"];
			entity.Deadline = (System.DateTime)dataRow["Deadline"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.Active = Convert.IsDBNull(dataRow["Active"]) ? null : (System.Boolean?)dataRow["Active"];
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
		/// <param name="entity">The <see cref="Agile.Entities.Project"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.Project Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.Project entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProjectId methods when available
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByProjectId(transactionManager, entity.ProjectId);

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
		/// Deep Save the entire object graph of the Agile.Entities.Project object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.Project instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.Project Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.Project entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.ProjectIdSource != null)
						{
							child.ProjectId = child.ProjectIdSource.ProjectId;
						}
						else
						{
							child.ProjectId = entity.ProjectId;
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
	
	#region ProjectChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.Project</c>
	///</summary>
	public enum ProjectChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Project</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion ProjectChildEntityTypes
	
	#region ProjectFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProjectColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectFilterBuilder : SqlFilterBuilder<ProjectColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectFilterBuilder class.
		/// </summary>
		public ProjectFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectFilterBuilder
	
	#region ProjectParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProjectColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProjectParameterBuilder : ParameterizedSqlFilterBuilder<ProjectColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectParameterBuilder class.
		/// </summary>
		public ProjectParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProjectParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProjectParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProjectParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProjectParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProjectParameterBuilder
	
	#region ProjectSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProjectColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Project"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProjectSortBuilder : SqlSortBuilder<ProjectColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProjectSqlSortBuilder class.
		/// </summary>
		public ProjectSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProjectSortBuilder
	
} // end namespace
