using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBCRUDCOREENTITY.Models.ViewModels
{
    public class EmpleadoVm
    {
        public Empleado oEmpleado {  get; set; }
        public List<SelectListItem> oListaCargo { get; set; }

    }
}
