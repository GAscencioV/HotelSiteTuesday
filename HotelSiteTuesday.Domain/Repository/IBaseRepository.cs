using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Repository
{
    public interface IBaseRepository <TEntity> where TEntity: class 
    {

        TEntity GetEntity(int id);
        List<TEntity> GetEntities();

        List<TEntity> FindAll (Func<TEntity, bool> filter);

        bool Exists (Func <TEntity, bool> filter);

        void Save (TEntity entity);

        void Update (TEntity entity);

        void Remove(TEntity entity);
    }
}
