using database.mysql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace database
{
    public class todoer
    {
        public void add(Guid project_id, Guid status_id, string text)
        {
            todosEntities te = new todosEntities();
            database.mysql.todo_todos todo = new database.mysql.todo_todos();

            todo.todo_id = Guid.NewGuid().ToString();
            todo.project_id = project_id.ToString();
            todo.status_id = status_id.ToString();
            todo.issue_number = "";
            todo.todo_text = text;
            todo.added_on = System.DateTime.Now;
            todo.modified_on = System.DateTime.Now;
            todo.is_active = "Y";
            te.todo_todos.Add(todo);

            te.SaveChanges();
        }

        public List<v_todos> todos()
        {
            // @todo read from api, instead of sql

            List<v_todos> lv = new List<v_todos>();
            todosEntities te = new todosEntities();
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
            todosEntities te = new todosEntities();
            foreach (todo_projects p in te.todo_projects)
            {
                lp.Add(p);
            }

            return lp;
        }

        public bool done(string todo_id, string status_id)
        {
            bool deleted = false;
            todosEntities te = new todosEntities();
            todo_todos todo = te.todo_todos.SingleOrDefault(x => x.todo_id == todo_id);
            if(null != todo)
            {
                todo.modified_on = System.DateTime.Now;
                todo.is_active = "N";
                deleted = true;

                todo_projects_statuses history = new todo_projects_statuses();
                history.history_id = Guid.NewGuid().ToString();
                history.project_id = todo.project_id;
                history.status_id = new Guid(status_id).ToString(); // temp deleted
                history.status_on = System.DateTime.Now;
                te.todo_projects_statuses.Add(history);
            }

            te.SaveChanges();
            return deleted;
        }
    }
}
