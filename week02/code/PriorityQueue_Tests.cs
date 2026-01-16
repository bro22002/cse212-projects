using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities: Item1 (1), Item2 (5), Item3 (3)
    // Expected Result: Item2, Item3, Item1 based on priority
    // Defect(s) Found: The item is not removed from the queue after Dequeue, so the same item is returned repeatedly.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 3);

        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with duplicate highest priorities: Item1 (2), Item2 (5), Item3 (5), Item4 (3)
    // Expected Result: Item2, Item3, Item4, Item1 based on priority using FIFO for same priority
    // Defect(s) Found: The Dequeue function picks the last item with the highest priority instead of the first one (LIFO instead of FIFO for ties).
    public void TestPriorityQueue_PriorityTie()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 5);
        priorityQueue.Enqueue("Item4", 3);

        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. This test passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue items and ensure the last item is considered for highest priority.
    // Item1 (1), Item2 (2), Item3 (5) that is Item3 is the last one added and has the highest priority.
    // Expected Result: Item3, Item2, Item1
    // Defect(s) Found: The Dequeue loop skips the last item in the queue so the last item is not considered for highest priority.
    public void TestPriorityQueue_LastItemPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 5);

        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }
}
