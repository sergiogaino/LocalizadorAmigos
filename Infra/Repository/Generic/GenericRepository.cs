using Domain.Interface.Generic;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repository.Generic
{
    public class GenericRepository<T> : GenericInterface<T>, IDisposable where T : class
    {
        private DbContextOptionsBuilder<DataBaseContext> _OptionsBuilder;

        public GenericRepository()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        }

        ~GenericRepository()
        {
            Dispose(false);
        }

        public void Add(T Entitie)
        {
            using (var dataBase = new DataBaseContext(_OptionsBuilder.Options))
            {
                dataBase.Add(Entitie);
                dataBase.SaveChanges();
            };
        }

        public void Delete(int Id)
        {
            using (var dataBase = new DataBaseContext(_OptionsBuilder.Options))
            {
                var obj = dataBase.Set<T>().Find(Id);
                dataBase.Remove(obj);
                dataBase.SaveChanges();
            };
        }

        public List<T> List()
        {
            using (var dataBase = new DataBaseContext(_OptionsBuilder.Options))
            {
                return dataBase.Set<T>().ToList();
            };
        }

        public void Update(T Entitie)
        {
            using (var dataBase = new DataBaseContext(_OptionsBuilder.Options))
            {
                dataBase.Update(Entitie);
                dataBase.SaveChanges();
            };
        }

        public T GetForId(int id)
        {
            using (var dataBase = new DataBaseContext(_OptionsBuilder.Options))
            {
                return dataBase.Set<T>().Find(id);
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool Status)
        {
            if (!Status) return;
        }
    }
}
