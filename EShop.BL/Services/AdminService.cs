using AutoMapper;
using DAL.Interfaces;
using Eshop.DAL.Enums;
using Eshop.DAL.Models;
using EShop.BL.DTOs;
using EShop.BL.Enums;
using EShop.BL.Interfaces;
using System.Collections.Generic;

namespace EShop.BL.Services
{
    public class AdminService : UserService, IAdminService
    {
        public AdminService(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)  { }

        public string AddProduct(string productName, 
                                decimal productPrice, 
                                string productDescription,
                                ProductCategoryDTO productCategory)
        {
            if (productPrice <= 0 || productPrice >= 8_000_000_000)
                return "Invalid price!";

            var product  = new ProductDTO
            {
                Name = productName,
                Price = productPrice,
                Description = productDescription,
                Category = productCategory
            };

            var productMapper = _mapper.Map<Product>(product);
            
            _unit.Products.AddProduct(productMapper);
            _unit.Save();

            return "Product added.";
        }

        public string ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var order = _unit.Orders.GetOrderById(orderId);

            if (order == null)
                return "No order with such ID!";

            switch (status)
            {
                case OrderStatus.CanceledByAdmin:
                    status = OrderStatus.CanceledByAdmin;
                    break;
                case OrderStatus.New:
                    status = OrderStatus.New;
                    break;
                case OrderStatus.PaymentReceived:
                    status = OrderStatus.PaymentReceived;
                    break;
                case OrderStatus.Sent:
                    status = OrderStatus.Sent;
                    break;
                case OrderStatus.Complete:
                    status = OrderStatus.Complete;
                    break;
                default:
                    return "Invalid status!";
            }

            order.Status = status;

            _unit.Orders.Update(order);
            _unit.Save();
            
            return "Status changed.";
        }

        public string ChangeUserPassword(int userId, string newUserPassword)
        {
            var user = _unit.Users.GetUserById(userId); 
            
            if (user is null)
                return "No user thith such ID";

            if (string.IsNullOrWhiteSpace(newUserPassword))
                return "Invalid password!";

            user.Password = newUserPassword;
            
            _unit.Users.Update(user);
            _unit.Save();

            return "Password changed.";
        }

        public string ModifyProduct(int productId, string newProductName = default, decimal newProductPrice = default, string newProductDescription = default, ProductCategoryDTO newProductCategory = default)
        {
            if (newProductName == default &&
                newProductPrice == default &&
                newProductDescription == default &&
                newProductName == default)
            {
                return "You have not made any changes.";
            }

            var oldProduct = _unit.Products.GetProductById(productId);

            if (oldProduct == null)
                return "No product with such ID";

            var newProduct = new ProductDTO() 
            { 
                Name = newProductName,
                Price = newProductPrice,
                Description = newProductDescription,
                Category = newProductCategory
            };

            if (newProduct.Price <= 0)
                return "Invalid price!";

            var mapperNewProduct = _mapper.Map<Product>(newProduct);

            _unit.Products.UpdateProduct(mapperNewProduct);
            _unit.Save();

            return "Product changed.";
        }

        public string SeeOrdersOfUser(int userId)
        {
            if (!UserExists(userId))
                return "No user with such Id!";

            var orders = _unit.Orders.GetOrderByUserId(userId); 

            if (orders.Count == 0)
                return "User hasn't made any purchase yet.";

            return GetStringOfEnumerable(orders);
        }

        private bool UserExists(int userId)
        {
            var user = _unit.Users.GetUserById(userId);

            return user.UserId == userId 
                ? true 
                : false;
        }

        public string SeeUsersInfo()
        {
            var users = _unit.Users.GetAllUsers();

            return GetStringOfEnumerable(users);
        }

        // TODO : застосувати IEnumerable і IEnumerator з оператором yield ?
        private static string GetStringOfEnumerable<T>(IEnumerable<T> enumer)
        {
            string res = string.Empty;

            foreach (T item in enumer)
                res += item.ToString() + "\n";

            return res;
        }
    }
}