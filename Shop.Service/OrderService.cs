using Shop.Data.Repository;
using Shop.Models.Models;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IOrderService
    {
        Order Add(Order Order);

        void Update(Order Order);

        Order Delete(int id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAll(string keyWord);

        IEnumerable<Order> GetAllByParentId(int parentId);

        Order GetById(int id);

        void Save();
    }

    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public Order Add(Order Order)
        {
            return _orderRepository.Add(Order);
        }

        public Order Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAll(string keyWord)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllByParentId(int parentId)
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order Order)
        {
            throw new System.NotImplementedException();
        }
    }
}