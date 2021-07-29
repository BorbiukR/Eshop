using AutoMapper;
using DAL.Interfaces;
using EShop.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IUserService _userService;

        public UserContoller(IUnitOfWork unit, IMapper mapper, IUserService userService)
        {
            _unit = unit;
            _mapper = mapper;
            _userService = userService;
        }
    }
}
