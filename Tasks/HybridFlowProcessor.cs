using System;
using System.Reflection;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public int Length { get; set; } = 0;
        private Node head;
        private Node tail;

        public T Dequeue()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }

            head.next = head;
            head.next.prev = null;
            head = head.next;

            return head.data;
        }

        public void Enqueue(T item)
        {
            var node = new Node(item);

            if (tail == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
            }

            Length++;
        }

        public T Pop()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }

            tail.prev = tail;
            tail.next = null;
            tail = tail.prev;

            return tail.data;
        }

        public void Push(T item)
        {
            var node = new Node(item);

            if (tail == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
            }

            Length++;
        }

        private class Node
        {
            public T data;
            public Node prev;
            public Node next;
            public Node(T item)
            {
                data = item;
            }
        }
    }
}
