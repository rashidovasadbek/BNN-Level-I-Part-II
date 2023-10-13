 static IEnumerable<int> Fibonacci()
{
    int a = 0;
    int b = 1;

    while (true)
    {

        int temp = a;
        a = b;
        b = temp + b;
        Thread.Sleep(1000);
       yield return a;
    }
}

foreach (int number in Fibonacci())
{
    Console.WriteLine(number);
}