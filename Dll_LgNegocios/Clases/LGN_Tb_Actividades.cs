using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Actividades
    {
        ACD_Tb_Actividades _acd_Tb_Actividades = new ACD_Tb_Actividades();

        public ENT_Tb_Actividades Selecciona_ActividadDesarrollo(double pRutEmpresa, double pNumOt, int pCodAct)
        {
            ENT_Tb_Actividades actividades = new ENT_Tb_Actividades();
            try
            {
                actividades = _acd_Tb_Actividades.Selecciona_ActividadDesarrollo(pRutEmpresa, pNumOt, pCodAct);
                return actividades;
            }
            catch (Exception ex)
            {
                actividades = null;
                return actividades;
            }
        }

        public string Actualiza_EstadoActividadOt(ENT_Tb_Actividades oActividades)
        {
            string Tarea = string.Empty;
            try
            {
                Tarea = _acd_Tb_Actividades.Actualiza_EstadoActividadOt(oActividades);
                return Tarea;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Valida_EstadoActividadOt(ENT_Tb_Actividades oActividades)
        {
            string Tarea = string.Empty;
            try
            {
                Tarea = _acd_Tb_Actividades.Valida_EstadoActividadOt(oActividades);
                return Tarea;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Inserta_NuevaActividad(ENT_Tb_Actividades oActividades)
        {
            string Tarea = string.Empty;
            try
            {
                Tarea = _acd_Tb_Actividades.Inserta_NuevaActividad(oActividades);
                return Tarea;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}