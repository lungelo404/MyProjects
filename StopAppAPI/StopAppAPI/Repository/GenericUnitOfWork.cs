using StopAppAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StopAppAPI.Repository
{
    public class GenericUnitOfWork : IDisposable
    {
        private StoreAppEntities DbEntity = new StoreAppEntities();

        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GenericRepository<Tbl_EntityType>(DbEntity);
        }

        public void SaveChanges()
        {
            DbEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbEntity.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;


    }
}