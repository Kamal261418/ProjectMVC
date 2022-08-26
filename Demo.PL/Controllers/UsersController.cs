using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager=userManager;
        }

        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return View(userManager.Users);
            }
            else
            {
               var user = await userManager.FindByEmailAsync(searchValue);  
                    
                    return View( new List<ApplicationUser> { user });
            }
        }

        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var user = await userManager.FindByEmailAsync(id);
            if (user == null)
                return NotFound();
            return View(ViewName, user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, ApplicationUser updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest();
            if (ModelState.IsValid)
                try
                {
                    var user = await userManager.FindByEmailAsync(id);
                    user.UserName = updatedUser.UserName;
                    user.NormalizedUserName = updatedUser.UserName.ToUpper();
                    user.PhoneNumber = updatedUser.PhoneNumber;
                    var result = await userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }

            return View(updatedUser);
        }


        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]

        public async Task<IActionResult> Delete([FromRoute] string id, ApplicationUser DeletedUser)
        {
            if (id != DeletedUser.Id)
                return BadRequest();
            try
            {

                var user = await userManager.FindByIdAsync(DeletedUser.Id); 
              var result = await userManager.DeleteAsync(user);
                if(result.Succeeded)
                return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(DeletedUser);
            }
            catch(Exception)
            {
                throw;
            }


        }




   










    }
}
