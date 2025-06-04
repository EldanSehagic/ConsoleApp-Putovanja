using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Enums;

namespace Zadatak.Models
{
    internal record Putovanje
    {
        public Guid? Id { get; set; }
        public string Destinacija { get; set; }
        public DateTime Datum { get; set; }
        public string Prijevoz { get; set; }
        public StatusPutovanja Status { get; set; }
    }
}
