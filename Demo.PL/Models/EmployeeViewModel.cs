using Demo.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class EmployeeViewModel
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required !")]
        [MaxLength(50, ErrorMessage = " Maximum Length of Name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Minimum Length of Name is 50 Chars ")]
        public string Name { get; set; }

        [Range(22, 66, ErrorMessage = " Age must be between 22 and 66 ")]
        public int Age { get; set; }

        public string Address { set; get; }

        [DataType(DataType.Currency)]
        [Range(4000, 8000, ErrorMessage = "Salary must be between 4000 and 8000")]
        public decimal Salary { get; set; }

        public bool IsActvie { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }

        public IFormFile Image { get; set; }

        public string ImageName { get; set; }

        public virtual Department Department { get; set; }

    }
}
