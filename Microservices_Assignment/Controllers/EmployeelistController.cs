﻿using Microservices_Assignment.BAL;
using Microservices_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeelistController : ControllerBase
        
    {
        private readonly ILogger<EmployeelistController> _logger;

        public List<Employee> _employee;

        private readonly IEmployeeBAL EmpBal;

        public EmployeelistController(ILogger<EmployeelistController> logger, IEmployeeBAL _EmpBal)
        {
            _logger = logger;
            this.EmpBal = _EmpBal;          
        }

        [HttpGet]
        public async Task<ApiResponse<Employee>> Get()
        {
            ApiResponse<Employee> response = new ApiResponse<Employee>();
            try
            {
                response= await EmpBal.Get();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return response;
        }

        
        [HttpGet("{id}")]
        public async Task<ApiResponse<Employee>> Get(int id)
        {
            ApiResponse<Employee> response = new ApiResponse<Employee>();
            try
            {
                response = await EmpBal.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return response;
        }

        [HttpPost]
        public async Task<Response<Employee>> Post([FromBody] Employee Emp)
        {
            Response<Employee> response = new Response<Employee>();
            try
            {
                response =await EmpBal.Post(Emp);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return response;

        }

     
        [HttpPut("{id}")]
        public async Task<Response<Employee>> Put(int id, [FromBody] Employee emp)
        {
            Response<Employee> response = new Response<Employee>();
            try
            {
                response = await EmpBal.Put(id, emp);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return response;
        }

        [HttpPatch("{id}")]
        public async Task<Response<Employee>> Patch(int id, [FromBody] string name)
        {

            Response<Employee> response = new Response<Employee>();
            try
            {
                response = await EmpBal.Patch(id, name);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return response;

        }

        [HttpDelete("{id}")]
        public async Task<Response<Employee>> Delete(int id)
        {
            Response<Employee> response = new Response<Employee>();
            try
            {
                response = await EmpBal.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return response;
        }
    }
}
