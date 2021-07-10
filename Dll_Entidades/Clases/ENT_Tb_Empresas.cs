using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_Empresas
    {
        public double rut_empresa { get; set; }
        public string nom_empresa { get; set; }
        public char dv { get; set; }
        public string contacto_empresa { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}