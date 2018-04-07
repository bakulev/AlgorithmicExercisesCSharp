using System;

namespace TwinStrings
{
    class Program
    {
        static string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
        static string RemoveUnwantedChar(string input)
        {

            string result = "";
            var inputArr = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (allowedCharacters.Contains(inputArr[i].ToString()))
                {
                    result += input[i];
                }
            }
            return result;
        }

        // Returns encoding of string that can be used for hashing.
        // The idea is to return same encoding for strings which 
        // can become same after swapping a even positioned character
        // with other even characters OR swapping an odd character
        // with other odd characters.
        static string encodeString(char[] text)
        {
            // maximum char number
            int MAX_CHAR = 'z' - 'a' + 1;
            // hashEven stores the count of even indexed character
            // for each string hashOdd stores the count of odd
            // indexed characters for each string
            int[] hashEven = new int[MAX_CHAR];// { 0 };
            int[] hashOdd = new int[MAX_CHAR];// { 0 };

            // creating hash for each string
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (i % 2 == 0) // If index of current character is odd
                    hashOdd[c - 'a']++;
                else
                    hashEven[c - 'a']++;
            }

            // For every character from 'a' to 'z', we store its
            // count at even position followed by a separator,
            // followed by count at odd position.
            string encoding = "";
            for (int i = 0; i < MAX_CHAR; i++)
            {
                encoding += hashEven[i].ToString();
                encoding += '-';
                encoding += hashOdd[i].ToString();
                encoding += '-';
            }
            return encoding;
        }

        /*
         * Complete the function below.
         * DO NOT MODIFY CODE OUTSIDE THIS FUNCTION!
         */
        static string[] twins(string[] a, string[] b)
        {
            string[] results = new string[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (i < b.GetLength(0))
                {
                    var hash1 = encodeString(RemoveUnwantedChar(a[i].ToLower()).ToCharArray());
                    var hash2 = encodeString(RemoveUnwantedChar(b[i].ToLower()).ToCharArray());
                    if (hash1 == hash2)
                        results[i] = "Yes";
                    else
                        results[i] = "No";
                }
                else
                {
                    results[i] = "No";
                }
            }


            return results;

        }
        // DO NOT MODIFY CODE OUTSIDE THE ABOVE FUNCTION!

        static void Main(String[] args)
        {
            string[] res;

            int _a_size = 0;
            _a_size = Convert.ToInt32(Console.ReadLine());
            string[] _a = new string[_a_size];
            string _a_item;
            for (int _a_i = 0; _a_i < _a_size; _a_i++)
            {
                _a_item = Console.ReadLine();
                _a[_a_i] = _a_item;
            }


            int _b_size = 0;
            _b_size = Convert.ToInt32(Console.ReadLine());
            string[] _b = new string[_b_size];
            string _b_item;
            for (int _b_i = 0; _b_i < _b_size; _b_i++)
            {
                _b_item = Console.ReadLine();
                _b[_b_i] = _b_item;
            }

            res = twins(_a, _b);
            for (int res_i = 0; res_i < res.Length; res_i++)
            {
                Console.WriteLine(res[res_i]);
            }
        }
    }
}
