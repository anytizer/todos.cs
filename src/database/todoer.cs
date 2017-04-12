using database.mysql;
using dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace database
{
    public class todoer
    {
        private todosEntities te;

        public todoer()
        {
             this.te = new todosEntities();
        }

        public void add(Guid project_id, Guid status_id, string text)
        {
            string pid = new Guid("6F39DA75-EE09-44EA-80DB-23087F0C555D").ToString();

            database.mysql.todo_todos todo = new database.mysql.todo_todos();
            todo.todo_id = Guid.NewGuid().ToString();
            todo.project_id = pid; //  project_id.ToString();
            todo.status_id = status_id.ToString();
            todo.issue_number = "";
            todo.todo_text = text;
            todo.added_on = System.DateTime.Now;
            todo.modified_on = System.DateTime.Now;
            todo.is_active = "Y";
            te.todo_todos.Add(todo);

            te.SaveChanges();
        }

        public List<todosDTO> todos()
        {
            // @todo read from api, instead of sql

            List<todosDTO> lv = new List<todosDTO>();
            todosEntities te = new todosEntities();
            foreach (v_todos t in te.v_todos.OrderByDescending(x => x.added_on))
            {
                todosDTO todo = new todosDTO();

                todo.project_id = t.project_id;
                todo.project_name = t.project_name;
                todo.status_id = t.status_id;
                todo.status_name = t.status_name;
                todo.todo_id = t.todo_id;
                todo.todo_text = t.todo_text;

                lv.Add(todo);
            }

            return lv;
        }

        public List<projectsDTO> projects()
        {
            // @todo read from api, instead of sql
            List<projectsDTO> projects = new List<projectsDTO>();
            todosEntities te = new todosEntities();
            foreach (todo_projects p in te.todo_projects)
            {
                projectsDTO pd = new projectsDTO();
                pd.project_id = p.project_id;
                pd.project_name = p.project_name;
                projects.Add(pd);
            }

            return projects;
        }

        public bool done(Guid todo_id, Guid status_id)
        {
            bool deleted = false;
            
            todo_todos todo = te.todo_todos.SingleOrDefault(x => x.todo_id == todo_id.ToString());
            if(null != todo)
            {
                todo.modified_on = System.DateTime.Now;
                todo.is_active = "N";
                deleted = true;

                todo_projects_statuses history = new todo_projects_statuses();
                history.history_id = Guid.NewGuid().ToString();
                history.project_id = todo.project_id;
                history.status_id = status_id.ToString(); //  new Guid(status_id).ToString(); // temp deleted
                history.modified_on = System.DateTime.Now;
                te.todo_projects_statuses.Add(history);
            }

            te.SaveChanges();
            return deleted;
        }

        public Guid delete_status()
        {
            // First item with DELETE code name
            return new Guid(this.te.todo_statuses.FirstOrDefault(x=>x.status_code=="DELETE").status_code);
            //return "E827C910-5235-4C87-9F13-DAF960682D56";
        }
    }
}
