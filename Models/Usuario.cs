﻿using System;
using System.Collections.Generic;

namespace MVC_CRUD_VARGAS.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Clave { get; set; }
}
