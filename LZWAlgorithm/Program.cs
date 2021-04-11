using System;

namespace LZWAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var lzwCompressor = new LzwCompressor("banana_bandana");
            lzwCompressor.Encode();
        }
    }
}
