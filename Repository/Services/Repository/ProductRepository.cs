using DataModels.Data;
using DataModels.Models;
using DataModels.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Repository
{
    public class CustomerRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public void Add(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
            _dbContext.SaveChanges();
        }
    }

}
