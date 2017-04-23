using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtos.contracts
{
    public interface api_contract
    {
        void add(Guid user_id, Guid project_id, Guid status_id, string text);

        List<TodosDTO> todos(LimiterDTO limiter);

        bool done(Guid use_id, Guid todo_id, Guid status_id);

        List<ProjectsDTO> all_projects(Guid user_id);

        List<NameValueDTO> all_statuses(LimiterDTO limiter);
    }
}
