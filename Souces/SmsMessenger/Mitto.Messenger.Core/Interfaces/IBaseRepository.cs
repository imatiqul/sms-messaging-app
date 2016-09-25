using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mitto.Messenger.Core.Interfaces
{
  //
  // Repository interface
  //
  public interface IBaseRepository<T> where T : class
  {
    /// <summary>
    /// Get all elements of type T
    /// </summary>
    List<T> GetAll();
    /// <summary>
    /// Get elements that comply to the specified criteria
    /// </summary>
    List<T> Get(Expression<Func<T, bool>> exp);
    /// <summary>
    /// Get elements that comply to the specified criteria with/without paging
    /// </summary>
    List<T> Get(Expression<Func<T, bool>> exp, int? skip, int? take);
    /// <summary>
    /// Get an instance of T with the specified id
    /// </summary>
    T GetById(int id);
    /// <summary>
    /// Inserts or updates instance
    /// </summary>
    bool Save(T o);
    /// <summary>
    /// Deletes element with specified id
    /// </summary>
    void Delete(int id);
    /// <summary>
    /// Delete elements that comply to specified criteria
    /// </summary>
    void Delete(Expression<Func<T, bool>> exp);
  }
}
