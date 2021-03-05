using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ ProductId = 1, CategoryID = 1, ProductName ="Bardak", UnitPrice = 15, UnitsInStock = 15 } ,
            new Product { ProductId = 2, CategoryID = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 15 },
            new Product { ProductId = 3, CategoryID = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 15 },
            new Product { ProductId = 4, CategoryID = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 15 },
            new Product { ProductId = 5, CategoryID = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 15 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            // LINQ langue Integrated Query Arama Methodu, Foreach yerine yapilir.
            //    foreach (var p in _products)  { if (product.ProductId == p.ProductId){ productToDelete = p; }}
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCatagory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

    }
}
