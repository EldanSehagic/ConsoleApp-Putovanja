using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Enums;
using Zadatak.Models;

namespace Zadatak.Services
{
    internal interface IPutovanjeService
    {
        List<Putovanje> GetAllPutovanje();
        Putovanje GetPutovanje(Guid id);
        List<Putovanje> GetPutovanjeByDestinacija(string destinacija);
        void AddPutovanje(Putovanje putovanje);
        void AzurirajStatus(Guid id, StatusPutovanja status);
        void DeletePutovanje(Guid id);
    }
}
