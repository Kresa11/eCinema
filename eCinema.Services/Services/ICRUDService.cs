using eCinema.Model.SearchObjects;

namespace eCinema.Services.Services
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch> where T : class
        where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        Task<T> Insert(TInsert insert);
        Task<T> Update(Guid id, TUpdate update);
        Task<T> Delete(Guid id);
        Task<T> HardDelete(Guid id);

    }
}
