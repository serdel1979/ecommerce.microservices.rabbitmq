namespace Products.API.Repository
{
    public interface IGenericRepository<TEntity>
    {
     //   Task<IQueryable<TEntity>> GetAll(int Page = 1, int Size = 5);
        Task<(List<TEntity> Data, int TotalRecords)> GetAll(int page, int size, params string[] includes);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Get(int id, params string[] includes);

        Task save();
    }
}
