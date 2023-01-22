using System;
using System.IO;
using System.Threading;
using System.Text;
using System.IO.Pipes;
//Console.WriteLine("Основной поток: ставим в очередь рабочий элемент");
//Random r = new Random();
//for (int i = 0; i < 10; ++i)
//    ThreadPool.QueueUserWorkItem(WorkingElementMethod, r.Next(10));
//Console.WriteLine("Основной поток:выполняем другие задачи");
//Thread.Sleep(1000);
//Console.WriteLine("Нажмите любую клавишу для продолжения...");
//Console.ReadLine();
// static void WorkingElementMethod(object state)
//{
//    Console.WriteLine($"\tпоток: {Thread.CurrentThread.ManagedThreadId} состояние = {state}");
//    Thread.Sleep(1000);
//}

//FileStream fs = new FileStream(@"../../
// Program.cs",
// FileMode.Open,
// FileAccess.Read, FileShare.Read, 1024,
// FileOptions.Asynchronous);
//Byte[] data = new Byte[100];
//IAsyncResult ar = fs.BeginRead(data, 0,
//data.Length, null, null);
//while (!ar.IsCompleted)
//{
//    Console.WriteLine("Операция не завершена, ожидайте...");

//    Thread.Sleep(10);
//}
//Int32 bytesRead = fs.EndRead(ar);
//fs.Close();
//Console.WriteLine("Количество считаныхбайт = { 0}", bytesRead);
// Console.WriteLine(Encoding.UTF8.
//GetString(data).Remove(0, 1));

//using (FileStream fileStream = new FileStream("Test#@@#.dat", FileMode.OpenOrCreate,FileAccess.ReadWrite, FileShare.ReadWrite));

//string[] files = {"../../Program.cs",
// "../../Potoki.csproj",
// "../../Properties/AssemblyInfo.cs"};
//AsyncReader[] asrArr = new AsyncReader[3];
//for (int i = 0; i < asrArr.Length; ++i)
//{
//    asrArr[i] = new AsyncReader(new FileStream(path: files[i], FileMode.Open, FileAccess.Read, FileShare.Read, 2048, FileOptions.Asynchronous), 100);
//}
//foreach (AsyncReader asr in asrArr)
//    Console.WriteLine(asr.EndRead());
//class AsyncReader
//{
//    FileStream stream;
//    byte[] data;
//    IAsyncResult asRes;
//    public AsyncReader(FileStream s, int size)
//    {
//        stream = s;
//        data = new byte[size];
//        asRes = s.BeginRead(data, 0, size, null,
//       null);
//    }
//    public string EndRead()
//    {
//        int countByte = stream.EndRead(asRes);
//        stream.Close();
//        Array.Resize(ref data, countByte);
//        return string.Format("Файл: {0}\n{1}\n\n",
//        stream.Name,
//        Encoding.UTF8.
//        GetString(data));
//    }
//}

//FileStream fs = new FileStream(@"Potoki.exe",FileMode.Open,FileAccess.Read, FileShare.Read, 1024,FileOptions.Asynchronous);
//Byte[] data = new Byte[100];
//IAsyncResult ar = fs.BeginRead(data, 0,data.Length, null, null);
//while (!ar.IsCompleted)
//{
//    Console.WriteLine("Операция не завершена, ожидайте...");
//    Thread.Sleep(10);
//}
//Int32 bytesRead = fs.EndRead(ar);
//fs.Close();
//Console.WriteLine("Количество считаныхбайт = {0}", bytesRead);
//Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));

Byte[] data = new Byte[100];
Console.WriteLine("Основной поток ID ={0}", Thread.CurrentThread.ManagedThreadId);
FileStream fs = new FileStream(@"../../Program.cs",FileMode.Open,FileAccess.Read, FileShare.Read, 1024,FileOptions.Asynchronous);
fs.BeginRead(data, 0, data.Length,ReadIsComplete, fs);
Console.WriteLine("fijd");
Console.ReadLine();


static void ReadIsComplete(IAsyncResult ar)
{
    Byte[] data = new Byte[100];
    Console.WriteLine("Чтение в потоке {0} закончено",Thread.CurrentThread.ManagedThreadId);
    FileStream fs = (FileStream)ar.AsyncState;
    Int32 bytesRead = fs.EndRead(ar);
    fs.Close();
    Console.WriteLine("Количество считаныхбайт = {0}", bytesRead);
    Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));
}

