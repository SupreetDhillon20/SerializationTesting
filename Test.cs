using NUnit.Framework;
using Assignment3.Utility; 

[TestFixture]
public class Test
{
    private SLL<int> list; 

    [SetUp]
    public void Setup()
    {
        list = new SLL<int>(); 
    }

    [Test]
    public void ListIsEmpty()
    {
        Assert.AreEqual(0, list.Count());
    }

    [Test]
    public void PrependItem()
    {
        list.Prepend(1);
        Assert.AreEqual(1, list.GetAt(0));
    }

    [Test]
    public void AppendItem()
    {
        list.Append(1);
        Assert.AreEqual(1, list.GetAt(0));
    }

    [Test]
    public void InsertAtIndex()
    {
        list.Append(1);
        list.Append(3);
        list.InsertAt(1, 2);
        Assert.AreEqual(2, list.GetAt(1));
    }

    [Test]
    public void ReplaceItem()
    {
        list.Append(1);
        list.Append(2);
        list.Replace(1, 3);
        Assert.AreEqual(3, list.GetAt(1));
    }

    [Test]
    public void RemoveFromBeginning()
    {
        list.Append(1);
        list.Append(2);
        list.RemoveFirst();
        Assert.AreEqual(1, list.Count());
    }

    [Test]
    public void RemoveFromEnd()
    {
        list.Append(1);
        list.Append(2);
        list.RemoveLast();
        Assert.AreEqual(1, list.Count());
    }

    [Test]
    public void RemoveFromMiddle()
    {
        list.Append(1);
        list.Append(2);
        list.Append(3);
        list.RemoveAt(1); // Remove the item at index 1 (the second item)
        Assert.AreEqual(2, list.Count());
        Assert.AreEqual(3, list.GetAt(1));
    }

    // An existing item is found and retrieved.
    [Test]
    public void FindAndRetrieveItem()
    {
        list.Append(1);
        list.Append(2);
        list.Append(3);
        var item = list.GetAt(1); 
        Assert.AreEqual(2, item);
    }

    [Test]
    public void ReverseList()
    {
        list.Append(1);
        list.Append(2);
        list.Append(3);
        list.Reverse();
        Assert.AreEqual(3, list.GetAt(0));
        Assert.AreEqual(2, list.GetAt(1));
        Assert.AreEqual(1, list.GetAt(2));
    }

    [Test]
    public void CopyToArray_ReturnsEmpty()
    {
        var array = list.CopyToArray();
        Assert.IsEmpty(array);
    }

    [Test]
    public void CopyToArray_ReturnsArrayElements()
    {
        list.Append(1);
        list.Append(2);
        list.Append(3);

        var array = list.CopyToArray();

        Assert.AreEqual(3, array.Length);
        Assert.AreEqual(1, array[0]);
        Assert.AreEqual(2, array[1]);
        Assert.AreEqual(3, array[2]);
    }

}
