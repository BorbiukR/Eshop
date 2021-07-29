using AutoMapper;
using Eshop.DAL.Interfaces;
using EShop.BL.DTOs;
using EShop.BL.Interfaces;
using EShop.DAL.Models;
using EShop.DAL.Models.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            
            _unit.Products.Add(productMapper);
            _unit.Save();

            return "Product added.";
        }

        public string ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var order = _unit.Orders.FindByCondition(x => x.Id == orderId).FirstOrDefault();

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
            var user = _unit.Users.FindByCondition(x => x.Id == userId).FirstOrDefault();


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

            var oldProduct = _unit.Products.FindByCondition(x => x.Id == productId);

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

            _unit.Products.Update(mapperNewProduct);
            _unit.Save();

            return "Product changed.";
        }

        public string SeeOrdersOfUser(int userId)
        {
            if (!UserExists(userId))
                return "No user with such Id!";

            var orders = _unit.Orders.FindByCondition(x => x.UserId == userId);

            if (!orders.Any())
                return "User hasn't made any purchase yet.";

            foreach (var item in orders)
            {
                return $"{item.Id} - {item.Status}- {item.TotalPrice}- {item.UserId}";
            }

            return null;
        }

        private bool UserExists(int userId)
        {
            var user = _unit.Users.FindByCondition(x => x.Id == userId).FirstOrDefault();

            return user.Id == userId 
                ? true 
                : false;
        }

        public string SeeUsersInfo()
        {
            var users = _unit.Users.FindAll();

            if (users != null)
            {
                foreach (var item in users)
                {
                    return $"{item.Id} - {item.Email}- {item.Password}- {item.IsAdmin}- {item.Balance}";
                }
            }

            return null;
        }

        public static IEnumerator GetEnumerator<T>(IEnumerable<T> enumer)
        {
            foreach (T item in enumer)
            {
                yield return item;
            }
        }
    }
}