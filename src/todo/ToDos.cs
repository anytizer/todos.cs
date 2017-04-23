using configurations;
using database;
using database.mysql;
using dtos;
using settingsmanager;
using libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace todo
{
    public partial class ToDos : Form
    {
        private LimiterDTO limiter;

        private List<NameValueDTO> statuses = new List<NameValueDTO>();
        private List<ProjectsDTO> projects = new List<ProjectsDTO>();

        public ToDos()
        {
            InitializeComponent();

            /**
             * @see https://msdn.microsoft.com/en-us/library/system.windows.forms.datagridviewcellstyle.selectionbackcolor(v=vs.110).aspx
             */
            identities id = new identities();
            this.limiter = new LimiterDTO();
            this.limiter.default_project_id = id.ProjectID_default.ToString();
            this.limiter.default_status_id = id.status_new.ToString();
            this.limiter.default_user_id= id.UserID_default.ToString();

            api a = new api();
            this.projects = a.all_proejcts();
            this.statuses = a.all_statuses(limiter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // @todo test if project default IDs exist
            // project_defaults();

            reload();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            save_status(this.limiter);
            reload();
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /**
             * Project chosen
             */
            ToolStripMenuItemCustomProjects ms = sender as ToolStripMenuItemCustomProjects;
            if (null != ms)
            {
                this.limiter.default_project_id = ms.Tag.ToString();
                reload();
            }
        }

        private void filterByStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /**
             * Status chosen
             */
            ToolStripMenuItemCustomStatuses ms = sender as ToolStripMenuItemCustomStatuses;
            if (null != ms)
            {
                //this.limiter.default_project_id = ms.Tag.ToString();
                this.limiter.default_status_id = ms.Tag.ToString();

                reload();
            }
        }

        /**
         * Load list of available projects in the menu
         */
        private void main_menu_projects()
        {
            this.projectsToolStripMenuItem.DropDownItems.Clear();

            // status menus
            List<ToolStripMenuItemCustomProjects> ms = new List<ToolStripMenuItemCustomProjects>();
            foreach (ProjectsDTO p in this.projects)
            {
                ToolStripMenuItemCustomProjects mi = new ToolStripMenuItemCustomProjects();
                mi.id = p.id;
                mi.Tag = p.id;
                mi.Name = p.name;
                mi.Text = p.name;
                mi.Checked = this.limiter.default_project_id.Equals(new Guid(p.id));
                mi.Click += new EventHandler(this.projectsToolStripMenuItem_Click);

                ms.Add(mi);
            }

            this.projectsToolStripMenuItem.DropDownItems.AddRange(ms.ToArray());
        }

        /**
         * Load list of available status in the menu
         */
        private void main_menu_statuses(LimiterDTO limiter)
        {
            //int status_index = this.status.Index;
            this.filterByStatusToolStripMenuItem.DropDownItems.Clear();
            List<ToolStripMenuItemCustomStatuses> ms = new List<ToolStripMenuItemCustomStatuses>();

            // status menus
            // Limit statuses with todos counter
            foreach (NameValueDTO s in this.statuses)
            {
                ToolStripMenuItemCustomStatuses mi = new ToolStripMenuItemCustomStatuses();
                mi.id = s.id.ToString();
                mi.Tag = s.id.ToString();
                mi.Name = s.name;
                mi.Text = s.name;
                mi.Checked = this.limiter.default_status_id.Equals(s.id);
                mi.Click += new EventHandler(this.filterByStatusToolStripMenuItem_Click);

                ms.Add(mi);
            }

            this.filterByStatusToolStripMenuItem.DropDownItems.AddRange(ms.ToArray());
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // case 1: re-read default settings
            // case 2: dynamically change the user modified values
            //this.limiter.default_status_id = Guid.Empty.ToString();

            reload();
        }
    }
}
