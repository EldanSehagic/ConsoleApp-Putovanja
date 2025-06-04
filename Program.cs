using Microsoft.Extensions.DependencyInjection;
using Zadatak.Data;
using Zadatak.Enums;
using Zadatak.Models;
using Zadatak.Repositories;
using Zadatak.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<DataBaseContext>()
            .AddScoped<IPutovanjeRepository, PutovanjeRepository>()
            .AddScoped<IPutovanjeService, PutovanjeService>()
            .BuildServiceProvider();

        var putovanjeService = serviceProvider.GetService<IPutovanjeService>();

        while (true)
        {
            Console.WriteLine("Odaberite opciju:");
            Console.WriteLine("1. Dodaj novo putovanje");
            Console.WriteLine("2. Prikaz svih putovanja");
            Console.WriteLine("3. Prikaz putovanja prema destinaciji");
            Console.WriteLine("4. Azuriraj status putovanja");
            Console.WriteLine("5. Izlaz");

            var izbor = Console.ReadLine();
            switch (izbor)
            {
                case "1":
                    DodajNovoPutovanje(putovanjeService);
                    break;
                case "2":
                    PrikaziSvaPutovanja(putovanjeService);
                    break;
                case "3":
                    PretraziPutovanje(putovanjeService);
                    break;
                case "4":
                    Azuriraj(putovanjeService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Nepoznata opcija");
                    break;
            }
        }
    }

    static void DodajNovoPutovanje(IPutovanjeService putovanjeService)
    {
        Console.WriteLine("Unesite Destinaciju putovanja");
        var destinacija = Console.ReadLine();
        Console.WriteLine("Unesite datum (yyyy-mm-dd):");
        var datum = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Unesite prevoz");
        var prijevoz = Console.ReadLine();

        Putovanje putovanje = new Putovanje
        {
            Destinacija = destinacija,
            Datum = datum,
            Prijevoz = prijevoz,
            Status = StatusPutovanja.Planirano
        };

        putovanjeService.AddPutovanje(putovanje);
        Console.WriteLine("Putovanje uspjesno dodano");
    }

    static void PrikaziSvaPutovanja(IPutovanjeService putovanjeService)
    {
        var putovanja = putovanjeService.GetAllPutovanje();
        foreach (var putovanje in putovanja)
        {
            Console.WriteLine($"Id: {putovanje.Id}, Destinacija: {putovanje.Destinacija}, Datum: {putovanje.Datum.ToShortDateString()}, Status:{putovanje.Status}, Prijevoz:{putovanje.Prijevoz}");
        }
    }

    static void PretraziPutovanje(IPutovanjeService putovanjeService)
    {
        Console.WriteLine("Unesite destinaciju za pretragu");
        var destinacija = Console.ReadLine();
        var putovanja = putovanjeService.GetPutovanjeByDestinacija(destinacija);
        foreach (var putovanje in putovanja)
        {
            Console.WriteLine($"Id: {putovanje.Id},Destinacija: {putovanje.Destinacija}, Datum: {putovanje.Datum.ToShortDateString()}, Status:{putovanje.Status}, Prijevoz:{putovanje.Prijevoz}");
        }
        if (putovanja.Count == 0)
        {
            Console.WriteLine("Nema takvih putovanja");
        }
    }

    static void Azuriraj(IPutovanjeService putovanjeService)
    {
        Console.WriteLine("Unesite id putovanja: ");
        var id = Guid.Parse(Console.ReadLine());
        Console.WriteLine("Unesite novi status (Planirano-0, UProgesu-1,Zavrseno-2)");
        var status = Enum.Parse<StatusPutovanja>(Console.ReadLine(), true);
        putovanjeService.AzurirajStatus(id, status);
        Console.WriteLine("Uspjesno azurirano");
    
    }
}