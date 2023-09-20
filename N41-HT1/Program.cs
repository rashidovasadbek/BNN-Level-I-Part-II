using N41_HT1;

var queue = new ThreadSafeQueueWithLock<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);

int item;
if(queue.Dequeue(out item))
{
    Console.WriteLine(item);
}


