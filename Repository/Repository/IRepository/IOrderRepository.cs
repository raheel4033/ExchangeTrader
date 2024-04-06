using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repository.IRepository
{
    public interface IOrderRepository:IRepository<Order>
    {
        void Update(Order obj);
    }

}
