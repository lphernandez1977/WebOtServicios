using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_Personal
    {
        public double rut_personal { get; set; }
        public char dv { get; set; }
        public string nom_empleado { get; set; }
        public string ape_empleado { get; set; }
        public string cargo { get; set; }
        public double valor_hora { get; set; }
        public DateTime fecha_registro { get; set; }
        public string contrasenia { get; set; }
        public Int32 Cod_Cargo { get; set; }
    }
}