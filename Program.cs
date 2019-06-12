using System;

namespace longest_palindromic
{
    class Program
    {
        private static string givenString;
        private static char[] chars;
        static void Main(string[] args)
        {
            if (args.Length < 1) {
                Console.WriteLine("Please provide the palindromic string");
                return;
            }
            chars = args[0].ToCharArray();
            givenString = args[0];

            string longestString = "";

            int index = 0;
            CharEnumerator chEnum = givenString.GetEnumerator();

            while (chEnum.MoveNext() && chars.GetUpperBound(0) > index)
            {
                int end = chEnum.Current.Equals(chars[index + 1]) ? index + 1 : index;
                string str = GetPalindromic(index, end);
                if (str.Length > longestString.Length) {
                    // Might have same length
                    longestString = str;
                }

                index++;
            }
            Console.WriteLine("The palindromic is " + longestString);
        }

        static string GetPalindromic(int start, int end)
        {
            int distance = end - start + 1;
            string str = givenString.Substring(start, distance);
            if (
                (start > 0 && chars.GetUpperBound(0) > end) &&
                chars[start - 1].Equals(chars[end + 1])
            ) {
                str = GetPalindromic(start - 1, end + 1);
            }

            return str;
        }
    }
}
