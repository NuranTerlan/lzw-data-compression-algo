using System;

namespace LZWAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var lzwCompressor = new LzwCompressor("banana_bandana");
            var encodedStr = lzwCompressor.Encode();
            Console.WriteLine($"Encoded data -> %{encodedStr}% ({encodedStr.Length} bytes)");
        }
    }
}
