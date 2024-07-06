string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var variables = Environment.GetEnvironmentVariables();

Console.WriteLine("ASPNETCORE_ENVIRONMENT : " + environment);

Console.WriteLine("Push any key to list all environment variables");
Console.ReadKey();
foreach(var v in variables)
{
    Thread.Sleep(200);
    Console.WriteLine();
    Console.WriteLine(v);
}

Console.ReadKey();
