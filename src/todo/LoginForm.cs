using database.mysql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string password = this.password.Text;
            // valdiate username, password
            todosEntities te = new todosEntities();
            todo_users tu = te.todo_users.Where(x => x.user_username == username.Text && x.user_password == password).SingleOrDefault();
            if(null != tu)
            {
                this.Hide();

                ToDos t = new ToDos();
                t.Show();
            }           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.username.Focus();
        }
    }
}
