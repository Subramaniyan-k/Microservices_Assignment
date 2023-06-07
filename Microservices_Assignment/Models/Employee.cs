using System.ComponentModel.DataAnnotations;

namespace Microservices_Assignment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(10,ErrorMessage ="Max Length is 10 charater for Name")]
        public string Name { get; set; }

    }
}
