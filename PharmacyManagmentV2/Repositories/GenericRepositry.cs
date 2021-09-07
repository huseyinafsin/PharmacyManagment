using Microsoft.EntityFrameworkCore;
using PharmacyManagmentV2.Contexts;
using PharmacyManagmentV2.Data;
using PharmacyManagmentV2.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagmentV2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext _context;
      
        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }

        public async Task Update(T obj)
        {
            _context.Update(obj);
        }

        public async Task Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
