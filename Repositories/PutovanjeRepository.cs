
using Zadatak.Data;
using Zadatak.Enums;
using Zadatak.Models;

namespace Zadatak.Repositories
{
    internal class PutovanjeRepository : IPutovanjeRepository
    {
        private readonly DataBaseContext _context;
        public PutovanjeRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void AddPutovanje(Putovanje putovanje)
        {
            _context.Putovanja.Add(putovanje);
            _context.SaveChanges();
        }

        public void AzurirajStatus(Guid id, StatusPutovanja status)
        {
            var putovanje = _context.Putovanja.Find(id) ??
                 throw new Exception("Nema trzenog putovanja");
            var putovanjeUpdate = putovanje with { Status = status };
            //  je Putovanje klasa bilo bi:
            //putvanje.Status = status;
            _context.Entry(putovanje).CurrentValues.SetValues(putovanjeUpdate);
            _context.SaveChanges();
        }

        public void DeletePutovanje(Guid id)
        {
            var putovanje = _context.Putovanja.Find(id) ??
                throw new Exception("Nije pronadeno");
            _context.Putovanja.Remove(putovanje);
            _context.SaveChanges();
        }

        public List<Putovanje> GetAllPutovanje()
        {
            return _context.Putovanja.ToList();
        }

        public Putovanje GetPutovanje(Guid id)
        {
            var putovanje = _context.Putovanja.Find(id) ??
                throw new Exception("Nema tog putovanja");
            return putovanje;
        }

        public List<Putovanje> GetPutovanjeByDestinacija(string destinacija)
        {
            return _context.Putovanja
                .Where(p => p.Destinacija.ToLower().Contains(destinacija.ToLower()))
                .ToList();
        }

    }
}
