using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.Core.Entities
{
    public class Indirizzo
    {
        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        //Fk verso Contatto (data dalla relazione uno a molti con esso)
        public int IdContatto { get; set; }

        public override string ToString()
        {
            return $"Id: {IdIndirizzo}\t Tipologia: {Tipologia}\tVia: {Via}\tCittà: {Citta}\tCap: {Cap}\tProvincia: {Provincia}\tNazione: {Nazione}";
        }
    }
}
