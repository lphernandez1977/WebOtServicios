using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_OT_Detalle
    {
        ACD_Tb_OT_Detalle _acd_Tb_OT_Detalle = new ACD_Tb_OT_Detalle();

        public bool Inserta_DetalleOrdenTrabajoxEquipos(ENT_Tb_OT_Detalle _ent_Tb_OT_Detale)
        {
            bool res = false;
            try
            {
                res = _acd_Tb_OT_Detalle.Inserta_DetalleOrdenTrabajoxEquipos(_ent_Tb_OT_Detale);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public DataSet Selecciona_DetalleOtPDF(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Detalle.Selecciona_DetalleOtPDF(pRutEmp, pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Selecciona_DetalleOtPDFPendiente(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Detalle.Selecciona_DetalleOtPDFPendiente(pRutEmp, pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Selecciona_DetalleObservacionPDF(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Detalle.Selecciona_DetalleObservacionPDF(pRutEmp, pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}