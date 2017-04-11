using database.mysql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace todo
{
    public class todoer
    {
        public void add(Guid project_id, Guid status_id, string text)
        {
            // @todo save to api
            // no sorting
            // window resize blocked
            // row resize blocked
            // cell selection blocked
            // sorting blocked

            //MessageBox.Show("Load default");
            todoEntities te = new todoEntities();
            database.mysql.todo_todos td = new database.mysql.todo_todos();

            td.todo_id = Guid.NewGuid().ToString();
            td.project_id = project_id.ToString();
            td.status_id = status_id.ToString();
            td.issue_number = "";
            td.todo_text = text;
            td.added_on = System.DateTime.Now;
            te.todo_todos.Add(td);

            te.SaveChanges();
        }

        public List<v_todos> todos()
        {
            // @todo read from api, instead of sql

            List<v_todos> lv = new List<v_todos>();
            todoEntities te = new todoEntities();
            foreach (v_todos t in te.v_todos.OrderByDescending(x => x.added_on))
            {
                lv.Add(t);
            }

            return lv;
        }

        public List<todo_projects> projects()
        {
            // @todo read from api, instead of sql

            List<todo_projects> lp = new List<todo_projects>();
            todoEntities te = new todoEntities();
            foreach (todo_projects p in te.todo_projects)
            {
                lp.Add(p);
            }

            return lp;
        }

        public void done(Guid project_id)
        {
            todoEntities te = new todoEntities();
            todo_projects_statuses ps = new todo_projects_statuses();
            //ps.history_id = Guid.NewGuid();
            //ps.project_id = project_id;
            //te.todo_projects_statuses = new
            // todo_projects_statuses
        }
    }
}
