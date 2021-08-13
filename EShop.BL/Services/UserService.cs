using AutoMapper;
using Eshop.DAL.Interfaces;
using EShop.BL.DTOs;
using EShop.BL.Interfaces;
using EShop.DAL.Models;
using EShop.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShop.BL.Services
{
    public class UserService : GuestService, IUserService
    {
        public UserService(IUnitOfWork unit, IMapper mapper) : base(unit, mapper) { }

        public event IGeneralLogicForUserAndAdmin.LogOutHendler NotifyOfLoggingOut;

        private protected List<OrderItemDTO> Cart { get; set; } = new List<OrderItemDTO>();
        
        public string AddToOrder(string name, OrderDTO orderDTO)
        {
            var product = _unit.Products.FindByCondition(x => x.Name == name).FirstOrDefault();
            if (product == null)
                return "There is no such product in the store.";

            var newOrder = _mapper.Map<Order>(orderDTO);

            var order = _unit.Orders.FindByCondition(x => x.Id == newOrder.Id).FirstOrDefault();

            if (order == null)
                return "There is no such order";

            bool orderAlreadyExsist = newOrder.Id == order.Id;

            if (orderAlreadyExsist)
            {
                return $"Order with such {newOrder.Id} Id already exsist";
            }
            else
            {            
                var newProductMapper = _mapper.Map<ProductDTO>(product);
                var newItem = new OrderItemDTO() { ProductDTO = newProductMapper };
                var newItemMapper = _mapper.Map<OrderItem>(newItem);

                newOrder.OrderItems.Add(newItemMapper);
                _unit.SaveAsync();       

                return newItem.ToString();
            }
        }
      
        public string CancelOrder(int userId)
        {
            if (!_unit.Orders.FindByCondition(x => x.UserId == userId).Select(x => x.Id).Contains(userId))
                return "There is no order in your history with such ID.";

            var order = _unit.Orders.FindByCondition(x => x.UserId == userId).FirstOrDefault();

            if (order.Status == OrderStatus.Received
                || order.Status == OrderStatus.Complete
                || order.Status == OrderStatus.CanceledByUser
                || order.Status == OrderStatus.CanceledByAdmin)
            {
                return "You can't cancel this order";
            }

            order.Status = OrderStatus.CanceledByUser;

            _unit.Users.FindByCondition(x => x.Id == userId).FirstOrDefault().Balance += order.TotalPrice;
            _unit.SaveAsync();

            return $"Order with ID {userId} cancelled. Money returned";
        }

        public string ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _unit.Users.FindByCondition(x => x.Id == userId).FirstOrDefault();

            if (oldPassword != user.Password)
                return "Wrong password";

            user.Password = newPassword;

            _unit.SaveAsync();

            return "Password changed.";
        }

        public string LogOut()
        {
            NotifyOfLoggingOut?.Invoke();
            return "Logging Out...";
        }

        public IEnumerable<OrderDTO> SeeOrderHistory(int userId) 
        {
            var orders = _unit.Orders.FindByCondition(x => x.UserId == userId).ToList();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public string SetStatusReceived(int orderId)
        {
            try
            {
                if (_unit.Orders.FindByCondition(x => x.Id == orderId).FirstOrDefault().Id == orderId)
                    return "There is no order in your history with such ID.";

                var order = _unit.Orders.FindByCondition(x => x.Id == orderId)
                                        .FirstOrDefault()
                                        .Status = OrderStatus.Received;

                _unit.SaveAsync();

                return $"Status 'Received' set to order with ID {orderId}";
            }
            catch (OverflowException)
            {
                return "Outside the range of the Int type.";
            }
            catch (FormatException)
            {
                return "Not valid Id!";
            }
        }
    }
}