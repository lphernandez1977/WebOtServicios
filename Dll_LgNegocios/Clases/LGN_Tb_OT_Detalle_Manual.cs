using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_OT_Detalle_Manual
    {
        ACD_Tb_OT_Detalle_Manual _acd_Tb_OT_Detalle_Manual = new ACD_Tb_OT_Detalle_Manual();

        public DataSet Selecciona_DetalleOtPDFManual(double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_OT_Detalle_Manual.Selecciona_DetalleOtPDFManual(pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}