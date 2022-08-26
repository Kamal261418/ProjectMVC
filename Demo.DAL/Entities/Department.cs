using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public int Code { get; set; }
       
        public string Name  { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Department> Departments { get; set; }




    }
}
