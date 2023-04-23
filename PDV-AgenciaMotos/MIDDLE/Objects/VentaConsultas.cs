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
    internal class VentaConsultas
    {
        private ConexionMySql mConexion;
        private List<Venta> mVentas;
        private List<VentaDetalle> mVentaDetalles;


        public VentaConsultas()
        {
            mConexion = new ConexionMySql();
            mVentas = new List<Venta>();
            mVentaDetalles = new List<VentaDetalle>();


        }

        public bool agregarVenta(Venta mVenta)
        {
            string INSERT = "INSERT INTO ventas(id,subtotal,fecha,cantidad)" + " values (@id,@subtotal,CURRENT_DATE,@cantidad);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());

            mCommand.Parameters.Add(new MySqlParameter("@id", mVenta.id));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mVenta.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@subtotal", mVenta.subtotal));
            mCommand.Parameters.Add(new MySqlParameter("@cantidad", mVenta.cantidad));
            
            return mCommand.ExecuteNonQuery() > 0;
        }

        public bool agregarVentaDet(VentaDetalle mVentaDetalle,Venta mVenta)
        {
            string INSERT = "INSERT INTO `ventasdetalles`(`ProductoId`, `monto`) " + " values (@id,@monto);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());

            mCommand.Parameters.Add(new MySqlParameter("@ProductoId", mVentaDetalle.ProductoId));
            mCommand.Parameters.Add(new MySqlParameter("@id", mVenta.id));
            mCommand.Parameters.Add(new MySqlParameter("@Monto", mVentaDetalle.Monto)) ;
           
            return mCommand.ExecuteNonQuery() > 0;
        }

        public List<VentaDetalle> consultarReporteVentas(string filtro)
        {
            string CONSULTA = "SELECT * FROM ventasdetalles ";

            MySqlDataReader mReader = null;
            VentaDetalle mVentaDetalle;
            try
            {
                if (filtro != "")
                {
                    CONSULTA += " WHERE " +
                        "IdVenta =  '" + filtro + "';";
                }

                MySqlCommand mCommand = new MySqlCommand(CONSULTA);
                mCommand.Connection = mConexion.getConexion();
                mReader = mCommand.ExecuteReader();

                while (mReader.Read())
                {
                    mVentaDetalle = new VentaDetalle();
                    mVentaDetalle.IdVenta = mReader.GetInt16("IdVenta");
                    mVentaDetalle.ProductoId = mReader.GetInt16("ProductoId");
                    mVentaDetalle.Monto = mReader.GetFloat("Monto");
                    //mVentaDetalle.fecha = mReader.GetString("fecha");

                    mVentaDetalles.Add(mVentaDetalle);
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

            return mVentaDetalles;
        }
        public List<Venta> consultarReporteVentasfecha(string filtro2)
        {
            string consulta = "SELECT * FROM ventas";
            List<Venta> ventas = new List<Venta>();

            if (!string.IsNullOrEmpty(filtro2))
            {
                consulta += " WHERE fecha = '" + filtro2 + "'";
            }

            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, mConexion.getConexion());
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Venta venta = new Venta();
                        venta.id = reader.GetInt16("id");
                        venta.cantidad = reader.GetString("cantidad");
                        venta.subtotal = reader.GetFloat("subtotal");
                        venta.fecha = reader.GetString("fecha");
                        ventas.Add(venta);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mConexion.closeConexion();
            }

            return ventas;
        }
        /* public bool agregarVentaDetalle(VentaDetalle mVentaDetalle)
         {
             string INSERT = "INSERT INTO ventasdetalles(IdVenta , ProductoId , Cantidad, Precio)" + "@IdVenta , @ProductoId , @Cantidad , @Precio);";

             MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());
             mCommand.Parameters.Add(new MySqlParameter("@IdVentas", mVentaDetalle.IdVenta));
             mCommand.Parameters.Add(new MySqlParameter("@ProductoId", mVentaDetalle.ProductoId));
             mCommand.Parameters.Add(new MySqlParameter("@Cantidad", mVentaDetalle.Cantidad));
             mCommand.Parameters.Add(new MySqlParameter("@Cantidad", mVentaDetalle.Precio));

             return mCommand.ExecuteNonQuery() > 0;
         } */


    }
}
