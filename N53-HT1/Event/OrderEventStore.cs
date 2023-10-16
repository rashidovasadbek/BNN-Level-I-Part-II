using N53_HT1.Model.Entities;

namespace N53_HT1.Event;

public class OrderEventStore
{
    public event Func<Order, ValueTask>? OnOrderCreated;

    public async ValueTask OrderCreatedEventAsync(Order order)
    {
        if(OnOrderCreated != null)
            await OnOrderCreated(order);
    }
}