using HotelSiteTuesday.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSiteTuesday.Infraestructure.Core
{
   public interface IBaseRepository<TEntity> where TEntity : class
    {
        /*
        void Saved();
        void Update();
        void Remove();
        List<TEntity> GetEntities();
        TEntity GetEntity(int id);
         */
    }
}
