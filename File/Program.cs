
var path = "D:\\3_month";
var fileName = "User.cs";

void FindFile(string path, string fileName)
{
    
    var directory = new DirectoryInfo(path);
    var subDirectories = directory.GetDirectories();
    var subFiles = directory.GetFiles();

    foreach(var file in subFiles)
    {
        if(file.Name == fileName)
            Console.WriteLine(file.FullName);
    }
    foreach(var subDirectory in subDirectories)
    {
        FindFile(subDirectory.FullName, fileName);
    }
    

}