using Dachy.DataAccess.Data;
using Dachy.DataAccess.Repository;
using Dachy.DataAccess.Repository.IRepository;
using Dachy.Models;
using Dachy.Models.ViewModels;
using Dachy.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DachyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoleManagment(string userId)
        {
            RoleManagmentViewModel RoleVM = new RoleManagmentViewModel() {
                ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId, includeProperties:"Company"),
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = _unitOfWork.Company.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            RoleVM.ApplicationUser.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u=>u.Id == userId))
                .GetAwaiter().GetResult().FirstOrDefault();
            return View(RoleVM);  
        }

        [HttpPost]
        public IActionResult RoleManagment(RoleManagmentViewModel roleManagmentViewModel)
        {
            string oldRole = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentViewModel.ApplicationUser.Id))
                .GetAwaiter().GetResult().FirstOrDefault();

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentViewModel.ApplicationUser.Id);


            if (!(roleManagmentViewModel.ApplicationUser.Role == oldRole))
            {
                if (roleManagmentViewModel.ApplicationUser.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId = roleManagmentViewModel.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    applicationUser.CompanyId = null;
                }
                _unitOfWork.ApplicationUser.Update(applicationUser);
                _unitOfWork.Save();                
                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagmentViewModel.ApplicationUser.Role).GetAwaiter().GetResult();
            }
            else
            {
                if (oldRole ==SD.Role_Company && applicationUser.CompanyId != roleManagmentViewModel.ApplicationUser.CompanyId)
                {
                    applicationUser.CompanyId = roleManagmentViewModel.ApplicationUser.CompanyId;
                    _unitOfWork.ApplicationUser.Update(applicationUser);
                    _unitOfWork.Save();
                }
            }

            return RedirectToAction("Index");
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll ()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUser.GetAll(includeProperties:"Company").ToList();
            foreach (var user in objUserList)
            {
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();
                if (user.Company == null)
                {
                    user.Company = new() { Name = "" };
                }
            }

            return Json (new {data = objUserList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Problem z blokadą" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //Użytkownik jest aktualnie zablokowany
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(999);
            }
            _unitOfWork.ApplicationUser.Update(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Gotowe! :)" });
        }

        #endregion
    }
}
