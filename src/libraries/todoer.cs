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

        public void add(Guid project_id, Guid status_id, string text)
        {
            this.api.add(project_id, status_id, text);
        }

        public List<ProjectsDTO> projects()
        {
            return this.api.projects();
        }

        public List<TodosDTO> todos()
        {
            return this.api.todos();
        }

        public bool done(Guid todo_id, Guid status_id)
        {
            return this.api.done(todo_id, status_id);
        }

        public List<NameValueDTO> all_statuses()
        {
            return this.api.all_statuses();
        }
    }
}
