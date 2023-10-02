namespace WorkBuddyServer.Repository
{
    public interface IUserRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(int id);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
    }
}