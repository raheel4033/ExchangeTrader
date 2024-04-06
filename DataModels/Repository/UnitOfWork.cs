using DataModels.Data;
using DataModels.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IProductRepository ProductRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db=db;
            ProductRepository=new ProductRepository(db);
            OrderRepository=new OrderRepository(db);
        }
        public void save()
        {
            _db.SaveChanges();
        }
    }
}
