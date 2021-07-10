using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;

namespace Dll_LgNegocios
{
    public class LGN_FechaHoraServer
    {
        ACD_FechaHoraServer acd_ACD_FechaHoraServer = new ACD_FechaHoraServer();
        public string Selecciona_FechaHoraServer()
        {
            string FecHora = string.Empty;
            try
            {
                FecHora = acd_ACD_FechaHoraServer.Selecciona_FechaHoraServer();
                return FecHora;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}