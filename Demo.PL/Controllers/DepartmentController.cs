using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository=departmentRepository;
        }

        public IActionResult Index()
        {
            return View(departmentRepository.GetAll());
        }


      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Add(department);
                return RedirectToAction("Index");   
            }

            return View(department);

        }

        public IActionResult Details(int? id , string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var Department = departmentRepository.Get(id);
            if (Department == null)
                return NotFound();
            return View(ViewName, Department);
        }

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
            //if (id==null)
            //    return NotFound();
            //var department = departmentRepository.Get(id);
            //if (department == null)
            //    return NotFound();
            //return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( [FromRoute] int? id , Department department)
        {
            if(id != department.Id)
                return BadRequest();
            if(ModelState .IsValid)

                try
                {
                    departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View(department);
                }

                    return View(department);
        }

        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]

        public IActionResult Delete ([FromRoute] int? id , Department department )
        {
            if (id != department.Id)
                return BadRequest();
          try
            {
                departmentRepository.Delete(department);
                return RedirectToAction(nameof (Index));

            }
            catch
            {
                return View(department);
            }
        }









    }
}
