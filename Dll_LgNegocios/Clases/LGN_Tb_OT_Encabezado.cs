using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_OT_Encabezado
    {
        ACD_Tb_OT_Encabezado _acd_Tb_OT_Encabezado = new ACD_Tb_OT_Encabezado();

        public int Selecciona_CreaFolioOT(double vRutEmp)
        {
            int res = 0;
            try
            {
                res = _acd_Tb_OT_Encabezado.Selecciona_CreaFolioOT(vRutEmp);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public string Inserta_NuevaOrdenTrabajo(string xml)
        //public string Inserta_NuevaOrdenTrabajo(ENT_Tb_OT_Encabezado Cabecera, List<ENT_Tb_OT_Detalle> in_lista)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajo(xml);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public bool Inserta_NuevaOrdenTrabajoxEquipos(ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado)
        {
            bool res = false;
            try
            {
                res = _acd_Tb_OT_Encabezado.Inserta_EncabezadoOrdenTrabajoxEquipos(_ent_Tb_OT_Encabezado);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public bool Actualiza_AsignacionOT_Tecnico(ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado)
        {
            bool res = false;
            try
            {
                res = _acd_Tb_OT_Encabezado.Actualiza_AsignacionOT_Tecnico(_ent_Tb_OT_Encabezado);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public string Selecciona_OtAsignada(double pRutEmp, double pNumOt, double pRutTec)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_OT_Encabezado.Selecciona_OtAsignada(pRutEmp, pNumOt, pRutTec);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public string Actualiza_CerrarOTenTrabajo(double pRutEmp, double pNumOt)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_OT_Encabezado.Actualiza_CerrarOTenTrabajo(pRutEmp, pNumOt);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public DataSet Selecciona_EncabezadoOtPDF(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Encabezado.Selecciona_EncabezadoOtPDF(pRutEmp, pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Modifica_OrdenTrabajo(ENT_Tb_OT_Encabezado oEncaOT)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_OT_Encabezado.Modifica_OrdenTrabajo(oEncaOT);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
        
    }
}