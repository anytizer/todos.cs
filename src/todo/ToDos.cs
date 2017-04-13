﻿using database;
using database.mysql;
using dtos;
using libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            libraries.todoer td = new libraries.todoer();
            this.statuses = td.all_statuses();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
            combo();
        }

        private void button1_Click(object sender, EventArgs e)
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
                Guid project_id = dtos.defaults.projects.ProjectID;
                Guid status_id = dtos.defaults.statuses.NEW;
                //if (null != this.project_id)
                //{
                //    MessageBox.Show("Project: " + this.project_id);
                //}
                td.add(project_id, status_id, textBox1.Text);

                reload();
            }
        }

        private void reload()
        {
            // alternate color
            // little padding
            // row level selection
            int selectedIndex = 0;
            if (this.dataGridView1.SelectedRows.Count >= 1)
            {
                selectedIndex = this.dataGridView1.SelectedRows[0].Index;
            }

            this.SuspendLayout();
            this.dataGridView1.Rows.Clear();

            textBox1.Text = "";
            database.api t = new database.api();
            List<todosDTO> lv = t.todos();

            foreach (todosDTO v in lv)
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

            if (selectedIndex <= this.dataGridView1.Rows.Count)
            {
                this.dataGridView1.Rows[selectedIndex].Selected = true;
            }

            this.ResumeLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Delete Key - Delete Selected Row!
            if (keyData == Keys.Delete)
            {
                // MessageBox.Show("Index: "+this.dataGridView1.SelectedRows[0].Index.ToString());
                // MessageBox.Show("Index: " + this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());

                if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Do stuff after 'YES is clicked'
                    database.api td = new database.api();
                    // @todo There may not be a selection or wrong entry pre-selected
                    Guid todo_id = new Guid(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                    Guid status_id = new Guid("E827C910-5235-4C87-9F13-DAF960682D59");
                    if (td.done(todo_id, status_id))
                    {
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Did not delete.");
                    }

                }

                //Guid todo = Guid.NewGuid();
                //todoer td = new todoer();
                //td.done(todo);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void combo()
        {
            this.comboBox1.Items.Clear();

            database.api t = new database.api();
            List<projectsDTO> lp = t.projects();
            foreach (projectsDTO p in lp)
            {
                NameValueDTO pi = new NameValueDTO();
                pi.id = new Guid(p.project_id);
                pi.name = p.project_name;
                pi.value = p.project_name;
                this.comboBox1.Items.Add(pi);
            };

            //this.SuspendLayout();
            //this.ResumeLayout();
        }
    }
}
