using FMS.Data;
using FMS.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Data.Repository
{
   public  class Repository<T>:IRepository<T> where T:class
    {
        internal FMSDBContext fmsDBContext;
        internal DbSet<T> dbSet;

        public Repository(FMSDBContext fmsDBContext)
        {
            this.fmsDBContext = fmsDBContext;
            // this.dbSet = maintenanceDBContext.Set<T>();
        }

        public IQueryable<T> Table
        {
            get
            {
                //return dbSet.AsQueryable<T>();
                return Entities;
            }
        }
        public IEnumerable<T> TableAsEnumerable
        {
            get
            {
                IQueryable<T> query = dbSet;
                return query.ToList();

            }
        }

        public virtual T GetById(object Id)
        {
            return Entities.Find(Id);
        }
        public virtual int Insert(T entity)
        {
            var obj = Entities.Add(entity);
            return fmsDBContext.SaveChanges();

        }
        public virtual void Delete(Object Id)
        {
            T entityToDelete = Entities.Find(Id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (fmsDBContext.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            Entities.Remove(entity);
        }
        public virtual int Update(T entity)
        {
            Entities.Attach(entity);
            fmsDBContext.Entry(entity).State = EntityState.Modified;
            return fmsDBContext.SaveChanges();
        }
        public DbSet<T> Entities
        {
            get
            {
                if (dbSet == null)
                    dbSet = fmsDBContext.Set<T>();
                return dbSet;
            }
        }


    }


}

