using database;
using dtos;
using System.Collections.Generic;

namespace libraries
{
    public class todoer
    {
        public List<TodosDTO> todo()
        {
            List<TodosDTO> l = new List<TodosDTO>();

            todoEntities te = new todoEntities();
            foreach(v_todo t in te.v_todo)
            {
                TodosDTO item = new TodosDTO();
                item.project = new NameIDDTO { id = new System.Guid(t.project_id), name = t.project_name };
                item.status = new NameIDDTO { id = new System.Guid(t.status_id), name = t.status_name };

                l.Add(item);
            }

            return l;
        }
    }
}
