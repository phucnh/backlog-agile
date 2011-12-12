﻿using System;
using System.ComponentModel;

namespace Agile.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblDIECategory' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IDieCategory 
	{
		/// <summary>			
		/// DIECategoryID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblDIECategory"</remarks>
		System.Int32 DieCategoryId { get; set; }
				
		
		
		/// <summary>
		/// DIECategoryName : 
		/// </summary>
		System.String  DieCategoryName  { get; set; }
		
		/// <summary>
		/// DEICategoryDescription : 
		/// </summary>
		System.String  DeiCategoryDescription  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _dieRequestDieCategoryId
		/// </summary>	
		TList<DieRequest> DieRequestCollection {  get;  set;}	

		#endregion Data Properties

	}
}


