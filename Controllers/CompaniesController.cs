using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Infrastructure;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompanyController : ControllerBase

    {
      ICRUDRepository<Companies, int> _repository; 
        public CompanyController( ICRUDRepository<Companies, int> repository )  => _repository = repository;
        public ActionResult<IEnumerable<Companies>> Get()
        {
            var items = _repository.GetAll(); 
            return items.ToList();
        }
        //Add the EFCore.SQLServer package 
        //dotnet add package Microsoft.EntityFrameworkCore.SqlServer


         //URL: /api/employees/1
         //try with id parameter values between 1 and 9

         [HttpGet("{id}")]
         public ActionResult<Companies> GetDetails(int id)
        {
            var item = _repository.GetDetails(id);
            if(item==null)
            return NotFound();

            return item;
        }
         [HttpPost("addnew")]
        public ActionResult<Companies> Create(Companies emp)
       {
           if(emp==null)
           
             return BadRequest();


             _repository.Create(emp);
              return emp;
  
            
       }

       [HttpPut("update/{id}")]
       public ActionResult<Companies> update(int id, Companies emp)
       {
           if(emp==null)
             return BadRequest();
            _repository.update(emp);
            return emp;
       }
       [HttpDelete("remove/{id}")]
       public ActionResult Delete(int id)
       {
           _repository.Delete(id);

            return Ok();
       }


    }

}