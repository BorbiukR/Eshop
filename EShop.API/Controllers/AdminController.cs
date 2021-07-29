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
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly IAdminService _adminService;

        public AdminController(IUnitOfWork unit, IMapper mapper, IAdminService adminService)
        {
            _unit = unit;
            _mapper = mapper;
            _adminService = adminService;
        }
    }
}
