using System.Text;

namespace EmailTemplateApp;
public class MutexTestA
{
    public static Task ExecuteAsync()
    {
        var filePath = "D:\\3_month\\mutex\\mutex.txt";
        var mutex = new Mutex(false, "write in File");
        return Task.Run(() =>
        {
            mutex.WaitOne();
            var guid = Guid.NewGuid();
            var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);

            var emailTemplate = "Hello {{UserName}}, Welcome to out platform".Replace("{{UserName}}","Asadbek");

            fileStream.Write(buffer: Encoding.UTF8.GetBytes(emailTemplate));

            Thread.Sleep(15000);

            fileStream.Close();
            Console.WriteLine($"App {guid} closed the file");
            mutex.ReleaseMutex();

            var buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            var template = Encoding.UTF8.GetString(buffer);
        });
    }

}
