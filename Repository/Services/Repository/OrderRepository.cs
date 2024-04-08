using DataModels.Data;
using DataModels.Models;
using DataModels.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public void Add(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Order entity)
        {
            _dbContext.Orders.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
