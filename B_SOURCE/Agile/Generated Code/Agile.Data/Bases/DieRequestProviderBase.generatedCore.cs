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
	/// This class is the base class for any <see cref="DieRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DieRequestProviderBaseCore : EntityProviderBase<Agile.Entities.DieRequest, Agile.Entities.DieRequestKey>
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
		public override bool Delete(TransactionManager transactionManager, Agile.Entities.DieRequestKey key)
		{
			return Delete(transactionManager, key.DieRequestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dieRequestId">khóa của bảng. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dieRequestId)
		{
			return Delete(null, _dieRequestId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId">khóa của bảng. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dieRequestId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIECategory key.
		///		FK_tblDIERequest_tblDIECategory Description: 
		/// </summary>
		/// <param name="_dieCategoryId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieCategoryId(System.Int32? _dieCategoryId)
		{
			int count = -1;
			return GetByDieCategoryId(_dieCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIECategory key.
		///		FK_tblDIERequest_tblDIECategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByDieCategoryId(TransactionManager transactionManager, System.Int32? _dieCategoryId)
		{
			int count = -1;
			return GetByDieCategoryId(transactionManager, _dieCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIECategory key.
		///		FK_tblDIERequest_tblDIECategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieCategoryId(TransactionManager transactionManager, System.Int32? _dieCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieCategoryId(transactionManager, _dieCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIECategory key.
		///		fkTblDieRequestTblDieCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieCategoryId(System.Int32? _dieCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDieCategoryId(null, _dieCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIECategory key.
		///		fkTblDieRequestTblDieCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieCategoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieCategoryId(System.Int32? _dieCategoryId, int start, int pageLength,out int count)
		{
			return GetByDieCategoryId(null, _dieCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIECategory key.
		///		FK_tblDIERequest_tblDIECategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByDieCategoryId(TransactionManager transactionManager, System.Int32? _dieCategoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIERequest key.
		///		FK_tblDIERequest_tblDIERequest Description: 
		/// </summary>
		/// <param name="_parentDie"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByParentDie(System.Int32? _parentDie)
		{
			int count = -1;
			return GetByParentDie(_parentDie, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIERequest key.
		///		FK_tblDIERequest_tblDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_parentDie"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByParentDie(TransactionManager transactionManager, System.Int32? _parentDie)
		{
			int count = -1;
			return GetByParentDie(transactionManager, _parentDie, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIERequest key.
		///		FK_tblDIERequest_tblDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_parentDie"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByParentDie(TransactionManager transactionManager, System.Int32? _parentDie, int start, int pageLength)
		{
			int count = -1;
			return GetByParentDie(transactionManager, _parentDie, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIERequest key.
		///		fkTblDieRequestTblDieRequest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_parentDie"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByParentDie(System.Int32? _parentDie, int start, int pageLength)
		{
			int count =  -1;
			return GetByParentDie(null, _parentDie, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIERequest key.
		///		fkTblDieRequestTblDieRequest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_parentDie"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByParentDie(System.Int32? _parentDie, int start, int pageLength,out int count)
		{
			return GetByParentDie(null, _parentDie, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIERequest key.
		///		FK_tblDIERequest_tblDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_parentDie"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByParentDie(TransactionManager transactionManager, System.Int32? _parentDie, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEStatus key.
		///		FK_tblDIERequest_tblDIEStatus Description: 
		/// </summary>
		/// <param name="_dieStatus"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieStatus(System.Int32? _dieStatus)
		{
			int count = -1;
			return GetByDieStatus(_dieStatus, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEStatus key.
		///		FK_tblDIERequest_tblDIEStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByDieStatus(TransactionManager transactionManager, System.Int32? _dieStatus)
		{
			int count = -1;
			return GetByDieStatus(transactionManager, _dieStatus, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEStatus key.
		///		FK_tblDIERequest_tblDIEStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieStatus(TransactionManager transactionManager, System.Int32? _dieStatus, int start, int pageLength)
		{
			int count = -1;
			return GetByDieStatus(transactionManager, _dieStatus, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEStatus key.
		///		fkTblDieRequestTblDieStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieStatus"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieStatus(System.Int32? _dieStatus, int start, int pageLength)
		{
			int count =  -1;
			return GetByDieStatus(null, _dieStatus, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEStatus key.
		///		fkTblDieRequestTblDieStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieStatus"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieStatus(System.Int32? _dieStatus, int start, int pageLength,out int count)
		{
			return GetByDieStatus(null, _dieStatus, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEStatus key.
		///		FK_tblDIERequest_tblDIEStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieStatus"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByDieStatus(TransactionManager transactionManager, System.Int32? _dieStatus, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEType key.
		///		FK_tblDIERequest_tblDIEType Description: 
		/// </summary>
		/// <param name="_dieTypeId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieTypeId(System.Int32? _dieTypeId)
		{
			int count = -1;
			return GetByDieTypeId(_dieTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEType key.
		///		FK_tblDIERequest_tblDIEType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByDieTypeId(TransactionManager transactionManager, System.Int32? _dieTypeId)
		{
			int count = -1;
			return GetByDieTypeId(transactionManager, _dieTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEType key.
		///		FK_tblDIERequest_tblDIEType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieTypeId(TransactionManager transactionManager, System.Int32? _dieTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieTypeId(transactionManager, _dieTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEType key.
		///		fkTblDieRequestTblDieType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieTypeId(System.Int32? _dieTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDieTypeId(null, _dieTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEType key.
		///		fkTblDieRequestTblDieType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dieTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByDieTypeId(System.Int32? _dieTypeId, int start, int pageLength,out int count)
		{
			return GetByDieTypeId(null, _dieTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblDIEType key.
		///		FK_tblDIERequest_tblDIEType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByDieTypeId(TransactionManager transactionManager, System.Int32? _dieTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblMileStole key.
		///		FK_tblDIERequest_tblMileStole Description: 
		/// </summary>
		/// <param name="_milestoneId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByMilestoneId(System.Int32? _milestoneId)
		{
			int count = -1;
			return GetByMilestoneId(_milestoneId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblMileStole key.
		///		FK_tblDIERequest_tblMileStole Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_milestoneId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByMilestoneId(TransactionManager transactionManager, System.Int32? _milestoneId)
		{
			int count = -1;
			return GetByMilestoneId(transactionManager, _milestoneId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblMileStole key.
		///		FK_tblDIERequest_tblMileStole Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_milestoneId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByMilestoneId(TransactionManager transactionManager, System.Int32? _milestoneId, int start, int pageLength)
		{
			int count = -1;
			return GetByMilestoneId(transactionManager, _milestoneId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblMileStole key.
		///		fkTblDieRequestTblMileStole Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_milestoneId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByMilestoneId(System.Int32? _milestoneId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMilestoneId(null, _milestoneId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblMileStole key.
		///		fkTblDieRequestTblMileStole Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_milestoneId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByMilestoneId(System.Int32? _milestoneId, int start, int pageLength,out int count)
		{
			return GetByMilestoneId(null, _milestoneId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblMileStole key.
		///		FK_tblDIERequest_tblMileStole Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_milestoneId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByMilestoneId(TransactionManager transactionManager, System.Int32? _milestoneId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblPriorityDIERequest key.
		///		FK_tblDIERequest_tblPriorityDIERequest Description: 
		/// </summary>
		/// <param name="_priorityDieRequestId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByPriorityDieRequestId(System.Int32? _priorityDieRequestId)
		{
			int count = -1;
			return GetByPriorityDieRequestId(_priorityDieRequestId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblPriorityDIERequest key.
		///		FK_tblDIERequest_tblPriorityDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByPriorityDieRequestId(TransactionManager transactionManager, System.Int32? _priorityDieRequestId)
		{
			int count = -1;
			return GetByPriorityDieRequestId(transactionManager, _priorityDieRequestId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblPriorityDIERequest key.
		///		FK_tblDIERequest_tblPriorityDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByPriorityDieRequestId(TransactionManager transactionManager, System.Int32? _priorityDieRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByPriorityDieRequestId(transactionManager, _priorityDieRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblPriorityDIERequest key.
		///		fkTblDieRequestTblPriorityDieRequest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByPriorityDieRequestId(System.Int32? _priorityDieRequestId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPriorityDieRequestId(null, _priorityDieRequestId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblPriorityDIERequest key.
		///		fkTblDieRequestTblPriorityDieRequest Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByPriorityDieRequestId(System.Int32? _priorityDieRequestId, int start, int pageLength,out int count)
		{
			return GetByPriorityDieRequestId(null, _priorityDieRequestId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblPriorityDIERequest key.
		///		FK_tblDIERequest_tblPriorityDIERequest Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_priorityDieRequestId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByPriorityDieRequestId(TransactionManager transactionManager, System.Int32? _priorityDieRequestId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblProject key.
		///		FK_tblDIERequest_tblProject Description: 
		/// </summary>
		/// <param name="_projectId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByProjectId(System.Int32? _projectId)
		{
			int count = -1;
			return GetByProjectId(_projectId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblProject key.
		///		FK_tblDIERequest_tblProject Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByProjectId(TransactionManager transactionManager, System.Int32? _projectId)
		{
			int count = -1;
			return GetByProjectId(transactionManager, _projectId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblProject key.
		///		FK_tblDIERequest_tblProject Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByProjectId(TransactionManager transactionManager, System.Int32? _projectId, int start, int pageLength)
		{
			int count = -1;
			return GetByProjectId(transactionManager, _projectId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblProject key.
		///		fkTblDieRequestTblProject Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_projectId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByProjectId(System.Int32? _projectId, int start, int pageLength)
		{
			int count =  -1;
			return GetByProjectId(null, _projectId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblProject key.
		///		fkTblDieRequestTblProject Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_projectId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByProjectId(System.Int32? _projectId, int start, int pageLength,out int count)
		{
			return GetByProjectId(null, _projectId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblProject key.
		///		FK_tblDIERequest_tblProject Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_projectId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByProjectId(TransactionManager transactionManager, System.Int32? _projectId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblRelease key.
		///		FK_tblDIERequest_tblRelease Description: 
		/// </summary>
		/// <param name="_completedReleaseId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCompletedReleaseId(System.Int32? _completedReleaseId)
		{
			int count = -1;
			return GetByCompletedReleaseId(_completedReleaseId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblRelease key.
		///		FK_tblDIERequest_tblRelease Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_completedReleaseId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByCompletedReleaseId(TransactionManager transactionManager, System.Int32? _completedReleaseId)
		{
			int count = -1;
			return GetByCompletedReleaseId(transactionManager, _completedReleaseId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblRelease key.
		///		FK_tblDIERequest_tblRelease Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_completedReleaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCompletedReleaseId(TransactionManager transactionManager, System.Int32? _completedReleaseId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompletedReleaseId(transactionManager, _completedReleaseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblRelease key.
		///		fkTblDieRequestTblRelease Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_completedReleaseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCompletedReleaseId(System.Int32? _completedReleaseId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCompletedReleaseId(null, _completedReleaseId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblRelease key.
		///		fkTblDieRequestTblRelease Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_completedReleaseId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCompletedReleaseId(System.Int32? _completedReleaseId, int start, int pageLength,out int count)
		{
			return GetByCompletedReleaseId(null, _completedReleaseId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblRelease key.
		///		FK_tblDIERequest_tblRelease Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_completedReleaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByCompletedReleaseId(TransactionManager transactionManager, System.Int32? _completedReleaseId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblResolutions key.
		///		FK_tblDIERequest_tblResolutions Description: 
		/// </summary>
		/// <param name="_resolutionsId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByResolutionsId(System.Int32? _resolutionsId)
		{
			int count = -1;
			return GetByResolutionsId(_resolutionsId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblResolutions key.
		///		FK_tblDIERequest_tblResolutions Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resolutionsId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByResolutionsId(TransactionManager transactionManager, System.Int32? _resolutionsId)
		{
			int count = -1;
			return GetByResolutionsId(transactionManager, _resolutionsId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblResolutions key.
		///		FK_tblDIERequest_tblResolutions Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resolutionsId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByResolutionsId(TransactionManager transactionManager, System.Int32? _resolutionsId, int start, int pageLength)
		{
			int count = -1;
			return GetByResolutionsId(transactionManager, _resolutionsId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblResolutions key.
		///		fkTblDieRequestTblResolutions Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resolutionsId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByResolutionsId(System.Int32? _resolutionsId, int start, int pageLength)
		{
			int count =  -1;
			return GetByResolutionsId(null, _resolutionsId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblResolutions key.
		///		fkTblDieRequestTblResolutions Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_resolutionsId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByResolutionsId(System.Int32? _resolutionsId, int start, int pageLength,out int count)
		{
			return GetByResolutionsId(null, _resolutionsId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblResolutions key.
		///		FK_tblDIERequest_tblResolutions Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_resolutionsId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByResolutionsId(TransactionManager transactionManager, System.Int32? _resolutionsId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser key.
		///		FK_tblDIERequest_tblUser Description: 
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByUserId(System.Int32? _userId)
		{
			int count = -1;
			return GetByUserId(_userId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser key.
		///		FK_tblDIERequest_tblUser Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByUserId(TransactionManager transactionManager, System.Int32? _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser key.
		///		FK_tblDIERequest_tblUser Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByUserId(TransactionManager transactionManager, System.Int32? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser key.
		///		fkTblDieRequestTblUser Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByUserId(System.Int32? _userId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserId(null, _userId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser key.
		///		fkTblDieRequestTblUser Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByUserId(System.Int32? _userId, int start, int pageLength,out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser key.
		///		FK_tblDIERequest_tblUser Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByUserId(TransactionManager transactionManager, System.Int32? _userId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_CodeBy key.
		///		FK_tblDIERequest_tblUser_CodeBy Description: 
		/// </summary>
		/// <param name="_codeBy"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCodeBy(System.Int32? _codeBy)
		{
			int count = -1;
			return GetByCodeBy(_codeBy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_CodeBy key.
		///		FK_tblDIERequest_tblUser_CodeBy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codeBy"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByCodeBy(TransactionManager transactionManager, System.Int32? _codeBy)
		{
			int count = -1;
			return GetByCodeBy(transactionManager, _codeBy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_CodeBy key.
		///		FK_tblDIERequest_tblUser_CodeBy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codeBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCodeBy(TransactionManager transactionManager, System.Int32? _codeBy, int start, int pageLength)
		{
			int count = -1;
			return GetByCodeBy(transactionManager, _codeBy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_CodeBy key.
		///		fkTblDieRequestTblUserCodeBy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_codeBy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCodeBy(System.Int32? _codeBy, int start, int pageLength)
		{
			int count =  -1;
			return GetByCodeBy(null, _codeBy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_CodeBy key.
		///		fkTblDieRequestTblUserCodeBy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_codeBy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByCodeBy(System.Int32? _codeBy, int start, int pageLength,out int count)
		{
			return GetByCodeBy(null, _codeBy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_CodeBy key.
		///		FK_tblDIERequest_tblUser_CodeBy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_codeBy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByCodeBy(TransactionManager transactionManager, System.Int32? _codeBy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_Owner key.
		///		FK_tblDIERequest_tblUser_Owner Description: 
		/// </summary>
		/// <param name="_owner"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByOwner(System.Int32? _owner)
		{
			int count = -1;
			return GetByOwner(_owner, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_Owner key.
		///		FK_tblDIERequest_tblUser_Owner Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_owner"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByOwner(TransactionManager transactionManager, System.Int32? _owner)
		{
			int count = -1;
			return GetByOwner(transactionManager, _owner, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_Owner key.
		///		FK_tblDIERequest_tblUser_Owner Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_owner"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByOwner(TransactionManager transactionManager, System.Int32? _owner, int start, int pageLength)
		{
			int count = -1;
			return GetByOwner(transactionManager, _owner, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_Owner key.
		///		fkTblDieRequestTblUserOwner Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_owner"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByOwner(System.Int32? _owner, int start, int pageLength)
		{
			int count =  -1;
			return GetByOwner(null, _owner, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_Owner key.
		///		fkTblDieRequestTblUserOwner Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_owner"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByOwner(System.Int32? _owner, int start, int pageLength,out int count)
		{
			return GetByOwner(null, _owner, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_Owner key.
		///		FK_tblDIERequest_tblUser_Owner Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_owner"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByOwner(TransactionManager transactionManager, System.Int32? _owner, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_UserUpdate key.
		///		FK_tblDIERequest_tblUser_UserUpdate Description: 
		/// </summary>
		/// <param name="_lastUserUpdate"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByLastUserUpdate(System.Int32? _lastUserUpdate)
		{
			int count = -1;
			return GetByLastUserUpdate(_lastUserUpdate, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_UserUpdate key.
		///		FK_tblDIERequest_tblUser_UserUpdate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastUserUpdate"></param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		/// <remarks></remarks>
		public TList<DieRequest> GetByLastUserUpdate(TransactionManager transactionManager, System.Int32? _lastUserUpdate)
		{
			int count = -1;
			return GetByLastUserUpdate(transactionManager, _lastUserUpdate, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_UserUpdate key.
		///		FK_tblDIERequest_tblUser_UserUpdate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastUserUpdate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByLastUserUpdate(TransactionManager transactionManager, System.Int32? _lastUserUpdate, int start, int pageLength)
		{
			int count = -1;
			return GetByLastUserUpdate(transactionManager, _lastUserUpdate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_UserUpdate key.
		///		fkTblDieRequestTblUserUserUpdate Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastUserUpdate"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByLastUserUpdate(System.Int32? _lastUserUpdate, int start, int pageLength)
		{
			int count =  -1;
			return GetByLastUserUpdate(null, _lastUserUpdate, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_UserUpdate key.
		///		fkTblDieRequestTblUserUserUpdate Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_lastUserUpdate"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public TList<DieRequest> GetByLastUserUpdate(System.Int32? _lastUserUpdate, int start, int pageLength,out int count)
		{
			return GetByLastUserUpdate(null, _lastUserUpdate, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tblDIERequest_tblUser_UserUpdate key.
		///		FK_tblDIERequest_tblUser_UserUpdate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastUserUpdate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Agile.Entities.DieRequest objects.</returns>
		public abstract TList<DieRequest> GetByLastUserUpdate(TransactionManager transactionManager, System.Int32? _lastUserUpdate, int start, int pageLength, out int count);
		
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
		public override Agile.Entities.DieRequest Get(TransactionManager transactionManager, Agile.Entities.DieRequestKey key, int start, int pageLength)
		{
			return GetByDieRequestId(transactionManager, key.DieRequestId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDIERequest index.
		/// </summary>
		/// <param name="_dieRequestId">khóa của bảng</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieRequest"/> class.</returns>
		public Agile.Entities.DieRequest GetByDieRequestId(System.Int32 _dieRequestId)
		{
			int count = -1;
			return GetByDieRequestId(null,_dieRequestId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIERequest index.
		/// </summary>
		/// <param name="_dieRequestId">khóa của bảng</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieRequest"/> class.</returns>
		public Agile.Entities.DieRequest GetByDieRequestId(System.Int32 _dieRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieRequestId(null, _dieRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIERequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId">khóa của bảng</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieRequest"/> class.</returns>
		public Agile.Entities.DieRequest GetByDieRequestId(TransactionManager transactionManager, System.Int32 _dieRequestId)
		{
			int count = -1;
			return GetByDieRequestId(transactionManager, _dieRequestId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIERequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId">khóa của bảng</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieRequest"/> class.</returns>
		public Agile.Entities.DieRequest GetByDieRequestId(TransactionManager transactionManager, System.Int32 _dieRequestId, int start, int pageLength)
		{
			int count = -1;
			return GetByDieRequestId(transactionManager, _dieRequestId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIERequest index.
		/// </summary>
		/// <param name="_dieRequestId">khóa của bảng</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieRequest"/> class.</returns>
		public Agile.Entities.DieRequest GetByDieRequestId(System.Int32 _dieRequestId, int start, int pageLength, out int count)
		{
			return GetByDieRequestId(null, _dieRequestId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDIERequest index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dieRequestId">khóa của bảng</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Agile.Entities.DieRequest"/> class.</returns>
		public abstract Agile.Entities.DieRequest GetByDieRequestId(TransactionManager transactionManager, System.Int32 _dieRequestId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DieRequest&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DieRequest&gt;"/></returns>
		public static TList<DieRequest> Fill(IDataReader reader, TList<DieRequest> rows, int start, int pageLength)
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
				
				Agile.Entities.DieRequest c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DieRequest")
					.Append("|").Append((System.Int32)reader[((int)DieRequestColumn.DieRequestId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DieRequest>(
					key.ToString(), // EntityTrackingKey
					"DieRequest",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Agile.Entities.DieRequest();
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
					c.DieRequestId = (System.Int32)reader[((int)DieRequestColumn.DieRequestId - 1)];
					c.DieName = (reader.IsDBNull(((int)DieRequestColumn.DieName - 1)))?null:(System.String)reader[((int)DieRequestColumn.DieName - 1)];
					c.DieTag = (reader.IsDBNull(((int)DieRequestColumn.DieTag - 1)))?null:(System.String)reader[((int)DieRequestColumn.DieTag - 1)];
					c.DieDescription = (reader.IsDBNull(((int)DieRequestColumn.DieDescription - 1)))?null:(System.String)reader[((int)DieRequestColumn.DieDescription - 1)];
					c.DieTypeId = (reader.IsDBNull(((int)DieRequestColumn.DieTypeId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.DieTypeId - 1)];
					c.ResolutionsId = (reader.IsDBNull(((int)DieRequestColumn.ResolutionsId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.ResolutionsId - 1)];
					c.UserId = (reader.IsDBNull(((int)DieRequestColumn.UserId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.UserId - 1)];
					c.ProjectId = (reader.IsDBNull(((int)DieRequestColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.ProjectId - 1)];
					c.DieStatus = (reader.IsDBNull(((int)DieRequestColumn.DieStatus - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.DieStatus - 1)];
					c.PriorityDieRequestId = (reader.IsDBNull(((int)DieRequestColumn.PriorityDieRequestId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.PriorityDieRequestId - 1)];
					c.DieDateSubmit = (reader.IsDBNull(((int)DieRequestColumn.DieDateSubmit - 1)))?null:(System.DateTime?)reader[((int)DieRequestColumn.DieDateSubmit - 1)];
					c.CodeBy = (reader.IsDBNull(((int)DieRequestColumn.CodeBy - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.CodeBy - 1)];
					c.Owner = (reader.IsDBNull(((int)DieRequestColumn.Owner - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.Owner - 1)];
					c.UpdateTime = (reader.IsDBNull(((int)DieRequestColumn.UpdateTime - 1)))?null:(System.DateTime?)reader[((int)DieRequestColumn.UpdateTime - 1)];
					c.LastUserUpdate = (reader.IsDBNull(((int)DieRequestColumn.LastUserUpdate - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.LastUserUpdate - 1)];
					c.TargetDate = (reader.IsDBNull(((int)DieRequestColumn.TargetDate - 1)))?null:(System.DateTime?)reader[((int)DieRequestColumn.TargetDate - 1)];
					c.CompletedReleaseId = (reader.IsDBNull(((int)DieRequestColumn.CompletedReleaseId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.CompletedReleaseId - 1)];
					c.MilestoneId = (reader.IsDBNull(((int)DieRequestColumn.MilestoneId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.MilestoneId - 1)];
					c.DieCategoryId = (reader.IsDBNull(((int)DieRequestColumn.DieCategoryId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.DieCategoryId - 1)];
					c.Estimated = (reader.IsDBNull(((int)DieRequestColumn.Estimated - 1)))?null:(System.Double?)reader[((int)DieRequestColumn.Estimated - 1)];
					c.Actual = (reader.IsDBNull(((int)DieRequestColumn.Actual - 1)))?null:(System.Double?)reader[((int)DieRequestColumn.Actual - 1)];
					c.ParentDie = (reader.IsDBNull(((int)DieRequestColumn.ParentDie - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.ParentDie - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieRequest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieRequest"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Agile.Entities.DieRequest entity)
		{
			if (!reader.Read()) return;
			
			entity.DieRequestId = (System.Int32)reader[((int)DieRequestColumn.DieRequestId - 1)];
			entity.DieName = (reader.IsDBNull(((int)DieRequestColumn.DieName - 1)))?null:(System.String)reader[((int)DieRequestColumn.DieName - 1)];
			entity.DieTag = (reader.IsDBNull(((int)DieRequestColumn.DieTag - 1)))?null:(System.String)reader[((int)DieRequestColumn.DieTag - 1)];
			entity.DieDescription = (reader.IsDBNull(((int)DieRequestColumn.DieDescription - 1)))?null:(System.String)reader[((int)DieRequestColumn.DieDescription - 1)];
			entity.DieTypeId = (reader.IsDBNull(((int)DieRequestColumn.DieTypeId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.DieTypeId - 1)];
			entity.ResolutionsId = (reader.IsDBNull(((int)DieRequestColumn.ResolutionsId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.ResolutionsId - 1)];
			entity.UserId = (reader.IsDBNull(((int)DieRequestColumn.UserId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.UserId - 1)];
			entity.ProjectId = (reader.IsDBNull(((int)DieRequestColumn.ProjectId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.ProjectId - 1)];
			entity.DieStatus = (reader.IsDBNull(((int)DieRequestColumn.DieStatus - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.DieStatus - 1)];
			entity.PriorityDieRequestId = (reader.IsDBNull(((int)DieRequestColumn.PriorityDieRequestId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.PriorityDieRequestId - 1)];
			entity.DieDateSubmit = (reader.IsDBNull(((int)DieRequestColumn.DieDateSubmit - 1)))?null:(System.DateTime?)reader[((int)DieRequestColumn.DieDateSubmit - 1)];
			entity.CodeBy = (reader.IsDBNull(((int)DieRequestColumn.CodeBy - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.CodeBy - 1)];
			entity.Owner = (reader.IsDBNull(((int)DieRequestColumn.Owner - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.Owner - 1)];
			entity.UpdateTime = (reader.IsDBNull(((int)DieRequestColumn.UpdateTime - 1)))?null:(System.DateTime?)reader[((int)DieRequestColumn.UpdateTime - 1)];
			entity.LastUserUpdate = (reader.IsDBNull(((int)DieRequestColumn.LastUserUpdate - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.LastUserUpdate - 1)];
			entity.TargetDate = (reader.IsDBNull(((int)DieRequestColumn.TargetDate - 1)))?null:(System.DateTime?)reader[((int)DieRequestColumn.TargetDate - 1)];
			entity.CompletedReleaseId = (reader.IsDBNull(((int)DieRequestColumn.CompletedReleaseId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.CompletedReleaseId - 1)];
			entity.MilestoneId = (reader.IsDBNull(((int)DieRequestColumn.MilestoneId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.MilestoneId - 1)];
			entity.DieCategoryId = (reader.IsDBNull(((int)DieRequestColumn.DieCategoryId - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.DieCategoryId - 1)];
			entity.Estimated = (reader.IsDBNull(((int)DieRequestColumn.Estimated - 1)))?null:(System.Double?)reader[((int)DieRequestColumn.Estimated - 1)];
			entity.Actual = (reader.IsDBNull(((int)DieRequestColumn.Actual - 1)))?null:(System.Double?)reader[((int)DieRequestColumn.Actual - 1)];
			entity.ParentDie = (reader.IsDBNull(((int)DieRequestColumn.ParentDie - 1)))?null:(System.Int32?)reader[((int)DieRequestColumn.ParentDie - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Agile.Entities.DieRequest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Agile.Entities.DieRequest"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Agile.Entities.DieRequest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieRequestId = (System.Int32)dataRow["DIERequestID"];
			entity.DieName = Convert.IsDBNull(dataRow["DIEName"]) ? null : (System.String)dataRow["DIEName"];
			entity.DieTag = Convert.IsDBNull(dataRow["DIETag"]) ? null : (System.String)dataRow["DIETag"];
			entity.DieDescription = Convert.IsDBNull(dataRow["DIEDescription"]) ? null : (System.String)dataRow["DIEDescription"];
			entity.DieTypeId = Convert.IsDBNull(dataRow["DIETypeID"]) ? null : (System.Int32?)dataRow["DIETypeID"];
			entity.ResolutionsId = Convert.IsDBNull(dataRow["ResolutionsID"]) ? null : (System.Int32?)dataRow["ResolutionsID"];
			entity.UserId = Convert.IsDBNull(dataRow["UserID"]) ? null : (System.Int32?)dataRow["UserID"];
			entity.ProjectId = Convert.IsDBNull(dataRow["ProjectID"]) ? null : (System.Int32?)dataRow["ProjectID"];
			entity.DieStatus = Convert.IsDBNull(dataRow["DIEStatus"]) ? null : (System.Int32?)dataRow["DIEStatus"];
			entity.PriorityDieRequestId = Convert.IsDBNull(dataRow["PriorityDIERequestID"]) ? null : (System.Int32?)dataRow["PriorityDIERequestID"];
			entity.DieDateSubmit = Convert.IsDBNull(dataRow["DIEDateSubmit"]) ? null : (System.DateTime?)dataRow["DIEDateSubmit"];
			entity.CodeBy = Convert.IsDBNull(dataRow["CodeBy"]) ? null : (System.Int32?)dataRow["CodeBy"];
			entity.Owner = Convert.IsDBNull(dataRow["Owner"]) ? null : (System.Int32?)dataRow["Owner"];
			entity.UpdateTime = Convert.IsDBNull(dataRow["UpdateTime"]) ? null : (System.DateTime?)dataRow["UpdateTime"];
			entity.LastUserUpdate = Convert.IsDBNull(dataRow["LastUserUpdate"]) ? null : (System.Int32?)dataRow["LastUserUpdate"];
			entity.TargetDate = Convert.IsDBNull(dataRow["TargetDate"]) ? null : (System.DateTime?)dataRow["TargetDate"];
			entity.CompletedReleaseId = Convert.IsDBNull(dataRow["CompletedReleaseID"]) ? null : (System.Int32?)dataRow["CompletedReleaseID"];
			entity.MilestoneId = Convert.IsDBNull(dataRow["MilestoneID"]) ? null : (System.Int32?)dataRow["MilestoneID"];
			entity.DieCategoryId = Convert.IsDBNull(dataRow["DIECategoryID"]) ? null : (System.Int32?)dataRow["DIECategoryID"];
			entity.Estimated = Convert.IsDBNull(dataRow["Estimated"]) ? null : (System.Double?)dataRow["Estimated"];
			entity.Actual = Convert.IsDBNull(dataRow["Actual"]) ? null : (System.Double?)dataRow["Actual"];
			entity.ParentDie = Convert.IsDBNull(dataRow["ParentDie"]) ? null : (System.Int32?)dataRow["ParentDie"];
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
		/// <param name="entity">The <see cref="Agile.Entities.DieRequest"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Agile.Entities.DieRequest Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Agile.Entities.DieRequest entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DieCategoryIdSource	
			if (CanDeepLoad(entity, "DieCategory|DieCategoryIdSource", deepLoadType, innerList) 
				&& entity.DieCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DieCategoryId ?? (int)0);
				DieCategory tmpEntity = EntityManager.LocateEntity<DieCategory>(EntityLocator.ConstructKeyFromPkItems(typeof(DieCategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DieCategoryIdSource = tmpEntity;
				else
					entity.DieCategoryIdSource = DataRepository.DieCategoryProvider.GetByDieCategoryId(transactionManager, (entity.DieCategoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DieCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DieCategoryProvider.DeepLoad(transactionManager, entity.DieCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DieCategoryIdSource

			#region ParentDieSource	
			if (CanDeepLoad(entity, "DieRequest|ParentDieSource", deepLoadType, innerList) 
				&& entity.ParentDieSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ParentDie ?? (int)0);
				DieRequest tmpEntity = EntityManager.LocateEntity<DieRequest>(EntityLocator.ConstructKeyFromPkItems(typeof(DieRequest), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ParentDieSource = tmpEntity;
				else
					entity.ParentDieSource = DataRepository.DieRequestProvider.GetByDieRequestId(transactionManager, (entity.ParentDie ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ParentDieSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ParentDieSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DieRequestProvider.DeepLoad(transactionManager, entity.ParentDieSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ParentDieSource

			#region DieStatusSource	
			if (CanDeepLoad(entity, "DieStatus|DieStatusSource", deepLoadType, innerList) 
				&& entity.DieStatusSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DieStatus ?? (int)0);
				DieStatus tmpEntity = EntityManager.LocateEntity<DieStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(DieStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DieStatusSource = tmpEntity;
				else
					entity.DieStatusSource = DataRepository.DieStatusProvider.GetByDieStatus(transactionManager, (entity.DieStatus ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieStatusSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DieStatusSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DieStatusProvider.DeepLoad(transactionManager, entity.DieStatusSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DieStatusSource

			#region DieTypeIdSource	
			if (CanDeepLoad(entity, "DieType|DieTypeIdSource", deepLoadType, innerList) 
				&& entity.DieTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DieTypeId ?? (int)0);
				DieType tmpEntity = EntityManager.LocateEntity<DieType>(EntityLocator.ConstructKeyFromPkItems(typeof(DieType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DieTypeIdSource = tmpEntity;
				else
					entity.DieTypeIdSource = DataRepository.DieTypeProvider.GetByDieTypeId(transactionManager, (entity.DieTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DieTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DieTypeProvider.DeepLoad(transactionManager, entity.DieTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DieTypeIdSource

			#region MilestoneIdSource	
			if (CanDeepLoad(entity, "MileStole|MilestoneIdSource", deepLoadType, innerList) 
				&& entity.MilestoneIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MilestoneId ?? (int)0);
				MileStole tmpEntity = EntityManager.LocateEntity<MileStole>(EntityLocator.ConstructKeyFromPkItems(typeof(MileStole), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MilestoneIdSource = tmpEntity;
				else
					entity.MilestoneIdSource = DataRepository.MileStoleProvider.GetByMileStoleId(transactionManager, (entity.MilestoneId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MilestoneIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MilestoneIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.MileStoleProvider.DeepLoad(transactionManager, entity.MilestoneIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MilestoneIdSource

			#region PriorityDieRequestIdSource	
			if (CanDeepLoad(entity, "PriorityDieRequest|PriorityDieRequestIdSource", deepLoadType, innerList) 
				&& entity.PriorityDieRequestIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PriorityDieRequestId ?? (int)0);
				PriorityDieRequest tmpEntity = EntityManager.LocateEntity<PriorityDieRequest>(EntityLocator.ConstructKeyFromPkItems(typeof(PriorityDieRequest), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PriorityDieRequestIdSource = tmpEntity;
				else
					entity.PriorityDieRequestIdSource = DataRepository.PriorityDieRequestProvider.GetByPriorityDieRequestId(transactionManager, (entity.PriorityDieRequestId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PriorityDieRequestIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PriorityDieRequestIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PriorityDieRequestProvider.DeepLoad(transactionManager, entity.PriorityDieRequestIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PriorityDieRequestIdSource

			#region ProjectIdSource	
			if (CanDeepLoad(entity, "Project|ProjectIdSource", deepLoadType, innerList) 
				&& entity.ProjectIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ProjectId ?? (int)0);
				Project tmpEntity = EntityManager.LocateEntity<Project>(EntityLocator.ConstructKeyFromPkItems(typeof(Project), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProjectIdSource = tmpEntity;
				else
					entity.ProjectIdSource = DataRepository.ProjectProvider.GetByProjectId(transactionManager, (entity.ProjectId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProjectIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProjectIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProjectProvider.DeepLoad(transactionManager, entity.ProjectIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProjectIdSource

			#region CompletedReleaseIdSource	
			if (CanDeepLoad(entity, "Release|CompletedReleaseIdSource", deepLoadType, innerList) 
				&& entity.CompletedReleaseIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CompletedReleaseId ?? (int)0);
				Release tmpEntity = EntityManager.LocateEntity<Release>(EntityLocator.ConstructKeyFromPkItems(typeof(Release), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompletedReleaseIdSource = tmpEntity;
				else
					entity.CompletedReleaseIdSource = DataRepository.ReleaseProvider.GetByReleaseId(transactionManager, (entity.CompletedReleaseId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompletedReleaseIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompletedReleaseIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ReleaseProvider.DeepLoad(transactionManager, entity.CompletedReleaseIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompletedReleaseIdSource

			#region ResolutionsIdSource	
			if (CanDeepLoad(entity, "Resolutions|ResolutionsIdSource", deepLoadType, innerList) 
				&& entity.ResolutionsIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ResolutionsId ?? (int)0);
				Resolutions tmpEntity = EntityManager.LocateEntity<Resolutions>(EntityLocator.ConstructKeyFromPkItems(typeof(Resolutions), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ResolutionsIdSource = tmpEntity;
				else
					entity.ResolutionsIdSource = DataRepository.ResolutionsProvider.GetByResolutionsId(transactionManager, (entity.ResolutionsId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ResolutionsIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ResolutionsIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ResolutionsProvider.DeepLoad(transactionManager, entity.ResolutionsIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ResolutionsIdSource

			#region UserIdSource	
			if (CanDeepLoad(entity, "User|UserIdSource", deepLoadType, innerList) 
				&& entity.UserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UserId ?? (int)0);
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserIdSource = tmpEntity;
				else
					entity.UserIdSource = DataRepository.UserProvider.GetByUserId(transactionManager, (entity.UserId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.UserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UserIdSource

			#region CodeBySource	
			if (CanDeepLoad(entity, "User|CodeBySource", deepLoadType, innerList) 
				&& entity.CodeBySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CodeBy ?? (int)0);
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CodeBySource = tmpEntity;
				else
					entity.CodeBySource = DataRepository.UserProvider.GetByUserId(transactionManager, (entity.CodeBy ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CodeBySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CodeBySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.CodeBySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CodeBySource

			#region OwnerSource	
			if (CanDeepLoad(entity, "User|OwnerSource", deepLoadType, innerList) 
				&& entity.OwnerSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Owner ?? (int)0);
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OwnerSource = tmpEntity;
				else
					entity.OwnerSource = DataRepository.UserProvider.GetByUserId(transactionManager, (entity.Owner ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OwnerSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OwnerSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.OwnerSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OwnerSource

			#region LastUserUpdateSource	
			if (CanDeepLoad(entity, "User|LastUserUpdateSource", deepLoadType, innerList) 
				&& entity.LastUserUpdateSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.LastUserUpdate ?? (int)0);
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.LastUserUpdateSource = tmpEntity;
				else
					entity.LastUserUpdateSource = DataRepository.UserProvider.GetByUserId(transactionManager, (entity.LastUserUpdate ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LastUserUpdateSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.LastUserUpdateSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.LastUserUpdateSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion LastUserUpdateSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDieRequestId methods when available
			
			#region DieAttachFileCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieAttachFile>|DieAttachFileCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieAttachFileCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieAttachFileCollection = DataRepository.DieAttachFileProvider.GetByDieRequestId(transactionManager, entity.DieRequestId);

				if (deep && entity.DieAttachFileCollection.Count > 0)
				{
					deepHandles.Add("DieAttachFileCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DieAttachFile>) DataRepository.DieAttachFileProvider.DeepLoad,
						new object[] { transactionManager, entity.DieAttachFileCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DieRequestCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DieRequest>|DieRequestCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DieRequestCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DieRequestCollection = DataRepository.DieRequestProvider.GetByParentDie(transactionManager, entity.DieRequestId);

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
		/// Deep Save the entire object graph of the Agile.Entities.DieRequest object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Agile.Entities.DieRequest instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Agile.Entities.DieRequest Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Agile.Entities.DieRequest entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DieCategoryIdSource
			if (CanDeepSave(entity, "DieCategory|DieCategoryIdSource", deepSaveType, innerList) 
				&& entity.DieCategoryIdSource != null)
			{
				DataRepository.DieCategoryProvider.Save(transactionManager, entity.DieCategoryIdSource);
				entity.DieCategoryId = entity.DieCategoryIdSource.DieCategoryId;
			}
			#endregion 
			
			#region ParentDieSource
			if (CanDeepSave(entity, "DieRequest|ParentDieSource", deepSaveType, innerList) 
				&& entity.ParentDieSource != null)
			{
				DataRepository.DieRequestProvider.Save(transactionManager, entity.ParentDieSource);
				entity.ParentDie = entity.ParentDieSource.DieRequestId;
			}
			#endregion 
			
			#region DieStatusSource
			if (CanDeepSave(entity, "DieStatus|DieStatusSource", deepSaveType, innerList) 
				&& entity.DieStatusSource != null)
			{
				DataRepository.DieStatusProvider.Save(transactionManager, entity.DieStatusSource);
				entity.DieStatus = entity.DieStatusSource.DieStatus;
			}
			#endregion 
			
			#region DieTypeIdSource
			if (CanDeepSave(entity, "DieType|DieTypeIdSource", deepSaveType, innerList) 
				&& entity.DieTypeIdSource != null)
			{
				DataRepository.DieTypeProvider.Save(transactionManager, entity.DieTypeIdSource);
				entity.DieTypeId = entity.DieTypeIdSource.DieTypeId;
			}
			#endregion 
			
			#region MilestoneIdSource
			if (CanDeepSave(entity, "MileStole|MilestoneIdSource", deepSaveType, innerList) 
				&& entity.MilestoneIdSource != null)
			{
				DataRepository.MileStoleProvider.Save(transactionManager, entity.MilestoneIdSource);
				entity.MilestoneId = entity.MilestoneIdSource.MileStoleId;
			}
			#endregion 
			
			#region PriorityDieRequestIdSource
			if (CanDeepSave(entity, "PriorityDieRequest|PriorityDieRequestIdSource", deepSaveType, innerList) 
				&& entity.PriorityDieRequestIdSource != null)
			{
				DataRepository.PriorityDieRequestProvider.Save(transactionManager, entity.PriorityDieRequestIdSource);
				entity.PriorityDieRequestId = entity.PriorityDieRequestIdSource.PriorityDieRequestId;
			}
			#endregion 
			
			#region ProjectIdSource
			if (CanDeepSave(entity, "Project|ProjectIdSource", deepSaveType, innerList) 
				&& entity.ProjectIdSource != null)
			{
				DataRepository.ProjectProvider.Save(transactionManager, entity.ProjectIdSource);
				entity.ProjectId = entity.ProjectIdSource.ProjectId;
			}
			#endregion 
			
			#region CompletedReleaseIdSource
			if (CanDeepSave(entity, "Release|CompletedReleaseIdSource", deepSaveType, innerList) 
				&& entity.CompletedReleaseIdSource != null)
			{
				DataRepository.ReleaseProvider.Save(transactionManager, entity.CompletedReleaseIdSource);
				entity.CompletedReleaseId = entity.CompletedReleaseIdSource.ReleaseId;
			}
			#endregion 
			
			#region ResolutionsIdSource
			if (CanDeepSave(entity, "Resolutions|ResolutionsIdSource", deepSaveType, innerList) 
				&& entity.ResolutionsIdSource != null)
			{
				DataRepository.ResolutionsProvider.Save(transactionManager, entity.ResolutionsIdSource);
				entity.ResolutionsId = entity.ResolutionsIdSource.ResolutionsId;
			}
			#endregion 
			
			#region UserIdSource
			if (CanDeepSave(entity, "User|UserIdSource", deepSaveType, innerList) 
				&& entity.UserIdSource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.UserIdSource);
				entity.UserId = entity.UserIdSource.UserId;
			}
			#endregion 
			
			#region CodeBySource
			if (CanDeepSave(entity, "User|CodeBySource", deepSaveType, innerList) 
				&& entity.CodeBySource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.CodeBySource);
				entity.CodeBy = entity.CodeBySource.UserId;
			}
			#endregion 
			
			#region OwnerSource
			if (CanDeepSave(entity, "User|OwnerSource", deepSaveType, innerList) 
				&& entity.OwnerSource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.OwnerSource);
				entity.Owner = entity.OwnerSource.UserId;
			}
			#endregion 
			
			#region LastUserUpdateSource
			if (CanDeepSave(entity, "User|LastUserUpdateSource", deepSaveType, innerList) 
				&& entity.LastUserUpdateSource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.LastUserUpdateSource);
				entity.LastUserUpdate = entity.LastUserUpdateSource.UserId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<DieAttachFile>
				if (CanDeepSave(entity.DieAttachFileCollection, "List<DieAttachFile>|DieAttachFileCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieAttachFile child in entity.DieAttachFileCollection)
					{
						if(child.DieRequestIdSource != null)
						{
							child.DieRequestId = child.DieRequestIdSource.DieRequestId;
						}
						else
						{
							child.DieRequestId = entity.DieRequestId;
						}

					}

					if (entity.DieAttachFileCollection.Count > 0 || entity.DieAttachFileCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DieAttachFileProvider.Save(transactionManager, entity.DieAttachFileCollection);
						
						deepHandles.Add("DieAttachFileCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DieAttachFile >) DataRepository.DieAttachFileProvider.DeepSave,
							new object[] { transactionManager, entity.DieAttachFileCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DieRequest>
				if (CanDeepSave(entity.DieRequestCollection, "List<DieRequest>|DieRequestCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DieRequest child in entity.DieRequestCollection)
					{
						if(child.ParentDieSource != null)
						{
							child.ParentDie = child.ParentDieSource.DieRequestId;
						}
						else
						{
							child.ParentDie = entity.DieRequestId;
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
	
	#region DieRequestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Agile.Entities.DieRequest</c>
	///</summary>
	public enum DieRequestChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>DieCategory</c> at DieCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(DieCategory))]
		DieCategory,
			
		///<summary>
		/// Composite Property for <c>DieRequest</c> at ParentDieSource
		///</summary>
		[ChildEntityType(typeof(DieRequest))]
		DieRequest,
			
		///<summary>
		/// Composite Property for <c>DieStatus</c> at DieStatusSource
		///</summary>
		[ChildEntityType(typeof(DieStatus))]
		DieStatus,
			
		///<summary>
		/// Composite Property for <c>DieType</c> at DieTypeIdSource
		///</summary>
		[ChildEntityType(typeof(DieType))]
		DieType,
			
		///<summary>
		/// Composite Property for <c>MileStole</c> at MilestoneIdSource
		///</summary>
		[ChildEntityType(typeof(MileStole))]
		MileStole,
			
		///<summary>
		/// Composite Property for <c>PriorityDieRequest</c> at PriorityDieRequestIdSource
		///</summary>
		[ChildEntityType(typeof(PriorityDieRequest))]
		PriorityDieRequest,
			
		///<summary>
		/// Composite Property for <c>Project</c> at ProjectIdSource
		///</summary>
		[ChildEntityType(typeof(Project))]
		Project,
			
		///<summary>
		/// Composite Property for <c>Release</c> at CompletedReleaseIdSource
		///</summary>
		[ChildEntityType(typeof(Release))]
		Release,
			
		///<summary>
		/// Composite Property for <c>Resolutions</c> at ResolutionsIdSource
		///</summary>
		[ChildEntityType(typeof(Resolutions))]
		Resolutions,
			
		///<summary>
		/// Composite Property for <c>User</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(User))]
		User,
	
		///<summary>
		/// Collection of <c>DieRequest</c> as OneToMany for DieAttachFileCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieAttachFile>))]
		DieAttachFileCollection,

		///<summary>
		/// Collection of <c>DieRequest</c> as OneToMany for DieRequestCollection
		///</summary>
		[ChildEntityType(typeof(TList<DieRequest>))]
		DieRequestCollection,
	}
	
	#endregion DieRequestChildEntityTypes
	
	#region DieRequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DieRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestFilterBuilder : SqlFilterBuilder<DieRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestFilterBuilder class.
		/// </summary>
		public DieRequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieRequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieRequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieRequestFilterBuilder
	
	#region DieRequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DieRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DieRequestParameterBuilder : ParameterizedSqlFilterBuilder<DieRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestParameterBuilder class.
		/// </summary>
		public DieRequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DieRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DieRequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DieRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DieRequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DieRequestParameterBuilder
	
	#region DieRequestSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DieRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DieRequest"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DieRequestSortBuilder : SqlSortBuilder<DieRequestColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DieRequestSqlSortBuilder class.
		/// </summary>
		public DieRequestSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DieRequestSortBuilder
	
} // end namespace
