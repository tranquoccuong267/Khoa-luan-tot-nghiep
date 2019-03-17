using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyCosmetic.Common.ViewModels;
using BeautyCosmetic.Data.Infrastructure;
using BeautyCosmetic.Data.Repositories;
using BeautyCosmetic.Model.Models;

namespace BeautyCosmetic.Service
{
    public interface IOrderService
    {
        Order Create(ref Order order, List<OrderDetail> orderDetails);
        void UpdateStatus(int orderId);
        void UpdatePayStatus(int orderId);
        void Save();

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAll(string keyword);

        IEnumerable<OrderDetail> GetListdetailByOrderId(int id);

        Order GetById(int id);

    }
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;


        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }
        public Order Create(ref Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailRepository.Add(orderDetail);
                }
                return order;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateStatus(int orderId)
        {
            var order = _orderRepository.GetSingleById(orderId);
            order.Status = true;
            _orderRepository.Update(order);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAllnew();
        }

        public IEnumerable<Order> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _orderRepository.GetMulti(x => x.CustomerName.Contains(keyword));
            else
                return _orderRepository.GetAllnew();
        }

        public IEnumerable<OrderDetail> GetListdetailByOrderId(int id)
        {
            return _orderDetailRepository.GetMulti(x => x.OrderID == id);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        public void UpdatePayStatus(int orderId)
        {
            var order = _orderRepository.GetSingleById(orderId);
            order.PaymentStatus = "yes";
            _orderRepository.Update(order);
        }
    }
}
