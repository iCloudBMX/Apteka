using Apteka.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.IRepository
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto userDto);

        Task<string> CreateToken();
    }
}
