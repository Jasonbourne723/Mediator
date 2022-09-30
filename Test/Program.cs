// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

{
    Task hand() => handle("aa");

    var list = new List<Ipipebehavier>()
    {
        new Apipibehavier(),new Bpipibehavier()
    };

    list.Aggregate((RequestHandleDelegate)hand, (next, pipe) => () => pipe.handle("aa", next));
}





Task handle(string reqest)
{
    Console.WriteLine("--");
    return Task.CompletedTask;
}



public delegate Task RequestHandleDelegate();

public interface Ipipebehavier
{
    Task handle(string request, RequestHandleDelegate next);
}

public class Apipibehavier : Ipipebehavier
{
    public async Task handle(string request, RequestHandleDelegate next)
    {
        Console.WriteLine($"enter A ");
        await next();
        Console.WriteLine($"exit A");

    }
}

public class Bpipibehavier : Ipipebehavier
{
    public async Task handle(string request, RequestHandleDelegate next)
    {
        Console.WriteLine($"enter b ");
        await next();
        Console.WriteLine($"exit b");
    }
}
