using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dll_Datos;
using Dll_Entidades;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Periodos
    {
        ACD_Tb_Periodos _acd_ACD_Tb_Periodos = new ACD_Tb_Periodos();

        public DataSet Selecciona_ListaPeriodos(double pRutEmp)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_ACD_Tb_Periodos.Selecciona_ListaPeriodos(pRutEmp);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_Periodos()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_ACD_Tb_Periodos.Selecciona_Periodos();
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