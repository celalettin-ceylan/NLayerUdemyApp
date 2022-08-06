using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    IQueryable<T> GetAll();
    //productRepository.Where(x => x.id > 5) --> ToList() Database
    IQueryable<T> Where( Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entitites);
    // Update Aysnc bir function olmasina gerek yok cunku memoride kayitli olan datayi guncelliyor.
    // Add metodunun vardir cunku memoriye once kaydedilmesi ve trake edilmesi gerekiyor. Bu da belli bir surec gerektiriyor.  
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
