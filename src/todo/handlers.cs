using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public partial class ToDos
    {
        private int currentContextRow = 0;
        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (sender as ToolStripMenuItem);

            if (menu.Text != "")
            {
                this.TopMost = !this.TopMost;
                if (this.TopMost)
                {
                    menu.Text = "\u2714 Always On Top";
                }
                else
                {
                    menu.Text = "\u2000 Always On Top";
                }
            }
        }

        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statuses s = new statuses();
            database.api td = new database.api();
            Guid todo_id = new Guid(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            Guid status_id = td.delete_status();
            if (td.done(todo_id, status_id))
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
            Guid status_id = dtos.defaults.statuses.LOWPRIORITY;
            if (td.done(todo_id, status_id))
            {
                reload();
            }
        }

        private void doingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Doing");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentContextRowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                dataGridView1.ClearSelection();
                

                ContextMenu m = new ContextMenu();
                if (currentContextRowIndex >=1 )
                {
                    // highlight selected row
                    dataGridView1.Rows[currentContextRowIndex].Selected = true;

                    // skip header columns
                    // disabled menu if status matches

                    foreach (var s in this.statuses)
                    {
                        MenuItem mi = new MenuItem(s.name);
                        string current_status = dataGridView1.Rows[currentContextRowIndex].Cells[0].ToString();
                        if (current_status == s.name)
                        {
                            // @todo skipped re-selecting on current status
                            mi.Enabled = false;
                        }
                        mi.Click += new EventHandler(this.menu_selected);
                        m.MenuItems.Add(mi);
                    }
                }
                else
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do nothing at {0}", currentContextRowIndex.ToString())) { Enabled = false, });
                }
                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        void menu_selected(object sender, System.EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            MessageBox.Show(mi.ToString());
        }
    }
}
