using InveonECommerce.Bussines.Abstract;
using InveonECommerce.DataAccess;
using InveonECommerce.Entities;
using InveonECommerce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.Bussines.Concrete
{
    public class UserRepository : IUserRepository
    {
        ProductContext _context;
        public UserRepository(ProductContext context)
        {
            _context = context;
        }

        public bool Create(UserModel model)
        {
            var user = new User()
            {
                UserID = model.UserID,
                UserName = model.Username,
                Password = model.Password,
                Role = model.Role
                
            };
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool userExist(UserModel model)
        {
            return _context.Users.Any(x => x.UserName == model.Username && x.Password == model.Password);
           
        }


    }
}
