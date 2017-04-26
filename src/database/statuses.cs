using configurations;
using database.mysql;
using dtos;
using dtos.contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            identities id = new identities();
            StatusIDs status = new StatusIDs();
            return status.DELETED;
        }

        public List<NameValueDTO> all_statuses(LimiterDTO limiter)
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

        public List<ProjectsDTO> all_proejcts(LimiterDTO limiter)
        {
            string filter_projects_sql = @"
SELECT
	p.project_id id,
    p.project_name `name`
FROM todo_projects p
INNER JOIN todo_users_projects up ON up.project_id = p.project_id
WHERE
	up.user_id='{0}'
;";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@user_id", limiter.UserID),
            };

            List<ProjectsDTO> projects = te.Database.SqlQuery<ProjectsDTO>(string.Format(filter_projects_sql, limiter.UserID.ToString())).ToList();

            //List<ProjectsDTO> projects = te.Database.SqlQuery<ProjectsDTO>(filter_projects_sql, parameters.ToArray()).ToList();

            // OR
            /*
            // @todo Limit the projects to the users
            List<ProjectsDTO> projects = new List<ProjectsDTO>();
            //foreach (todo_projects project in this.te.todo_projects)
            foreach (todo_projects project in this.te.todo_projects.Where())
            {
                ProjectsDTO p = new ProjectsDTO();
                p.id = project.project_id;
                p.name = project.project_name;
                projects.Add(p);
            }*/

            return projects;
        }
    }
}
