using AutoMapper;
using DAL.Interfaces;
using Eshop.DAL.Models;
using EShop.BL.DTOs;
using EShop.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShop.BL.Services
{
    public class GuestService : IGuestSerivece
    {
        public event IGuestSerivece.LogInHendler NotifyOfLogginIn;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unit;

        public GuestService(IUnitOfWork unit, IMapper mapper)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _unit.Products.GetAllProducts();

            return _mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(int productId)
        {
            var product = _unit.Products.FindByCondition(x => x.ProductId.Equals(productId)).FirstOrDefault();
            
            if (product == null)
                return null;

            return _mapper.Map<ProductDTO>(product);
        }

        public ProductDTO GetProductByName(string productName)
        {
            var product = _unit.Products.FindByCondition(x => x.Name.Equals(productName)).FirstOrDefault();

            if (product == null)
                return null;

            return _mapper.Map<ProductDTO>(product);
        }

        public string LogIn(string email, string password)
        {
            var user =  _unit.Users.GetAllUsers().FirstOrDefault(u => (u.Email == email) && (u.Password == password));

            if (user != null)
            {
                var mapperUser = _mapper.Map<UserDTO>(user);
                NotifyOfLogginIn?.Invoke(mapperUser);
                return "WellCome back!";
            }

            return "Wrong email or password";
        }

        public string Register(string email, string password, string confirmPassword)
        {
            if (!email.Contains("@"))
                return "Email should contain '@' symbol.";

            var registeredEmails = _unit.Users.FindAll().Select(u => u.Email);

            if (registeredEmails.Contains(email))
                return "Email already registered.";

            if (password != confirmPassword)
                return "Passwords don't match!";

            var newUser = new UserDTO() { Email = email, Password = password };
            var mapperNewUser = _mapper.Map<User>(newUser);
           
            _unit.Users.AddUser(mapperNewUser);
            _unit.Save();

            NotifyOfLogginIn?.Invoke(newUser);

            return "Registered";
        }
    }
}