using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_OT_Detalle
    {
        public double num_ot { get; set; }
        public int cod_equipos { get; set; }
        public string estado_mantencion { get; set; }
        public double rut_empresa { get; set; }
        public int variableNum { get; set; }

        public static List<ENT_Tb_OT_Detalle>ListaStatica { get; set; }
    }
}