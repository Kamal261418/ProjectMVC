using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IEmployeeRepository:IGenaricRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeeByDepartmentName(string departmentName);

        //Employee Get(int? id);

        //IEnumerable<Employee> GetAll();

        //int Add(Department department);

        //int Update(Department department);

        //int Delete(Department department);
        Task<IEnumerable<Employee>> SearchEmployee(string value);
    }
}
