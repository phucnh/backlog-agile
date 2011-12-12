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
    /// A designer class for a strongly typed repeater <c>DieHistoryRepeater</c>
    /// </summary>
	public class DieHistoryRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:DieHistoryRepeaterDesigner"/> class.
        /// </summary>
		public DieHistoryRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is DieHistoryRepeater))
			{ 
				throw new ArgumentException("Component is not a DieHistoryRepeater."); 
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
			DieHistoryRepeater z = (DieHistoryRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="DieHistoryRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(DieHistoryRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:DieHistoryRepeater runat=\"server\"></{0}:DieHistoryRepeater>")]
	public class DieHistoryRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:DieHistoryRepeater"/> class.
        /// </summary>
		public DieHistoryRepeater()
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
		[TemplateContainer(typeof(DieHistoryItem))]
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
		[TemplateContainer(typeof(DieHistoryItem))]
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
        [TemplateContainer(typeof(DieHistoryItem))]
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
		[TemplateContainer(typeof(DieHistoryItem))]
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
		[TemplateContainer(typeof(DieHistoryItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
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
						Agile.Entities.DieHistory entity = o as Agile.Entities.DieHistory;
						DieHistoryItem container = new DieHistoryItem(entity);
	
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
	public class DieHistoryItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Agile.Entities.DieHistory _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DieHistoryItem"/> class.
        /// </summary>
		public DieHistoryItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DieHistoryItem"/> class.
        /// </summary>
		public DieHistoryItem(Agile.Entities.DieHistory entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the DieHistoryId
        /// </summary>
        /// <value>The DieHistoryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DieHistoryId
		{
			get { return _entity.DieHistoryId; }
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
        /// Gets the DieDateSubmit
        /// </summary>
        /// <value>The DieDateSubmit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime DieDateSubmit
		{
			get { return _entity.DieDateSubmit; }
		}
        /// <summary>
        /// Gets the DieStatus
        /// </summary>
        /// <value>The DieStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int16 DieStatus
		{
			get { return _entity.DieStatus; }
		}
        /// <summary>
        /// Gets the DieHistoryNote
        /// </summary>
        /// <value>The DieHistoryNote.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieHistoryNote
		{
			get { return _entity.DieHistoryNote; }
		}
        /// <summary>
        /// Gets the DieHistoryNoteJp
        /// </summary>
        /// <value>The DieHistoryNoteJp.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DieHistoryNoteJp
		{
			get { return _entity.DieHistoryNoteJp; }
		}
        /// <summary>
        /// Gets the ReleaseId
        /// </summary>
        /// <value>The ReleaseId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ReleaseId
		{
			get { return _entity.ReleaseId; }
		}
        /// <summary>
        /// Gets the UserId
        /// </summary>
        /// <value>The UserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UserId
		{
			get { return _entity.UserId; }
		}
        /// <summary>
        /// Gets the Owner
        /// </summary>
        /// <value>The Owner.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Owner
		{
			get { return _entity.Owner; }
		}
        /// <summary>
        /// Gets the LastUserUpdate
        /// </summary>
        /// <value>The LastUserUpdate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? LastUserUpdate
		{
			get { return _entity.LastUserUpdate; }
		}
        /// <summary>
        /// Gets the LastTimeUpdate
        /// </summary>
        /// <value>The LastTimeUpdate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? LastTimeUpdate
		{
			get { return _entity.LastTimeUpdate; }
		}
        /// <summary>
        /// Gets the ActionTypeId
        /// </summary>
        /// <value>The ActionTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ActionTypeId
		{
			get { return _entity.ActionTypeId; }
		}

        /// <summary>
        /// Gets a <see cref="T:Agile.Entities.DieHistory"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Agile.Entities.DieHistory Entity
        {
            get { return _entity; }
        }
	}
}
