using AutoMapper;
using Eshop.DAL.Interfaces;
using EShop.BL.DTOs;
using EShop.BL.Interfaces;
using EShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShop.BL.Services
{
    public class GuestService : IGuestService
    {
        public event IGuestService.LogInHendler NotifyOfLogginIn;
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unit;

        public GuestService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _unit.Products.FindAll().ToList();
           
            if (products == null)
                return null;

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public ProductDTO FindById(int productId)
        {
            var product = _unit.Products.FindByCondition(x => x.Id == productId).FirstOrDefault();
            
            if (product == null)
                return null;

            return _mapper.Map<ProductDTO>(product);
        }

        public ProductDTO FindByName(string productName)
        {
            var product = _unit.Products.FindByCondition(x => x.Name == productName).FirstOrDefault();

            if (product == null)
                return null;

            return _mapper.Map<ProductDTO>(product);
        }

        public string LogIn(string email, string password)
        {
            var user =  _unit.Users.FindAll().FirstOrDefault(u => (u.Email == email) && (u.Password == password));

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
           
            _unit.Users.AddAsync(mapperNewUser);
            _unit.SaveAsync();

            NotifyOfLogginIn?.Invoke(newUser);

            return "Registered";
        }
    }
}