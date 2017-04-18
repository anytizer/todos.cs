using dtos;
using dtos.contracts;
using System;
using System.Collections.Generic;

namespace libraries
{
    public class todoer: api_contract
    {
        private database.api api;

        public todoer()
        {
            this.api = new database.api();
        }

        public void add(Guid user_id, Guid project_id, Guid status_id, string text)
        {
            this.api.add(user_id, project_id, status_id, text);
        }

        public List<ProjectsDTO> all_projects(Guid user_id)
        {
            return this.api.all_projects(user_id);
        }

        public List<TodosDTO> todos(LimiterDTO limiter)
        {
            return this.api.todos(limiter);
        }

        public bool done(Guid user_id, Guid todo_id, Guid status_id)
        {
            return this.api.done(user_id, todo_id, status_id);
        }

        public List<NameValueDTO> all_statuses()
        {
            return this.api.all_statuses();
        }
    }
}
