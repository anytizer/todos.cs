using libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awesome_todo.net
{
    public partial class display : Form
    {
        public display()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            todoer todo = new todoer();
            todo.todo();
        }
    }
}
