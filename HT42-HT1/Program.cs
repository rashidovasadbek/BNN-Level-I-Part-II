using System.Collections.Concurrent;

public class ThreadSafeQueue<T> : ConcurrentQueue<T>
{
    private readonly object _lock = new object();

/*    public override void Enqueue(T item)
    {
        lock (_lock)
        {
            base.Enqueue(item);
        }
    }

    public override T Dequeue()
    {
        lock (_lock)
        {
            return base.Dequeue();
        }
    }*/
}
