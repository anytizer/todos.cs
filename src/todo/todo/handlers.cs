﻿using configurations;
using database;
using dtos;
using libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static settingsmanager.ids;

namespace todo
{
    public partial class ToDos
    {
        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /**
             * Always on top
             */
            ToolStripMenuItem menu = (sender as ToolStripMenuItem);

            if (menu.Text != "")
            {
                this.TopMost = !this.TopMost;
                if (this.TopMost)
                {
                    menu.Text = "\u2714 Always On Top";
                    menu.ForeColor = Color.Red;
                }
                else
                {
                    menu.Text = "x Always On Top";
                    menu.ForeColor = Color.Green;
                }
            }
        }

        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statuses s = new statuses();
            database.api td = new database.api();
            Guid todo_id = new Guid(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            Guid status_id = td.delete_status();
            if (td.done(limiter.UserID, todo_id, status_id))
            {
                reload();
            }
            else
            {
                MessageBox.Show("Error: Could NOT delete.");
            }
        }

        private void lowPriorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Low Priority");

            database.api td = new database.api();
            Guid todo_id = new Guid(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());

            StatusIDs ts = new StatusIDs();
            Guid status_id = ts.LOWPRIORITY;
            if (td.done(limiter.UserID, todo_id, status_id))
            {
                reload();
            }
        }

        private void doingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Doing");
        }

        private int currentContextRowIndex = 0;

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            // int currentContextRowIndex = 0; // use global

            if (e.Button == MouseButtons.Right)
            {
                currentContextRowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                dataGridView1.ClearSelection();

                ContextMenu m = new ContextMenu();
                if (currentContextRowIndex >= 0)
                {
                    // highlight selected row
                    dataGridView1.Rows[currentContextRowIndex].Selected = true;

                    // skip header columns
                    // disabled menu if status matches

                    foreach (NameValueDTO s in this.statuses)
                    {
                        MenuItem mi = new MenuItem(s.name);
                        int status_index = this.status.Index;
                        string current_status = dataGridView1.Rows[currentContextRowIndex].Cells[status_index].Value.ToString();
                        if (current_status == s.name)
                        {
                            // @todo skipped re-selecting on current status
                            mi.Enabled = false;
                        }
                        mi.Click += new EventHandler(this.menu_selected);
                        m.MenuItems.Add(mi);
                    }

                    // todo auto adjust menu location
                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }

        private void save_status(LimiterDTO limiter)
        {
            /**
             * ToDo has something typed in
             */
            if (textBox1.Text.Length >= 1)
            {
                database.api td = new database.api();
                settingsmanager.ids id = new settingsmanager.ids();

                Guid project_id;
                if (null != limiter.ProjectID && limiter.ProjectID != Guid.Empty)
                {
                    /**
                     * @todo Pickup from project menu dropdown lists
                     */
                    project_id = limiter.ProjectID;
                }
                else
                {
                    project_id = id.ProjectID;
                }

                Guid user_id = id.UserID;

                StatusIDs s = new StatusIDs();
                Guid status_id = s.NEW;

                td.add(user_id, project_id, status_id, textBox1.Text);
            }
        }
    }
}
