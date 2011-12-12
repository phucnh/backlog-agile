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
    /// A designer class for a strongly typed repeater <c>UserRepeater</c>
    /// </summary>
	public class UserRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRepeaterDesigner"/> class.
        /// </summary>
		public UserRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is UserRepeater))
			{ 
				throw new ArgumentException("Component is not a UserRepeater."); 
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
			UserRepeater z = (UserRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="UserRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(UserRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:UserRepeater runat=\"server\"></{0}:UserRepeater>")]
	public class UserRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRepeater"/> class.
        /// </summary>
		public UserRepeater()
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
		[TemplateContainer(typeof(UserItem))]
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
		[TemplateContainer(typeof(UserItem))]
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
        [TemplateContainer(typeof(UserItem))]
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
		[TemplateContainer(typeof(UserItem))]
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
		[TemplateContainer(typeof(UserItem))]
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
						Agile.Entities.User entity = o as Agile.Entities.User;
						UserItem container = new UserItem(entity);
	
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
	public class UserItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Agile.Entities.User _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserItem"/> class.
        /// </summary>
		public UserItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserItem"/> class.
        /// </summary>
		public UserItem(Agile.Entities.User entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the UserId
        /// </summary>
        /// <value>The UserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UserId
		{
			get { return _entity.UserId; }
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
        /// Gets the PassWord
        /// </summary>
        /// <value>The PassWord.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PassWord
		{
			get { return _entity.PassWord; }
		}
        /// <summary>
        /// Gets the QlnsId
        /// </summary>
        /// <value>The QlnsId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? QlnsId
		{
			get { return _entity.QlnsId; }
		}
        /// <summary>
        /// Gets the Email
        /// </summary>
        /// <value>The Email.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Email
		{
			get { return _entity.Email; }
		}
        /// <summary>
        /// Gets the EmployeeName
        /// </summary>
        /// <value>The EmployeeName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmployeeName
		{
			get { return _entity.EmployeeName; }
		}
        /// <summary>
        /// Gets the Remove
        /// </summary>
        /// <value>The Remove.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Remove
		{
			get { return _entity.Remove; }
		}
        /// <summary>
        /// Gets the IsLoginSystem
        /// </summary>
        /// <value>The IsLoginSystem.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsLoginSystem
		{
			get { return _entity.IsLoginSystem; }
		}
        /// <summary>
        /// Gets the UpdateDate
        /// </summary>
        /// <value>The UpdateDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdateDate
		{
			get { return _entity.UpdateDate; }
		}
        /// <summary>
        /// Gets the UserUpdate
        /// </summary>
        /// <value>The UserUpdate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UserUpdate
		{
			get { return _entity.UserUpdate; }
		}
        /// <summary>
        /// Gets the PageDefaultLogin
        /// </summary>
        /// <value>The PageDefaultLogin.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PageDefaultLogin
		{
			get { return _entity.PageDefaultLogin; }
		}
        /// <summary>
        /// Gets the DateCreated
        /// </summary>
        /// <value>The DateCreated.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DateCreated
		{
			get { return _entity.DateCreated; }
		}
        /// <summary>
        /// Gets the DateRemoved
        /// </summary>
        /// <value>The DateRemoved.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DateRemoved
		{
			get { return _entity.DateRemoved; }
		}
        /// <summary>
        /// Gets the IsNoBody
        /// </summary>
        /// <value>The IsNoBody.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsNoBody
		{
			get { return _entity.IsNoBody; }
		}

        /// <summary>
        /// Gets a <see cref="T:Agile.Entities.User"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Agile.Entities.User Entity
        {
            get { return _entity; }
        }
	}
}
