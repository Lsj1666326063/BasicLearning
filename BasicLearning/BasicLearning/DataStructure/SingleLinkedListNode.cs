using System;

namespace BasicLearning
{
    public class SingleLinkedListNode<T>:IDisposable
    {
        public T Data { get; set; }
        public SingleLinkedListNode<T> Next { get; set; }

        public SingleLinkedListNode(T data)
        {
            this.Data = data;
        }

        public void Dispose()
        {
            Next = null;
        }
    }
}