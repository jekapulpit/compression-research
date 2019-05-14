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
            string input = "Each year fewer people speak English as their mother tongue — but more people speak it as a second or foreign language. In  nearly  of the world’s population spoke English as their first language. By the proportion will have dropped to just over . Chinese is spoken by more speakers than any other language and the numbers of speakers of Spanish, ";
            Researcher researcher = new Researcher(input, new BWT(), new RLE());
            researcher.execute();
            Console.ReadKey();
        }
    }
}
