using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Update(int id);
        void Delete(int id);
        void Add();
    }
}
