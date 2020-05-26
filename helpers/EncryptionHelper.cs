using System;
using System.Text;
using System.Security.Cryptography;

namespace Project.Helpers {

    public class EncryptionHelper {

        // Creates a hash value for the specified value
        public static string CreateHash(string value) {
            byte[] data = Encoding.UTF8.GetBytes(value);
            data = new SHA256Managed().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

    }

}
