using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefaAula3.Repository.Interfaces
{
    public interface IRepository<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
