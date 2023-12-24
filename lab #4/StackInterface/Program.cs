namespace StackInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(5);
            stack.Push(16);
            stack.Push(-3);

            stack.Push(31);
            stack.Push(1);
            stack.Push(-1);

            stack.Clear();

            foreach (var i in stack.elements) Console.WriteLine(i);
        }
    }
}