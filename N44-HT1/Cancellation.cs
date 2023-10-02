namespace N44_HT1;
public static class Cancellation
{
    public static async ValueTask Execute()
    {

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        try
        {
            await UploadAsync(cts.Token);
        }
        catch (Exception ex) 
        { 
            Console.WriteLine(ex);
            throw;
        }
    }
    public static async ValueTask UploadAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        for (int i = 0; i < 100; i++)
        {
            if (cancellationToken.IsCancellationRequested)
                Console.WriteLine(" "); 
                return;
        }

        Console.WriteLine("Upload a file...");

        await Task.Delay(100,cancellationToken);
    }
}
