using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Presistance.Repositories.Departments
{

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public DepartmentRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Department> GetAll(bool WithAsNoTracking = true)
        {
            if(WithAsNoTracking)
            {
                _dbcontext.Departments.AsNoTracking().ToList();
            }
            return _dbcontext.Departments.ToList();
        } 

        public Department? GetById(int id)
        {
            //var department = _dbcontext.Departments.Local.FirstOrDefault(D => D.Id == id);
            var department = _dbcontext.Departments.Find(id);
            return department;
        }
        public int Add(Department entity)
        {
            _dbcontext.Departments.Add(entity);//add local
            return _dbcontext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _dbcontext.Departments.Update(entity);
            return _dbcontext.SaveChanges();
        }
        public int Delete(Department entity)
        {
            _dbcontext.Departments.Remove(entity);
            return _dbcontext.SaveChanges();
        }

        public IQueryable<Department> GetAllAsQuarable()
        {
            return _dbcontext.Departments;
        }
    }
}
