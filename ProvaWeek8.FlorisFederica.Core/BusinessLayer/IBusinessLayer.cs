using ProvaWeek8.FlorisFederica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Contratto dei metodi che poi voglio esporre al Presentation
        List<Contatto> GetAllContatto();

        Esito InserisciNuovoContatto(Contatto nuovoContatto);

        Esito InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo);
        List<Indirizzo> GetAllIndirizzo();
        Esito EliminaContatto(int idCorso);
        bool VerificaEsistenzaId(int idCorso);
    }
}
