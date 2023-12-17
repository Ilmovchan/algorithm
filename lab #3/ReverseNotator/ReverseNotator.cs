namespace ReverseNotator
{
    public class ReverseNotator
    {
        public void Demo(string infixExpression)
        {
            string postfixExpression = ConvertToRPN(infixExpression);
            Console.WriteLine($"RPN: {postfixExpression}");

            double result = Calculate(postfixExpression);
            Console.WriteLine($"Result: {result}");
        }

        public ReverseNotator()
        {
            symbols = new Dictionary<string, Func<double, double, double>>
            {
                { "+", (double i, double j) => i + j },
                { "-", (double i, double j) => i - j },
                { "%", (double i, double j) => i % j },
                { "/", (double i, double j) => i / j },
                { "*", (double i, double j) => i * j },
            };

            functions = new Dictionary<string, Func<double, double>>
            {
                { "sqrt", (double i) => i * i },
                { "abs", (double i) => Math.Abs(i) },
            };

            numbers = new Dictionary<string, double>();
        }

        private bool IsOperator(string elem)
        {
            return symbols.ContainsKey(elem);
        }

        private bool IsFunc(string elem)
        {
            return functions.ContainsKey(elem);
        }

        private double OperatorCalc(string sym, double i, double j)
        {
            return symbols[sym](i, j);
        }

        private double FuncCalc(string sym, double i)
        {
            return functions[sym](i);
        }

        public double Calculate(string str)
        {
            List<double> numbers = new List<double>();
            string[] elements = str.Split();

            foreach (string element in elements)
            {
                if (double.TryParse(element, out double number))
                {
                    numbers.Add(number);
                }
                else if (IsOperator(element))
                {
                    if (numbers.Count < 2)
                        throw new InvalidOperationException($"ERROR! (Not enough syms) {element}");

                    double b = numbers[numbers.Count - 1];
                    double a = numbers[numbers.Count - 2];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.RemoveAt(numbers.Count - 1);
                    double result = OperatorCalc(element, a, b);
                    numbers.Add(result);
                }
                else if (IsFunc(element))
                {
                    if (numbers.Count < 1)
                        throw new InvalidOperationException($"ERROR! (Not enough syms) {element}");

                    double a = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    double result = FuncCalc(element, a);
                    numbers.Add(result);
                }
                else if (this.numbers.ContainsKey(element))
                {
                    numbers.Add(this.numbers[element]);
                }
                else
                {
                    throw new InvalidOperationException($"ERROR! (Incorrect element) {element}");
                }
            }

            if (numbers.Count != 1) throw new InvalidOperationException("ERROR! (Incorrect expression)");

            return numbers[0];
        }

        public string ConvertToRPN(string str)
        {
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();

            Dictionary<string, int> priority = new Dictionary<string, int>
            {
                { "+", 1 }, { "-", 1 },
                { "*", 2 }, { "/", 2 }, { "%", 2 },
                { "abs", 3 }, { "sqrt", 3 },
                { "(", 0 }
            };

            string[] elements = str.Split();
            foreach (string element in elements)
            {
                if (double.TryParse(element, out double _))
                {
                    result.Add(element);
                }
                else if (IsOperator(element) || IsFunc(element))
                {
                    while (stack.Count > 0 && priority[stack.Peek()] >= priority[element])
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Push(element);
                }
                else if (element == "(")
                {
                    stack.Push(element);
                }
                else if (element == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else if (numbers.ContainsKey(element))
                {
                    result.Add(numbers[element].ToString());
                }
                else
                {
                    throw new InvalidOperationException($"Invalid token: {element}");
                }
            }

            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            return string.Join(" ", result);
        }

        private Dictionary<string, Func<double, double, double>> symbols;
        private Dictionary<string, Func<double, double>> functions;
        private Dictionary<string, double> numbers;
    }
}