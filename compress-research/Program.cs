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
            string input = "пввыпваававвыпвыввпвыпвпвыпыпвпвыпвыпвыпвыпвыввпвыпвпвыпвыпвыпввыпвыввпвыпвпвыпвыпаавыпавпавыпвыпвыпвыпвыввпвыпвпвыпвыпвыпвыпвыпввыпввыпвыввпвыпвпвыпыпвыпвып";
            Researcher researcher = new Researcher(input, new BWT(), new RLE());
            researcher.execute(0, 0);
            Console.ReadKey();
        }
    }
}
