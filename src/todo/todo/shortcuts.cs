using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public partial class ToDos
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return false;

            /*
            // @todo Make sure the row was selected in the grid
            // @todo Proceed why when there are records
            // @todo Delete only if item is pre selected
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return false;

            // Delete Key - Delete Selected Row!
            if (keyData == Keys.Delete)
            {
                // MessageBox.Show("Index: "+this.dataGridView1.SelectedRows[0].Index.ToString());
                // MessageBox.Show("Index: " + this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());

                if (MessageBox.Show("Are you sure DELETE this item?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Do stuff after 'YES is clicked'
                    database.api td = new database.api();
                    // @todo There may not be a selection or wrong entry pre-selected
                    Guid todo_id = new Guid(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                    Guid status_id = configurations.defaults.statuses.DELETED;
                    if (td.done(todo_id, status_id))
                    {
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Did not delete.");
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
            */
        }

    }
}
