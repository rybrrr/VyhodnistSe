using System;
using System.Collections.Generic;
using System.Globalization;

namespace Vyhodnoceoguifrghsioeuoj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            try
            {
                float result = Expression.EvaluatePostfix(expression);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Expression
    {
        public static float EvaluatePostfix(string postfixString)
        {
            Stack<float> stack = new Stack<float>();
            string[] values = postfixString.Split(' ');

            foreach (string valStr in values)
            {
                bool succ = float.TryParse(valStr, NumberStyles.Float, CultureInfo.InvariantCulture, out float val);
                if (succ)
                {
                    stack.Push(val);
                    continue;
                }

                if (stack.Count < 2)
                {
                    throw new Exception("Neplatný výraz: chybí operand/y!");
                }

                float num2 = stack.Pop();
                float num1 = stack.Pop();

                switch (valStr)
                {
                    case ("+"):
                        stack.Push(num1 + num2);
                        break;
                    case ("-"):
                        stack.Push(num1 - num2);
                        break;
                    case ("*"):
                        stack.Push(num1 * num2);
                        break;
                    case ("/"):
                        if (num2 == 0)
                        {
                            throw new Exception("Dělení nulou není definováno!");
                        }

                        stack.Push(num1 / num2);
                        break;
                }
            }

            return stack.Pop();
        }


    }
}
