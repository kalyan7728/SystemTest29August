using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccentureSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2.Get Character Count
            Console.WriteLine("Enter a array of string\n example : hello,world,kalyan");
            string inputStrings = Console.ReadLine();
            Console.WriteLine("Letter Count:\n" + GetCharacterCount(inputStrings.Split(',')) + "\n");
            Console.ReadLine();
            #endregion

            #region 3.Get all keys present in an object at any level
            string json = "{a:5,b:{c:{d:10}}}";
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            List<string> keys = new List<string>();
            Console.WriteLine("Keys : \n" + JsonConvert.SerializeObject(GetKeys(values, keys)) + "\n");

            Console.WriteLine("Enter a Json string\n example : {a:5,b:{c:{d:10}}}");
            json = Console.ReadLine();
            try
            {
                values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                keys = new List<string>();
                Console.WriteLine("Keys : \n" + JsonConvert.SerializeObject(GetKeys(values, keys)));
            }
            catch
            {
                Console.WriteLine("Invalid Json String");
            }
            Console.ReadLine();
            #endregion

            #region 4.1 Reverse every word of a string
            Console.WriteLine("Enter sentence to reverse every word:");
            string str = Console.ReadLine();
            Console.WriteLine("Reverse string:\n" + ReverseString(str));
            Console.ReadLine();
            #endregion

            #region 4.2 Without using split and reverse
            Console.WriteLine("Enter sentence to reverse every word:");
            string inputStr = Console.ReadLine();
            Console.WriteLine("Reverse string:\n" + WithOutSplitandReverse(inputStr));
            Console.ReadLine();
            #endregion

            #region 5. Remove duplicate strings from an array of strings
            Console.WriteLine("Enter a array of duplicate strings\n example : [\"First\", \"Second\", \"third\", \"third\", \"welcome\", \"welcome\"]");
            try
            {
                string[] strings = JsonConvert.DeserializeObject<string[]>(Console.ReadLine());
                Console.WriteLine(GetUniqueString(strings));
            }
            catch
            {
                Console.WriteLine("Invalid Json String");
            }
            #endregion

            Console.ReadLine();
        }

        public static string GetCharacterCount(string[] inputStrings)
        {
            string allWords = string.Join("", inputStrings);
            Char[] allChars = allWords.Distinct().ToArray();
            Dictionary<string, int> outputDictionary = new Dictionary<string, int>();
            int count, i, j;

            for (i = 0; i < allChars.Count(); i++)
            {
                count = 0;
                for (j = 0; j < allWords.Length; j++)
                {
                    if (allChars[i] == allWords[j])
                    {
                        count++;
                    }
                }
                outputDictionary[allChars[i].ToString()] = count;
            }

            return JsonConvert.SerializeObject(outputDictionary);
        }

        public static List<string> GetKeys(Dictionary<string, object> values, List<string> keys)
        {
            foreach (var d in values)
            {
                keys.Add(d.Key);
                if (d.Value.GetType().Name.ToLower() == "jobject")
                {
                    GetKeys(JsonConvert.DeserializeObject<Dictionary<string, object>>(d.Value.ToString()), keys);
                }
            }
            return keys;
        }

        public static string ReverseString(string word)
        {
            var reversedWords = string.Join(" ", word.Split(' ').Select(x => new String(x.Reverse().ToArray())));
            return reversedWords;
        }

        public static string WithOutSplitandReverse(string word)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<char> charlist = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ' || i == word.Length - 1)
                {
                    if (i == word.Length - 1)
                        charlist.Add(word[i]);
                    for (int j = charlist.Count - 1; j >= 0; j--)
                        stringBuilder.Append(charlist[j]);

                    stringBuilder.Append(' ');
                    charlist = new List<char>();
                }
                else
                    charlist.Add(word[i]);
            }
            return stringBuilder.ToString();
        }

        public static string GetUniqueString(string[] strings)
        {
            return JsonConvert.SerializeObject(strings.Distinct());
        }
    }
}
