using InveonECommerce.Entities;
using InveonECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.Bussines.Abstract
{
    //Ürün CRUD Interface
    public interface IProductRepository
    {
        IQueryable<ProductModel> GetProducts(); 
        ProductModel GetProduct(int id);
        bool Insert(ProductModel model);
        void Update(ProductModel model);
        void Delete(int id);
    }
}
