using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtos.contracts
{
    public interface api_contract
    {
        void add(Guid project_id, Guid status_id, string text);

        List<ProjectsDTO> projects();

        List<TodosDTO> todos();

        bool done(Guid todo_id, Guid status_id);

        List<NameValueDTO> all_statuses();
    }
}
