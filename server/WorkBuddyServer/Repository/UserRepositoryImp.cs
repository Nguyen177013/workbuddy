using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WorkBuddyServer.Data;

namespace WorkBuddyServer.Repository
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<TEntity> _entities;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }
        public TEntity FindById(int id)
        {
            return _entities.Find(id);
        }
        public void Delete(int id)
        {
            TEntity entity = FindById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
