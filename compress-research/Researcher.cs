using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int execute(int sortAlgorythm, int blockSize) // need to add a sort algorythm and block size
        {
            string resString = this._input;
            float startLength = resString.Length;
            float endLength;
            Console.WriteLine("Supreme message: " + resString + " length: " + startLength);
            resString = this.prepareSort(resString); // add a sort algorythm
            Console.WriteLine("\nSorted message: " + resString);
            resString = this.compress(resString);
            endLength = resString.Length;
            Console.WriteLine("\nCompressed message: " + resString + " length: " + endLength);
            resString = this.decompress(resString);
            Console.WriteLine("\nDecompressed message: " + resString);
            resString = this.encodeSort(resString);
            Console.WriteLine("\nResorted message: " + resString);
            Console.WriteLine("\nCompress effitiency: " + (startLength - endLength)*100/startLength + "%");
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

        private string encodeSort(string sortedString)
        {
            return this._sorter.decrypt(sortedString, _sorter.Number);
        }
    }
}
