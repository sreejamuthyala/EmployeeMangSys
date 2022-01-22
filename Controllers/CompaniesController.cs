using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
         ICRUDRepository<Companies, int> _repository;
        public CompaniesController(ICRUDRepository<Companies, int> repository) => _repository = repository;
        public ActionResult<IEnumerable<Companies>> Get()
        {
            var items = _repository.GetAll();
            return items.ToList();
        }

        [HttpGet("Company")]
        public Models.Companies GetCompany()
        {
            Models.Companies obj = new Models.Companies{
                CompanyId=1,
                CompanyName="Capgemini",
                
            };
           return obj;  
        }
       
    }
}
    
