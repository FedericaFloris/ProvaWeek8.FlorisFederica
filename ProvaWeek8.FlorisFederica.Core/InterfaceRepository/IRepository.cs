using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek8.FlorisFederica.Core.InterfaceRepository
{
    public interface IRepository<T>
    {
        //Metto tutte le Crud che hanno in comune le mie due entità
        List<T> GetAll();
        T Add(T item);

    }
}
