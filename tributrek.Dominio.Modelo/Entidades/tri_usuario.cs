﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tributrek.Infraestructura.AccesoDatos;

public partial class tri_usuario
{
    public int tri_usu_id { get; set; }

    public string tri_usu_nombres { get; set; }

    public string tri_usu_apellido { get; set; }

    public DateOnly? tri_usu_fecha_nacimiento { get; set; }

    public string tri_usu_correo { get; set; }

    public string tri_usu_estado { get; set; }

    public string tri_usu_nombre_usuario { get; set; }

    public string tri_usu_clave { get; set; }

    public int? tri_usu_rol_id { get; set; }



    [JsonIgnore]
    public virtual tri_rol tri_usu_rol { get; set; }
    public virtual ICollection<tri_itinerario> tri_itinerario { get; set; } = new List<tri_itinerario>();

}