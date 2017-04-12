using dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraries
{
    public class todoer
    {
        private database.todoer db;

        public todoer()
        {
            db = new database.todoer();
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

        public bool done(string todo_id, string status_id)
        {
            return db.done(todo_id, status_id);
        }

        public string delete_status()
        {
            return "E827C910-5235-4C87-9F13-DAF960682D56";
        }
    }
}
