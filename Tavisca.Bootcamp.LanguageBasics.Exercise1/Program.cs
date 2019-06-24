using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            int idx1 = equation.IndexOf("*");
            int idx2 = equation.IndexOf("=");

            String s1 = equation.Substring(0, idx1);
            String s2 = equation.Substring(idx1+1, idx2-idx1-1);
            String s3 = equation.Substring(idx2+1);

            if(s1.IndexOf("?") != -1 || s2.IndexOf("?") != -1){
                if(s2.IndexOf("?") != -1){
                    String temp = s1;
                    s1 = s2;
                    s2 = temp;
                }
                
                int val3 = int.Parse(s3);
                int val2 = int.Parse(s2);

                int val1 = val3 / val2;
                String s1original = val1.ToString();
                if(s1.Length != s1original.Length) return -1;

                int idx = s1.IndexOf("?");
                char ch = s1original[idx];

                return ch - '0' == 0 && idx == 0 ? -1 : (ch-'0');
            }
            else{
                int val1 = int.Parse(s1);
                int val2 = int.Parse(s2);
                int val3 = val1 * val2;

                String s3original = val3.ToString();
                if(s3.Length != s3original.Length) return -1;

                int idx = s3.IndexOf("?");
                char ch = s3original[idx];

                return ch - '0' == 0 && idx == 0 ? -1 : (ch - '0');
            }
            throw new NotImplementedException();
        }
    }
}
