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
        public void add(Guid project_id, Guid status_id, string text) { }
        public List<projectsDTO> projects()
        {
            List<projectsDTO> projects = new List<projectsDTO>();
            return projects;
        }
        public List<todosDTO> todos()
        {
            List<todosDTO> todos = new List<todosDTO>();
            return todos;
        }
        public bool done(string todo_id, string status_id)
        {
            return false;
        }
    }
}
