using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashers
{
    public interface EncryptionInterface
    {
        /**
         * Encrypt something
         */
        string encrypt(string plain);

        /**
         * Decrypt something
         */
        string decrypt(string cypher);
    }
}
