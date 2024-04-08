using DataModels.Models;
using DataModels.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _ProductRepository;

        public ProductService(IRepository<Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public Product GetProductById(int id)
        {
            return _ProductRepository.GetById(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ProductRepository.GetAll();
        }

        public void CreateProduct(Product Product)
        {
            _ProductRepository.Add(Product);
        }

        public void UpdateProduct(Product Product)
        {
            _ProductRepository.Update(Product);
        }

        public void DeleteProduct(int id)
        {
            var Product = _ProductRepository.GetById(id);
            if (Product != null)
            {
                _ProductRepository.Delete(Product);
            }
            }
    }
}
