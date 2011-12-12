﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file ActionType.cs instead.
*/

#region using directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using Agile.Entities.Validation;
#endregion

namespace Agile.Entities
{
	///<summary>
	/// An object representation of the 'tblActionType' table. [No description found the database]	
	///</summary>
	[Serializable]
	[DataObject, CLSCompliant(true)]
	public abstract partial class ActionTypeBase : EntityBase, IActionType, IEntityId<ActionTypeKey>, System.IComparable, System.ICloneable, ICloneableEx, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private ActionTypeEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private ActionTypeEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private ActionTypeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<ActionType> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ActionTypeEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ActionTypeEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ActionTypeBase"/> instance.
		///</summary>
		public ActionTypeBase()
		{
			this.entityData = new ActionTypeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ActionTypeBase"/> instance.
		///</summary>
		///<param name="_actionTypeName"></param>
		public ActionTypeBase(System.String _actionTypeName)
		{
			this.entityData = new ActionTypeEntityData();
			this.backupData = null;

			this.ActionTypeName = _actionTypeName;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="ActionType"/> instance.
		///</summary>
		///<param name="_actionTypeName"></param>
		public static ActionType CreateActionType(System.String _actionTypeName)
		{
			ActionType newActionType = new ActionType();
			newActionType.ActionTypeName = _actionTypeName;
			return newActionType;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the ActionTypeId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>




		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 ActionTypeId
		{
			get
			{
				return this.entityData.ActionTypeId; 
			}
			
			set
			{
				if (this.entityData.ActionTypeId == value)
					return;
					
				OnColumnChanging(ActionTypeColumn.ActionTypeId, this.entityData.ActionTypeId);
				this.entityData.ActionTypeId = value;
				this.EntityId.ActionTypeId = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ActionTypeColumn.ActionTypeId, this.entityData.ActionTypeId);
				OnPropertyChanged("ActionTypeId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ActionTypeName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 100)]
		public virtual System.String ActionTypeName
		{
			get
			{
				return this.entityData.ActionTypeName; 
			}
			
			set
			{
				if (this.entityData.ActionTypeName == value)
					return;
					
				OnColumnChanging(ActionTypeColumn.ActionTypeName, this.entityData.ActionTypeName);
				this.entityData.ActionTypeName = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(ActionTypeColumn.ActionTypeName, this.entityData.ActionTypeName);
				OnPropertyChanged("ActionTypeName");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
		#endregion Children Collections
		
		#endregion
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("ActionTypeName", "Action Type Name", 100));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "tblActionType"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ActionTypeID", "ActionTypeName"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as ActionTypeEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (ActionType) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<ActionType>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as ActionType);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed ActionType Entity 
		///</summary>
		protected virtual ActionType Copy(IDictionary existingCopies)
		{
			if (existingCopies == null)
			{
				// This is the root of the tree to be copied!
				existingCopies = new Hashtable();
			}

			//shallow copy entity
			ActionType copy = new ActionType();
			existingCopies.Add(this, copy);
			copy.SuppressEntityEvents = true;
				copy.ActionTypeId = this.ActionTypeId;
				copy.ActionTypeName = this.ActionTypeName;
			
		
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}		
		
		
		
		///<summary>
		///  Returns a Typed ActionType Entity 
		///</summary>
		public virtual ActionType Copy()
		{
			return this.Copy(null);	
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy(null);
		}
		
		///<summary>
		/// ICloneableEx.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone(IDictionary existingCopies)
		{
			return this.Copy(existingCopies);
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x, IDictionary existingCopies)
		{
			if (x == null)
				return null;
			
			if (x is ICloneableEx)
			{
				// Return a deep copy of the object
				return ((ICloneableEx)x).Clone(existingCopies);
			}
			else if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable or IClonableEx Interface.");
		}
		
		
		///<summary>
		///  Returns a Typed ActionType Entity which is a deep copy of the current entity.
		///</summary>
		public virtual ActionType DeepCopy()
		{
			return EntityHelper.Clone<ActionType>(this as ActionType);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as ActionTypeEntityData;
			}
			else
			{
				//Since this had no _originalData, then just reset the entityData with a new one.  entityData cannot be null.
				this.entityData = new ActionTypeEntityData();
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as ActionTypeEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(ActionTypeColumn column)
		{
			switch(column)
			{
					case ActionTypeColumn.ActionTypeId:
					return entityData.ActionTypeId != _originalData.ActionTypeId;
					case ActionTypeColumn.ActionTypeName:
					return entityData.ActionTypeName != _originalData.ActionTypeName;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="columnName">The column name.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public override bool IsPropertyChanged(string columnName)
		{
			return 	IsPropertyChanged(EntityHelper.GetEnumValue< ActionTypeColumn >(columnName));
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if data has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.ActionTypeId != _originalData.ActionTypeId;
			result = result || entityData.ActionTypeName != _originalData.ActionTypeName;
			return result;
		}	
		
		///<summary>
		///  Returns a ActionType Entity with the original data.
		///</summary>
		public ActionType GetOriginalEntity()
		{
			if (_originalData != null)
				return CreateActionType(
				_originalData.ActionTypeName
				);
				
			return (ActionType)this.Clone();
		}
		#endregion
	
	#region Value Semantics Instance Equality
        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object using value semantics.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="ActionTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			// Cast exception if Object1 is null or DbNull
			if (Object1 != null && Object1 != DBNull.Value && Object1 is ActionTypeBase)
				return ValueEquals(this, (ActionTypeBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="ActionTypeBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.ActionTypeId.GetHashCode() ^ 
					((this.ActionTypeName == null) ? string.Empty : this.ActionTypeName.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object using value semantics.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ActionTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ActionTypeBase toObject)
		{
			if (toObject == null)
				return false;
			return ValueEquals(this, toObject);
		}
		#endregion
		
		///<summary>
		/// Determines whether the specified <see cref="ActionTypeBase"/> instances are considered equal using value semantics.
		///</summary>
		///<param name="Object1">The first <see cref="ActionTypeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ActionTypeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool ValueEquals(ActionTypeBase Object1, ActionTypeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ActionTypeId != Object2.ActionTypeId)
				equal = false;
			if ( Object1.ActionTypeName != null && Object2.ActionTypeName != null )
			{
				if (Object1.ActionTypeName != Object2.ActionTypeName)
					equal = false;
			}
			else if (Object1.ActionTypeName == null ^ Object2.ActionTypeName == null )
			{
				equal = false;
			}
					
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((ActionTypeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static ActionTypeComparer GetComparer()
        {
            return new ActionTypeComparer();
        }
        */

        // Comparer delegates back to ActionType
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(ActionType rhs, ActionTypeColumn which)
        {
            switch (which)
            {
            	
            	
            	case ActionTypeColumn.ActionTypeId:
            		return this.ActionTypeId.CompareTo(rhs.ActionTypeId);
            		
            		                 
            	
            	
            	case ActionTypeColumn.ActionTypeName:
            		return this.ActionTypeName.CompareTo(rhs.ActionTypeName);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<ActionTypeKey> Members
		
		// member variable for the EntityId property
		private ActionTypeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual ActionTypeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ActionTypeKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("ActionType")
					.Append("|").Append( this.ActionTypeId.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- ActionTypeId: {0}{2}- ActionTypeName: {1}{2}{4}", 
				this.ActionTypeId,
				(this.ActionTypeName == null) ? string.Empty : this.ActionTypeName.ToString(),
				System.Environment.NewLine, 
				this.GetType(),
				this.Error.Length == 0 ? string.Empty : string.Format("- Error: {0}\n",this.Error));
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'tblActionType' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class ActionTypeEntityData : ICloneable, ICloneableEx
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
		/// <summary>			
		/// ActionTypeID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblActionType"</remarks>
		public System.Int32 ActionTypeId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// ActionTypeName : 
		/// </summary>
		public System.String		  ActionTypeName = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			ActionTypeEntityData _tmp = new ActionTypeEntityData();
						
			_tmp.ActionTypeId = this.ActionTypeId;
			
			_tmp.ActionTypeName = this.ActionTypeName;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone(IDictionary existingCopies)
		{
			if (existingCopies == null)
				existingCopies = new Hashtable();
				
			ActionTypeEntityData _tmp = new ActionTypeEntityData();
						
			_tmp.ActionTypeId = this.ActionTypeId;
			
			_tmp.ActionTypeName = this.ActionTypeName;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct











		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ActionTypeColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanging(ActionTypeColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ActionTypeColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanged(ActionTypeColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ActionTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanging(ActionTypeColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ActionTypeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ActionTypeEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ActionTypeColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanged(ActionTypeColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				ActionTypeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ActionTypeEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region ActionTypeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="ActionType"/> object.
	/// </remarks>
	public class ActionTypeEventArgs : System.EventArgs
	{
		private ActionTypeColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the ActionTypeEventArgs class.
		///</summary>
		public ActionTypeEventArgs(ActionTypeColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the ActionTypeEventArgs class.
		///</summary>
		public ActionTypeEventArgs(ActionTypeColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The ActionTypeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ActionTypeColumn" />
		public ActionTypeColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all ActionType related events.
	///</summary>
	public delegate void ActionTypeEventHandler(object sender, ActionTypeEventArgs e);
	
	#region ActionTypeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ActionTypeComparer : System.Collections.Generic.IComparer<ActionType>
	{
		ActionTypeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ActionTypeComparer"/> class.
        /// </summary>
		public ActionTypeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ActionTypeComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ActionTypeComparer(ActionTypeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="ActionType"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="ActionType"/> to compare.</param>
        /// <param name="b">The second <c>ActionType</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(ActionType a, ActionType b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(ActionType entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(ActionType a, ActionType b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ActionTypeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ActionTypeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="ActionType"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ActionTypeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ActionTypeKey class.
		/// </summary>
		public ActionTypeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ActionTypeKey class.
		/// </summary>
		public ActionTypeKey(ActionTypeBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.ActionTypeId = entity.ActionTypeId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ActionTypeKey class.
		/// </summary>
		public ActionTypeKey(System.Int32 _actionTypeId)
		{
			#region Init Properties

			this.ActionTypeId = _actionTypeId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ActionTypeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ActionTypeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ActionTypeId property
		private System.Int32 _actionTypeId;
		
		/// <summary>
		/// Gets or sets the ActionTypeId property.
		/// </summary>
		public System.Int32 ActionTypeId
		{
			get { return _actionTypeId; }
			set
			{
				if ( this.Entity != null )
					this.Entity.ActionTypeId = value;
				
				_actionTypeId = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				ActionTypeId = ( values["ActionTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ActionTypeId"], typeof(System.Int32)) : (int)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("ActionTypeId", ActionTypeId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ActionTypeId: {0}{1}",
								ActionTypeId,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region ActionTypeColumn Enum
	
	/// <summary>
	/// Enumerate the ActionType columns.
	/// </summary>
	[Serializable]
	public enum ActionTypeColumn : int
	{
		/// <summary>
		/// ActionTypeId : 
		/// </summary>
		[EnumTextValue("ActionTypeID")]
		[ColumnEnum("ActionTypeID", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		ActionTypeId = 1,
		/// <summary>
		/// ActionTypeName : 
		/// </summary>
		[EnumTextValue("ActionTypeName")]
		[ColumnEnum("ActionTypeName", typeof(System.String), System.Data.DbType.String, false, false, true, 100)]
		ActionTypeName = 2
	}//End enum

	#endregion ActionTypeColumn Enum

} // end namespace
