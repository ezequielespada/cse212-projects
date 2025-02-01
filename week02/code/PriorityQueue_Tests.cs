using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue elements with different priorities and check the Dequeue order.
    // Expected Result: "Banana" (Priority 5), "Apple" (Priority 3), "Cherry" (Priority 1)
    public void TestPriorityQueue_EnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 3);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Cherry", 1);

        // Dequeue and check the order of elements based on priority
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("Banana", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("Apple", second);

        var third = priorityQueue.Dequeue();
        Assert.AreEqual("Cherry", third);
    }

    [TestMethod]
    // Scenario: Enqueue elements with the same priority, ensure FIFO order.
    // Expected Result: "Apple" then "Banana" (both Priority 3)
    public void TestPriorityQueue_FifoOnSamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 3);
        priorityQueue.Enqueue("Banana", 3);

        // Dequeue and check that they come out in the same order they were added (FIFO)
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("Apple", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("Banana", second);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue should throw an exception.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    public void TestPriorityQueue_EmptyQueueDequeue()
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
    // Scenario: Test multiple elements with mixed priorities.
    // Expected Result: "Banana", "Orange", "Apple", "Pear" (FIFO for same priority)
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 2);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Orange", 5);
        priorityQueue.Enqueue("Pear", 1);

        // Dequeue and check the order based on priority
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("Banana", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("Orange", second);

        var third = priorityQueue.Dequeue();
        Assert.AreEqual("Apple", third);

        var fourth = priorityQueue.Dequeue();
        Assert.AreEqual("Pear", fourth);
    }
}
