using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_Equipos
    {
        public double rut_empresa { get; set; }
        public int cod_equipos { get; set; }
        public string nom_equipos { get; set; }
        public string nom_corto { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}