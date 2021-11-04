using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Interfaces
{
    public interface IGenericService<T>:IDisposable
    {
        T Add(T entity);
        T Get(int id);

        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate); //dinamik filtreleme ile listeleme
        bool Remove(int id); //id ye göre sil

        bool Remove(T entity); //Entity ye göre sil
        T Update(T entity);


    }
}
