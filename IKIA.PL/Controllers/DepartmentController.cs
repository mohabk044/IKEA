using IKEA.BLL.Models.Departments;
using IKEA.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace IKIA.PL.Controllers
{
    //Inheritance: Department Controller is a Controller 
    //composition: Department Controller has a IDepartmentservice
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IWebHostEnvironment _environment;

        public ILogger _Logger { get; }
                       
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> Logger, IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _Logger = Logger;
            _environment = environment;
        }

        #region Index
        [HttpGet]//dep/index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
        #endregion
        #region Create
        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO department)
        {
            if (ModelState.IsValid)
            {
                var message = string.Empty;
                try
                {
                    var result = _departmentService.CreateDepartment(department);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        message = "Department was not created";
                        ModelState.AddModelError(string.Empty,message);
                        return View(department);
                    }
                }
                catch (Exception ex)
                {
                    //1- log exception
                    _Logger.LogError(ex, ex.Message);
                    //2- add error message to model state(set frindly message)
                    if(_environment.IsDevelopment())
                    {
                       message = ex.Message;
                       return View(department);

                    }
                    else
                    {
                        message = "Department was not created";
                        return View("Error",message);
                    }
                }
            }
            return View(department);
        }

        #endregion
        #endregion

    }
}
