using System;
using System.Collections.Generic;
using System.Linq;

namespace LZWAlgorithm
{
    public static class LzwStaticCompressor
    {
        private static Dictionary<string, int> _dict;

        public static string Encode(string text)
        {
            _dict = new Dictionary<string, int>();

            int count = 0;
            MakeDictionary(text, ref count);

            string temp = "";
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (_dict.ContainsKey(temp + text[i]))
                {
                    temp += text[i];
                    continue;
                }

                result += _dict[temp] + ".";
                _dict[temp + text[i]] = count;
                count++;
                temp = "" + text[i];
            }
            // one more step to finalize encoded data
            result += _dict[temp];

            return result;
        }

        public static string Decode(string text)
        {
            string result = "";

            var numbers = text.Split(".").Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                result += _dict.FirstOrDefault(pair =>
                    pair.Value == numbers[i]).Key;
            }

            return result;
        }

        private static void MakeDictionary(string text, ref int count)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' || _dict.ContainsKey(text[i].ToString())) continue;
                _dict[text[i].ToString()] = count;
                count++;
            }
        }
    }
}