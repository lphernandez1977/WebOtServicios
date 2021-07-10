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
    public class ACD_Tb_Empresas
    {
        ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();

        public DataSet Selecciona_ListaEmpresas()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_empresas", con))
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
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_Lista_OT_Empresas()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_ordenes_pendientes_empresa", con))
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
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                ds = null;
                return ds;
            }
        }

        public ENT_Tb_Empresas Selecciona_Empresas(double pRut) 
        {
            try
            {

                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_DatosEmpresa", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                        //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                        //de entidades...
                        cmd.Parameters.Add("@pRutEmp", SqlDbType.Float).Value = pRut;
                        //abrimos conexion
                        con.Open();

                        SqlDataReader dataReader = cmd.ExecuteReader();

                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        ENT_Tb_Empresas empresas = new ENT_Tb_Empresas();

                        ////Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            empresas.rut_empresa = Convert.ToInt32(dataReader["rut_empresa"]);
                            empresas.nom_empresa = dataReader["nom_empresa"].ToString();
                            empresas.dv = Convert.ToChar(dataReader["dv"]);
                            empresas.contacto_empresa = dataReader["contacto_empresa"].ToString();
                        }
                        return empresas;
                    }
                }
                //se define que si no hay datos envia null
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }                
        }

        public DataSet Selecciona_Lista_OT_EmpresasMant()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_ordenes_pendientes_empresa_MantOt", con))
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
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
                ds = null;
                return ds;
            }
        }

        public string Inserta_NuevaEmpresa(ENT_Tb_Empresas _oEmpresa)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_ins_NuevaEmpresa", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = _oEmpresa.rut_empresa;
                cmd.Parameters.Add("@pNomEmp", System.Data.SqlDbType.Text, 255).Value = _oEmpresa.nom_empresa;
               
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

        public string Actualiza_Empresas(ENT_Tb_Empresas _oEmpresa)
        {
            //int exe = 0;
            //try
            //{
            //    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            //    SqlCommand cmd = new SqlCommand("sp_actualiza_Empresa", cnx);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = _oEmpresa.rut_empresa;
            //    cmd.Parameters.Add("@pNomEmp", SqlDbType.Text, 50).Value = _oEmpresa.nom_empresa;
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
                SqlCommand cmd = new SqlCommand("sp_actualiza_Empresa", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = _oEmpresa.rut_empresa;
                cmd.Parameters.Add("@pNomEmp", System.Data.SqlDbType.Text, 255).Value = _oEmpresa.nom_empresa;

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

        public string Actualiza_EstadoEmpresas(ENT_Tb_Empresas _oEmpresa)
        {
            //int exe = 0;
            //try
            //{
            //    SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            //    SqlCommand cmd = new SqlCommand("sp_actualiza_EmpresaEstado", cnx);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = _oEmpresa.rut_empresa;
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
                SqlCommand cmd = new SqlCommand("sp_actualiza_EmpresaEstado", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = _oEmpresa.rut_empresa;

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