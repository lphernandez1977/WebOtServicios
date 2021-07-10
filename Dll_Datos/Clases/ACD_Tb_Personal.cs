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
    public class ACD_Tb_Personal
    {
        ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();

        public string Selecciona_Usuario(ENT_Tb_Personal _ent_tb_personal)
        {
            string Resultado = string.Empty;
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            SqlCommand cmd = new SqlCommand("sp_sel_usuario", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pRut", SqlDbType.Float).Value = _ent_tb_personal.rut_personal;
            cmd.Parameters.Add("@pPass",SqlDbType.NVarChar).Value =  _ent_tb_personal.contrasenia;
            
            try
            {
                cnx.Open();
                SqlDataReader rs = cmd.ExecuteReader();
                rs.Read();
                Resultado =  Convert.ToString(rs["valida"]);
                cnx.Close();
                return Resultado;
            }
            catch (Exception ex)
            {
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                return Resultado;
            }            
        }

        public ENT_Tb_Personal Selecciona_PerfilUsuario(ENT_Tb_Personal _ent_tb_personal)
        {
            ENT_Tb_Personal _Perfil_User = new ENT_Tb_Personal();

            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            SqlCommand cmd = new SqlCommand("sp_SeleccionaPerfilUser", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pRut", SqlDbType.Float).Value = _ent_tb_personal.rut_personal;
            cmd.Parameters.Add("@pPass", SqlDbType.NVarChar).Value = _ent_tb_personal.contrasenia;

            try
            {
                cnx.Open();
                SqlDataReader rs = cmd.ExecuteReader();
                rs.Read();

                _ent_tb_personal.rut_personal = Convert.ToInt32(rs["rut_personal"]);
                _ent_tb_personal.nom_empleado = Convert.ToString(rs["nom_empleado"]);
                _ent_tb_personal.ape_empleado = Convert.ToString(rs["ape_empleado"]);
                _ent_tb_personal.cargo = Convert.ToString(rs["cargo"]);

                cnx.Close();
                return _ent_tb_personal;
            }
            catch (Exception ex)
            {
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                return null;
            }
        }

        public string Actualiza_EstadoPersonal(ENT_Tb_Personal _ent_tb_personal)
        {
            //int exe = 0;
            //try
            //{
            //    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            //    SqlCommand cmd = new SqlCommand("sp_actualiza_EstadoFuncionario", cnx);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@pRut_fun", System.Data.SqlDbType.Float).Value = _ent_tb_personal.rut_personal;
            //    //cmd.Parameters.Add("@pDv", SqlDbType.Char, 1).Value = _ent_tb_personal.dv;
            //    //cmd.Parameters.Add("@pNom_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.nom_empleado;
            //    //cmd.Parameters.Add("@pApe_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.ape_empleado;
            //    //cmd.Parameters.Add("@pPass", SqlDbType.Text, 50).Value = _ent_tb_personal.contrasenia;
            //    //cmd.Parameters.Add("@pCod_Cargo", SqlDbType.Text, 50).Value = _ent_tb_personal.Cod_Cargo;
            //    cnx.Open();
            //    exe = cmd.ExecuteNonQuery();
            //    cnx.Close();
            //    cnx.Dispose();
            //    return exe;
            //}
            //catch (Exception ex)
            //{
            //    return exe;
            //}

            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_actualiza_EstadoFuncionario", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut_fun", System.Data.SqlDbType.Float).Value = _ent_tb_personal.rut_personal;
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMod_Err_Sp", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                mensaje1 = Convert.ToString(cmd.Parameters["@Pgi_Salida"].Value);
                mensaje2 = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                mensaje3 = Convert.ToString(cmd.Parameters["@pMod_Err_Sp"].Value);
                cnx.Close();
                cnx.Dispose();
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje3; }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public string Inserta_NuevoPersonal(ENT_Tb_Personal _ent_tb_personal)
        {
            //int exe = 0;
            //try
            //{
            //    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            //    SqlCommand cmd = new SqlCommand("sp_ins_NuevoFuncionarios", cnx);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@pRut_fun", System.Data.SqlDbType.Float).Value = _ent_tb_personal.rut_personal;
            //    cmd.Parameters.Add("@pDv", SqlDbType.Char, 1).Value = _ent_tb_personal.dv;
            //    cmd.Parameters.Add("@pNom_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.nom_empleado;
            //    cmd.Parameters.Add("@pApe_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.ape_empleado;
            //    cmd.Parameters.Add("@pPass", SqlDbType.Int).Value = _ent_tb_personal.contrasenia;
            //    cmd.Parameters.Add("@pCod_Cargo", SqlDbType.Int).Value = _ent_tb_personal.Cod_Cargo;
            //    cnx.Open();
            //    exe = cmd.ExecuteNonQuery();
            //    cnx.Close();
            //    cnx.Dispose();
            //    return exe;
            //}
            //catch (Exception ex)
            //{
            //    return exe;
            //}

            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_ins_NuevoFuncionarios", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut_fun", System.Data.SqlDbType.Float).Value = _ent_tb_personal.rut_personal;                
                cmd.Parameters.Add("@pNom_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.nom_empleado;
                cmd.Parameters.Add("@pApe_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.ape_empleado;
                cmd.Parameters.Add("@pPass", SqlDbType.Int).Value = _ent_tb_personal.contrasenia;
                cmd.Parameters.Add("@pCod_Cargo", SqlDbType.Int).Value = _ent_tb_personal.Cod_Cargo;

                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMod_Err_Sp", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                mensaje1 = Convert.ToString(cmd.Parameters["@Pgi_Salida"].Value);
                mensaje2 = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                mensaje3 = Convert.ToString(cmd.Parameters["@pMod_Err_Sp"].Value);
                cnx.Close();
                cnx.Dispose();
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje3; }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public DataSet Selecciona_ListaFuncionarios()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_ListaFuncionarios", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rut;
                        //abrimos conexion
                        con.Open();
                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);
                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Modifica_Personal(ENT_Tb_Personal _ent_tb_personal)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Mod_Funcionarios", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut_fun", System.Data.SqlDbType.Float).Value = _ent_tb_personal.rut_personal;
                cmd.Parameters.Add("@pNom_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.nom_empleado;
                cmd.Parameters.Add("@pApe_fun", SqlDbType.Text, 50).Value = _ent_tb_personal.ape_empleado;
                cmd.Parameters.Add("@pPass", SqlDbType.Int).Value = _ent_tb_personal.contrasenia;
                cmd.Parameters.Add("@pCod_Cargo", SqlDbType.Int).Value = _ent_tb_personal.Cod_Cargo;

                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMod_Err_Sp", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                mensaje1 = Convert.ToString(cmd.Parameters["@Pgi_Salida"].Value);
                mensaje2 = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                mensaje3 = Convert.ToString(cmd.Parameters["@pMod_Err_Sp"].Value);
                cnx.Close();
                cnx.Dispose();
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje3; }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}