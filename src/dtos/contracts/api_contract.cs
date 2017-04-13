using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtos.contracts
{
    public interface api_contract
    {
        List<NameValueDTO> all_statuses();
    }
}
