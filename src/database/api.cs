using database.mysql;
using dtos;
using dtos.contracts;
using settingsmanager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace database
{
    public partial class api : BaseAPI, api_contract
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

        public void add(Guid user_id, Guid project_id, Guid status_id, string text)
        {
            /**
             * Pre-verify that the project id and status id exist
             */
            if (this.project_exists(project_id))
            {
                if (this.status_exists(status_id))
                {
                    DateTime now = System.DateTime.Now;

                    database.mysql.todo_todos todo = new database.mysql.todo_todos();
                    todo.todo_id = Guid.NewGuid().ToString();
                    todo.issue_number = "";
                    todo.todo_text = text;
                    todo.is_active = "Y";

                    todo_projects_todos tpd = new todo_projects_todos();
                    tpd.project_id = project_id.ToString();
                    tpd.todo_id = todo.todo_id;
                    tpd.added_on = now;

                    // @ set all other existing ones into not latest
                    string todo_id_text = todo.todo_id.ToString();
                    foreach (todo_todos_statuses ids in te.todo_todos_statuses.Where(x=>x.todo_id == todo_id_text))
                    {
                        ids.is_latest = "N";
                    }

                    StatusIDs s = new StatusIDs();

                    todo_todos_statuses ts = new todo_todos_statuses();
                    ts.todo_status_id = Guid.NewGuid().ToString();
                    ts.user_id = user_id.ToString();
                    ts.todo_id = todo.todo_id;
                    ts.status_id = s.NEW.ToString();
                    ts.added_on = System.DateTime.Now;
                    ts.is_latest = "Y";

                    todo_users_todos tut = new todo_users_todos();
                    tut.user_id = user_id.ToString();
                    tut.todo_id = todo.todo_id;
                    tut.added_on = now;

                    te.todo_todos.Add(todo);
                    te.todo_projects_todos.Add(tpd);
                    te.todo_todos_statuses.Add(ts);

                    te.SaveChanges();
                }
            }
        }

        public List<TodosDTO> todos()
        {
            // @todo read from api, instead of sql

            List<TodosDTO> lv = new List<TodosDTO>();
            foreach (v_todos t in te.v_todos) //.OrderByDescending(x => x.added_on)
            {
                TodosDTO todo = new TodosDTO();

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

        /**
         * @todo List the projects limited to the user
         * @todo read from api, instead of sql
         */
        public List<ProjectsDTO> all_projects(Guid user_id)
        {
            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            string user_id_text = user_id.ToString();
            foreach (todo_projects p in te.todo_projects)
            //foreach (todo_projects p in te.todo_users_projects.Where(x=>x.user_id == user_id_text))
            {
                ProjectsDTO pd = new ProjectsDTO();
                pd.id = p.project_id;
                pd.name = p.project_name;
                projects.Add(pd);
            }

            return projects;
        }

        /**
         * Patch only: Mark the item as completed
         */
        public bool done(Guid user_id, Guid todo_id, Guid status_id)
        {
            string todo_id_text = todo_id.ToString();
            foreach (todo_todos_statuses ids in te.todo_todos_statuses.Where(x => x.todo_id == todo_id_text))
            {
                ids.is_latest = "N";
            }

            todo_todos_statuses ts = new todo_todos_statuses();
            ts.todo_status_id = Guid.NewGuid().ToString();
            ts.user_id = user_id.ToString();
            ts.todo_id = todo_id_text;
            ts.status_id = status_id.ToString(); //  dtos.defaults.statuses.NEW.ToString();
            ts.added_on = System.DateTime.Now;
            ts.is_latest = "Y";
            te.todo_todos_statuses.Add(ts);

            int total = te.SaveChanges();
            return total >= 1;
        }
    }
}
