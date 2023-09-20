namespace N41_HT1;

public class ThreadSafeQueueWithLock<T>
{
    private Queue<T> queue;
    private readonly object _lock =new ();
    public ThreadSafeQueueWithLock()
    {
        queue = new Queue<T>();
    }

    public void Enqueue(T item)
    {
        lock (_lock)
        {
            queue.Enqueue(item);
        }
    }
    public bool Dequeue(out T item)
    {
        lock (_lock)
        {
            if (queue.Count > 0) 
            {
              item =  queue.Dequeue();   
                return true;
            }
            else
            {
                item = default;
                return false;
            }
        }
    }
}
