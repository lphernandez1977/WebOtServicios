using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_OT_Encabezado_Manual
    {
        public double num_ot { get; set; }
        public double rut_empresa { get; set; }
        public string nom_empresa { get; set; }
        public DateTime fecha_creacion_ot { get; set; }
        public int estado { get; set; }
        public string periodo { get; set; }        
    }
}