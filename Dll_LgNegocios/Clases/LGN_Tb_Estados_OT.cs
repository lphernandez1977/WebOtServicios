using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Estados_OT
    {
        ACD_Tb_Estados_OT _acd_Tb_Estados_OT = new ACD_Tb_Estados_OT();
        public DataSet Selecciona_EstadosOT()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Estados_OT.Selecciona_EstadosOT();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}