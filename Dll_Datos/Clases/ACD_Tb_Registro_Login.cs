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
    public class ACD_Tb_Registro_Login
    {
        ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();
        int exe = 0;
        
        public bool Inserta_RegistroLoginUsuario(double pRut, DateTime pFechaReg)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_ins_login_usuario", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRut;
                cmd.Parameters.Add("@pFechaReg", System.Data.SqlDbType.DateTime).Value = pFechaReg;
                cmd.Parameters.Add("@pExecuto", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                _ent_Lista_Mensajes.MsjExepcion = Convert.ToString(cmd.Parameters["@pExecuto"].Value);
                _ent_Lista_Mensajes.MsjErrorSql = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                
                cnx.Close();
                cnx.Dispose();
                if (_ent_Lista_Mensajes.MsjExepcion == "Y") { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                return false;
            }
        }

        public bool Actualiza_FinRegistroLoginUsuario(double pRut, DateTime pFechaReg)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_upd_terminologin_usuario", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRut;
                cmd.Parameters.Add("@pFechaTer", System.Data.SqlDbType.DateTime).Value = pFechaReg;
                cmd.Parameters.Add("@pExecuto", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                _ent_Lista_Mensajes.MsjExepcion = Convert.ToString(cmd.Parameters["@pExecuto"].Value);
                _ent_Lista_Mensajes.MsjErrorSql = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);

                cnx.Close();
                cnx.Dispose();
                if (_ent_Lista_Mensajes.MsjExepcion == "Y") { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                return false;
            }

        }
    }
}