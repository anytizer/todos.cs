using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtos
{
    public class TodosDTO
    {
        public NameIDDTO project;
        public NameIDDTO status;

        public Guid todo_id;
        public DateTime added_on;
        public string todo_text;
    }
}
