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
        public IActionResult Index()
        {
            return View();
        }
    }
}
