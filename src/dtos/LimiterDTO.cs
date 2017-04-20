using System;
using System.Windows.Forms;

namespace dtos
{
    public class LimiterDTO
    {
        /**
         * Limits the search results to these configurations
         * @todo Replace these items
         */
        public Guid defaultProjectID { get; set; /** when setting, update the list of projects */}
        public Guid defaultStatusID;
        public Guid defaultUserID;
    }

    public class ToolStripMenuItemCustomStatuses : ToolStripMenuItem
    {
        public string id { get; set; }
    }

    public class ToolStripMenuItemCustomProjects : ToolStripMenuItem
    {
        public string id { get; set; }
    }
}

        //public ToolStripMenuItemCustom(string name)
        //{
        //    //base(name);
        //}
        //public ToolStripMenuItemCustom(string text) : base(text) { }
        //public ToolStripMenuItemCustom(Drawing.Image image) : base(image) { }
        //public ToolStripMenuItemCustom(string text, Drawing.Image image);
        //public ToolStripMenuItemCustom(string text, Drawing.Image image, EventHandler onClick);
        //public ToolStripMenuItemCustom(string text, Drawing.Image image, params ToolStripItem[] dropDownItems);
        //public ToolStripMenuItemCustom(string text, Drawing.Image image, EventHandler onClick, string name);
        //public ToolStripMenuItemCustom(string text, Drawing.Image image, EventHandler onClick, Keys shortcutKeys);

        /*
        private void BuildMenuItems()
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[2]; // You would obviously calculate this value at runtime
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = "dynamicItem" + i.ToString();
                items[i].Tag = "specialDataHere";
                items[i].Text = "Visible Menu Text Here";
                items[i].Click += new EventHandler(MenuItemClickHandler);
            }

            //myMenu.DropDownItems.AddRange(items);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            // Take some action based on the data in clickedItem
        }
        */