namespace N55_HT1;

public static class TestExample
{
    public static void Execute()
    {
        var appfolder = Directory.GetCurrentDirectory();
        var appFile = Directory.GetFiles(appfolder);
        var appFolder = Directory.GetDirectories(appfolder);

        long fileSizeInKB = 0;
        Console.Write("Folder:");
        Console.WriteLine(appFolder.Count());
        Console.Write("File:");
        Console.WriteLine(appFile.Count());
        Console.Write("Files size:");
        foreach (var file in appFile)
             fileSizeInKB += file.Length;
        Console.WriteLine(fileSizeInKB);
        Console.Write("Max file size:");
        var list = new List<long>();
        foreach (var file in appFile)
            list.Add(file.Length); 
        list.Sort();
        Console.WriteLine(list.Last());
    }
}
