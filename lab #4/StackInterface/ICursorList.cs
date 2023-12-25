using System;
namespace StackInterface
{
	public interface ICursorList<T>
	{
		void Next();
		void Previous();
		T getCurrent();
		void RemoveCurrent();
		void Clear();
		void Add(T val);
	}

    public class CursorList<T> : ICursorList<T>
    {
        List<T> elements;
        public int Cursor { get; private set; }
        public int Count { get; private set; }

        CursorList()
        {
            elements = new List<T>();
            Cursor = 0;
            Count = 0;
        }

        public void Add(T val)
        {
            elements.Add(val);
            Count++;
        }

        public void Clear()
        {
            elements.Clear();
            Count = 0;
        }

        public T getCurrent()
        {
            if (Cursor >= 0 && Cursor <= elements.Count - 1)
            {
                return elements[Cursor];
            }
            return default(T);
        }

        public void Next()
        {
            if (Cursor != elements.Count - 1) Cursor++;
        }

        public void Previous()
        {
            if (Cursor != 0) Cursor--;
        }

        public void RemoveCurrent()
        {
            if (Cursor >= 0 && Cursor <= elements.Count - 1)
            {
                elements.RemoveAt(Cursor);
                Count--;
            }
        }
    }
}

