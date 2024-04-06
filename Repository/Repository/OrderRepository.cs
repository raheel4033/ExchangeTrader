using DataModels.Data;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository.IRepository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {   
            _db = db;
        }

        public void Update(Order obj)
        {
            _db.Orders.Update(obj);
        }
    }
}
