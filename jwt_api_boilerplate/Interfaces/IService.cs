using System.Collections.Generic;
using System.Threading.Tasks;

namespace jwt_api_boilerplate.Interfaces
{
    public interface IService<T>
    {
        Task<T> Get(int? Oid);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T element);
        Task<T> Update(T element);
        Task<T> Delete(int? Oid);
    }
}
