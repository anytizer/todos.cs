using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashers
{
    public class SimpleEncrypter : EncryptionInterface
    {
        public string encrypt(string plain)
        {
            string cipher = plain;
            // @todo Implement proper encrypt
            cipher = new string(cipher.Reverse().ToArray());
            cipher = "ENCRYPTED" + cipher;

            return cipher;
        }

        public string decrypt(string cipher)
        {
            // @todo Implement proper decrypt
            // https://msdn.microsoft.com/en-us/library/xwewhkd1(v=vs.110).aspx

            string decrypted = cipher;
            decrypted = decrypted.Replace("ENCRYPTED", "");
            decrypted = new string(decrypted.Reverse().ToArray());

            return decrypted;
        }
    }
}
