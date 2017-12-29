using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Context;

namespace TaskManager.Services
{
    public class Repository<T> where T:class
    {
        TaskManagerContext context;

        public Repository(TaskManagerContext context)
        {
            this.context = context;
        }

        public void AddItem(T addItem)
        {
            context.Set<T>().Add(addItem);
            var changes = context.ChangeTracker.Entries();
            context.SaveChanges();
        }
        public void RemoveItem(T removeItem)
        {
            context.Set<T>().Remove(removeItem);
            context.SaveChanges();
        }
        public DbSet<T> GetItems()
        {
            return context.Set<T>();
        }
        public List<T> GetItems(Expression<Func<T,bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }
        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
