using StoreAppWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StoreAppWeb.Repository
{
    public class GenericRepository<Tbl_Entity> : IRepository<Tbl_Entity> where Tbl_Entity : class
    {
        DbSet<Tbl_Entity> _dbSet;

        private StoreAppEntities _DbEntity;

        public GenericRepository(StoreAppEntities storeAppEntities)
        {
            _DbEntity = storeAppEntities;
            _dbSet = _DbEntity.Set<Tbl_Entity>();
        }
        public void Add(Tbl_Entity entity)
        {

            _dbSet.Add(entity);
            _DbEntity.SaveChanges();

        }

        public int GetAllrecordCount()
        {
          return _dbSet.Count();
           
        }

        public IEnumerable<Tbl_Entity> GetAllRecords()
        {
            return _dbSet.ToList();
           
        }

        public IQueryable<Tbl_Entity> GetAllRecoredsIQueryalbe()
        {
            return _dbSet;
        }

        public Tbl_Entity GetFirstofDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
            
        }

        public Tbl_Entity GetFirstorDefault(int recordId)
        {
            return _dbSet.Find(recordId);
            
        }

        public IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
           return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<Tbl_Entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<Tbl_Entity, bool>> wherePredict, Expression<Func<Tbl_Entity, int>> orderByPredict)
        {
            if(wherePredict != null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }

        public IEnumerable<Tbl_Entity> GetResultbySqlprocedure(string query, params object[] parameters)
        {
            if(parameters != null)
            {
                return _DbEntity.Database.SqlQuery<Tbl_Entity>(query, parameters).ToList();
            }else
            {
                return _DbEntity.Database.SqlQuery<Tbl_Entity>(query).ToList();
            }
            
        }

        public void InactiveAndDeleteMarkbyWhereCluase(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(Tbl_Entity entity)
        {
            if(_DbEntity.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }else
            {
                _dbSet.Remove(entity);
            }
        }

        public void RemovebyWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {

            Tbl_Entity entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
           
        }

        public void RemoveRangeBywhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            List<Tbl_Entity> entity = _dbSet.Where (wherePredict).ToList();
            foreach(var ent in entity)
            {
               Remove(ent);
            }
        }

        public void UdateByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
           _dbSet.Where(wherePredict).ToList().ForEach (ForEachPredict);
        }

        public void Update(Tbl_Entity entity)
        {
            _dbSet.Attach(entity);
            _DbEntity.Entry(entity).State = EntityState.Modified;
         
        }
    }
}