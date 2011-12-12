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
	/// This class is the base class for any <see cref="UserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UserProviderBaseCore : EntityProviderBase<Agile.Entities.User, Agile.Entities.UserKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.UserKey key)
		{
			return Delete(transactionManager, key.UserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _userId)
		{
			return Delete(null, _userId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _userId);		
		
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
		public override Agile.Entities.User Get(TransactionManager transactionManager, Agile.Entities.UserKey key, int start, int pageLength)
		{
			return GetByUserId(transactionManager, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_tblUser_Email index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserId(System.Int32 _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUser_Email index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserId(System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUser_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUser_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUser_Email index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserId(System.Int32 _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUser_Email index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public abstract Agile.Entities.User GetByUserId(TransactionManager transactionManager, System.Int32 _userId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_tblUsername index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserName(System.String _userName)
		{
			int count = -1;
			return GetByUserName(null,_userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUsername index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserName(System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUsername index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserName(TransactionManager transactionManager, System.String _userName)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUsername index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUsername index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public Agile.Entities.User GetByUserName(System.String _userName, int start, int pageLength, out int count)
		{
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_tblUsername index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.User"/> class.</returns>
		public abstract Agile.Entities.User GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;User&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;User&gt;"/></returns>
		public static TList<User> Fill(IDataReader reader, TList<User> rows, int start, int pageLength)
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
				
				Agile.Entities.User c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("User")
					.Append("|").Append((System.Int32)reader[((int)UserColumn.UserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<User>(
					key.ToString(), // EntityTrackingKey
					"User",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.User();
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
					c.UserId = (System.Int32)reader[((int)UserColumn.UserId - 1)];
					c.UserName = (System.String)reader[((int)UserColumn.UserName - 1)];
					c.PassWord = (System.String)reader[((int)UserColumn.PassWord - 1)];
					c.QlnsId = (reader.IsDBNull(((int)UserColumn.QlnsId - 1)))?null:(System.Int32?)reader[((int)UserColumn.QlnsId - 1)];
					c.Email = (reader.IsDBNull(((int)UserColumn.Email - 1)))?null:(System.String)reader[((int)UserColumn.Email - 1)];
					c.EmployeeName = (reader.IsDBNull(((int)UserColumn.EmployeeName - 1)))?null:(System.String)reader[((int)UserColumn.EmployeeName - 1)];
					c.Remove = (reader.IsDBNull(((int)UserColumn.Remove - 1)))?null:(System.Boolean?)reader[((int)UserColumn.Remove - 1)];
					c.IsLoginSystem = (reader.IsDBNull(((int)UserColumn.IsLoginSystem - 1)))?null:(System.Boolean?)reader[((int)UserColumn.IsLoginSystem - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)UserColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)UserColumn.UpdateDate - 1)];
					c.UserUpdate = (reader.IsDBNull(((int)UserColumn.UserUpdate - 1)))?null:(System.Int32?)reader[((int)UserColumn.UserUpdate - 1)];
					c.PageDefaultLogin = (reader.IsDBNull(((int)UserColumn.PageDefaultLogin - 1)))?null:(System.String)reader[((int)UserColumn.PageDefaultLogin - 1)];
					c.DateCreated = (reader.IsDBNull(((int)UserColumn.DateCreated - 1)))?null:(System.DateTime?)reader[((int)UserColumn.DateCreated - 1)];
					c.DateRemoved = (reader.IsDBNull(((int)UserColumn.DateRemoved - 1)))?null:(System.DateTime?)reader[((int)UserColumn.DateRemoved - 1)];
					c.IsNoBody = (reader.IsDBNull(((int)UserColumn.IsNoBody - 1)))?null:(System.Boolean?)reader[((int)UserColumn.IsNoBody - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.User"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.User"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.User entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Int32)reader[((int)UserColumn.UserId - 1)];
			entity.UserName = (System.String)reader[((int)UserColumn.UserName - 1)];
			entity.PassWord = (System.String)reader[((int)UserColumn.PassWord - 1)];
			entity.QlnsId = (reader.IsDBNull(((int)UserColumn.QlnsId - 1)))?null:(System.Int32?)reader[((int)UserColumn.QlnsId - 1)];
			entity.Email = (reader.IsDBNull(((int)UserColumn.Email - 1)))?null:(System.String)reader[((int)UserColumn.Email - 1)];
			entity.EmployeeName = (reader.IsDBNull(((int)UserColumn.EmployeeName - 1)))?null:(System.String)reader[((int)UserColumn.EmployeeName - 1)];
			entity.Remove = (reader.IsDBNull(((int)UserColumn.Remove - 1)))?null:(System.Boolean?)reader[((int)UserColumn.Remove - 1)];
			entity.IsLoginSystem = (reader.IsDBNull(((int)UserColumn.IsLoginSystem - 1)))?null:(System.Boolean?)reader[((int)UserColumn.IsLoginSystem - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)UserColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)UserColumn.UpdateDate - 1)];
			entity.UserUpdate = (reader.IsDBNull(((int)UserColumn.UserUpdate - 1)))?null:(System.Int32?)reader[((int)UserColumn.UserUpdate - 1)];
			entity.PageDefaultLogin = (reader.IsDBNull(((int)UserColumn.PageDefaultLogin - 1)))?null:(System.String)reader[((int)UserColumn.PageDefaultLogin - 1)];
			entity.DateCreated = (reader.IsDBNull(((int)UserColumn.DateCreated - 1)))?null:(System.DateTime?)reader[((int)UserColumn.DateCreated - 1)];
			entity.DateRemoved = (reader.IsDBNull(((int)UserColumn.DateRemoved - 1)))?null:(System.DateTime?)reader[((int)UserColumn.DateRemoved - 1)];
			entity.IsNoBody = (reader.IsDBNull(((int)UserColumn.IsNoBody - 1)))?null:(System.Boolean?)reader[((int)UserColumn.IsNoBody - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.User"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.User"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.User entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Int32)dataRow["UserID"];
			entity.UserName = (System.String)dataRow["UserName"];
			entity.PassWord = (System.String)dataRow["PassWord"];
			entity.QlnsId = Convert.IsDBNull(dataRow["QlnsID"]) ? null : (System.Int32?)dataRow["QlnsID"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.EmployeeName = Convert.IsDBNull(dataRow["EmployeeName"]) ? null : (System.String)dataRow["EmployeeName"];
			entity.Remove = Convert.IsDBNull(dataRow["Remove"]) ? null : (System.Boolean?)dataRow["Remove"];
			entity.IsLoginSystem = Convert.IsDBNull(dataRow["IsLoginSystem"]) ? null : (System.Boolean?)dataRow["IsLoginSystem"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.UserUpdate = Convert.IsDBNull(dataRow["UserUpdate"]) ? null : (System.Int32?)dataRow["UserUpdate"];
			entity.PageDefaultLogin = Convert.IsDBNull(dataRow["PageDefaultLogin"]) ? null : (System.String)dataRow["PageDefaultLogin"];
			entity.DateCreated = Convert.IsDBNull(dataRow["DateCreated"]) ? null : (System.DateTime?)dataRow["DateCreated"];
			entity.DateRemoved = Convert.IsDBNull(dataRow["DateRemoved"]) ? null : (System.DateTime?)dataRow["DateRemoved"];
			entity.IsNoBody = Convert.IsDBNull(dataRow["IsNoBody"]) ? null : (System.Boolean?)dataRow["IsNoBody"];
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
		/// <param name="entity">The <see cref="Agile.Entities.User"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.User Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.User entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByUserId methods when available
			
			#region DieRequestCollectionGetByUserId
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollectionGetByUserId", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollectionGetByUserId' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollectionGetByUserId = DataRepository.DieRequestProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.DieRequestCollectionGetByUserId.Count > 0)
				{
					deepHandles.Add("DieRequestCollectionGetByUserId",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DieRequest>) DataRepository.DieRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.DieRequestCollectionGetByUserId, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DieRequestCollectionGetByOwner
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollectionGetByOwner", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollectionGetByOwner' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollectionGetByOwner = DataRepository.DieRequestProvider.GetByOwner(transactionManager, entity.UserId);

				if (deep && entity.DieRequestCollectionGetByOwner.Count > 0)
				{
					deepHandles.Add("DieRequestCollectionGetByOwner",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DieRequest>) DataRepository.DieRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.DieRequestCollectionGetByOwner, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DieRequestCollectionGetByLastUserUpdate
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollectionGetByLastUserUpdate", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollectionGetByLastUserUpdate' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollectionGetByLastUserUpdate = DataRepository.DieRequestProvider.GetByLastUserUpdate(transactionManager, entity.UserId);

				if (deep && entity.DieRequestCollectionGetByLastUserUpdate.Count > 0)
				{
					deepHandles.Add("DieRequestCollectionGetByLastUserUpdate",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DieRequest>) DataRepository.DieRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.DieRequestCollectionGetByLastUserUpdate, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DieRequestCollectionGetByCodeBy
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollectionGetByCodeBy", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollectionGetByCodeBy' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollectionGetByCodeBy = DataRepository.DieRequestProvider.GetByCodeBy(transactionManager, entity.UserId);

				if (deep && entity.DieRequestCollectionGetByCodeBy.Count > 0)
				{
					deepHandles.Add("DieRequestCollectionGetByCodeBy",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DieRequest>) DataRepository.DieRequestProvider.DeepLoad,
						new object[] { transactionManager, entity.DieRequestCollectionGetByCodeBy, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Agile.Entities.User object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.User instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.User Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.User entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
				if (CanDeepSave(entity.DieRequestCollectionGetByUserId, "List<DieRequest>|DieRequestCollectionGetByUserId", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieRequest child in entity.DieRequestCollectionGetByUserId)
					{
						if(child.UserIdSource != null)
						{
							child.UserId = child.UserIdSource.UserId;
						}
						else
						{
							child.UserId = entity.UserId;
						}

					}

					if (entity.DieRequestCollectionGetByUserId.Count > 0 || entity.DieRequestCollectionGetByUserId.DeletedItems.Count > 0)
					{
						//DataRepository.DieRequestProvider.Save(transactionManager, entity.DieRequestCollectionGetByUserId);
						
						deepHandles.Add("DieRequestCollectionGetByUserId",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DieRequest >) DataRepository.DieRequestProvider.DeepSave,
							new object[] { transactionManager, entity.DieRequestCollectionGetByUserId, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DieRequest>
				if (CanDeepSave(entity.DieRequestCollectionGetByOwner, "List<DieRequest>|DieRequestCollectionGetByOwner", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieRequest child in entity.DieRequestCollectionGetByOwner)
					{
						if(child.OwnerSource != null)
						{
							child.Owner = child.OwnerSource.UserId;
						}
						else
						{
							child.Owner = entity.UserId;
						}

					}

					if (entity.DieRequestCollectionGetByOwner.Count > 0 || entity.DieRequestCollectionGetByOwner.DeletedItems.Count > 0)
					{
						//DataRepository.DieRequestProvider.Save(transactionManager, entity.DieRequestCollectionGetByOwner);
						
						deepHandles.Add("DieRequestCollectionGetByOwner",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DieRequest >) DataRepository.DieRequestProvider.DeepSave,
							new object[] { transactionManager, entity.DieRequestCollectionGetByOwner, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DieRequest>
				if (CanDeepSave(entity.DieRequestCollectionGetByLastUserUpdate, "List<DieRequest>|DieRequestCollectionGetByLastUserUpdate", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieRequest child in entity.DieRequestCollectionGetByLastUserUpdate)
					{
						if(child.LastUserUpdateSource != null)
						{
							child.LastUserUpdate = child.LastUserUpdateSource.UserId;
						}
						else
						{
							child.LastUserUpdate = entity.UserId;
						}

					}

					if (entity.DieRequestCollectionGetByLastUserUpdate.Count > 0 || entity.DieRequestCollectionGetByLastUserUpdate.DeletedItems.Count > 0)
					{
						//DataRepository.DieRequestProvider.Save(transactionManager, entity.DieRequestCollectionGetByLastUserUpdate);
						
						deepHandles.Add("DieRequestCollectionGetByLastUserUpdate",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DieRequest >) DataRepository.DieRequestProvider.DeepSave,
							new object[] { transactionManager, entity.DieRequestCollectionGetByLastUserUpdate, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DieRequest>
				if (CanDeepSave(entity.DieRequestCollectionGetByCodeBy, "List<DieRequest>|DieRequestCollectionGetByCodeBy", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieRequest child in entity.DieRequestCollectionGetByCodeBy)
					{
						if(child.CodeBySource != null)
						{
							child.CodeBy = child.CodeBySource.UserId;
						}
						else
						{
							child.CodeBy = entity.UserId;
						}

					}

					if (entity.DieRequestCollectionGetByCodeBy.Count > 0 || entity.DieRequestCollectionGetByCodeBy.DeletedItems.Count > 0)
					{
						//DataRepository.DieRequestProvider.Save(transactionManager, entity.DieRequestCollectionGetByCodeBy);
						
						deepHandles.Add("DieRequestCollectionGetByCodeBy",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DieRequest >) DataRepository.DieRequestProvider.DeepSave,
							new object[] { transactionManager, entity.DieRequestCollectionGetByCodeBy, deepSaveType, childTypes, innerList }
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
	
	#region UserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.User</c>
	///</summary>
	public enum UserChildEntityTypes
	{

		///<summary>
		/// Collection of <c>User</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollectionGetByUserId,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollectionGetByOwner,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollectionGetByLastUserUpdate,

		///<summary>
		/// Collection of <c>User</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollectionGetByCodeBy,
	}
	
	#endregion UserChildEntityTypes
	
	#region UserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilterBuilder : SqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		public UserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilterBuilder
	
	#region UserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserParameterBuilder : ParameterizedSqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		public UserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserParameterBuilder
	
	#region UserSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class UserSortBuilder : SqlSortBuilder<UserColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserSqlSortBuilder class.
		/// </summary>
		public UserSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion UserSortBuilder
	
} // end namespace
