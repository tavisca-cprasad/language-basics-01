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

        public int FindDigit(String equation){
            int idx_star = equation.IndexOf("*");
            int idx_equal = equation.IndexOf("=");

            String operand1 = equation.Substring(0, idx_star);
            String operand2 = equation.Substring(idx_star+1, idx_equal-idx_star-1);
            String operand3 = equation.Substring(idx_equal+1);

            if(operand1.IndexOf("?") != -1 || operand2.IndexOf("?") != -1){
                if(operand2.IndexOf("?") != -1){
                    String temp = operand1;
                    operand1 = operand2;
                    operand2 = temp;
                }
                
                int intval3 = int.Parse(operand3);
                int intval2 = int.Parse(operand2);

                int intval1 = intval3 / intval2;
                String operand1original = intval1.ToString();
                if(operand1.Length != operand1original.Length) return -1;

                int idx = operand1.IndexOf("?");
                char ch = operand1original[idx];

                return ch - '0' == 0 && idx == 0 ? -1 : (ch-'0');
            }
            else{
                int intval1 = int.Parse(operand1);
                int intval2 = int.Parse(operand2);
                int intval3 = intval1 * intval2;

                String operand3original = intval3.ToString();
                if(operand3.Length != operand3original.Length) return -1;

                int idx = operand3.IndexOf("?");
                char ch = operand3original[idx];

                return ch - '0' == 0 && idx == 0 ? -1 : (ch - '0');
            }
        }
    }
}
