﻿using System;
using System.ComponentModel;

namespace Agile.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblRelease' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IRelease 
	{
		/// <summary>			
		/// ReleaseID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblRelease"</remarks>
		System.Int32 ReleaseId { get; set; }
				
		
		
		/// <summary>
		/// ProjectID : 
		/// </summary>
		System.Int32  ProjectId  { get; set; }
		
		/// <summary>
		/// ReleaseDate : 
		/// </summary>
		System.DateTime  ReleaseDate  { get; set; }
		
		/// <summary>
		/// ReleaseName : 
		/// </summary>
		System.String  ReleaseName  { get; set; }
		
		/// <summary>
		/// ReleaseNote : 
		/// </summary>
		System.String  ReleaseNote  { get; set; }
		
		/// <summary>
		/// Active : 
		/// </summary>
		System.Boolean?  Active  { get; set; }
		
		/// <summary>
		/// UserID : 
		/// </summary>
		System.Int32?  UserId  { get; set; }
		
		/// <summary>
		/// LastUserUpdate : 
		/// </summary>
		System.Int32?  LastUserUpdate  { get; set; }
		
		/// <summary>
		/// LastDateUpdate : 
		/// </summary>
		System.DateTime?  LastDateUpdate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _dieRequestCompletedReleaseId
		/// </summary>	
		TList<DieRequest> DieRequestCollection {  get;  set;}	

		#endregion Data Properties

	}
}


