using System;
namespace StackInterface
{
    public interface IQueue<T>
    {
        void Enqueue(T val);
        T Dequeue();
        T Peek();
        void Clear();
    }

    public class SimpleQueue<T> : IQueue<T>
    {
        List<T> items;
        public int Count { get; private set; }

        public SimpleQueue()
        {
            items = new List<T>();
            Count = 0;
        }

        public void Enqueue(T val)
        {
            items.Add(val);
            Count++;
        }

        public T Dequeue()
        {
            if (items.Count == 0) return default(T);

            T val = items[0];
            items.RemoveAt(0);
            Count--;
            return val;
        }

        public T Peek()
        {
            if (items.Count == 0) return default(T);
            return items[0];
        }

        public void Clear()
        {
            items.Clear();
            Count = 0;
        }
    }
}

