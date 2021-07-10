using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dll_Datos;
using Dll_Entidades;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Tipo_Dispositivo
    {
        ACD_Tb_Tipo_Dispositivo _acd_Tb_Tipo_Dispositivo = new ACD_Tb_Tipo_Dispositivo();

        public DataSet Selecciona_Dispositivos()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Tipo_Dispositivo.Selecciona_Dispositivos();
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