﻿using configurations;
using database;
using dtos;
using libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public partial class ToDos : Form
    {
        /**
 * Right click context menu on toto items.
 */
        void menu_selected(object sender, System.EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            string new_staus_name = mi.Text;
            //MessageBox.Show(new_staus_name);
            Guid todo_id = new Guid(dataGridView1.Rows[currentContextRowIndex].Cells[this.ToDoID.Index].Value.ToString());
            //Guid todo_id = new Guid(dataGridView1.Rows[currentContextRowIndex].Cells[this.ToDoID.Index].Value.ToString());
            foreach (NameValueDTO s in this.statuses)
            {
                if (s.name.Equals(new_staus_name))
                {
                    if (s.confirm)
                    {
                        if (MessageBox.Show(s.question, "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            todoer td = new todoer();
                            td.done(limiter.defaultUserID, todo_id, s.id);
                        }
                        else
                        {
                            // confirmation said no
                        }
                    }
                    else
                    {
                        todoer td = new todoer();
                        td.done(limiter.defaultUserID, todo_id, s.id);
                        // MessageBox.Show(string.Format("{0} @ {1}", todo_id, new_staus_name));
                    }

                    break;
                }
            }

            reload();
            // MessageBox.Show(todo_id.ToString());
        }

        void menu_filter_status(object sender, System.EventArgs e)
        {
            // filter view list

            ToolStripMenuItemCustomStatuses mis = sender as ToolStripMenuItemCustomStatuses;
            if (null != mis)
            {
                MessageBox.Show("Filtering by Status: "+ mis.Tag.ToString());

                this.limiter.defaultStatusID = new Guid(mis.Tag.ToString());
                //reload();
            }

            //reload();
        }

        private void reload()
        {
            //menuStrip1.Renderer = new MyRenderer();            
            libraries.todoer td = new libraries.todoer();

            main_menu_statuses();
            main_menu_projects();

            /**
             * @todo Use the values from limiters
             */
            grid_todos();
        }

        private void grid_todos()
        {
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
            List<TodosDTO> lv = t.todos(limiter);

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

            this.dataGridView1.Enabled = true;
        }
    }
}
