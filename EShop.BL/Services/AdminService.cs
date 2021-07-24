using AutoMapper;
using DAL.Interfaces;
using Eshop.DAL.Enums;
using Eshop.DAL.Models;
using EShop.BL.DTOs;
using EShop.BL.Enums;
using EShop.BL.Interfaces;
using System;
using System.Collections.Generic;

namespace EShop.BL.Services
{
    public class AdminService : UserService, IAdminService
    {
        public AdminService(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)  { }

        public string AddProduct(string productName, decimal productPrice, string productDescription, ProductCategoryDTO productCategory)
        {
            bool success = false;

            if (productPrice <= 0 || productPrice >= 800000)
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

            success = true;

            return success == true
                ? "Product added."
                : "Name is invalid or already taken!";
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

            _unit.Save();
            
            return "Status changed.";
        }

        public string ChangeUserPassword(int userId, string newUserPassword)
        {
            //_console.WriteLine("Input the ID of user you want to modify:");

            //int userId;

            //try
            //{
            //    userId = Convert.ToInt32(_console.ReadLine());
            //}
            //catch (OverflowException)
            //{
            //    return "outside the range of the Int32 type.";
            //}
            //catch (FormatException)
            //{
            //    return "Not valid Id!";
            //}

            //var user = _repo.GetUserById(userId);
            //if (user is null)
            //    return "No user thith such ID";

            //_console.WriteLine("New password:");
            //var newPassword = _console.ReadLine();

            //if (string.IsNullOrWhiteSpace(newPassword))
            //    return "Invalid password!";

            //user.Password = newPassword;
            //_repo.UpdateUser(user);

            //return "Password changed.";
            throw new NotImplementedException();
        }

        public string ModifyProduct(int productId, string newProductName = default, decimal newProductPrice = default, string newProductDescription = default, ProductCategoryDTO newProductCategory = default)
        {
            //_console.WriteLine("Input ID of the product:");
            //int prodId = Convert.ToInt32(_console.ReadLine());

            //var prod = _repo.GetProductById(prodId);

            //if (prod == null)
            //    return "No product with such ID";

            //var newProd = new Product();

            //_console.WriteLine("New name:");
            //newProd.Name = _console.ReadLine();

            //_console.WriteLine("New price:");
            //newProd.Price = Convert.ToInt32(_console.ReadLine());

            //if (newProd.Price <= 0)
            //    return "Invalid price!";

            //bool success = _repo.UpdateProduct(prodId, newProd);

            //if (success)
            //    return "Product changed.";

            //return "Invaliv product data";
            throw new NotImplementedException();
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