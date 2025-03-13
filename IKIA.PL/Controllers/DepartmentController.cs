using IKEA.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace IKIA.PL.Controllers
{
    //Inheritance: Department Controller is a Controller 
    //composition: Department Controller has a IDepartmentservice
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        #region Index
        [HttpGet]//dep/index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        } 
        #endregion

    }
}
