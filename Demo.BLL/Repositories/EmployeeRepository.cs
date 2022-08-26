using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository: GenaricRepository<Employee> , IEmployeeRepository
    {
        public MVCAppGr03DbContext Context { get; }
        public EmployeeRepository(MVCAppGr03DbContext context):base(context)
        {
            Context=context;
        }

      

        public IEnumerable<Employee> GetEmployeeByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Employee>> SearchEmployee(string value)
        => await Context.employees.Where(E => E.Name.Contains(value)).ToListAsync();
    }
}
