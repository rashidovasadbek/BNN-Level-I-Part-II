
using N44_HT1;

await Cancellation.Execute();
LinqExecutionExample.Execute();
public static class LinqExecutionExample
{
    public static void Execute()
    {

        var collection = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        var query = collection.Select(x =>
        {
            Console.WriteLine($"Processing number {x}");
            return x * 5;
        });

        var result = query.ToArray();

        var mixedQuery = query.Take(3);

    }
}
