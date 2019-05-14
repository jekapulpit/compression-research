using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace compress_research
{
    class Researcher
    {
        BWT _sorter;
        RLE _compressor;
        string _input;
        public Researcher(string input, BWT sorter, RLE compressor)
        {
            _input = input;
            _sorter = sorter;
            _compressor = compressor;
        }

        public int execute() // need to add a sort algorythm and block size
        {
            string resString = this._input;
            string resBuffer = resString;
            float startLength = resString.Length;
            float endLength = 0;
            Console.WriteLine("Supreme message length: " + startLength);
            Console.WriteLine("\nAlgorythm\t\t\tTime");
            for(int i = 1; i < 6; i++ )
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                resString = this.prepareSort(resString);
                resString = this.compress(resString);
                resBuffer = resString;
                endLength = resString.Length;
                resString = this.decompress(resString);
                resString = this.encodeSort(resString, i);
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds + "ms");
            }
            Console.WriteLine("\nCompressed message: " + resBuffer + "\nlength: " + resBuffer.Length);
            Console.WriteLine("\nResorted message: " + resString);
            Console.WriteLine("\nEffitiency: " + (startLength - endLength)*100/startLength + "%");
            return 0;
        }

        private string prepareSort(string supremeString)
        {
            return this._sorter.encrypt(supremeString);
        }

        private string compress(string sortedString)
        {
            return this._compressor.encode(sortedString);
        }

        private string decompress(string compressedString)
        {
            return this._compressor.decode(compressedString);
        }

        private string encodeSort(string sortedString, int sortAlgorythm)
        {
            return this._sorter.decrypt(sortedString, _sorter.Number, sortAlgorythm);
        }
    }
}
