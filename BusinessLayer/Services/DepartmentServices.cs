using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    internal class DepartmentServices : IGenericRepository<Department>
    {
        public Task Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
