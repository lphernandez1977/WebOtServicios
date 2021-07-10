using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dll_Datos;
using Dll_Entidades;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Tipo_OT
    {
        ACD_Tb_Tipo_OT _acd_Tb_Tipo_OT = new ACD_Tb_Tipo_OT();

        public DataSet Selecciona_ListaTipoOT(double pRutEmp)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Tipo_OT.Selecciona_ListaTipoOT(pRutEmp);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_Familias()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Tipo_OT.Selecciona_Familias();
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

    }
}