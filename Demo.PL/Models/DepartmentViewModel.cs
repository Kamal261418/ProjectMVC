using Demo.DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class DepartmentViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Code is Required")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name length must be between 5 and 100 chars")]
        public string Name { get; set; }

        public virtual ICollection<Department> Departments { get; set; }


    }
}
