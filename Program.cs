using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<LocateHub>("/atualizacao");

app.MapGet("/", () => "Hello World!");

app.Run();


class LocateHub : Hub
{
    public async IAsyncEnumerable<Locate> StremingLocate(CancellationToken encerramento)
    {
        while (true)
        {

            yield return new Locate
            {
                Percurso = "Rio Xingu",
                Latitude = 45.01,
                Longitude = 32.12,
                Momento = DateTime.UtcNow,
            };
            await Task.Delay(1000, encerramento);
        
        }
    }
}

class Locate
{
    public string Percurso { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime Momento { get; set; }
}