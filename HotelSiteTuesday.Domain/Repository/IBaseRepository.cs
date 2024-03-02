using HotelSiteTuesday.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
       /*
        void Save();
        void Update();
        void Remove();
        List<TEntity> GetEntities();
        TEntity GetEntity(int id);
       */
    }
}
