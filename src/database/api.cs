using database.mysql;
using dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace database
{
    public partial class api : BaseAPI
    {
        private bool project_exists(Guid project_id)
        {
            bool success = false;
            string _project_id = project_id.ToString();
            if (null != this.te.todo_projects.SingleOrDefault(x => x.project_id == _project_id))
            {
                success = true;
            }

            return success;
        }

        private bool status_exists(Guid status_id)
        {
            bool success = false;
            string _status_id = status_id.ToString();
            if (null != this.te.todo_statuses.SingleOrDefault(x => x.status_id == _status_id))
            {
                success = true;
            }

            return success;
        }

        public void add(Guid project_id, Guid status_id, string text)
        {
            /**
             * Pre-verify that the project id and status id exist
             */
            if (this.project_exists(project_id) && this.status_exists(status_id))
            {
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
            else
            {
                // invalid status
                // FK invalid
            }
        }

        public List<todosDTO> todos()
        {
            // @todo read from api, instead of sql

            List<todosDTO> lv = new List<todosDTO>();
            foreach (v_todos t in te.v_todos.OrderByDescending(x => x.added_on))
            {
                todosDTO todo = new todosDTO();

                todo.project_id = t.project_id;
                todo.project_name = t.project_name;
                todo.status_id = t.status_id;
                todo.status_name = t.status_name;
                todo.todo_id = t.todo_id;
                todo.todo_text = t.todo_text;
                todo.added_on = t.added_on;

                lv.Add(todo);
            }

            return lv;
        }

        public List<projectsDTO> projects()
        {
            // @todo read from api, instead of sql
            List<projectsDTO> projects = new List<projectsDTO>();
            foreach (todo_projects p in te.todo_projects)
            {
                projectsDTO pd = new projectsDTO();
                pd.project_id = p.project_id;
                pd.project_name = p.project_name;
                projects.Add(pd);
            }

            return projects;
        }

        /**
         * Mark the item as completed
         */
        public bool done(Guid todo_id, Guid status_id)
        {
            bool found = false;

            string todo_id_string = todo_id.ToString();
            todo_todos todo = te.todo_todos.SingleOrDefault(x => x.todo_id == todo_id_string);
            if (null != todo)
            {
                todo.status_id = status_id.ToString();
                todo.modified_on = System.DateTime.Now;
                //todo.is_active = "N";

                todo_projects_statuses history = new todo_projects_statuses();
                history.history_id = Guid.NewGuid().ToString();
                history.project_id = todo.project_id;
                history.status_id = status_id.ToString(); // new Guid(status_id).ToString(); // temp deleted
                history.modified_on = System.DateTime.Now;
                te.todo_projects_statuses.Add(history);

                found = true;
            }

            int total = te.SaveChanges();
            return found && total >= 1;
        }
    }
}
