﻿using configurations;
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
        private List<NameValueDTO> statuses;

        public ToDos()
        {
            InitializeComponent();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.AreAllCellsSelected(false);
            // row.DefaultCellStyle.BackColor = Color.Red;

            libraries.todoer td = new libraries.todoer();
            this.statuses = td.all_statuses();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload(); // reload list of todos

            // combo projects

            //reloadProjects(); // list of projects
            combo(); // list of projects, ... remove
            
            // menus
            foreach (NameValueDTO s in this.statuses)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(s.name);
                int status_index = this.status.Index;
                string current_status = dataGridView1.Rows[currentContextRowIndex].Cells[status_index].Value.ToString();
                if (current_status == s.name)
                {
                    // @todo skipped re-selecting on current status
                    mi.Enabled = false;
                }
                mi.Click += new EventHandler(this.menu_filter_status);
                this.filterByStatusToolStripMenuItem.DropDownItems.Add(mi);
            }            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // nothing
            // do not entertain DELETE key
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // nothing
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            this.Visible = !this.Visible;
            if (this.Visible == false)
            {
                //this.Hide();
                this.TopMost = true;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
            }
            else
            {
                this.Show();
                //this.TopMost = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
            */
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
            reload();
        }

        private void reload()
        {
            this.SuspendLayout();
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Enabled = false;

            // alternate color
            // little padding
            // row level selection
            int selectedIndex = 0;
            if (this.dataGridView1.SelectedRows.Count >= 1)
            {
                selectedIndex = this.dataGridView1.SelectedRows[0].Index;
            }

            textBox1.Text = "";
            database.api t = new database.api();
            List<TodosDTO> lv = t.todos();

            foreach (TodosDTO v in lv)
            {
                // add to grid
                // dataGridView1.row
                // @xee http://stackoverflow.com/questions/10063770/how-to-add-a-new-row-to-datagridview-programmatically
                // @see https://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.selectionchanged(v=vs.110).aspx
                DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                row.CreateCells(dataGridView1, v.todo_id, v.added_on, "", v.project_name, v.status_name, v.todo_text);
                this.dataGridView1.Rows.Add(row);

                // flickering
                // http://stackoverflow.com/questions/2041782/how-to-prevent-rows-in-datagrid-from-flickering-while-application-is-running
            }

            if (selectedIndex >= 0 && this.dataGridView1.Rows.Count >= 1)
            {
                this.dataGridView1.Rows[selectedIndex].Selected = true;
            }

            this.ResumeLayout();
            this.dataGridView1.Enabled = true;
        }

        private void combo()
        {
            this.SuspendLayout();
            this.comboBox1.Items.Clear();

            database.api t = new database.api();
            List<ProjectsDTO> lp = t.projects();
            foreach (ProjectsDTO p in lp)
            {
                NameValueDTO pi = new NameValueDTO();
                pi.id = new Guid(p.project_id);
                pi.name = p.project_name;
                pi.value = p.project_name;
                this.comboBox1.Items.Add(pi);
            };
            this.ResumeLayout();
        }

        private void save()
        {
            /**
             * ToDo has something typed in
             */
            if (textBox1.Text.Length >= 1)
            {
                database.api td = new database.api();
                /**
                 * @todo Pickup from dropdown lists
                 */
                settingsmanager.ids id = new settingsmanager.ids();
                Guid project_id = id.ProjectID;

                StatusIDs s = new StatusIDs();
                Guid status_id = s.NEW;
                td.add(project_id, status_id, textBox1.Text);
            }
        }

        private void filterByStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // child filter by status
        }

        private void m2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
