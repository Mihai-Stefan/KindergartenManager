using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DatabaseAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            employee.CreatedDate = DateTime.Now;
            employee.CreatedBy = "whhen we will have users";
            var addedEmployee = await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return _mapper.Map<Employee, EmployeeDTO>(addedEmployee.Entity);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTOs =
                    _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(_db.Employees);

                return employeeDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EmployeeDTO> GetEmployee(int employeeId)
        {
            try
            {
                EmployeeDTO employee = _mapper.Map<Employee, EmployeeDTO>(
                    await _db.Employees.FirstOrDefaultAsync(x => x.Id == employeeId));

                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        // if unique returns null else returns the employee object
        public async Task<EmployeeDTO> IsEmployeeUnique(string fullName, int employeeId = 0)
        {
            try
            {
                if (employeeId == 0)
                {
                    EmployeeDTO employee = _mapper.Map<Employee, EmployeeDTO>(
                        await _db.Employees.FirstOrDefaultAsync(x => x.FirstName.ToLower() + " " + x.LastName.ToLower() == fullName.ToLower()));

                    return employee;
                }
                else
                {
                    EmployeeDTO employee = _mapper.Map<Employee, EmployeeDTO>(
                        await _db.Employees.FirstOrDefaultAsync(x => x.FirstName.ToLower() + " " + x.LastName.ToLower() == fullName.ToLower()
                        && x.Id != employeeId));

                    return employee;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<EmployeeDTO> UpdateEmployee(int employeeId, EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeId == employeeDTO.Id)
                {
                    // valid employee
                    Employee employeeDetails = await _db.Employees.FindAsync(employeeId);
                    // do the mapping:
                    Employee employee = _mapper.Map<EmployeeDTO, Employee>(employeeDTO, employeeDetails);
                    employee.UpdatedBy = "";
                    employee.UpdatedDate = DateTime.Now;
                    var updatedEmployee = _db.Employees.Update(employee);
                    await _db.SaveChangesAsync();
                    // map again to Employee.DTO:
                    return _mapper.Map<Employee, EmployeeDTO>(updatedEmployee.Entity);

                }
                else
                {
                    // invalid
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // we return how many employees are deleted
        public async Task<int> DeleteEmployee(int employeeId)
        {
            var employeeDetails = await _db.Employees.FindAsync(employeeId);
            if (employeeDetails != null)
            {
                _db.Employees.Remove(employeeDetails);
                return await _db.SaveChangesAsync();

            }
            return 0;
        }
    }
}
