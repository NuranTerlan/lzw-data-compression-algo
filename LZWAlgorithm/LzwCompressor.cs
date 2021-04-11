using System;
using System.Collections.Generic;
using System.Linq;

namespace LZWAlgorithm
{
    public class LzwCompressor : IOperations
    {
        public string Data { get; set; }

        private Dictionary<string, int> _dict;
        private List<int> _encodedList;

        public LzwCompressor(string data)
        {
            Data = data;
            Console.WriteLine($"Initial data is -> %{data}% ({data.Length} bytes)");
        }

        public string Encode()
        {
            _dict = new Dictionary<string, int>();
            int count = 0;
            MakeDictionary(_dict, ref count);

            string s = "";
            _encodedList = new List<int>();
            for (int i = 0; i < Data.Length; i++)
            {
                if (_dict.ContainsKey(s + Data[i]))
                {
                    s += Data[i];
                    continue;
                }

                _encodedList.Add(_dict[s]);
                _dict[s + Data[i]] = count;
                count++;
                s = "" + Data[i];
            }
            // one more step to finalize encoded data
            _encodedList.Add(_dict[s]);

            string result = "";

            for (int i = 0; i < _encodedList.Count; i++)
            {
                result += _encodedList[i];
            }

            return result;
        }

        private void MakeDictionary(Dictionary<string, int> dict, ref int count)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == ' ' || dict.ContainsKey(Data[i].ToString())) continue;
                dict[Data[i].ToString()] = count;
                count++;
            }
        }

        public string Decode()
        {
            string result = "";
            for (int i = 0; i < _encodedList.Count; i++)
            {
                result += _dict.FirstOrDefault(pair =>
                    pair.Value == _encodedList[i]).Key;
            }

            return result;
        }
    }
}