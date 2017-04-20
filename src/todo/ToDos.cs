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
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.White; // sky blue
            //dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Maroon;
            //dataGridView1.CurrentRow.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AreAllCellsSelected(false);
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;

            identities id = new identities();
            this.limiter = new LimiterDTO();
            this.limiter.defaultProjectID = id.ProjectID_default;
            this.limiter.defaultUserID = id.UserID_default;
            this.limiter.defaultStatusID = id.status_new;

            api a = new api();
            this.projects = a.all_proejcts();
            this.statuses = a.all_statuses();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload(); // reload list of todos            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_status();
            reload();
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /**
             * Project chosen
             */
            ToolStripMenuItemCustomProjects mis = sender as ToolStripMenuItemCustomProjects;
            if (null != mis)
            {
                this.limiter.defaultProjectID = new Guid(mis.Tag.ToString());
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
                mi.Tag = p.id.ToString();
                mi.Name = p.name;
                mi.Text = p.name;
                mi.Click += new EventHandler(this.projectsToolStripMenuItem_Click);
                ms.Add(mi);
            }

            this.projectsToolStripMenuItem.DropDownItems.AddRange(ms.ToArray());
        }

        /**
         * Load list of available status in the menu
         */
        private void main_menu_statuses()
        {
            //int status_index = this.status.Index;
            this.filterByStatusToolStripMenuItem.DropDownItems.Clear();
            List<ToolStripMenuItem> mis = new List<ToolStripMenuItem>();

            // status menus
            foreach (NameValueDTO s in this.statuses)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(s.name);
                //string current_status = dataGridView1.Rows[currentContextRowIndex].Cells[status_index].Value.ToString();
                mi.Click += new EventHandler(this.menu_filter_status_handler);
                mis.Add(mi);
            }

            this.filterByStatusToolStripMenuItem.DropDownItems.AddRange(mis.ToArray());
        }
    }
}
