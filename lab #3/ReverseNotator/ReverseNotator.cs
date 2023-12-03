using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReverseNotator
{
    public static class ReverseNotator
    {
        public static List<string> Convert(string tokens)
        {
            Stack<string> operatorStack = new Stack<string>();
            List<string> outputQueue = new List<string>();
            
            List<string> tokenizedList = Tokenize(tokens);

            foreach (string token in tokenizedList)
            {
                if (char.IsDigit(token[0]) || char.IsLetter(token[0]))
                {
                    outputQueue.Add(token);
                }
                else if (IsOperator(token[0]))
                {
                    while (operatorStack.Count > 0 && GetOperatorPriority(operatorStack.Peek()[0]) >= GetOperatorPriority(token[0]))
                    {
                        outputQueue.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
                else if (token[0] == '(')
                {
                    operatorStack.Push(token);
                }
                else if (token[0] == ')')
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek()[0] != '(')
                    {
                        outputQueue.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0 && operatorStack.Peek()[0] == '(')
                    {
                        operatorStack.Pop();
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                outputQueue.Add(operatorStack.Pop());
            }

            return outputQueue;
        }


        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private static int GetOperatorPriority(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0; // Не оператор
            }
        }
        private static List<string> Tokenize(string str)
        {
            str = str.Replace(" ", "");  // Убираем пробелы
            string pattern = @"([+\-*/()])|(\d+(\.\d+)?)"; // Регулярное выражение

            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(str);
            List<string> result = new List<string>();

            foreach (Match match in matchCollection)
            {
                result.Add(match.Value);
            }

            return result;
        }

    }
}
