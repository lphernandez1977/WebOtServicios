using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_Registro_Login
    {
        public double rut_personal { get; set; }
        public DateTime fecha_login { get; set; }
        public DateTime fecha_ter_login { get; set; }
    }
}