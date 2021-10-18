using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO);

        public Task<EmployeeDTO> UpdateEmployee(int employeeId, EmployeeDTO employeeDTO);

        public Task<EmployeeDTO> GetEmployee(int employeeId);

        public Task<int> DeleteEmployee(int employeeId);

        public Task<IEnumerable<EmployeeDTO>> GetAllEmployees();

        public Task<EmployeeDTO> IsEmployeeUnique(string name, int employeeId = 0);
    }
}
