
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Agile.Entities;

#endregion

namespace Agile.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current ActionTypeProviderBase instance.
		///</summary>
		public virtual ActionTypeProviderBase ActionTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PriorityDieRequestProviderBase instance.
		///</summary>
		public virtual PriorityDieRequestProviderBase PriorityDieRequestProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProjectProviderBase instance.
		///</summary>
		public virtual ProjectProviderBase ProjectProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ReleaseProviderBase instance.
		///</summary>
		public virtual ReleaseProviderBase ReleaseProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ResolutionsProviderBase instance.
		///</summary>
		public virtual ResolutionsProviderBase ResolutionsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MileStoleProviderBase instance.
		///</summary>
		public virtual MileStoleProviderBase MileStoleProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DieTypeProviderBase instance.
		///</summary>
		public virtual DieTypeProviderBase DieTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DieStatusProviderBase instance.
		///</summary>
		public virtual DieStatusProviderBase DieStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DieCategoryProviderBase instance.
		///</summary>
		public virtual DieCategoryProviderBase DieCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DieAttachFileProviderBase instance.
		///</summary>
		public virtual DieAttachFileProviderBase DieAttachFileProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DieHistoryProviderBase instance.
		///</summary>
		public virtual DieHistoryProviderBase DieHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserProviderBase instance.
		///</summary>
		public virtual UserProviderBase UserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DieRequestProviderBase instance.
		///</summary>
		public virtual DieRequestProviderBase DieRequestProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current HomeDieRequestProviderBase instance.
		///</summary>
		public virtual HomeDieRequestProviderBase HomeDieRequestProvider{get {throw new NotImplementedException();}}
		
	}
}
