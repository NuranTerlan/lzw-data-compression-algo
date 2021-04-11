using System;

namespace LZWAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var lzwCompressor = new LzwCompressor("banana_bandana_bandana_bananabanana");
            var encodedStr = lzwCompressor.Encode();
            Console.WriteLine($"Encoded data -> %{encodedStr}% ({encodedStr.Length} bytes)");

            var decodedStr = lzwCompressor.Decode();
            Console.WriteLine($"Decoded data -> %{decodedStr}%");

            string input = Console.ReadLine();
            string encData = LzwStaticCompressor.Encode(input);
            Console.WriteLine($"Encoded data -> %{encData}%");
            Console.WriteLine($"Decoded data -> %{LzwStaticCompressor.Decode(encData)}%");
        }
    }
}
