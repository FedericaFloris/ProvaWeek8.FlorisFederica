using ProvaWeek8.FlorisFederica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.Core.InterfaceRepository
{
    public interface IRepositoryIndirizzo : IRepository<Indirizzo>
    {
         bool EsisteIndirizzoContatto(int idContatto);
    }
}
