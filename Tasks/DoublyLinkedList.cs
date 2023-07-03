using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; set; } = 0;
        private Node head;
        private Node tail;

        public void Add(T e)
        {
            Node node = new Node(e);
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

        public void AddAt(int index, T e)
        {

            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (index == Length)
            {
                Add(e);
                return;
            }

            Node node = new Node(e);
            if (index == 0)
            {
                head = node;
                return;
            }
            var current = head;
            var currentIndex = 0;

            while (currentIndex < index - 1)
            {
                current = current.next;
                currentIndex++;
            }

            node.next = current.next;
            node.prev = current;
            current.next.prev = node;
            current.next = node;

            Length++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var current = head;
            var currentIndex = 0;

            while (currentIndex < index)
            {
                current = current.next;
                currentIndex++;
            }

            return current.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        public void Remove(T item)
        {
            var current = head;
            var currentIndex = 0;

            while (!current.data.Equals(item))
            {
                current = current.next;
                currentIndex++;
                if (currentIndex >= Length)
                {
                    return;
                }
            }

            if (current.next != null)
            {
                current.next.prev = current.prev;
            }
            else
            {
                tail = current.next;
            }

            if (current.prev != null)
            {
                current.prev.next = current.next;
            }
            else
            {
                head = current.next;
            }


            Length = Length - 1;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var current = head;
            var currentIndex = 0;

            while (currentIndex < index)
            {
                current = current.next;
                currentIndex++;
            }

            if (current.next != null)
            {
                current.next.prev = current.prev;
            }
            else
            {
                tail = current.next;
            }

            if (current.prev != null)
            {
                current.prev.next = current.next;
            }
            else
            {
                head = current.next;
            }

            Length--;
            return current.data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
