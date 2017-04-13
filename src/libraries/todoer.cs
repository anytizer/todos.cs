using dtos;
using System;
using System.Collections.Generic;

namespace libraries
{
    public class todoer
    {
        private database.api db;

        public todoer()
        {
            db = new database.api();
        }

        public void add(Guid project_id, Guid status_id, string text)
        {
            db.add(project_id, status_id, text);
        }

        public List<projectsDTO> projects()
        {
            return db.projects();
        }

        public List<todosDTO> todos()
        {
            //List<todosDTO> todos = new List<todosDTO>();
            //return todos;
            return db.todos();
        }
        public bool done(Guid todo_id, Guid status_id)
        {
            return db.done(todo_id, status_id);
        }
    }
}
