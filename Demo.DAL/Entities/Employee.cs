using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { set; get; }

        [DataType (DataType.Currency)]  
        public decimal Salary { get; set; }

        public bool IsActvie { get; set; }

        [EmailAddress]
        public string Email { get; set; }   

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int DepartmentId { get; set; }

        public string ImageName { get; set; }

        public virtual Department Department { get; set; }

      
    }
}
