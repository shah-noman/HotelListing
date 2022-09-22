using System.Linq.Expressions;
using System.Collections.Generic; 
namespace HotelListing.IRepasitary
{
    public interface IGenericRepository<T> where T : class
    {
      Task<IList<T>> GetAll(  
      Expression<Func<T, bool>> expression = null,   
       Func<IQueryable<T>, IOrderedQueryable <T>> orderBy = null,  
        List<string> includes = null
            );
        Task<T> Get (Expression<Func<T, bool>>expression,List<string> includes = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entites);
        Task Delete(int id);
        void Delete(IEnumerable<T> entites);
        void Update(T entity);


    }
}
