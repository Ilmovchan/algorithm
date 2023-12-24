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
        public T Top { get; private set; }

        public MyStack()
        {
            elements = new List<T>();
            Count = 0;
            Top = default(T);
        }

        public void Push(T val)
        {
            elements.Add(val);
            Count++;
            Top = elements[elements.Count - 1];
        }

        public T Pop()
        {
            if (elements.Count == 0) return default(T);

            T lastElement = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            Count--;
            Top = elements[elements.Count - 1];
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
            Top = default(T);
            Count = 0;
        }

    }
}

