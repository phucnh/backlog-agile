using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Agile.Web.UI
{
    /// <summary>
    /// Percent bar control
    /// </summary>
    [DefaultProperty("Text")]
    public class PercentControl : WebControl
    {
        private List<PercentItem> items;

        /// <summary>
        /// Gets or sets a value indicating whether [show ratio].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show ratio]; otherwise, <c>false</c>.
        /// </value>
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        public Boolean ShowRatio
        {
            get
            {
                Boolean showRatio = (Boolean)((ViewState["ShowRatio"] == null) ? false : ViewState["ShowRatio"]);
                return showRatio;
            }
            set
            {
                ViewState["ShowRatio"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public String CssClass
        {
            get
            {
                string cssClass = (String)((ViewState["CssClass"] == null) ? "inherit" : ViewState["CssClass"]);
                return ((cssClass == null) ? "" : cssClass);
            }
            set
            {
                ViewState["CssClass"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("inherit")]
        public String ItemWidth
        {
            get
            {
                string width = (String)((ViewState["ItemWidth"] == null) ? "inherit" : ViewState["ItemWidth"]);
                return ((width == null) ? "10px" : width);
            }
            set
            {
                ViewState["ItemWidth"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("15px")]
        public String ItemHeight
        {
            get
            {
                string height = (String)((ViewState["ItemHeight"] == null) ? "15px" : ViewState["ItemHeight"]);
                return ((height == null) ? "15px" : height);
            }
            set
            {
                ViewState["ItemHeight"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        public List<PercentItem> Items
        {
            get
            {
                if (items == null) items = new List<PercentItem>();
                return items;
            }
            set
            {
                items = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }


        /// <summary>
        /// Renders the contents.
        /// </summary>
        /// <param name="output">The output.</param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            if (Items == null)
            {
                output.Write(Text);
                return;
            }

            HtmlGenericControl containner = new HtmlGenericControl("div");

            containner.Style.Add(HtmlTextWriterStyle.Height, ItemHeight);
            containner.Style.Add(HtmlTextWriterStyle.Width, "100%");

            if (!string.IsNullOrEmpty(CssClass))
                containner.Attributes.Add("class", CssClass);

            HtmlGenericControl percentContainer = new HtmlGenericControl("div");
            percentContainer.Style.Add(HtmlTextWriterStyle.Width, "85%");
            //percentContainer.Style.Add(HtmlTextWriterStyle.Height, "inherit");

            int itemSum = ItemSum;

            //Add html div to containner for each item
            foreach (PercentItem item in Items)
            {
                float itemPercent = (float)(item.Count * 100 / itemSum);
                HtmlGenericControl itemSection = new HtmlGenericControl("div");

                itemSection.Style.Add(HtmlTextWriterStyle.BackgroundColor, item.Color);
                itemSection.Style.Add(HtmlTextWriterStyle.BackgroundImage, item.BackGroundImage);
                itemSection.Style.Add(HtmlTextWriterStyle.Width, (itemPercent).ToString() + "%");
                itemSection.Style.Add(HtmlTextWriterStyle.Height, ItemHeight);
                itemSection.Style.Add("float", "left");

                percentContainer.Controls.Add(itemSection);
            }

            containner.Controls.Add(percentContainer);

            if (ShowRatio)
            {
                HtmlGenericControl ratioSection = new HtmlGenericControl("div");
                ratioSection.Style.Add(HtmlTextWriterStyle.Width, "15%");
                //ratioSection.Style.Add(HtmlTextWriterStyle.Height, "inherit");
                ratioSection.InnerText = "(" + Items[0].Count.ToString() + "/" + itemSum.ToString() + ")";
                ratioSection.Style.Add("float", "right");

                containner.Controls.Add(ratioSection);
            }

            containner.RenderControl(output);
        }

        /// <summary>
        /// Gets the sum of all item in percent bar.
        /// </summary>
        private int ItemSum
        {
            get
            {
                int count = 0;

                foreach (PercentItem item in Items)
                {
                    count += item.Count;
                }

                return count;
            }
        }
    }

    /// <summary>
    /// Percent item
    /// </summary>
    public class PercentItem
    {
        private string itemName;
        private string itemText;
        private int count;
        private string color = string.Empty;
        private string backGroundImage = string.Empty;

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// Gets or sets the item text.
        /// </summary>
        /// <value>
        /// The item text.
        /// </value>
        public string ItemText
        {
            get { return itemText; }
            set { itemText = value; }
        }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Gets or sets the back ground.
        /// </summary>
        /// <value>
        /// The back ground.
        /// </value>
        public string BackGroundImage
        {
            get
            {
                return backGroundImage;
            }
            set { backGroundImage = value; }
        }

    }
}
