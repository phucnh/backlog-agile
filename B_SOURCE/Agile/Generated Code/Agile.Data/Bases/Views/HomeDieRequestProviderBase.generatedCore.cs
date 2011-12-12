#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Agile.Entities;
using Agile.Data;

#endregion

namespace Agile.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="HomeDieRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class HomeDieRequestProviderBaseCore : EntityViewProviderBase<HomeDieRequest>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;HomeDieRequest&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;HomeDieRequest&gt;"/></returns>
		protected static VList&lt;HomeDieRequest&gt; Fill(DataSet dataSet, VList<HomeDieRequest> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<HomeDieRequest>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;HomeDieRequest&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<HomeDieRequest>"/></returns>
		protected static VList&lt;HomeDieRequest&gt; Fill(DataTable dataTable, VList<HomeDieRequest> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					HomeDieRequest c = new HomeDieRequest();
					c.DieName = (Convert.IsDBNull(row["DIEName"]))?string.Empty:(System.String)row["DIEName"];
					c.DieRequestId = (Convert.IsDBNull(row["DIERequestID"]))?(int)0:(System.Int32)row["DIERequestID"];
					c.DieTag = (Convert.IsDBNull(row["DIETag"]))?string.Empty:(System.String)row["DIETag"];
					c.DieDescription = (Convert.IsDBNull(row["DIEDescription"]))?string.Empty:(System.String)row["DIEDescription"];
					c.UpdateUserId = (Convert.IsDBNull(row["UpdateUserID"]))?(int)0:(System.Int32?)row["UpdateUserID"];
					c.ProjectId = (Convert.IsDBNull(row["ProjectID"]))?(int)0:(System.Int32?)row["ProjectID"];
					c.DieDateSubmit = (Convert.IsDBNull(row["DIEDateSubmit"]))?DateTime.MinValue:(System.DateTime?)row["DIEDateSubmit"];
					c.DieNameStatus = (Convert.IsDBNull(row["DIENameStatus"]))?string.Empty:(System.String)row["DIENameStatus"];
					c.DieTypeName = (Convert.IsDBNull(row["DIETypeName"]))?string.Empty:(System.String)row["DIETypeName"];
					c.PriorityDieRequestName = (Convert.IsDBNull(row["PriorityDIERequestName"]))?string.Empty:(System.String)row["PriorityDIERequestName"];
					c.Color = (Convert.IsDBNull(row["Color"]))?string.Empty:(System.String)row["Color"];
					c.ColorName = (Convert.IsDBNull(row["ColorName"]))?string.Empty:(System.String)row["ColorName"];
					c.DieStatus = (Convert.IsDBNull(row["DIEStatus"]))?(int)0:(System.Int32?)row["DIEStatus"];
					c.UpdateTime = (Convert.IsDBNull(row["UpdateTime"]))?DateTime.MinValue:(System.DateTime?)row["UpdateTime"];
					c.UpdatedUsername = (Convert.IsDBNull(row["UpdatedUsername"]))?(int)0:(System.Int32?)row["UpdatedUsername"];
					c.TargetDate = (Convert.IsDBNull(row["TargetDate"]))?DateTime.MinValue:(System.DateTime?)row["TargetDate"];
					c.Estimated = (Convert.IsDBNull(row["Estimated"]))?0.0f:(System.Double?)row["Estimated"];
					c.Actual = (Convert.IsDBNull(row["Actual"]))?0.0f:(System.Double?)row["Actual"];
					c.UserName = (Convert.IsDBNull(row["UserName"]))?string.Empty:(System.String)row["UserName"];
					c.UpdatedUserId = (Convert.IsDBNull(row["UpdatedUserID"]))?(int)0:(System.Int32)row["UpdatedUserID"];
					c.DieSubmitDateOnly = (Convert.IsDBNull(row["DIESubmitDateOnly"]))?string.Empty:(System.String)row["DIESubmitDateOnly"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;HomeDieRequest&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;HomeDieRequest&gt;"/></returns>
		protected VList<HomeDieRequest> Fill(IDataReader reader, VList<HomeDieRequest> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					HomeDieRequest entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<HomeDieRequest>("HomeDieRequest",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new HomeDieRequest();
					}
					
					entity.SuppressEntityEvents = true;

					entity.DieName = (reader.IsDBNull(((int)HomeDieRequestColumn.DieName)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieName)];
					//entity.DieName = (Convert.IsDBNull(reader["DIEName"]))?string.Empty:(System.String)reader["DIEName"];
					entity.DieRequestId = (System.Int32)reader[((int)HomeDieRequestColumn.DieRequestId)];
					//entity.DieRequestId = (Convert.IsDBNull(reader["DIERequestID"]))?(int)0:(System.Int32)reader["DIERequestID"];
					entity.DieTag = (reader.IsDBNull(((int)HomeDieRequestColumn.DieTag)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieTag)];
					//entity.DieTag = (Convert.IsDBNull(reader["DIETag"]))?string.Empty:(System.String)reader["DIETag"];
					entity.DieDescription = (reader.IsDBNull(((int)HomeDieRequestColumn.DieDescription)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieDescription)];
					//entity.DieDescription = (Convert.IsDBNull(reader["DIEDescription"]))?string.Empty:(System.String)reader["DIEDescription"];
					entity.UpdateUserId = (reader.IsDBNull(((int)HomeDieRequestColumn.UpdateUserId)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.UpdateUserId)];
					//entity.UpdateUserId = (Convert.IsDBNull(reader["UpdateUserID"]))?(int)0:(System.Int32?)reader["UpdateUserID"];
					entity.ProjectId = (reader.IsDBNull(((int)HomeDieRequestColumn.ProjectId)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.ProjectId)];
					//entity.ProjectId = (Convert.IsDBNull(reader["ProjectID"]))?(int)0:(System.Int32?)reader["ProjectID"];
					entity.DieDateSubmit = (reader.IsDBNull(((int)HomeDieRequestColumn.DieDateSubmit)))?null:(System.DateTime?)reader[((int)HomeDieRequestColumn.DieDateSubmit)];
					//entity.DieDateSubmit = (Convert.IsDBNull(reader["DIEDateSubmit"]))?DateTime.MinValue:(System.DateTime?)reader["DIEDateSubmit"];
					entity.DieNameStatus = (reader.IsDBNull(((int)HomeDieRequestColumn.DieNameStatus)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieNameStatus)];
					//entity.DieNameStatus = (Convert.IsDBNull(reader["DIENameStatus"]))?string.Empty:(System.String)reader["DIENameStatus"];
					entity.DieTypeName = (reader.IsDBNull(((int)HomeDieRequestColumn.DieTypeName)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieTypeName)];
					//entity.DieTypeName = (Convert.IsDBNull(reader["DIETypeName"]))?string.Empty:(System.String)reader["DIETypeName"];
					entity.PriorityDieRequestName = (reader.IsDBNull(((int)HomeDieRequestColumn.PriorityDieRequestName)))?null:(System.String)reader[((int)HomeDieRequestColumn.PriorityDieRequestName)];
					//entity.PriorityDieRequestName = (Convert.IsDBNull(reader["PriorityDIERequestName"]))?string.Empty:(System.String)reader["PriorityDIERequestName"];
					entity.Color = (reader.IsDBNull(((int)HomeDieRequestColumn.Color)))?null:(System.String)reader[((int)HomeDieRequestColumn.Color)];
					//entity.Color = (Convert.IsDBNull(reader["Color"]))?string.Empty:(System.String)reader["Color"];
					entity.ColorName = (reader.IsDBNull(((int)HomeDieRequestColumn.ColorName)))?null:(System.String)reader[((int)HomeDieRequestColumn.ColorName)];
					//entity.ColorName = (Convert.IsDBNull(reader["ColorName"]))?string.Empty:(System.String)reader["ColorName"];
					entity.DieStatus = (reader.IsDBNull(((int)HomeDieRequestColumn.DieStatus)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.DieStatus)];
					//entity.DieStatus = (Convert.IsDBNull(reader["DIEStatus"]))?(int)0:(System.Int32?)reader["DIEStatus"];
					entity.UpdateTime = (reader.IsDBNull(((int)HomeDieRequestColumn.UpdateTime)))?null:(System.DateTime?)reader[((int)HomeDieRequestColumn.UpdateTime)];
					//entity.UpdateTime = (Convert.IsDBNull(reader["UpdateTime"]))?DateTime.MinValue:(System.DateTime?)reader["UpdateTime"];
					entity.UpdatedUsername = (reader.IsDBNull(((int)HomeDieRequestColumn.UpdatedUsername)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.UpdatedUsername)];
					//entity.UpdatedUsername = (Convert.IsDBNull(reader["UpdatedUsername"]))?(int)0:(System.Int32?)reader["UpdatedUsername"];
					entity.TargetDate = (reader.IsDBNull(((int)HomeDieRequestColumn.TargetDate)))?null:(System.DateTime?)reader[((int)HomeDieRequestColumn.TargetDate)];
					//entity.TargetDate = (Convert.IsDBNull(reader["TargetDate"]))?DateTime.MinValue:(System.DateTime?)reader["TargetDate"];
					entity.Estimated = (reader.IsDBNull(((int)HomeDieRequestColumn.Estimated)))?null:(System.Double?)reader[((int)HomeDieRequestColumn.Estimated)];
					//entity.Estimated = (Convert.IsDBNull(reader["Estimated"]))?0.0f:(System.Double?)reader["Estimated"];
					entity.Actual = (reader.IsDBNull(((int)HomeDieRequestColumn.Actual)))?null:(System.Double?)reader[((int)HomeDieRequestColumn.Actual)];
					//entity.Actual = (Convert.IsDBNull(reader["Actual"]))?0.0f:(System.Double?)reader["Actual"];
					entity.UserName = (System.String)reader[((int)HomeDieRequestColumn.UserName)];
					//entity.UserName = (Convert.IsDBNull(reader["UserName"]))?string.Empty:(System.String)reader["UserName"];
					entity.UpdatedUserId = (System.Int32)reader[((int)HomeDieRequestColumn.UpdatedUserId)];
					//entity.UpdatedUserId = (Convert.IsDBNull(reader["UpdatedUserID"]))?(int)0:(System.Int32)reader["UpdatedUserID"];
					entity.DieSubmitDateOnly = (reader.IsDBNull(((int)HomeDieRequestColumn.DieSubmitDateOnly)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieSubmitDateOnly)];
					//entity.DieSubmitDateOnly = (Convert.IsDBNull(reader["DIESubmitDateOnly"]))?string.Empty:(System.String)reader["DIESubmitDateOnly"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="HomeDieRequest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HomeDieRequest"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, HomeDieRequest entity)
		{
			reader.Read();
			entity.DieName = (reader.IsDBNull(((int)HomeDieRequestColumn.DieName)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieName)];
			//entity.DieName = (Convert.IsDBNull(reader["DIEName"]))?string.Empty:(System.String)reader["DIEName"];
			entity.DieRequestId = (System.Int32)reader[((int)HomeDieRequestColumn.DieRequestId)];
			//entity.DieRequestId = (Convert.IsDBNull(reader["DIERequestID"]))?(int)0:(System.Int32)reader["DIERequestID"];
			entity.DieTag = (reader.IsDBNull(((int)HomeDieRequestColumn.DieTag)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieTag)];
			//entity.DieTag = (Convert.IsDBNull(reader["DIETag"]))?string.Empty:(System.String)reader["DIETag"];
			entity.DieDescription = (reader.IsDBNull(((int)HomeDieRequestColumn.DieDescription)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieDescription)];
			//entity.DieDescription = (Convert.IsDBNull(reader["DIEDescription"]))?string.Empty:(System.String)reader["DIEDescription"];
			entity.UpdateUserId = (reader.IsDBNull(((int)HomeDieRequestColumn.UpdateUserId)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.UpdateUserId)];
			//entity.UpdateUserId = (Convert.IsDBNull(reader["UpdateUserID"]))?(int)0:(System.Int32?)reader["UpdateUserID"];
			entity.ProjectId = (reader.IsDBNull(((int)HomeDieRequestColumn.ProjectId)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.ProjectId)];
			//entity.ProjectId = (Convert.IsDBNull(reader["ProjectID"]))?(int)0:(System.Int32?)reader["ProjectID"];
			entity.DieDateSubmit = (reader.IsDBNull(((int)HomeDieRequestColumn.DieDateSubmit)))?null:(System.DateTime?)reader[((int)HomeDieRequestColumn.DieDateSubmit)];
			//entity.DieDateSubmit = (Convert.IsDBNull(reader["DIEDateSubmit"]))?DateTime.MinValue:(System.DateTime?)reader["DIEDateSubmit"];
			entity.DieNameStatus = (reader.IsDBNull(((int)HomeDieRequestColumn.DieNameStatus)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieNameStatus)];
			//entity.DieNameStatus = (Convert.IsDBNull(reader["DIENameStatus"]))?string.Empty:(System.String)reader["DIENameStatus"];
			entity.DieTypeName = (reader.IsDBNull(((int)HomeDieRequestColumn.DieTypeName)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieTypeName)];
			//entity.DieTypeName = (Convert.IsDBNull(reader["DIETypeName"]))?string.Empty:(System.String)reader["DIETypeName"];
			entity.PriorityDieRequestName = (reader.IsDBNull(((int)HomeDieRequestColumn.PriorityDieRequestName)))?null:(System.String)reader[((int)HomeDieRequestColumn.PriorityDieRequestName)];
			//entity.PriorityDieRequestName = (Convert.IsDBNull(reader["PriorityDIERequestName"]))?string.Empty:(System.String)reader["PriorityDIERequestName"];
			entity.Color = (reader.IsDBNull(((int)HomeDieRequestColumn.Color)))?null:(System.String)reader[((int)HomeDieRequestColumn.Color)];
			//entity.Color = (Convert.IsDBNull(reader["Color"]))?string.Empty:(System.String)reader["Color"];
			entity.ColorName = (reader.IsDBNull(((int)HomeDieRequestColumn.ColorName)))?null:(System.String)reader[((int)HomeDieRequestColumn.ColorName)];
			//entity.ColorName = (Convert.IsDBNull(reader["ColorName"]))?string.Empty:(System.String)reader["ColorName"];
			entity.DieStatus = (reader.IsDBNull(((int)HomeDieRequestColumn.DieStatus)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.DieStatus)];
			//entity.DieStatus = (Convert.IsDBNull(reader["DIEStatus"]))?(int)0:(System.Int32?)reader["DIEStatus"];
			entity.UpdateTime = (reader.IsDBNull(((int)HomeDieRequestColumn.UpdateTime)))?null:(System.DateTime?)reader[((int)HomeDieRequestColumn.UpdateTime)];
			//entity.UpdateTime = (Convert.IsDBNull(reader["UpdateTime"]))?DateTime.MinValue:(System.DateTime?)reader["UpdateTime"];
			entity.UpdatedUsername = (reader.IsDBNull(((int)HomeDieRequestColumn.UpdatedUsername)))?null:(System.Int32?)reader[((int)HomeDieRequestColumn.UpdatedUsername)];
			//entity.UpdatedUsername = (Convert.IsDBNull(reader["UpdatedUsername"]))?(int)0:(System.Int32?)reader["UpdatedUsername"];
			entity.TargetDate = (reader.IsDBNull(((int)HomeDieRequestColumn.TargetDate)))?null:(System.DateTime?)reader[((int)HomeDieRequestColumn.TargetDate)];
			//entity.TargetDate = (Convert.IsDBNull(reader["TargetDate"]))?DateTime.MinValue:(System.DateTime?)reader["TargetDate"];
			entity.Estimated = (reader.IsDBNull(((int)HomeDieRequestColumn.Estimated)))?null:(System.Double?)reader[((int)HomeDieRequestColumn.Estimated)];
			//entity.Estimated = (Convert.IsDBNull(reader["Estimated"]))?0.0f:(System.Double?)reader["Estimated"];
			entity.Actual = (reader.IsDBNull(((int)HomeDieRequestColumn.Actual)))?null:(System.Double?)reader[((int)HomeDieRequestColumn.Actual)];
			//entity.Actual = (Convert.IsDBNull(reader["Actual"]))?0.0f:(System.Double?)reader["Actual"];
			entity.UserName = (System.String)reader[((int)HomeDieRequestColumn.UserName)];
			//entity.UserName = (Convert.IsDBNull(reader["UserName"]))?string.Empty:(System.String)reader["UserName"];
			entity.UpdatedUserId = (System.Int32)reader[((int)HomeDieRequestColumn.UpdatedUserId)];
			//entity.UpdatedUserId = (Convert.IsDBNull(reader["UpdatedUserID"]))?(int)0:(System.Int32)reader["UpdatedUserID"];
			entity.DieSubmitDateOnly = (reader.IsDBNull(((int)HomeDieRequestColumn.DieSubmitDateOnly)))?null:(System.String)reader[((int)HomeDieRequestColumn.DieSubmitDateOnly)];
			//entity.DieSubmitDateOnly = (Convert.IsDBNull(reader["DIESubmitDateOnly"]))?string.Empty:(System.String)reader["DIESubmitDateOnly"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="HomeDieRequest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HomeDieRequest"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, HomeDieRequest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DieName = (Convert.IsDBNull(dataRow["DIEName"]))?string.Empty:(System.String)dataRow["DIEName"];
			entity.DieRequestId = (Convert.IsDBNull(dataRow["DIERequestID"]))?(int)0:(System.Int32)dataRow["DIERequestID"];
			entity.DieTag = (Convert.IsDBNull(dataRow["DIETag"]))?string.Empty:(System.String)dataRow["DIETag"];
			entity.DieDescription = (Convert.IsDBNull(dataRow["DIEDescription"]))?string.Empty:(System.String)dataRow["DIEDescription"];
			entity.UpdateUserId = (Convert.IsDBNull(dataRow["UpdateUserID"]))?(int)0:(System.Int32?)dataRow["UpdateUserID"];
			entity.ProjectId = (Convert.IsDBNull(dataRow["ProjectID"]))?(int)0:(System.Int32?)dataRow["ProjectID"];
			entity.DieDateSubmit = (Convert.IsDBNull(dataRow["DIEDateSubmit"]))?DateTime.MinValue:(System.DateTime?)dataRow["DIEDateSubmit"];
			entity.DieNameStatus = (Convert.IsDBNull(dataRow["DIENameStatus"]))?string.Empty:(System.String)dataRow["DIENameStatus"];
			entity.DieTypeName = (Convert.IsDBNull(dataRow["DIETypeName"]))?string.Empty:(System.String)dataRow["DIETypeName"];
			entity.PriorityDieRequestName = (Convert.IsDBNull(dataRow["PriorityDIERequestName"]))?string.Empty:(System.String)dataRow["PriorityDIERequestName"];
			entity.Color = (Convert.IsDBNull(dataRow["Color"]))?string.Empty:(System.String)dataRow["Color"];
			entity.ColorName = (Convert.IsDBNull(dataRow["ColorName"]))?string.Empty:(System.String)dataRow["ColorName"];
			entity.DieStatus = (Convert.IsDBNull(dataRow["DIEStatus"]))?(int)0:(System.Int32?)dataRow["DIEStatus"];
			entity.UpdateTime = (Convert.IsDBNull(dataRow["UpdateTime"]))?DateTime.MinValue:(System.DateTime?)dataRow["UpdateTime"];
			entity.UpdatedUsername = (Convert.IsDBNull(dataRow["UpdatedUsername"]))?(int)0:(System.Int32?)dataRow["UpdatedUsername"];
			entity.TargetDate = (Convert.IsDBNull(dataRow["TargetDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["TargetDate"];
			entity.Estimated = (Convert.IsDBNull(dataRow["Estimated"]))?0.0f:(System.Double?)dataRow["Estimated"];
			entity.Actual = (Convert.IsDBNull(dataRow["Actual"]))?0.0f:(System.Double?)dataRow["Actual"];
			entity.UserName = (Convert.IsDBNull(dataRow["UserName"]))?string.Empty:(System.String)dataRow["UserName"];
			entity.UpdatedUserId = (Convert.IsDBNull(dataRow["UpdatedUserID"]))?(int)0:(System.Int32)dataRow["UpdatedUserID"];
			entity.DieSubmitDateOnly = (Convert.IsDBNull(dataRow["DIESubmitDateOnly"]))?string.Empty:(System.String)dataRow["DIESubmitDateOnly"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region HomeDieRequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HomeDieRequestFilterBuilder : SqlFilterBuilder<HomeDieRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestFilterBuilder class.
		/// </summary>
		public HomeDieRequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HomeDieRequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HomeDieRequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HomeDieRequestFilterBuilder

	#region HomeDieRequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class HomeDieRequestParameterBuilder : ParameterizedSqlFilterBuilder<HomeDieRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestParameterBuilder class.
		/// </summary>
		public HomeDieRequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public HomeDieRequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public HomeDieRequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion HomeDieRequestParameterBuilder
	
	#region HomeDieRequestSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="HomeDieRequest"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class HomeDieRequestSortBuilder : SqlSortBuilder<HomeDieRequestColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the HomeDieRequestSqlSortBuilder class.
		/// </summary>
		public HomeDieRequestSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion HomeDieRequestSortBuilder

} // end namespace
