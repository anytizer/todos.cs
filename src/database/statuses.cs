using database.mysql;
using dtos;
using dtos.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace database
{
    public partial class api: BaseAPI, api_contract // , contract
    {
        /**
         * Status repository
         */
        public Guid delete_status()
        {
            return dtos.defaults.statuses.DELETED;
        }

        public List<NameValueDTO> all_statuses()
        {
            List<NameValueDTO> l = new List<NameValueDTO>();
            foreach(todo_statuses status in this.te.todo_statuses.Where(x=>x.in_menu =="Y"))
            {
                NameValueDTO st = new NameValueDTO();
                st.id = new Guid(status.status_id);
                st.name = status.status_shortname;
                st.value = status.status_code;

                l.Add(st);
            }

            return l;
        }
    }
}
