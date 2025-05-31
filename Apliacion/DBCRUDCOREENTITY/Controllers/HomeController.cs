using System.Diagnostics;
using DBCRUDCOREENTITY.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBCRUDCOREENTITY.Models;
using System.Diagnostics.Contracts;
using DBCRUDCOREENTITY.Models.ViewModels;

namespace DBCRUDCOREENTITY.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbcrudcoreentityContext _dbcrudcoreentityContext;

        public HomeController(DbcrudcoreentityContext dbcrudcoreentityContext)
        {
            _dbcrudcoreentityContext = dbcrudcoreentityContext;
        }

        public IActionResult Index()
        {
            List<Empleado> lista=_dbcrudcoreentityContext.Empleados.Include(c=>c.oCargo).ToList();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Empleado_Detalle(int IdEmpleado)
        {
            EmpleadoVm empleadoVm = new EmpleadoVm();
            empleadoVm.oEmpleado = new Empleado();
            empleadoVm.oListaCargo = _dbcrudcoreentityContext.Cargos.Select(cargo => new SelectListItem()
            {
                Text = cargo.Descripcion,
                Value = cargo.IdCargo.ToString()
            }).ToList();
            if (IdEmpleado != 0)
            {
                empleadoVm.oEmpleado = _dbcrudcoreentityContext.Empleados.Find(IdEmpleado);
            }
            return View(empleadoVm);

        }
        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVm oEmpleadoVm)
        {
            if(oEmpleadoVm.oEmpleado.IdEmpleado==0)
            {
                _dbcrudcoreentityContext.Empleados.Add(oEmpleadoVm.oEmpleado);
            }
            else
            {
                _dbcrudcoreentityContext.Empleados.Update(oEmpleadoVm.oEmpleado);
            }
                _dbcrudcoreentityContext.SaveChanges();
            return RedirectToAction("Index","home");
        }

        public IActionResult Eliminar(int IdEmpleado)
        {
            EmpleadoVm empleadoVm = new EmpleadoVm();
            empleadoVm.oEmpleado = new Empleado();
            empleadoVm.oListaCargo = _dbcrudcoreentityContext.Cargos.Select(cargo => new SelectListItem()
            {
                Text = cargo.Descripcion,
                Value = cargo.IdCargo.ToString()
            }).ToList();
            if (IdEmpleado != 0)
            {
                empleadoVm.oEmpleado = _dbcrudcoreentityContext.Empleados.Include(c => c.oCargo).Where(c=>c.IdEmpleado==IdEmpleado).FirstOrDefault();
            }
            return View(empleadoVm);
        }
        [HttpPost]
        public IActionResult Eliminar(EmpleadoVm empleado)
        {
            _dbcrudcoreentityContext.Empleados.Remove(empleado.oEmpleado);
            _dbcrudcoreentityContext.SaveChanges();
            return RedirectToAction("Index", "home");
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
