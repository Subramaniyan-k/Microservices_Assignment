using Microservices_Assignment.Models;

namespace Microservices_Assignment.BAL
{
    public class EmployeeBAL: IEmployeeBAL
    {
        private readonly ILogger<EmployeeBAL> _logger;

        public List<Employee> _employee;

        public EmployeeBAL(ILogger<EmployeeBAL> logger)
        {
            _logger = logger;
            _employee = new List<Employee>();
            _employee.Add(new Employee { Id = 1, Name = "Mani" });
            _employee.Add(new Employee { Id = 2, Name = "David" });
            _employee.Add(new Employee { Id = 3, Name = "Hussion" });
        }
        public async Task<ApiResponse<Employee>> Get()
        {
            ApiResponse<Employee> response = new ApiResponse<Employee>();
            if (_employee.Count > 0)
            {
                response.IsError = false;
                response.ErrorMessage = "Success";
                response.Response = _employee;

            }
            return response;

        }


        public async Task<ApiResponse<Employee>> Get(int id)
        {
            var result = _employee.Where(x => x.Id == id).ToList();

            ApiResponse<Employee> response = new ApiResponse<Employee>();
            if (result.Count > 0)
            {
                response.IsError = false;
                response.ErrorMessage = "Success";
                response.Response = result;

            }
            return response;
        }

              public async Task<Response<Employee>> Post( Employee Emp)
        {
            var result = _employee.Where(x => x.Id == Emp.Id).ToList();

            Response<Employee> response = new Response<Employee>();
            if (result.Count > 0)
            {
                response.StatusCode = "409";
                response.Status = "Duplicate Records";


            }
            else
            {
                _employee.Add(Emp);
                response.StatusCode = "200";
                response.Status = "Success";
                response.Data = _employee;
            }
            return response;

        }

      
        public async Task<Response<Employee>> Put(int id, Employee emp)
        {
            var result = _employee.Where(x => x.Id == emp.Id).ToList();

            Response<Employee> response = new Response<Employee>();
            if (result.Count > 0)
            {
                _employee.RemoveAll(x => x.Id == emp.Id);
                _employee.Add(emp);
                response.StatusCode = "200";
                response.Status = "Record Updated Successfully.";
                response.Data = _employee;


            }
            else
            {

                response.StatusCode = "409";
                response.Status = "Record Not Available.";

            }
            return response;
        }

       public async Task<Response<Employee>> Patch(int id, string name)
        {

            var result = _employee.Where(x => x.Id == id).ToList();

            Response<Employee> response = new Response<Employee>();
            if (result.Count > 0)
            {
                _employee.Where(w => w.Id == id).ToList().ForEach(i => i.Name = name);
                response.StatusCode = "200";
                response.Status = "Record Updated Successfully.";
                response.Data = _employee;


            }
            else
            {

                response.StatusCode = "409";
                response.Status = "Record Not Available.";

            }
            return response;

        }

       
        public async Task<Response<Employee>> Delete(int id)
        {
            var result = _employee.Where(x => x.Id == id).ToList();

            Response<Employee> response = new Response<Employee>();
            if (result.Count > 0)
            {
                _employee.RemoveAll(x => x.Id == id);
                response.StatusCode = "200";
                response.Status = "Record Deleted Successfully.";
                response.Data = _employee;



            }
            else
            {

                response.StatusCode = "409";
                response.Status = "Record Not Available.";

            }
            return response;
        }
    }
}
