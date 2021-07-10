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
    public class ACD_Tb_Actividades
    {
        public ENT_Tb_Actividades Selecciona_ActividadDesarrollo(double pRutEmpresa, double pNumOt, int pCodAct)
        {
            {
                try
                {

                    //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                    {
                        //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                        using (SqlCommand cmd = new SqlCommand("sp_sel_ActividadEnDesarrollo", con))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                            //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                            //de entidades...
                            cmd.Parameters.Add("@pRutEmp", SqlDbType.Float).Value = pRutEmpresa;
                            cmd.Parameters.Add("@pNumOt", SqlDbType.Float).Value = pNumOt;
                            cmd.Parameters.Add("@pCodAct", SqlDbType.Int).Value = pCodAct;
                            //abrimos conexion
                            con.Open();

                            SqlDataReader dataReader = cmd.ExecuteReader();

                            //Instanciamos al objeto Eproducto para llenar sus propiedades
                            ENT_Tb_Actividades actividades = new ENT_Tb_Actividades();

                            ////Preguntamos si el DataReader fue devuelto con datos
                            while (dataReader.Read())
                            {
                                actividades.Rut_Empresa = Convert.ToInt32(dataReader["rut_empresa"]);
                                actividades.NumOt = Convert.ToInt32(dataReader["num_ot"]);
                                actividades.Cod_Act = Convert.ToInt32(dataReader["Cod_Act"]);
                                actividades.Componente = dataReader["Componente"].ToString();
                                actividades.Actividad = dataReader["Actividad"].ToString();
                                actividades.ActRealizada = dataReader["Act_Realizada"].ToString();
                            }
                            return actividades;
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
        }

        public string Actualiza_EstadoActividadOt(ENT_Tb_Actividades oActividades)
        {
            int exe = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_actualiza_EstadoActividadOT", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = oActividades.Rut_Empresa;
                cmd.Parameters.Add("@pnum_ot", SqlDbType.Float).Value = oActividades.NumOt;
                cmd.Parameters.Add("@pCod_Act", SqlDbType.Float).Value = oActividades.Cod_Act;
                cmd.Parameters.Add("@pObserv", SqlDbType.VarChar,255).Value = oActividades.ObservacionAct;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                cnx.Close();

                if (exe >= 1)
                {
                    string func = "1";
                    return func;
                }
                else
                {
                    string func = "0";
                    return func;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Valida_EstadoActividadOt(ENT_Tb_Actividades oActividades)
        {
            string Estado = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_sel_EstadoActividad", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = oActividades.Rut_Empresa;
                cmd.Parameters.Add("@pnum_ot", SqlDbType.Float).Value = oActividades.NumOt;
                cmd.Parameters.Add("@pCod_Act", SqlDbType.Float).Value = oActividades.Cod_Act;
                cnx.Open();
                SqlDataReader rs = cmd.ExecuteReader();
                rs.Read();
                Estado = Convert.ToString(rs["Act_Realizada"]);
                cnx.Close();
                return Estado;
            }
            catch (Exception ex)
            {
                return Estado;
            }
        }

        public string Inserta_NuevaActividad(ENT_Tb_Actividades oActividades)
        {
            int exe = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_inserta_actividad", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pTipo_Equipo", System.Data.SqlDbType.Int).Value = oActividades.Tipo_Equipo;
                cmd.Parameters.Add("@pComponente", SqlDbType.VarChar,250).Value = oActividades.Componente;
                cmd.Parameters.Add("@pActividad", SqlDbType.VarChar,250).Value = oActividades.Actividad;
                cmd.Parameters.Add("@pRut_Empresa", SqlDbType.Float).Value = oActividades.Rut_Empresa;
                cmd.Parameters.Add("@pPeriodo_Actividad", SqlDbType.Int).Value = oActividades.Periodo_Actividad;
                cmd.Parameters.Add("@pNom_Disp", SqlDbType.VarChar, 255).Value = oActividades.Nom_Disp;
                cmd.Parameters.Add("@Cod_Nom_Dispo", SqlDbType.Int).Value = oActividades.Cod_Nom_Dispo;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                cnx.Close();

                if (exe >= 1)
                {
                    string func = "1";
                    return func;
                }
                else
                {
                    string func = "0";
                    return func;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


    }
}