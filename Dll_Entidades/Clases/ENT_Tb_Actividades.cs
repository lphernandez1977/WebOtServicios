using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dll_Entidades
{
    public class ENT_Tb_Actividades
    {
        public int Cod_Act { get; set; }
        public int Tipo_Equipo { get; set; }
        public string Componente { get; set; }
        public string Actividad { get; set; }
        public double Rut_Empresa { get; set; }
        public int Periodo_Actividad { get; set; }
        public string Nom_Disp { get; set; }
        public int Cod_Nom_Dispo { get; set; }
        public double NumOt { get; set; }
        public string ActRealizada { get; set; }
        public DateTime FechaTerTarea { get; set; }
        public string ObservacionAct { get; set; }
        
    }
}