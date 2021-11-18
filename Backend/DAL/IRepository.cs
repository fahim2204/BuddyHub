using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T,ID>
    {
        bool Add(T entity);
        IEnumerable<T> Get();
        T Get(ID id);
        bool Edit(ID id, T entity);
        bool Delete(ID id);

    }
}
