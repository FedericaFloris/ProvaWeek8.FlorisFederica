using ProvaWeek8.FlorisFederica.Core.Entities;
using ProvaWeek8.FlorisFederica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzo indirizziRepo;

        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzo indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito EliminaContatto(int idContatto)
        {
            var contattoEliminato = contattiRepo.GetByCode(idContatto);
            if(contattoEliminato == null && indirizziRepo.EsisteIndirizzoContatto(idContatto)==false )
            {
                return new Esito { Messaggio = "Spiacenti il contatto non è stato eliminato", IsOk = false };
                
            }
            contattiRepo.Delete(contattoEliminato);
            return new Esito { Messaggio = " il contatto  è stato eliminato", IsOk = false };
        }

        public List<Contatto> GetAllContatto()
        {
            return contattiRepo.GetAll();
        }

        public List<Indirizzo> GetAllIndirizzo()
        {
            return indirizziRepo.GetAll();
        }

        public Esito InserisciNuovoContatto(Contatto nuovoContatto)
        {
            var contattoAggiunto = contattiRepo.Add(nuovoContatto);
            if(contattoAggiunto == null)
            {
                return new Esito { Messaggio = "Spiacenti il contatto non è stato inserito", IsOk = false };
            }
            return new Esito { Messaggio = "Contatto inserito corretamente", IsOk = true };
        }

        public Esito InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo)
        {
            Contatto contattoEsistente = contattiRepo.GetByCode(nuovoIndirizzo.IdContatto);
            if (contattoEsistente == null)
            {
                return new Esito { Messaggio = "Spiacenti l id contatto errato", IsOk = false };
            }
            var contattoAggiunto = indirizziRepo.Add(nuovoIndirizzo);
            return new Esito { Messaggio = "Indirizzo inserito corretamente", IsOk = true };
        }

        public bool VerificaEsistenzaId(int idCorso)
        {
            
            
                if (contattiRepo.GetByCode(idCorso) == null)
                {
                    return false;
                }
                return true;
            
        }
    }
}
