

namespace ProductApp.DataAccess
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
    }
}
