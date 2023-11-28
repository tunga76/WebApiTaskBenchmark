// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using WebApiTaskBenchmark.ConsoleApp;

Console.WriteLine("Hello, World!");

do
{

    AddLog("App is running....");
    Console.Write("Request Type (Sync = 0, Async = 1): ");
    int requestType = int.Parse(Console.ReadLine());

    Console.Write("How Many Request : ");
    int requestCount = int.Parse(Console.ReadLine());


    var sw = Stopwatch.StartNew();

    var tasks = requestType == 0 ? GetSyncTasks(requestCount) : GetAsyncTask(requestCount);

    await Task.WhenAll(tasks);

    sw.Stop();

    Console.WriteLine($"Total Time : {sw.ElapsedMilliseconds} MS");



} while (Console.ReadKey().Key == ConsoleKey.R);

IEnumerable<Task> GetAsyncTask(int howMany)
{
    var result = new Task[howMany];
    var client = new WebApiClient();

    for (int i = 0; i < howMany; i++)
        result[i] = client.CallAsync();
    return result;
}

IEnumerable<Task> GetSyncTasks(int howMany)
{
    var result = new Task[howMany];

    var client = new WebApiClient();
    for (int i = 0; i < howMany; i++)
        result[i] = client.CallSync();
    return result;
}

void AddLog(string log)
{
    log = $"[{DateTime.Now:g}] - {log}";
    Console.WriteLine(log);
}