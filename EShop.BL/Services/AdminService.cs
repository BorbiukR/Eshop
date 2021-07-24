using AutoMapper;
using DAL.Interfaces;
using Eshop.DAL.Models;
using EShop.BL.DTOs;
using EShop.BL.DTOs.Enums;
using EShop.BL.Enums;
using EShop.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShop.BL.Services
{
    public class AdminService : UserService, IAdminService
    {
        public AdminService(IUnitOfWork unit, IMapper mapper) : base(unit, mapper) { }

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

        public string ChangeOrderStatus(int orderId, OrderStatusDTO status)
        {
            var order = _unit.Orders.GetOrderById(orderId);

            if (order == null)
                return "No order with such ID!";

            switch (status)
            {
                case OrderStatusDTO.CanceledByAdmin:
                    status = OrderStatusDTO.CanceledByAdmin;
                    break;
                case OrderStatusDTO.New:
                    status = OrderStatusDTO.New;
                    break;
                case OrderStatusDTO.PaymentReceived:
                    status = OrderStatusDTO.PaymentReceived;
                    break;
                case OrderStatusDTO.Sent:
                    status = OrderStatusDTO.Sent;
                    break;
                case OrderStatusDTO.Complete:
                    status = OrderStatusDTO.Complete;
                    break;
                default:
                    return "Invalid status!";
            }

            _unit.Orders.SetNewOrderStatus(orderId, status);
            _unit.Save();

            return "Status changed.";
        }

        public string ChangeUserPassword(int userId, string newUserPassword)
        {
            throw new NotImplementedException();
        }

        public string ModifyProduct(int productId, string newProductName = null, decimal newProductPrice = 0, string newProductDescription = null, ProductCategoryDTO newProductCategory = ProductCategoryDTO.Vegetables)
        {
            throw new NotImplementedException();
        }

        public string SeeOrdersOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public string SeeUsersInfo()
        {
            throw new NotImplementedException();
        }
    }
}
