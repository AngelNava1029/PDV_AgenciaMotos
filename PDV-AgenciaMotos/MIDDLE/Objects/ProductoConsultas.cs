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
    internal class ProductoConsultas
    { 
        private ConexionMySql mConexion;
        private List<Producto> mProductos;
        public ProductoConsultas()
        {
            mConexion = new ConexionMySql();
            mProductos = new List<Producto>();

        }

        public bool agregarProducto(Producto mProducto)
        {
            string INSERT = "INSERT INTO producto (nombre, precio, cantidad, tipo, marca, serie, color, imagen)" + " values (@nombre, @precio, @cantidad, @tipo, @marca, @serie ,@color, @imagen);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mProducto.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@precio", mProducto.precio));
            mCommand.Parameters.Add(new MySqlParameter("@cantidad", mProducto.cantidad));
            mCommand.Parameters.Add(new MySqlParameter("@tipo", mProducto.tipo));
            mCommand.Parameters.Add(new MySqlParameter("@marca", mProducto.marca));
            mCommand.Parameters.Add(new MySqlParameter("@serie", mProducto.serie));
            mCommand.Parameters.Add(new MySqlParameter("@color", mProducto.color));
            mCommand.Parameters.Add(new MySqlParameter("@imagen", mProducto.imagen));

            return mCommand.ExecuteNonQuery() > 0;
        }





            public bool modificarProducto(Producto mProducto)
        {
            string UPDATE = " UPDATE producto " +
                "SET nombre = @nombre, " +
                "precio = @precio, " +
                "cantidad = @cantidad, " +
                "tipo = @tipo, " +
                "marca = @marca, " +
                "serie = @serie, " +
                "color = @color, " +
                "imagen = @imagen " +
                "WHERE id = @id";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mProducto.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@precio", mProducto.precio));
            mCommand.Parameters.Add(new MySqlParameter("@cantidad", mProducto.cantidad));
            mCommand.Parameters.Add(new MySqlParameter("@tipo", mProducto.tipo));
            mCommand.Parameters.Add(new MySqlParameter("@marca", mProducto.marca));
            mCommand.Parameters.Add(new MySqlParameter("@serie", mProducto.serie));
            mCommand.Parameters.Add(new MySqlParameter("@color", mProducto.color));
            mCommand.Parameters.Add(new MySqlParameter("@imagen", mProducto.imagen));
            mCommand.Parameters.Add(new MySqlParameter("@id", mProducto.id));

            return mCommand.ExecuteNonQuery() > 0;
        }




        public bool eliminarProducto(Producto mProducto)
        {
            string DELETE = " DELETE FROM producto WHERE id=@id";
            MySqlCommand mCommand = new MySqlCommand(DELETE, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@id", mProducto.id));
            return mCommand.ExecuteNonQuery() > 0;
        }





        public List<Producto> consultarProductos(string filtro)
        {
            string CONSULTA = "SELECT * FROM producto";

            MySqlDataReader mReader = null;
            Producto mProducto;
            try
            {
                if (filtro != "")
                {
                    CONSULTA += " WHERE " +
                        "id LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "precio LIKE '%" + filtro + "%' OR " +
                        "cantidad LIKE '%" + filtro + "%';";
                }

                MySqlCommand mCommand = new MySqlCommand(CONSULTA);
                mCommand.Connection = mConexion.getConexion();
                mReader = mCommand.ExecuteReader();

                while (mReader.Read())
                {
                    mProducto = new Producto();
                    mProducto.id = mReader.GetInt16("id");
                    mProducto.nombre = mReader.GetString("nombre");
                    mProducto.precio = mReader.GetInt32("precio");
                    mProducto.cantidad = mReader.GetInt16("cantidad");
                    mProducto.tipo = mReader.GetString("tipo");
                    mProducto.marca = mReader.GetString("marca");
                    mProducto.serie = mReader.GetString("serie");
                    mProducto.color = mReader.GetString("color");
                    mProducto.imagen = (byte[]) mReader.GetValue(4);
                    mProductos.Add(mProducto);
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

            return mProductos;
        }

        



        public List<Producto> consultarProductosCaja(string filtro)
        {
            string CONSULTA = "SELECT * FROM producto";

            MySqlDataReader mReader = null;
            Producto mProducto;
            try
            {
                if (filtro != "")
                {
                    CONSULTA += " WHERE " +
                        "id LIKE '%" + filtro + "%';";
                }

                MySqlCommand mCommand = new MySqlCommand(CONSULTA);
                mCommand.Connection = mConexion.getConexion();
                mReader = mCommand.ExecuteReader();

                while (mReader.Read())
                {
                    mProducto = new Producto();
                    mProducto.id = mReader.GetInt16("id");
                    mProducto.nombre = mReader.GetString("nombre");
                    mProducto.precio = mReader.GetInt32("precio");
                    mProducto.imagen = (byte[])mReader.GetValue(4);
                    mProductos.Add(mProducto);
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

            return mProductos;
        }


    }
}
