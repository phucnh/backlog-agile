﻿using System;
using System.ComponentModel;

namespace Agile.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblPriorityDIERequest' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IPriorityDieRequest 
	{
		/// <summary>			
		/// PriorityDIERequestID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblPriorityDIERequest"</remarks>
		System.Int32 PriorityDieRequestId { get; set; }
				
		
		
		/// <summary>
		/// PriorityDIERequestName : 
		/// </summary>
		System.String  PriorityDieRequestName  { get; set; }
		
		/// <summary>
		/// PriorityDIERequestDescription : 
		/// </summary>
		System.String  PriorityDieRequestDescription  { get; set; }
		
		/// <summary>
		/// Color : 
		/// </summary>
		System.String  Color  { get; set; }
		
		/// <summary>
		/// ColorName : 
		/// </summary>
		System.String  ColorName  { get; set; }
		
		/// <summary>
		/// PriorityDIERequestOrder : 
		/// </summary>
		System.Int32?  PriorityDieRequestOrder  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _dieRequestPriorityDieRequestId
		/// </summary>	
		TList<DieRequest> DieRequestCollection {  get;  set;}	

		#endregion Data Properties

	}
}

