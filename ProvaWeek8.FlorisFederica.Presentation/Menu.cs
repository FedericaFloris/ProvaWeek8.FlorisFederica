using ProvaWeek8.FlorisFederica.Core.BusinessLayer;
using ProvaWeek8.FlorisFederica.Core.Entities;
using ProvaWeek8.FlorisFederica.RepositoryMOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.Presentation
{
    internal static class Menu
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());

        internal static void Start()
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    //Visualizza tutti i contatti (mi creo un metodo per visualizzare tutti i contatti)
                    VisualizzaContatti();
                    break;
                case 2:
                    //Aggiungi nuovo contatto
                    AggiungiContatto();
                    break;
                case 3:
                    //Aggiungi indirizzo
                    AggiungiIndirizzo();
                    break;
                case 4:
                    //Elimina contatto
                    EliminaContatto();
                    break;

                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
        }

        private static void EliminaContatto()
        {
            VisualizzaContatti();
            Console.WriteLine("Quale contatto vuoi eliminare?Inserisci l id");
            int idContatto;
            do
            {
                Console.WriteLine("Inserisci id del contatto");

            } while (!(int.TryParse(Console.ReadLine(), out idContatto)&& bl.VerificaEsistenzaId(idContatto)==true));
            Esito esito = bl.EliminaContatto(idContatto);
            Console.WriteLine(esito.Messaggio);

        }

      

        private static void AggiungiIndirizzo()
        {
            //chiedo tutti i dati dell indirizzo all utente
            Console.WriteLine("Inserisci tipologia indirizzo: Domicilio o Residenza");
            string tipologia = Console.ReadLine();
            Console.WriteLine("Inserisci la via:");
            string via = Console.ReadLine();
            Console.WriteLine("Inserisci la Città:");
            string citta = Console.ReadLine();
            Console.WriteLine("Inserisci il cap:");
            string cap = Console.ReadLine();
            Console.WriteLine("Inserisci la provincia:");
            string provincia = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione:");
            string nazione = Console.ReadLine();
            VisualizzaContatti();
            int idContatto;
            do
            {
                Console.WriteLine("Inserisci id del contatto");

            } while (!(int.TryParse(Console.ReadLine(), out idContatto)&& bl.VerificaEsistenzaId(idContatto) == true));


            //creo un nuovo indirizzo
            Indirizzo nuovoIndirizzo = new Indirizzo();
            nuovoIndirizzo.Tipologia = tipologia;
            nuovoIndirizzo.Via = via;
            nuovoIndirizzo.Citta = citta;
            nuovoIndirizzo.Cap = cap;
            nuovoIndirizzo.Provincia = provincia;
            nuovoIndirizzo.Nazione = nazione;
            nuovoIndirizzo.IdContatto = idContatto;

            //comunico con il bl
            Esito esito = bl.InserisciNuovoIndirizzo(nuovoIndirizzo);
           


            if (esito.IsOk == false)
            {
                Console.WriteLine(esito.Messaggio);
                return;

            }
            else
            {
                Console.WriteLine(esito.Messaggio);
                Console.WriteLine("Ecco gli indirizzi inseriti");
                VisualizzaIndirizzi();
            }




        }

        private static void AggiungiContatto()
        {
            //chiedo tutto quello che mi occorre per creare un nuovo contatto all utente
            Console.WriteLine("Inserisci il nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            string cognome = Console.ReadLine();
            //creo il nuovo contatto
            Contatto nuovoContatto = new Contatto();
            nuovoContatto.Nome = nome;
            nuovoContatto.Cognome = cognome;
            //comunico con il bl
            Esito esito = bl.InserisciNuovoContatto(nuovoContatto);
            Console.WriteLine(esito.Messaggio);

          



        }

        private static void VisualizzaIndirizzi() //mi creo questo metodo in modo tale da utilizzarlo in aggiungi indirizzo
        {
            var listaIndirizzi = bl.GetAllIndirizzo();
            if(listaIndirizzi.Count == 0)
            {
                Console.WriteLine("Non sono stati ancora stati inseriti indirizzi");

            }
            else
            {
                foreach(var item in listaIndirizzi)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaContatti()
        {
            var listacontatti = bl.GetAllContatto();
            //mi restituisce una lista controllo se è vuota o meno se non lo è la stampo
            if(listacontatti.Count== 0)
            {
                Console.WriteLine("Non sono stati ancora inseriti corsi");
            }
            else
            {
                foreach(var item in listacontatti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("1.Visualizza tutti i contatti");
            Console.WriteLine("2.Aggiungere nuovo contatto");
            Console.WriteLine("3.Aggiungere Indirizzo");
            Console.WriteLine("4.Elimina Contatto"); //solo se non ha alcun indirizzo associato
           



            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta)))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }
    }
}
