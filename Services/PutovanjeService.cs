using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Enums;
using Zadatak.Models;
using Zadatak.Repositories;

namespace Zadatak.Services
{
    internal class PutovanjeService : IPutovanjeService
    {
        private readonly IPutovanjeRepository _repository;
        public PutovanjeService(IPutovanjeRepository repository)
        {
            _repository = repository;
        }
        public void AddPutovanje(Putovanje putovanje)
        {
            _repository.AddPutovanje(putovanje);
        }

        public void AzurirajStatus(Guid id, StatusPutovanja status)
        {
            _repository.AzurirajStatus(id, status);
        }

        public void DeletePutovanje(Guid id)
        {
            _repository.DeletePutovanje(id);
        }

        public List<Putovanje> GetAllPutovanje()
        {
            return _repository.GetAllPutovanje();
        }

        public Putovanje GetPutovanje(Guid id)
        {
            return _repository.GetPutovanje(id);
        }

        public List<Putovanje> GetPutovanjeByDestinacija(string destinacija)
        {
            return _repository.GetPutovanjeByDestinacija(destinacija);
        }

    }
}
