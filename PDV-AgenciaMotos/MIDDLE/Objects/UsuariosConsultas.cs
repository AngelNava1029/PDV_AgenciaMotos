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
    internal class UsuariosConsultas
    {
        private ConexionMySql mConexion;
        private Usuario mUsuario;
        private List<Usuario> mUsuarios;

        public UsuariosConsultas()
        {
            mConexion = new ConexionMySql();
            mUsuarios = new List<Usuario>();
        }

        public bool agregarUsuario(Usuario mUsuarios)
        {
            string INSERT = "INSERT INTO usuarios (nombre, usuario, contrasena, imagen)" + " values (@nombre, @usuario, @contrasena, @imagen);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mUsuarios.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@usuario", mUsuarios.usuario));
            mCommand.Parameters.Add(new MySqlParameter("@contrasena", mUsuarios.contrasena));
            mCommand.Parameters.Add(new MySqlParameter("@imagen", mUsuarios.imagen));

            return mCommand.ExecuteNonQuery() > 0;
        }

        public bool modificarUsuario(Usuario mUsuario)
        {
            string UPDATE = " UPDATE usuarios " +
                "SET nombre = @nombre, " +
                "usuario = @usuario, " +
                "contrasena = @contrasena, " +
                "imagen = @imagen " +
                "WHERE id = @id";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mUsuario.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@usuario", mUsuario.usuario));
            mCommand.Parameters.Add(new MySqlParameter("@contrasena", mUsuario.contrasena));
            mCommand.Parameters.Add(new MySqlParameter("@imagen", mUsuario.imagen));
            mCommand.Parameters.Add(new MySqlParameter("@id", mUsuario.id));

            return mCommand.ExecuteNonQuery() > 0;
        }

        public bool eliminarUsuario(int id)
        {
            string DELETE = " DELETE FROM usuarios WHERE id=@id";
            MySqlCommand mCommand = new MySqlCommand(DELETE, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@id", id));
            return mCommand.ExecuteNonQuery() > 0;
        }

        public List<Usuario> consultarUser(string filtro)
        {
            string CONSULTA = "SELECT * FROM usuarios";

            MySqlDataReader mReader = null;
            Usuario mUsuario;
            try
            {
                if (filtro != "")
                {
                    CONSULTA += " WHERE " +
                        "usuario = '" + filtro + "';";
                }

                MySqlCommand mCommand = new MySqlCommand(CONSULTA);
                mCommand.Connection = mConexion.getConexion();
                mReader = mCommand.ExecuteReader();

                while (mReader.Read())
                {
                    mUsuario = new Usuario();
                    mUsuario.usuario = mReader.GetString("usuario");
                    mUsuario.contrasena = mReader.GetString("contrasena");
                    mUsuarios.Add(mUsuario);
                }
                mReader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mConexion.closeConexion();
            }

            return mUsuarios;
        }



        public List<Usuario> consultarUsuarios(string filtro)
        {
            string CONSULTA = "SELECT * FROM usuarios";

            MySqlDataReader mReader = null;
            Usuario mUsuario;
            try
            {
                if (filtro != "")
                {
                    CONSULTA += " WHERE " +
                        "id LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "usuario LIKE '%" + filtro + "%';";
                }

                MySqlCommand mCommand = new MySqlCommand(CONSULTA);
                mCommand.Connection = mConexion.getConexion();
                mReader = mCommand.ExecuteReader();

                while (mReader.Read())
                {
                    mUsuario = new Usuario();
                    
                    mUsuario.nombre = mReader.GetString("nombre");
                    mUsuario.usuario = mReader.GetString("usuario");
                    mUsuario.contrasena = mReader.GetString("contrasena");
                    mUsuario.imagen = (byte[])mReader.GetValue(3);
                    mUsuario.id = mReader.GetInt32("id");
                    mUsuarios.Add(mUsuario);
                }
                mReader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mConexion.closeConexion();
            }

            return mUsuarios;
        }
    }
}
