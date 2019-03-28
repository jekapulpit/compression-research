using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compress_research
{
    class Program
    {
        static void Main(string[] args)
        {
            BWT sorter = new BWT();
            string encryptMessage = sorter.Encrypt("scpsosat");
            Console.WriteLine("Encrypt message : " + encryptMessage + "; number : " + (sorter.Number + 1));
            string decryptMessage = sorter.Decrypt(encryptMessage, sorter.Number);
            Console.WriteLine("Decrypt message : " + decryptMessage);
            Console.ReadKey();
        }
    }
}
