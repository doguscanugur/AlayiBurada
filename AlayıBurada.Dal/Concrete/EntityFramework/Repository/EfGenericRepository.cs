using AlayıBurada.Dal.Abstract;
using AlayıBurada.Dal.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository
{
    public abstract class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {

        public AlayıBuradaContext context;
        public EfGenericRepository()
        {
            context = new AlayıBuradaContext();
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges(); //commit
            return entity; //kaydedilen verinin aynısını geri gönderir. Select * from yapmaya gerek kalmaz tekrardan. 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                context.Dispose();
            }
        }
        public T Get(int id)
        {
            var entity = context.Set<T>().Find(id);
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;//seçilen nesneye ait silme izni
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified; //seçilen nesneye ait değişiklik izni

            return entity;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public bool Remove(int id)
        {
            return Remove(Get(id));
        }

        public bool Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges() > 0;
        }

        public T Update(T entity)
        {
            
            
            context.Set<T>().AddOrUpdate(entity);
            context.SaveChanges();
            return entity;

            //var updatedEntity = context.Entry(entity);
            //updatedEntity.State = EntityState.Modified;
            //context.SaveChanges();
            //return updatedEntity;
        }
    }
}
