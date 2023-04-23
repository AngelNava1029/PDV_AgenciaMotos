using CRUD.BD;
using CRUD.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Objects
{
    public class MySql : CRUDs_BD
    {
        
        MySqlConnection con;
        MySqlCommand commando;
        MySqlDataReader dr,dr1;

        public MySql(string host, string us, string pwd, string bd, string puerto = "3306") : base()
        {
            
            this.connectionString = $"Server={host};Port={puerto};Database={bd};Uid={us};Pwd={pwd};";
            con = new MySqlConnection(connectionString);

        }

        public override bool insertar(string tabla, List<string> campos, List<ValoresAInsertar> valores)
        {
            
            bool resultado = false;
            
            try
            {
               
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                
                string camposConcat = "";
                foreach (var campo in campos)
                {
                    camposConcat += campo + ",";
                }
                
                camposConcat = camposConcat.Remove(camposConcat.Length - 1);
                string valsConcat = "";
                
                foreach (ValoresAInsertar valor in valores)
                {

                    if (valor.llevaApostrofes) 
                    {
                        valsConcat += "'" + valor + "',";
                    }
                    else
                    {
                        valsConcat += valor + ",";
                    }
                }
                valsConcat = valsConcat.Remove(valsConcat.Length - 1);
                
                commando = new MySqlCommand($"INSERT INTO {tabla} ({camposConcat}) VALUES({valsConcat})");
               
                commando.Connection = con;
               
                int res = commando.ExecuteNonQuery();
                
                if (res == 1)
                    resultado = true;
                else
                {
                    resultado = false;
                    this.msgError = "NO SE REGISTRÓ EL NUEVO RENGLÓN";
                }
            }
            catch (MySqlException mex)
            {
                this.msgError = "No se pudo insertar el nuevo registro, por que no se conectó a la BD. " + mex.Message;
            }
            catch (Exception ex)
            {
                
                this.msgError = "No se pudo insertar el nuevo registro, por error general de windows. " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
           
            return resultado;
        }

        public override bool modificar(string tabla, List<string> campos, List<ValoresAInsertar> valores, int id)
        {
            bool resultado = false;
            try
            {
                
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                string camposConcat = "";
               
                for (int i = 0; i < campos.Count; i++)
                {
                    
                    camposConcat += campos[i] + "=" + (valores[i].llevaApostrofes ? "'" + valores[i].valor + "'," : valores[i].valor + ",");
                    
                }
                camposConcat = camposConcat.Remove(camposConcat.Length - 1);

                commando = new MySqlCommand($"UPDATE {tabla} SET {camposConcat} WHERE id={id}");


                commando.Connection = con;
                int res = commando.ExecuteNonQuery();
                if (res == 1)
                    resultado = true;
                else
                    resultado = false;

            }
            catch (MySqlException mex)
            {
                this.msgError = "No se pudo moddificar el registro por problema de conexión. " + mex.Message;

            }
            catch (Exception ex)
            {
                this.msgError = "No se pudo modificar el registro por problema de windows. " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return resultado;
        }


        public override bool borrar(string tabla, int id)
        {
            bool resultado = false;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                commando = new MySqlCommand($"DELETE FROM {tabla} WHERE id={id}");
                commando.Connection = con;
                int res = commando.ExecuteNonQuery();
                if (res == 1)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (MySqlException mex)
            {
                this.msgError = "NO se pudo borrar el registro, por error de BD. " + mex.Message;
            }
            catch (Exception ex)
            {
                this.msgError = "NO se pudo borrar el registro. " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return resultado;

        }

        public override List<object[]> consulta(string tabla)
        {
            List<object[]> resultado = new List<object[]>();
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                commando = new MySqlCommand($"SELECT * FROM {tabla}");
                commando.Connection = con;
                dr = commando.ExecuteReader();
                
                if (dr.HasRows)
                {
                    
                    while (dr.Read())
                    {
                        object[] registro = new object[dr.FieldCount];
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            registro[i] = dr.GetValue(i);
                        }
                        
                        resultado.Add(registro);
                    }
                   
                }
                else
                {
                    this.msgError = $" 3 No existen registros en la tabla {tabla}.";
                    
                    resultado = new List<object[]>(); 
                }
            }
            catch (MySqlException mex)
            {
                this.msgError = "No se pudo hacer la consulta en el servidor de BD. " + mex.Message;
            }
            catch (Exception ex)
            {
                this.msgError = "No se pudo hacer la consulta por error de windows. " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return resultado;
        }

        public override List<object[]> consulta(string tabla, string criterioBusqueda)
        {
            List<object[]> resultado = new List<object[]>();

            try
            {

                if (con.State == System.Data.ConnectionState.Closed) con.Open();

                commando = new MySqlCommand($"SELECT * FROM {tabla} WHERE {criterioBusqueda}",con);
                commando.Connection = con;
                dr = commando.ExecuteReader();
                
                if (dr.HasRows)
                {                    
                    while (dr.Read())
                    {
                                                
                        object[] registro = new object[dr.FieldCount];
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            registro[i] = dr.GetValue(i);
                        }
                        
                        resultado.Add(registro);
                    }
                    
                }
                else
                {
                    this.msgError = $"No existen registros en la tabla {tabla}.";
                    
                    resultado = new List<object[]>(); 
                }
            }
            catch (MySqlException mex)
            {
                this.msgError = "No se pudo hacer la consulta en el servidor de BD. " + mex.Message;
            }
            catch (Exception ex)
            {
                this.msgError = "5 No se pudo hacer la consulta por error de windows. " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return resultado;
        }
    }
}

