using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Test.Web.Models;
using Test.Web.Models.Entity;

namespace TestMasGlobal.Controllers
{
    public class EmployeesController : Controller
    {
        int anualSalary = 0;
        List<EmployeeEntity> _Employees = DBApi.GetEmployees("http://masglobaltestapi.azurewebsites.net/api/Employees", "");
        List<EmployeeEntity> listEmployees = new List<EmployeeEntity>();

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult searchEmployees(string IdEmployee)
        {
            if (string.IsNullOrEmpty(IdEmployee))
            {
                listEmployees = _Employees;
            }
            else
            {
              listEmployees = _Employees.Where(p => p.id == Convert.ToInt32(IdEmployee)).ToList();
            }

            return Json(listEmployees, JsonRequestBehavior.AllowGet);
        }
    }
}
