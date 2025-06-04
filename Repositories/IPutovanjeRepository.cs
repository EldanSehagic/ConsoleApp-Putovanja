
using Zadatak.Enums;
using Zadatak.Models;

namespace Zadatak.Repositories
{
    internal interface IPutovanjeRepository
    {
        List<Putovanje> GetAllPutovanje();
        Putovanje GetPutovanje(Guid id);
        List<Putovanje> GetPutovanjeByDestinacija(string destinacija);
        void AddPutovanje(Putovanje putovanje);
        void AzurirajStatus(Guid id, StatusPutovanja status);
        void DeletePutovanje(Guid id);

    }
}
