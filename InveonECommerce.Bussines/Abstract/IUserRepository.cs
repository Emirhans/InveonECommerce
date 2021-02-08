using InveonECommerce.Entities;
using InveonECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.Bussines.Abstract
{
    public interface IUserRepository : IDisposable
    {
        bool userExist(UserModel model);
        bool Create(UserModel model);

    }
}
