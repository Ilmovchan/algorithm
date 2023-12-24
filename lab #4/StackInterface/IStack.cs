using System;
namespace StackInterface
{
	public interface IStack<T>
	{
		void Push(T val);
        void Clear();
		T Pop();
		T Peek();
	}

    public class MyStack<T> : IStack<T>
    {

        public List<T> elements;
        public int Count { get; private set; }

        public MyStack()
        {
            elements = new List<T>();
            Count = 0;
        }

        public void Push(T val)
        {
            elements.Add(val);
            Count++;
        }

        public T Pop()
        {
            if (elements.Count == 0) return default(T);

            T lastElement = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            Count--;
            return lastElement;
        }

        public T Peek()
        {
            if (elements.Count == 0) return default(T);

            T lastElement = elements[elements.Count - 1];
            return lastElement;
        }

        public void Clear()
        {
            elements.Clear();
            Count = 0;
        }

    }
}

