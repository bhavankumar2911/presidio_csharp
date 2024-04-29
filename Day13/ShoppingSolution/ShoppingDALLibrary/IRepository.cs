using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepository<K, T>
    {
        Task<T> Add(T item);
        Task<T> GetByKey(K key);
        Task<Collection<T>> GetAll();
        Task<T> Update(T item);
        Task<T> Delete(K key);
    }
}
