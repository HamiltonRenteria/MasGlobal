using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Web.Models;
using Test.Web.Models.Entity;

namespace TestMasGlobal.Controllers.APIs
{
    public class EmployeesController : ApiController
    {
        List<EmployeeEntity> _Employees = DBApi.GetEmployees("http://masglobaltestapi.azurewebsites.net/api/Employees", "");
        List<EmployeeEntity> listEmployees = new List<EmployeeEntity>();
        DBApi dBApi = new DBApi();

        // GET: api/Employees
        public IEnumerable<EmployeeEntity> Get()
        {
            float anualSalary = 0;
            //_Employees = dBApi.GetEmployees("http://masglobaltestapi.azurewebsites.net/api/Employees", "");

            if (_Employees.Count > 0)
            {
                foreach (var item in _Employees)
                {

                    if (item.contractTypeName == "HourlySalaryEmployee")
                    {
                        anualSalary = 120 * item.hourlySalary * 12;
                    }
                    else if (item.contractTypeName == "MonthlySalaryEmployee")
                    {
                        anualSalary = 120 * item.hourlySalary * 12;
                    }

                    listEmployees.Add(new EmployeeEntity
                    {
                        id = item.id,
                        name = item.name,
                        contractTypeName = item.contractTypeName,
                        roleId = item.roleId,
                        roleName = item.roleName,
                        roleDescription = item.roleDescription,
                        hourlySalary = item.hourlySalary,
                        monthlySalary = item.monthlySalary,
                        anualSalary = Convert.ToInt32(anualSalary)
                    });

                }
            }

            return listEmployees;
        }

        // GET: api/Employees/5
        public IEnumerable<EmployeeEntity> Get(int id)
        {
            float anualSalary = 0;
            //_Employees = dBApi.GetEmployees("http://masglobaltestapi.azurewebsites.net/api/Employees", "");

            if (_Employees.Count > 0)
            {
                foreach (var item in _Employees)
                {
                    if (item.id == id)
                    {
                        if (item.contractTypeName == "HourlySalaryEmployee")
                        {
                            anualSalary = 120 * item.hourlySalary * 12;
                        }
                        else if (item.contractTypeName == "MonthlySalaryEmployee")
                        {
                            anualSalary = 120 * item.hourlySalary * 12;
                        }

                        listEmployees.Add(new EmployeeEntity
                        {
                            id = item.id,
                            name = item.name,
                            contractTypeName = item.contractTypeName,
                            roleId = item.roleId,
                            roleName = item.roleName,
                            roleDescription = item.roleDescription,
                            hourlySalary = item.hourlySalary,
                            monthlySalary = item.monthlySalary,
                            anualSalary = Convert.ToInt32(anualSalary)
                        });
                    }
                }
            }

            return listEmployees;
        }
    }
}
