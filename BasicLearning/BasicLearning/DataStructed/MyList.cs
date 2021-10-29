using System;

namespace BasicLearning
{
    public class MyArrayList<T>
    {
        private T[] data;
        private int count;

        public MyArrayList(int capacity)
        {
            data = new T[capacity];
            count = 0;
        }

        public MyArrayList() : this(10)
        {
        }

        public int Capacity
        {
            get { return data.Length; }
        }

        public int Count
        {
            get { return count; }
        }
        
        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public void Add(int index,T t)
        {
            if (index < 0 || index > count)
                throw new ArrayTypeMismatchException("非法索引");

            if (index >= data.Length)
                ResetCapacity(Capacity * 2);
            
            for (int i = count-1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }

            data[index] = t;
            count++;
        }

        public void AddFirst(T t)
        {
            Add(0, t);
        }

        public void AddLast(T t)
        {
            Add(count, t);
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArrayTypeMismatchException("索引越界");

            T removeObj = data[index];
            for (int i = index + 1; i < count; i++)
            {
                data[i - 1] = data[i];
                if (i == count - 1)
                {
                    data[i] = default;
                }
            }

            count--;

            if (count <= data.Length / 4)
                ResetCapacity(data.Length / 2);

            return removeObj;
        }

        public T RemoveFirst()
        {
            return RemoveAt(0);
        }

        public T RemoveLast()
        {
            return RemoveAt(count - 1);
        }

        public T Remove(T t)
        {
            return RemoveAt(IndexOf(t));
        }

        public void Set(int index,T t)
        {
            if (index < 0 || index >= count)
                throw new ArrayTypeMismatchException("索引越界");

            data[index] = t;
        }

        public void Set(T t)
        {
            Set(IndexOf(t), t);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new ArrayTypeMismatchException("索引越界");

            return data[index];
        }

        public bool Contains(T t)
        {
            return IndexOf(t) > -1;
        }

        public int IndexOf(T t)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(t))
                    return i;
            }

            return -1;
        }

        private void ResetCapacity(int capacity)
        {
            T[] newData = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                newData[i] = data[i];
            }

            data = newData;
        }
    }
}