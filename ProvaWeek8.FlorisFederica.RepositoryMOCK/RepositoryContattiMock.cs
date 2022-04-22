using ProvaWeek8.FlorisFederica.Core.Entities;
using ProvaWeek8.FlorisFederica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.RepositoryMOCK
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        //creo una mia lista di contatti per vedere se tutto funziona
        private static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto{IdContatto=1, Nome="Federica", Cognome="Floris"},
            new Contatto{IdContatto=2, Nome="Francesco", Cognome="Marongiu"}
        };
        public Contatto Add(Contatto item)
        {
            if (Contatti.Count == 0)
            {
                item.IdContatto = 1;
            }
            else
            {
                int idMaggiore = 1;
                foreach(var contatto in Contatti)
                {
                    if(contatto.IdContatto > idMaggiore)
                    {
                        idMaggiore = contatto.IdContatto;
                    }
                }
                item.IdContatto = idMaggiore + 1;
            }
            Contatti.Add(item);
            return item;
        }

       

        public bool Delete(Contatto item)
        {
            if (item == null)
            {
                return false;
            }
            Contatti.Remove(item);
            return true;
        }

        public List<Contatto> GetAll()
        {
            return Contatti;
        }

        public Contatto GetByCode(int Contatto)
        {
            foreach (var item in Contatti)
            {
                if (item.IdContatto == Contatto)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
