using database.mysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class BaseAPI
    {
        protected todosEntities te;

        public BaseAPI()
        {
            this.te = new todosEntities();
        }
    }
}
