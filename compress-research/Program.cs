using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compress_research
{
    static class Program
    {
        static void Main(string[] args)
        {
            string input = "ddddfdsfdd;fds;kfjddsajhbkjfdsbgkjfdbgfdlgnfdslkjdsfg;dsjkgdmnbv;ldsmgh;ldsjgdsjgdspoidsjgtpodnpishgpodsjgdspogjdspgjdsgpo[dsjgdspojgdspogdsjgpodsgjspodjgsp";
            BWT sorter = new BWT();
            string encryptMessage = sorter.Encrypt(input);
            RLE compressor = new RLE();
            Console.WriteLine("Supreme message : " + input);
            Console.WriteLine("Sorted message : " + encryptMessage);
            encryptMessage = compressor.encode(encryptMessage);
            Console.WriteLine("Encrypted message : " + encryptMessage);
            string decryptMessage = compressor.decode(encryptMessage);
            Console.WriteLine("Decrypted message : " + decryptMessage);
            decryptMessage = sorter.Decrypt(decryptMessage, sorter.Number);
            Console.WriteLine("Resorted message : " + decryptMessage);
            Console.ReadKey();
        }
    }
}
