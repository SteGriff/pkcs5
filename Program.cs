using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rfc2898Crypt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                help();
            }

            try
            {
                string password = args[0];
                string username = args[1];
                int bytes = 16;

                if (args.Length >= 3)
                {
                    bytes = Int32.Parse(args[2]);
                }

                string key64 = Encrypt(password, username, bytes);
                Console.WriteLine(key64);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine(ex.Message);
            }

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        private static string Encrypt(string password, string username, int bytes)
        {
            var salt = Encoding.UTF8.GetBytes("rfc2898-syrup-" + username);

            var crypt = new Rfc2898DeriveBytes(password, salt, 1000);
            var key = crypt.GetBytes(bytes);

            return Convert.ToBase64String(key);
        }

        static void help()
        {
            string helptext =
@"
pkcs
    Generate PKCS #5 (RFC2898) key in base64
    by @SteGriff (stegriff.co.uk)

USAGE
    pkcs password salt [bytes]

password
    The password you would like to encrypt into a key

salt
    This string will be added to the end of 'rfc2898-syrup-' and used as salt
    I recommend you pass in the username here

bytes
    Optional - number of bytes in output key complexity. Defaults to 16.
";
            Console.WriteLine(helptext);

        }

    }
}
