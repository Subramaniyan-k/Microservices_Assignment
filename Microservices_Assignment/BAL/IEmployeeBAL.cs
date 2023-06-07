using Microservices_Assignment.Models;

namespace Microservices_Assignment.BAL
{
    public interface IEmployeeBAL
    {

        public ApiResponse<Employee> Get();
        public ApiResponse<Employee> Get(int id);
        public Response<Employee> Post( Employee Emp);
        public Response<Employee> Put(int id,  Employee emp);
        public Response<Employee> Patch(int id,  string name);
        public Response<Employee> Delete(int id);       
    }
}
