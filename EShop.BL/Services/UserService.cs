using AutoMapper;
using DAL.Interfaces;
using Eshop.DAL.Enums;
using EShop.BL.DTOs;
using EShop.BL.Interfaces;
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

        public string AddToOrder(string name)
        {
            var product = _unit.Products.GetProductByName(name);

            if (product == null)
                return "There is no such product in the store.";

            if (PresentInCart(product.Name))
            {
                var productInCart = Cart.FirstOrDefault(item => item.ProductDTO.Name == product.Name);
                return productInCart.ToString();
            }
            else
            {
                var newItemMapper = _mapper.Map<ProductDTO>(product);
                var newItem = new OrderItemDTO() { ProductDTO = newItemMapper };
                Cart.Add(newItem);
                // TODO : тут не зберігаються продукти в корзину
                _unit.Save();       

                return newItem.ToString();
            }
        }

        private protected bool PresentInCart(string name) => Cart.Any(item => item.ProductDTO.Name == name);

        public string CancelOrder(int userId)
        {
            if (!_unit.Orders.GetOrderByUserId(userId).Select(x => x.OrderId).Contains(userId))
                return "There is no order in your history with such ID.";

            var order = _unit.Orders.GetOrderById(userId);

            if (order.Status == OrderStatus.Received
                || order.Status == OrderStatus.Complete
                || order.Status == OrderStatus.CanceledByUser
                || order.Status == OrderStatus.CanceledByAdmin)
            {
                return "You can't cancel this order";
            }

            order.Status = OrderStatus.CanceledByUser;

            _unit.Users.GetUserById(userId).Balance += order.TotalPrice;
            _unit.Save();

            return $"Order with ID {userId} cancelled. Money returned";
        }

        public string ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _unit.Users.GetUserById(userId);

            if (oldPassword != user.Password)
                return "Wrong password";

            user.Password = newPassword;

            _unit.Save();

            return "Password changed.";
        }

        public string LogOut()
        {
            NotifyOfLoggingOut?.Invoke();
            return "Logging Out...";
        }

        public List<OrderDTO> SeeOrderHistory(int userId)
        {
            var orders = _unit.Orders.GetOrderByUserId(userId);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public string SetStatusReceived(int orderId)
        {
            try
            {
                if (_unit.Orders.GetOrderById(orderId).OrderId == orderId)
                    return "There is no order in your history with such ID.";

                var order = _unit.Orders.GetOrderById(orderId).Status = OrderStatus.Received;

                _unit.Save();

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