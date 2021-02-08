using InveonECommerce.Bussines.Abstract;
using InveonECommerce.DataAccess;
using InveonECommerce.Entities;
using InveonECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.Bussines.Concrete
{
    public class ProductRepository : IProductRepository
    {
        ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        //Ürün Sil
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        //ID'ye göre ürün getir
        public ProductModel GetProduct(int id)
        {
            return _context.Products.Select(model => new ProductModel()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                ProductDesc = model.ProductDesc,
                Barcode = model.Barcode,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity
            }).FirstOrDefault(p => p.ProductID == id);
        }

        //Tüm ürünleri getir
        public IQueryable<ProductModel> GetProducts()
        {
            return _context.Products.Select(model => new ProductModel()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                ProductDesc = model.ProductDesc,
                Barcode = model.Barcode,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity
            });
        }

        //Ürün Ekle
        public bool Insert(ProductModel model)
        {
            var product = new Product()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                ProductDesc = model.ProductDesc,
                Barcode = model.Barcode,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity
            };
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;
        }

        //Ürün bilgisi güncelle
        public void Update(ProductModel model)
        {
            var product = _context.Products.Find(model.ProductID);
            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.ProductDesc = model.ProductDesc;
                product.Barcode = model.Barcode;
                product.ImageUrl = model.ImageUrl;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
