using System;
using System.Collections.Generic;

namespace LZWAlgorithm
{
    public class LzwCompressor : IOperations
    {
        public string Data { get; set; }

        public LzwCompressor(string data)
        {
            Data = data;
        }

        public string Encode()
        {
            var dict = new Dictionary<char, int>();
            int count = 0;
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == ' ' || dict.ContainsKey(Data[i])) continue;
                dict[Data[i]] = count;
                count++;
            }

            foreach (var dictKey in dict.Keys)
            {
                Console.WriteLine(dictKey);
            }

            string result = "";
            return result;
        }

        public string Decode()
        {
            throw new System.NotImplementedException();
        }
    }
}