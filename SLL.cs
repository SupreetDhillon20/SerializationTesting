using Assignment3.Utility;
using Assignment3;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SLL<T> : ILinkedListADT<T>
{
    private Node<T> head;
    private int count;

    public SLL()
    {
        head = null;
        count = 0;
    }

    public void Prepend(T item)
    {
        var newNode = new Node<T>(item) { Next = head };
        head = newNode;
        count++;
    }

    public void Append(T item)
    {
        var newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }


    public void Serialize(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, this);
        }
    }

    public static SLL<T> Deserialize(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            return (SLL<T>)formatter.Deserialize(stream);
        }
    }

    public int Count()
    {
        return count;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        if (index == 0)
        {
            RemoveFirst();
            return;
        }

        var current = head;
        for (int i = 0; i < index - 1; i++)
            current = current.Next;

        current.Next = current.Next.Next;
        count--;
    }

    public void RemoveFirst()
    {
        if (head == null) return;
        head = head.Next;
        count--;
    }

    public void RemoveLast()
    {
        if (head == null) return;
        if (head.Next == null)
        {
            head = null;
        }
        else
        {
            var current = head;
            while (current.Next.Next != null)
                current = current.Next;

            current.Next = null;
        }
        count--;
    }

    public void InsertAt(int index, T item)
    {
        if (index < 0 || index > count) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        if (index == 0)
        {
            Prepend(item);
            return;
        }
        else if (index == count)
        {
            Append(item);
            return;
        }

        var newNode = new Node<T>(item);
        var current = head;
        for (int i = 0; i < index - 1; i++)
            current = current.Next;

        newNode.Next = current.Next;
        current.Next = newNode;
        count++;
    }

    public void Replace(int index, T item)
    {
        if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        var current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        current.Data = item;
    }

    public T GetAt(int index)
    {
        if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        var current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        return current.Data;
    }

    public int IndexAt(T item)
    {
        var current = head;
        for (int i = 0; i < count; i++)
        {
            if (Equals(current.Data, item)) return i;
            current = current.Next;
        }
        return -1; // Item not found
    }

    public bool Contains(T item)
    {
        return IndexAt(item) != -1;
    }

    public void Clear()
    {
        head = null;
        count = 0;
    }

    public void Reverse()
    {
        Node<T> prev = null;
        var current = head;
        while (current != null)
        {
            var next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        head = prev;
    }
    

    public T[] CopyToArray()
    {
        T[] array = new T[count];
        var current = head;
        for (int i = 0; i < count; i++)
        {
            array[i] = current.Data;
            current = current.Next;
        }
        return array;
    }

    public SLL<T> Divide(int index)
    {
        if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        SLL<T> newList = new SLL<T>();
        if (index == 0)
        {
            newList.head = head;
            head = null;
            newList.count = count;
            count = 0;
            return newList;
        }

        var current = head;
        for (int i = 0; i < index - 1; i++)
            current = current.Next;

        newList.head = current.Next;
        current.Next = null;
        newList.count = count - index;
        count = index;

        return newList;
    }
}
