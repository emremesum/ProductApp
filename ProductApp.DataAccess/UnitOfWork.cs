namespace ProductApp.DataAccess;

public class UnitOfWork(ProductAppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangeAsync() => context.SaveChangesAsync();
    

}
