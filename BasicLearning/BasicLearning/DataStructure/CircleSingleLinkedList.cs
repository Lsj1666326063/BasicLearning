using System;
using System.Runtime.CompilerServices;

namespace BasicLearning
{
    /// <summary>
    /// 单向环形链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircleSingleLinkedList<T>
    {
        public SingleLinkedListNode<T> First => first;
        private SingleLinkedListNode<T> first;

        public SingleLinkedListNode<T> Last => last;
        private SingleLinkedListNode<T> last;

        public int Count => count;
        private int count;

        public CircleSingleLinkedList()
        {
            first = null;
            last = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Add(T item)
        {
            SingleLinkedListNode<T> node = new SingleLinkedListNode<T>(item);
            if (IsEmpty())
            {
                first = node;
                node.Next = first;
                last = node;
            }
            else
            {
                last.Next = node;
                node.Next = first;
                last = node;
            }

            count++;
        }

        public void Remove(T item)
        {
            if (IsEmpty())
            {
                ConsoleUtil.WriteLine($"链表为空", ConsoleColor.Red);
                return;
            }

            // 只有一个元素时直接判断是不是要移除的元素
            if (count == 1)
            {
                if (first.Data.Equals(item))
                {
                    first.Dispose();
                    first = null;
                    last = null;
                    count = 0;
                    return;
                }
                else
                {
                    ConsoleUtil.WriteLine($"没找到要移除的元素", ConsoleColor.Red);
                    return;
                }
            }

            // 有一个以上元素时先找到要移除的元素和要移除元素的上一个元素
            bool isFind = false;
            SingleLinkedListNode<T> temp = first;
            SingleLinkedListNode<T> tempPrevious = last;
            for (int i = 0; i < count; i++)
            {
                if (temp.Data.Equals(item))
                {
                    isFind = true;
                    break;
                }

                temp = temp.Next;
                tempPrevious = tempPrevious.Next;
            }

            if(!isFind)
                ConsoleUtil.WriteLine($"没找到要移除的元素", ConsoleColor.Red);
            else
            {
                if (temp == first)
                    first = temp.Next;
                else if (temp == last)
                    last = tempPrevious;
                
                tempPrevious.Next = temp.Next;
                temp.Dispose();

                count--;
            }
        }

        public void Clear()
        {
            if (IsEmpty())
                return;
            
            // 把环断开
            last.Next = null;
            // 将所有节点释放
            SingleLinkedListNode<T> temp = first;
            while (temp != null)
            {
                SingleLinkedListNode<T> curTemp = temp;
                temp = temp.Next;
                curTemp.Dispose();
            }

            first = null;
            last = null;
            count = 0;
        }
    }
}