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
    public class ACD_Tb_Equipos
    {
        ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();

        public DataSet Selecciona_ListaEquipos(double pRutEmpresa, int pCodEqui)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_equipos_empresa", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRutEmpresa;
                        cmd.Parameters.Add("@pCodEqui", System.Data.SqlDbType.Int).Value = pCodEqui;
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
                //devolver el conjunto de datos
                return ds;
            }            
        }

        public DataSet Selecciona_OrdenesxEquipos(double pRutEmpresa, float pNumOt, int pEstado, string pFecIni, string pFecTer)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_ordenesxequipos", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRutEmpresa;
                        cmd.Parameters.Add("@pNumOt", System.Data.SqlDbType.Float).Value = pNumOt;
                        cmd.Parameters.Add("@pEstado", System.Data.SqlDbType.Int).Value = pEstado;
                        cmd.Parameters.Add("@pFecIni", System.Data.SqlDbType.VarChar,10).Value = pFecIni;
                        cmd.Parameters.Add("@pFecTer", System.Data.SqlDbType.VarChar, 10).Value = pFecTer;
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
                //devolver el conjunto de datos
                return ds;
            }

        }

        public DataSet Selecciona_OrdenesxEquiposP(double pRutEmpresa)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_ordenesxequiposP", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRutEmpresa;
                        //cmd.Parameters.Add("@pNumOt", System.Data.SqlDbType.Float).Value = pNumOt;
                        //cmd.Parameters.Add("@pEstado", System.Data.SqlDbType.Int).Value = pEstado;
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
                //devolver el conjunto de datos
                return ds;
            }

        }

        public DataSet Selecciona_ListaDeActividades(double pRutEmpresa, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_DetalleActividadOT", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRutEmpresa;
                        cmd.Parameters.Add("@pNumOt", System.Data.SqlDbType.Float).Value = pNumOt;
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
                //devolver el conjunto de datos
                return ds;
            }

        }

        public ENT_Tb_Equipos Selecciona_EquiposOT(double pRutEmp, double pNumOt)
        {
            ENT_Tb_Equipos _oDetalleEquipo = new ENT_Tb_Equipos();

            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            SqlCommand cmd = new SqlCommand("sp_sel_DetalleEquipoOtPDF", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pRutEmp", SqlDbType.Float).Value = pRutEmp;
            cmd.Parameters.Add("@pNumOT", SqlDbType.NVarChar).Value = pNumOt;

            try
            {
                cnx.Open();
                SqlDataReader rs = cmd.ExecuteReader();
                rs.Read();

                _oDetalleEquipo.cod_equipos = Convert.ToInt32(rs["cod_equipos"]);
                _oDetalleEquipo.nom_corto = Convert.ToString(rs["nom_corto"]);
                _oDetalleEquipo.nom_equipos = Convert.ToString(rs["nom_equipos"]);


                cnx.Close();
                return _oDetalleEquipo;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string Inserta_NuevaEquipo(ENT_Tb_Equipos _ent_equipos, int dispo)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_ins_nuevo_equipo", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = _ent_equipos.rut_empresa;
                cmd.Parameters.Add("@pnom_corto", System.Data.SqlDbType.VarChar, 100).Value = _ent_equipos.nom_corto;
                cmd.Parameters.Add("@pnom_equipos", System.Data.SqlDbType.VarChar, 100).Value = _ent_equipos.nom_equipos;
                cmd.Parameters.Add("@pCod_Nom_Dispo", System.Data.SqlDbType.Int).Value = dispo;
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
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje2; }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public DataSet Selecciona_ListaEquiposEmpresa(double pRutEmpresa)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_equipos_empresa_2", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = pRutEmpresa;
                        //cmd.Parameters.Add("@pCodEqui", System.Data.SqlDbType.Int).Value = pCodEqui;
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
                //devolver el conjunto de datos
                return ds;
            }
        }

        public string Elimina_Equipo(ENT_Tb_Equipos _ent_equipos)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_elimina_equipo", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = _ent_equipos.rut_empresa;
                cmd.Parameters.Add("@pcod_equipos", System.Data.SqlDbType.VarChar, 100).Value = _ent_equipos.cod_equipos;
                
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
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje2; }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public string Editar_Equipo(ENT_Tb_Equipos _ent_equipos, int dispo)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_editar_equipos", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = _ent_equipos.rut_empresa;
                cmd.Parameters.Add("@pnom_corto", System.Data.SqlDbType.VarChar, 100).Value = _ent_equipos.nom_corto;
                cmd.Parameters.Add("@pnom_equipos", System.Data.SqlDbType.VarChar, 100).Value = _ent_equipos.nom_equipos;
                cmd.Parameters.Add("@pCod_equipo", System.Data.SqlDbType.Int).Value = _ent_equipos.cod_equipos;                
                cmd.Parameters.Add("@pCod_Nom_Dispo", System.Data.SqlDbType.Int).Value = dispo;
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
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje2; }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}