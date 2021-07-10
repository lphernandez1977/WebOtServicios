using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_OT_Encabezado
    {
        public double num_ot { get; set; }
        public double rut_empresa { get; set; }
        public DateTime fecha_creacion_ot { get; set; }
        public DateTime fecha_termino_ot { get; set; }
        public int estado { get; set; }
        public double rut_personal { get; set; }
        public double rut_crea_ot { get; set; }
        public int periodo { get; set; }
        public int tipo_ot { get; set; }
        public DateTime fecha_reserva_captura { get; set; }
    }
}