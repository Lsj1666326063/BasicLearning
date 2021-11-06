using System;
using System.Text;

namespace BasicLearning
{
    /// <summary>
    /// 环形数组队列 (支持手动扩容)
    /// </summary>
    public class CircleArrayQueue
    {
        private static int DEFAULT_CAPACITY = 2;
        
        private int capacity;
        private int[] data;
        private int rear;
        private int front;

        public CircleArrayQueue(int capacity)
        {
            this.capacity = capacity + 1; // 判断为满的算法会空出一个不能使用的空间，这里将传入的总数+1，以保证队列可存储总数量的正确
            data = new int[this.capacity];
            rear = 0;
            front = 0;
        }

        public CircleArrayQueue():this(DEFAULT_CAPACITY){}

        public bool IsFull()
        {
            return (rear + 1) % capacity == front;
        }

        public bool IsEmpty()
        {
            return rear == front;
        }

        public void Enqueue(int item)
        {
            if (IsFull())
            {
                ConsoleUtil.WriteLine($"队列已满", ConsoleColor.Red);
                return;
            }

            data[rear] = item;
            rear = (rear + 1) % capacity;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception($"队列为空");
            }

            int item = data[front];
            front = (front + 1) % capacity;
            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception($"队列为空");
            }

            return data[front];
        }

        public int Count()
        {
            /*
             * 我对这个算法的理解
             * 
             * 一般情况下获得有效元素数量可以这么做 思路比较清晰
             *     如果 (rear > front) 那么 count = (rear - front)
             *     如果 (rear < front) 那么 count = (capacity - front + rear) = (capacity + rear - front)
             * 
             * 想出这个算法的人可能在想，卧槽！在 (rear < front) 的情况下只比 (rear > front) 的情况下多了个 capacity +
             * 那如果我在(rear > front)的情况下也使用(capacity + rear - front)呢
             * 
             * 举个例子：容量为5  索引为0-4  有效数量为4  
             *     如果情况为(rear > front)  rear为4  front为0
             *         带入公式 (capacity + rear - front)：count = 5+4-0 = 9  实际有效数量为4
             *     如果情况为(rear < front)  rear为2  front为3
             *         带入公式 (capacity + rear - front)：count = 5+2-3 = 4  实际有效数量为4
             * 想出这个算法的人可能在想，卧日a！9和4咋在经过计算后都变成4嘞， 结果就是 %capacity， 4 = 9%5 = 4%5 ，结合算出9和4的公式就是 4 = (5+4-0)%5 = (5+2-3)%5
             *
             * 感慨：
             * 真牛逼！他咋j8想到%capacity嘞啊...
             */
            return (capacity + rear - front) % capacity;
        }
        
        public int Capacity()
        {
            return capacity - 1;
        }

        public void SetCapacity(int newCapacity)
        {
            int count = Count();
            if (newCapacity < count) // 新容量必须能放下所有有效元素，否则不让修改容量
            {
                ConsoleUtil.WriteLine($"设置的容量不足以放下当前队列中所有的元素", ConsoleColor.Red);
                return;
            }

            newCapacity = newCapacity + 1; // 这里加1的原因 看上面的有参构造方法中的注释
            
            int[] newData = new int[newCapacity];
            for (int i = 0; i < count; i++)
            {
                int index = (i + front) % capacity;
                newData[i] = data[index];
            }

            capacity = newCapacity;
            data = newData;
            front = 0;
            rear = count;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            int count = Count();
            for (int i = 0; i < count; i++)
            {
                int index = (i + front) % capacity;
                info.Append($"Element[{index}] = {data[index]}\r\n");
            }

            info.Append($"Count = {count}\n");
            info.Append($"Capacity = {Capacity()}");
            return info.ToString();
        }
    }
}