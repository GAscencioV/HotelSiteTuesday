
using HotelSiteTuesday.Domain.Repository;


namespace HotelSiteTuesday.Infraestructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
