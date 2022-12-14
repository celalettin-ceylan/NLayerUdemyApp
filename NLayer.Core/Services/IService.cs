using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services;

public interface IService<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAysnc();
    //productRepository.Where(x => x.id > 5) --> ToList() Database
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entitites);
    // Update Aysnc bir function olmasina gerek yok cunku memoride kayitli olan datayi guncelliyor.
    // Add metodunun vardir cunku memoriye once kaydedilmesi ve trake edilmesi gerekiyor. Bu da belli bir surec gerektiriyor.  
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}
