using ProvaWeek8.FlorisFederica.Core.Entities;
using ProvaWeek8.FlorisFederica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.RepositoryMOCK
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzo
    {
        //mi creo la mia lista indirizzi per vedere se tutto funziona correttamente
        private static List<Indirizzo> Indirizzi = new List<Indirizzo>()
        {
            new Indirizzo{IdIndirizzo=1,Tipologia="Domicilio",Via="Nazionale",Citta="Palermo",Cap="09007",Provincia="Pa",Nazione="Italia",IdContatto=1},
            new Indirizzo{IdIndirizzo=2,Tipologia="Residenza",Via="di Vittorio",Citta="Cagliari",Cap="09100",Provincia="Ca",Nazione="Italia",IdContatto=1},
            new Indirizzo{IdIndirizzo=3,Tipologia="Residenza",Via="Libertà",Citta="Cagliari",Cap="09100",Provincia="Ca",Nazione="Italia",IdContatto=2}
        };
        public Indirizzo Add(Indirizzo item)
        {

            if (Indirizzi.Count == 0)
            {
                item.IdIndirizzo = 1;
            }
            else
            {
                int idMaggiore = 1;
                foreach (var indirizzo in Indirizzi)
                {
                    if (indirizzo.IdIndirizzo > idMaggiore)
                    {
                        idMaggiore = indirizzo.IdContatto;
                    }
                }
                item.IdIndirizzo = idMaggiore + 1;
            }
            Indirizzi.Add(item);
            return item;
        }

        public bool EsisteIndirizzoContatto(int idContatto)
        {
            foreach(var indirizzo in Indirizzi)
            {
                if(indirizzo.IdContatto == idContatto)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Indirizzo> GetAll()
        {
            return Indirizzi;
        }

        
        
    }
}
