using IKEA.BLL.Models.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentToReturnDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllAsQuarable().Select(department => new DepartmentToReturnDTO
            {

                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                //Description = department.Description,
                CreationDate = department.CreationDate


            }).AsNoTracking().ToList();
            return departments;
        }


        public DepartmentDetailsToReturnDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is not null)
            {
                return new DepartmentDetailsToReturnDTO
                {
                    Id = department.Id,
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,
                };
            }
            return null;
        }
        


        public int CreateDepartment(CreatedDepartmentDTO departmentDTO)
        {
            var Createddepartment = new Department()
            {
                Code = departmentDTO.Code,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreationDate = departmentDTO.CreationDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
                //CreatedOn = DateTime.UtcNow,
            };
            return _departmentRepository.Add(Createddepartment);
        }
        public int UpdateDepartment(UpdatedDepartmentDTO departmentDTO)
        {
           var Updateddepartment = new Department()
           {
               Id = departmentDTO.ID,
               Code = departmentDTO.Code,
               Name = departmentDTO.Name,
               Description = departmentDTO.Description,
               CreationDate = departmentDTO.CreationDate,
               CreatedBy = 1,
               LastModifiedBy = 1,
               LastModifiedOn = DateTime.UtcNow,
               //CreatedOn = DateTime.UtcNow,
           };
            return _departmentRepository.Update(Updateddepartment);
        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is not null)
            {
                return _departmentRepository.Delete(department) > 0;
            }
            return false;
        }
    }
}
