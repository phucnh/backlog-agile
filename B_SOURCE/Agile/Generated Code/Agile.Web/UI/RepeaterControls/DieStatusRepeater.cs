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
    /// A designer class for a strongly typed repeater <c>DieStatusRepeater</c>
    /// </summary>
	public class DieStatusRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:DieStatusRepeaterDesigner"/> class.
        /// </summary>
		public DieStatusRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is DieStatusRepeater))
			{ 
				throw new ArgumentException("Component is not a DieStatusRepeater."); 
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
			DieStatusRepeater z = (DieStatusRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="DieStatusRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(DieStatusRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:DieStatusRepeater runat=\"server\"></{0}:DieStatusRepeater>")]
	public class DieStatusRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:DieStatusRepeater"/> class.
        /// </summary>
		public DieStatusRepeater()
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
		[TemplateContainer(typeof(DieStatusItem))]
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
		[TemplateContainer(typeof(DieStatusItem))]
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
        [TemplateContainer(typeof(DieStatusItem))]
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
		[TemplateContainer(typeof(DieStatusItem))]
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
		[TemplateContainer(typeof(DieStatusItem))]
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
						Agile.Entities.DieStatus entity = o as Agile.Entities.DieStatus;
						DieStatusItem container = new DieStatusItem(entity);
	
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
	public class DieStatusItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Agile.Entities.DieStatus _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DieStatusItem"/> class.
        /// </summary>
		public DieStatusItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DieStatusItem"/> class.
        /// </summary>
		public DieStatusItem(Agile.Entities.DieStatus entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the DieStatus
        /// </summary>
        /// <value>The DieStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DieStatus
		{
			get { return _entity.DieStatus; }
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
        /// Gets the Order
        /// </summary>
        /// <value>The Order.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Order
		{
			get { return _entity.Order; }
		}
        /// <summary>
        /// Gets the Visible
        /// </summary>
        /// <value>The Visible.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Visible
		{
			get { return _entity.Visible; }
		}
        /// <summary>
        /// Gets the Selected
        /// </summary>
        /// <value>The Selected.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Selected
		{
			get { return _entity.Selected; }
		}
        /// <summary>
        /// Gets the IsDefault
        /// </summary>
        /// <value>The IsDefault.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsDefault
		{
			get { return _entity.IsDefault; }
		}
        /// <summary>
        /// Gets the IconLink
        /// </summary>
        /// <value>The IconLink.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String IconLink
		{
			get { return _entity.IconLink; }
		}
        /// <summary>
        /// Gets the IsCompleted
        /// </summary>
        /// <value>The IsCompleted.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsCompleted
		{
			get { return _entity.IsCompleted; }
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
        /// Gets the ProjectId
        /// </summary>
        /// <value>The ProjectId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ProjectId
		{
			get { return _entity.ProjectId; }
		}

        /// <summary>
        /// Gets a <see cref="T:Agile.Entities.DieStatus"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Agile.Entities.DieStatus Entity
        {
            get { return _entity; }
        }
	}
}
