using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_OT_Encabezado_Manual
    {
        ACD_Tb_OT_Encabezado_Manual _acd_Tb_OT_Encabezado_Manual = new ACD_Tb_OT_Encabezado_Manual();

        public int Selecciona_CreaFolioOT()
        {
            int res = 0;
            try
            {
                res = _acd_Tb_OT_Encabezado_Manual.Selecciona_CreaFolioOTManual();
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public string Inserta_NuevaOrdenTrabajo(ENT_Tb_OT_Encabezado_Manual _ent_Tb_OT_Encabezado_Manual, ENT_Tb_OT_Detalle_Manual _ent_Tb_OT_Detalle_Manual)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_OT_Encabezado_Manual.Inserta_NuevaOrdenTrabajoManual(_ent_Tb_OT_Encabezado_Manual, _ent_Tb_OT_Detalle_Manual);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public string Inserta_DetalleNuevaOrdenTrabajoManual(ENT_Tb_OT_Detalle_Manual _ent_Tb_OT_Detalle_Manual)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_OT_Encabezado_Manual.Inserta_DetalleNuevaOrdenTrabajoManual(_ent_Tb_OT_Detalle_Manual);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public DataSet Selecciona_DetalleOtMan()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Encabezado_Manual.Selecciona_DetalleOtMan();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Selecciona_DetalleOtManOrdenColum(string in_Columna, string in_Direccion)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Encabezado_Manual.Selecciona_DetalleOtManOrdenColum(in_Columna,in_Direccion);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Selecciona_Encabezado_OtManual(double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Encabezado_Manual.Selecciona_Encabezado_OtManual(pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}