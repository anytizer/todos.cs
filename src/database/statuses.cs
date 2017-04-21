using configurations;
using database.mysql;
using dtos;
using dtos.contracts;
using settingsmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using static settingsmanager.ids;

namespace database
{
    public partial class api : BaseAPI, api_contract
    {
        /**
         * Status repository
         */
        public Guid delete_status()
        {
            configurations.identities id = new configurations.identities();
            StatusIDs status = new StatusIDs();
            return status.DELETED;
        }

        public List<NameValueDTO> all_statuses()
        {
            List<NameValueDTO> l = new List<NameValueDTO>();
            foreach (todo_statuses status in this.te.todo_statuses.Where(x => x.in_menu == "Y"))
            {
                NameValueDTO st = new NameValueDTO();
                st.id = new Guid(status.status_id);
                st.name = status.status_shortname;
                st.value = status.status_code;

                st.confirm = status.confirmation_required == "Y";
                st.question = status.confirmation_question;

                l.Add(st);
            }

            return l;
        }

        public List<ProjectsDTO> all_proejcts()
        {
            // @todo Limit the projects to the users
            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            foreach (todo_projects project in this.te.todo_projects)
            {
                ProjectsDTO p = new ProjectsDTO();
                p.id = project.project_id;
                p.name = project.project_name;
                projects.Add(p);
            }

            return projects;
        }
    }
}
