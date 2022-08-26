using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
   public interface IGenaricRepository<T> 
    {
        Task<T> Get(int? id);

        Task<IEnumerable<T>> GetAll();

        Task<int> Add(T T);

        Task<int> Update(T T);

        Task<int> Delete(T T);
    }
}
