using HotelListing.Data;
using HotelListing.IRepasitary;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelListing.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseConext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseConext context)
        {
            _context=context;
            _db = _context.Set<T>(); 

        }


        public async Task Delek(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity); 
        }

        public void Delete(IEnumerable<T> entites)
        {
            _db.RemoveRange(entites);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                 foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);  
                }
            
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);


        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)

            {
                query= query.Where(expression); 

            }


            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }

            }

            if (orderBy != null)
            {
                query = orderBy(query); 
            }
            return await query.AsNoTracking().ToListAsync() ;
        }

        public async Task Insert(T entity)
        {
            await _db. AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entites)
        {
             await _db.AddRangeAsync(entites);  
        }

        public void Update(T entity)
        { 
            _db.Attach(entity); 
            _context.Entry(entity).State = EntityState.Modified;    
        }
    }
}        