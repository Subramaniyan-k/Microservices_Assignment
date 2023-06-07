using Microservices_Assignment.Models;

namespace Microservices_Assignment.BAL
{
    public interface IEmployeeBAL
    {

        public Task<ApiResponse<Employee>> Get();
        public Task<ApiResponse<Employee>> Get(int id);
        public Task<Response<Employee>> Post( Employee Emp);
        public Task<Response<Employee>> Put(int id,  Employee emp);
        public Task<Response<Employee>> Patch(int id,  string name);
        public Task<Response<Employee>> Delete(int id);       
    }
}
