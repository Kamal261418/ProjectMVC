using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Demo.PL.Helper;
using Demo.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork=unitOfWork;
            Mapper=mapper;
        }

        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
             {
                var mappedEmps = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>( await UnitOfWork.EmployeeRepository.GetAll());
                return View(mappedEmps);
            }
            else
            {
                var mappedEmps = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(await  UnitOfWork.EmployeeRepository.SearchEmployee(searchValue));
                return View(mappedEmps);
            }
        }



        public IActionResult Create()
        {
            ViewBag.Departments =UnitOfWork.DepartmentRepository.GetAll();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel Employee)
        {
            if (ModelState.IsValid)
            {

                /// Manual Mapping
                ///var mappEmp = new Employee()
                ///{
                ///    Id = Employee.Id,
                ///    Name = Employee.Name,
                ///    Age = Employee.Age,
                ///    Address = Employee.Address,
                ///    Salary = Employee.Salary,
                ///    IsActvie = Employee.IsActvie,
                ///    Email = Employee.Email,
                ///    PhoneNumber = Employee.PhoneNumber,
                ///    HireDate = Employee.HireDate,
                ///    DepartmentId = Employee.DepartmentId,
                ///};

               Employee.ImageName = DecumentSettings.UploadFile(Employee.Image, "Imgs");
                 var mappEmp = Mapper.Map<EmployeeViewModel , Employee>(Employee);
               await UnitOfWork.EmployeeRepository.Add(mappEmp);
                return RedirectToAction("Index");
            }

            ViewBag.Departments =UnitOfWork.DepartmentRepository.GetAll();
            return View(Employee);

        }

        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var Employee = await UnitOfWork.EmployeeRepository.Get(id);
            if (Employee == null)
                return NotFound();
            return View(ViewName, Employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();
            return  await Details(id, "Edit");
            //if (id==null)
            //    return NotFound();
            //var Employee = EmployeeRepository.Get(id);
            //if (Employee == null)
            //    return NotFound();
            //return View(Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeViewModel Employee)
        {
            if (id != Employee.Id)
                return BadRequest();
            if (ModelState.IsValid)

                try
                {
                    var mappEmp = Mapper.Map<EmployeeViewModel, Employee>(Employee);
                    await UnitOfWork.EmployeeRepository.Update(mappEmp);
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View(Employee);
                }

            ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();
            return View(Employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]

        public async Task<IActionResult> Delete([FromRoute] int? id, EmployeeViewModel Employee)
        {
            if (id != Employee.Id)
                return BadRequest();
            try
            {

                var mappEmp = Mapper.Map<EmployeeViewModel, Employee>(Employee);
                DecumentSettings.Delete(Employee.ImageName, "Imgs");
              await UnitOfWork.EmployeeRepository.Delete(mappEmp);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(Employee);
            }
        }




    }
}
