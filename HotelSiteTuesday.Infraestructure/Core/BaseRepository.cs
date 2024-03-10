using HotelSiteTuesday.Domain.Repository;
using HotelSiteTuesday.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelContext context;
        private readonly DbSet<TEntity> DBEntity;
        public BaseRepository(HotelContext context)
        {
            this.context = context;
            this.DBEntity = context.Set<TEntity>();
        }
        public virtual bool Exist(Func<TEntity, bool> filter)
        {
            return DBEntity.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DBEntity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DBEntity.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return DBEntity.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            DBEntity.Remove(entity);
            this.context.SaveChanges();
        }

        public virtual void Save( TEntity entity)
        {
            DBEntity.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DBEntity.Update(entity);
            context.SaveChanges();
        }
    }
}
