using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_DesActxTecnicos
    {
        public double Rut_empresa {get;set;}
        public double Num_ot {get;set;}
        public int Cod_equipos {get;set;}
        public int Cod_Act {get;set;}
        public DateTime Fecha_Asignacion { get; set; }
        public DateTime Fecha_cierre {get;set;}
        public char Estado_Actividad {get;set;}
        public double Rut_Tecnico { get; set; }
    }
}