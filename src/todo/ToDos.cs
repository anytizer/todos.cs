using database.mysql;
using libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace todo
{
    public partial class ToDos : Form
    {
        public ToDos()
        {
            InitializeComponent();
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.AreAllCellsSelected(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
            combo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
            {
                todoer td = new todoer();
                Guid project_id = new Guid("640BC432-CDFF-4B7D-8D04-C418CD989AA3");
                Guid status_id = new Guid("E827C910-5235-4C87-9F13-DAF960682D54");
                td.add(project_id, status_id, textBox1.Text);

                reload();
            }
        }

        private void reload()
        {
            // alternate color
            // little padding
            // row level selection

            this.SuspendLayout();

            textBox1.Text = "";
            todoer t = new todoer();
            List<v_todos> lv = t.todos();

            this.dataGridView1.Rows.Clear();
            foreach (v_todos v in lv)
            {
                // add to grid
                //dataGridView1.row
                // @xee http://stackoverflow.com/questions/10063770/how-to-add-a-new-row-to-datagridview-programmatically
                // @see https://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.selectionchanged(v=vs.110).aspx
                DataGridViewRow row = (DataGridViewRow)dataGridView1.RowTemplate.Clone();
                row.CreateCells(dataGridView1, v.todo_id, v.added_on, "", v.project_name, v.status_name, v.todo_text);
                this.dataGridView1.Rows.Add(row);

                // flickering
                // http://stackoverflow.com/questions/2041782/how-to-prevent-rows-in-datagrid-from-flickering-while-application-is-running
            }

            this.ResumeLayout();
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
                    todoer td = new todoer();
                    if (td.delete(this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString()))
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

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void combo()
        {
            this.SuspendLayout();
            this.comboBox1.Items.Clear();

            todoer t = new todoer();
            List<todo_projects> lp = t.projects();
            foreach (todo_projects p in lp)
            {
                ProjectItem pi = new ProjectItem();
                pi.Name = p.project_name;
                pi.Value = p.project_name;
                this.comboBox1.Items.Add(pi);
            };

            this.ResumeLayout();
        }

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
                    menu.Text = "Always On Top";
                }
            }

        }
    }

}
