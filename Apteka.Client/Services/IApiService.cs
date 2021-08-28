using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka.Client.Services
{
    public interface IApiService<T> where T : class
    {
        Task<IEnumerable<T>> Get();

        Task<string> Post(T entity);
    }
}
