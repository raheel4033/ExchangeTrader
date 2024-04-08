using DataModels.Models;
using DataModels.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _OrderRepository;

        public OrderService(IRepository<Order> OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public Order GetOrderById(int id)
        {
            return _OrderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _OrderRepository.GetAll();
        }

        public void CreateOrder(Order Order)
        {
            _OrderRepository.Add(Order);
        }

        public void UpdateOrder(Order Order)
        {
            _OrderRepository.Update(Order);
        }

        public void DeleteOrder(int id)
        {
            var Order = _OrderRepository.GetById(id);
            if (Order != null)
            {
                _OrderRepository.Delete(Order);
            }
        }
    }
}
