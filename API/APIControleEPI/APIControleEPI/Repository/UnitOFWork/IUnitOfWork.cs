namespace APIControleEPI.Repository.UnitOFWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task Commit();
    }
}
