using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//agregadas
using Dll_Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dll_Datos
{
    public class ACD_FechaHoraServer
    {
        public string Selecciona_FechaHoraServer()
        {
            string FecHora;
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            SqlCommand cmd = new SqlCommand("sp_sel_fecha_hora_servidor", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cnx.Open();
                SqlDataReader rs = cmd.ExecuteReader();
                rs.Read();
                FecHora = Convert.ToString(rs["Fecha"]);
                cnx.Close();
                return FecHora;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}