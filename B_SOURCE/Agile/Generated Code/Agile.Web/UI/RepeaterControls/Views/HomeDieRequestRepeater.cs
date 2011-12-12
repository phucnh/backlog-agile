using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Agile.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>HomeDieRequestRepeater</c>
    /// </summary>
	public class HomeDieRequestRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:HomeDieRequestRepeaterDesigner"/> class.
        /// </summary>
		public HomeDieRequestRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is HomeDieRequestRepeater))
			{ 
				throw new ArgumentException("Component is not a HomeDieRequestRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			HomeDieRequestRepeater z = (HomeDieRequestRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="HomeDieRequestRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(HomeDieRequestRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:HomeDieRequestRepeater runat=\"server\"></{0}:HomeDieRequestRepeater>")]
	public class HomeDieRequestRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:HomeDieRequestRepeater"/> class.
        /// </summary>
		public HomeDieRequestRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(HomeDieRequestItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(HomeDieRequestItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
		/// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(HomeDieRequestItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }

		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(HomeDieRequestItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(HomeDieRequestItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}
		
		
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//		{
//			if (ChildControlsCreated)
//			{
//				return;
//			}
//			Controls.Clear();
//
//			if (m_headerTemplate != null)
//			{
//				Control headerItem = new Control();
//				m_headerTemplate.InstantiateIn(headerItem);
//				Controls.Add(headerItem);
//			}
//
//			
//			if (m_footerTemplate != null)
//			{
//				Control footerItem = new Control();
//				m_footerTemplate.InstantiateIn(footerItem);
//				Controls.Add(footerItem);
//			}
//			ChildControlsCreated = true;
//		}
		
		/// <summary>
      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      /// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      {
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						Agile.Entities.HomeDieRequest entity = o as Agile.Entities.HomeDieRequest;
						HomeDieRequestItem container = new HomeDieRequestItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}

							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}

							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}            
			//Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }				
		 }
			
			return pos;
		}
		
      /// <summary>
      /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
      /// </summary>
      /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class HomeDieRequestItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Agile.Entities.HomeDieRequest _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:HomeDieRequestItem"/> class.
        /// </summary>
		public HomeDieRequestItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:HomeDieRequestItem"/> class.
        /// </summary>
		public HomeDieRequestItem(Agile.Entities.HomeDieRequest entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the DieName
        /// </summary>
        /// <value>The DieName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieName
		{
			get { return _entity.DieName; }
		}
        /// <summary>
        /// Gets the DieRequestId
        /// </summary>
        /// <value>The DieRequestId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DieRequestId
		{
			get { return _entity.DieRequestId; }
		}
        /// <summary>
        /// Gets the DieTag
        /// </summary>
        /// <value>The DieTag.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieTag
		{
			get { return _entity.DieTag; }
		}
        /// <summary>
        /// Gets the DieDescription
        /// </summary>
        /// <value>The DieDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieDescription
		{
			get { return _entity.DieDescription; }
		}
        /// <summary>
        /// Gets the UpdateUserId
        /// </summary>
        /// <value>The UpdateUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UpdateUserId
		{
			get { return _entity.UpdateUserId; }
		}
        /// <summary>
        /// Gets the ProjectId
        /// </summary>
        /// <value>The ProjectId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProjectId
		{
			get { return _entity.ProjectId; }
		}
        /// <summary>
        /// Gets the DieDateSubmit
        /// </summary>
        /// <value>The DieDateSubmit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DieDateSubmit
		{
			get { return _entity.DieDateSubmit; }
		}
        /// <summary>
        /// Gets the DieNameStatus
        /// </summary>
        /// <value>The DieNameStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieNameStatus
		{
			get { return _entity.DieNameStatus; }
		}
        /// <summary>
        /// Gets the DieTypeName
        /// </summary>
        /// <value>The DieTypeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieTypeName
		{
			get { return _entity.DieTypeName; }
		}
        /// <summary>
        /// Gets the PriorityDieRequestName
        /// </summary>
        /// <value>The PriorityDieRequestName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PriorityDieRequestName
		{
			get { return _entity.PriorityDieRequestName; }
		}
        /// <summary>
        /// Gets the Color
        /// </summary>
        /// <value>The Color.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Color
		{
			get { return _entity.Color; }
		}
        /// <summary>
        /// Gets the ColorName
        /// </summary>
        /// <value>The ColorName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ColorName
		{
			get { return _entity.ColorName; }
		}
        /// <summary>
        /// Gets the DieStatus
        /// </summary>
        /// <value>The DieStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DieStatus
		{
			get { return _entity.DieStatus; }
		}
        /// <summary>
        /// Gets the UpdateTime
        /// </summary>
        /// <value>The UpdateTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdateTime
		{
			get { return _entity.UpdateTime; }
		}
        /// <summary>
        /// Gets the UpdatedUsername
        /// </summary>
        /// <value>The UpdatedUsername.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UpdatedUsername
		{
			get { return _entity.UpdatedUsername; }
		}
        /// <summary>
        /// Gets the TargetDate
        /// </summary>
        /// <value>The TargetDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? TargetDate
		{
			get { return _entity.TargetDate; }
		}
        /// <summary>
        /// Gets the Estimated
        /// </summary>
        /// <value>The Estimated.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Double? Estimated
		{
			get { return _entity.Estimated; }
		}
        /// <summary>
        /// Gets the Actual
        /// </summary>
        /// <value>The Actual.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Double? Actual
		{
			get { return _entity.Actual; }
		}
        /// <summary>
        /// Gets the UserName
        /// </summary>
        /// <value>The UserName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UserName
		{
			get { return _entity.UserName; }
		}
        /// <summary>
        /// Gets the UpdatedUserId
        /// </summary>
        /// <value>The UpdatedUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UpdatedUserId
		{
			get { return _entity.UpdatedUserId; }
		}
        /// <summary>
        /// Gets the DieSubmitDateOnly
        /// </summary>
        /// <value>The DieSubmitDateOnly.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieSubmitDateOnly
		{
			get { return _entity.DieSubmitDateOnly; }
		}

	}
}
