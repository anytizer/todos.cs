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

        /**
         * when setting, update the list of projects
         */
        private Guid _ProjectID;
        private Guid _StatusID;
        private Guid _UserID;

        /**
         * String setup
         */
        public string default_project_id { get { return this._ProjectID.ToString(); } set { this._ProjectID = this.guidOrNull(value); } }
        public string default_status_id { get { return this._StatusID.ToString(); } set { this._StatusID = this.guidOrNull(value); } }
        public string default_user_id { get { return this._UserID.ToString(); } set { this._UserID = this.guidOrNull(value); } }

        /**
         * GUID setup
         */
        public Guid ProjectID { get { return _ProjectID; } private set { this._ProjectID = value; } }
        public Guid StatusID { get { return _StatusID; } private set { this._StatusID = value; } }
        public Guid UserID { get { return this._UserID; } private set { this._UserID = value; } }

        private Guid guidOrNull(string g)
        {
            Guid value = Guid.Empty;

            if(g!=null && g!="" && g.Length >= 30)
            {
                if(g.ToString() != Guid.Empty.ToString())
                {
                    value = new Guid(g);
                }
            }

            return value;
        }
    }
}

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
