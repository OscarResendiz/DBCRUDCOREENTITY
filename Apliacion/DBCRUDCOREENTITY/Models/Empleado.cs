using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBCRUDCOREENTITY.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    [Required(ErrorMessage = "El campo nombre es obligatorio")]
    public string? NombreCompleto { get; set; }

    [Required(ErrorMessage = "El campo Correo es obligatorio")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    public string? Telefono { get; set; }

    public int? IdCargo { get; set; }

    public virtual Cargo? oCargo { get; set; }
}
