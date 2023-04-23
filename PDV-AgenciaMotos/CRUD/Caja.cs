using CRUD.BD;
using CRUD.Modelo;
using CRUD.Objects;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace CRUD
{
    public partial class Caja : Form
    {
        private Commun mCommun;
        private ProductoConsultas mProductoConsultas;
        private VentaConsultas mVentaConsultas;
        private Producto mProducto;
        private Venta mVenta;
        private VentaDetalle mVentaDetalle;
        private List<Producto> mProductos;
        private List<Venta> mVentas;
        private List<VentaDetalle> mVentaDetalles;
        public float monto;
        public float subtotal;
        public float cantidad;



        public Caja()
        {
            InitializeComponent();
            mCommun = new Commun();
            mProductoConsultas = new ProductoConsultas();
            mVentaConsultas = new VentaConsultas();
            mProducto = new Producto();
            mProductos = new List<Producto>();
            mVenta = new Venta();
            mVentas = new List<Venta>();
            mVentaDetalle = new VentaDetalle();
            mVentaDetalles = new List<VentaDetalle>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarProductosCaja(txtId.Text.Trim());
        }

        private void CargarProductosCaja(string filtro = "")
        {

 
            mProductos.Clear();
            mProductos = mProductoConsultas.consultarProductosCaja(filtro);

            for (int i = 0; i < mProductos.Count(); i++)
            {
                txtNombre.Text = mProductos[i].nombre.ToString();
                txtPrecio.Text = mProductos[i].precio.ToString();
                txtCantidad.Text = "1";

                

            }
        }


        



        private void button2_Click(object sender, EventArgs e)
        {

            //CargarDatosProducto();


            int monto = Int32.Parse(txtPrecio.Text) * Int32.Parse(txtCantidad.Text);

            dataGridView1.Rows.Add(txtId.Text, txtNombre.Text, txtPrecio.Text, txtCantidad.Text, monto);


            subtotal = subtotal + monto;

            txtsubtotal.Text = subtotal.ToString();
            
            





            float total = float.Parse(txtsubtotal.Text) * .16f;

            



            txttotal.Text = subtotal.ToString();
            txtiva.Text = (subtotal * .16).ToString();
            txtsubtotal.Text = (subtotal - subtotal * .16).ToString();
            mVentaDetalle.subtotal = (float)Convert.ToDouble(txtsubtotal.Text);
            mVentaDetalle.Monto = (float)Convert.ToDouble(txttotal.Text);
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

        }

       /* private void Caja_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("codigo", "Codigo");
            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("precio", "Precio");
            dataGridView1.Columns.Add("cantidad", "Cantidad");
            dataGridView1.Columns.Add("monto", "Monto");
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            mVenta.id = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
            string valor="";
            for (int fila = 0; fila < dataGridView1.Rows.Count; fila++)
            {
                for (int col = 0; col < dataGridView1.Rows[fila].Cells.Count; col++)
                {
                     valor = dataGridView1.Rows[fila].Cells[col].Value.ToString();
                   
                    if (col == 2)
                    {
                        mVenta.nombre = valor;
                       // mVenta.id = Convert.ToInt32(valor);
                    }
                    if (col == 3)
                    {
                        mVenta.cantidad = valor;
                        //MessageBox.Show(valor);
                       
                    }
                    if (col == 4)
                    {
                        mVenta.subtotal = double.Parse(valor);
                        //MessageBox.Show(valor);
                        
                    }
                    



                }

                   CargarVentasCaja();
                //MessageBox.Show(valor);

               

                if (mVentaConsultas.agregarVenta(mVenta))
                {
                    MessageBox.Show("Venta agregada");
                    //CargarProductos();
                    //LimpiarDatosProducto();
                }
                else
                    MessageBox.Show("Error al agregar el producto");


            }

                if (mVentaConsultas.agregarVentaDet(mVentaDetalle,mVenta))
              {
                MessageBox.Show("Venta agregada");
                //CargarProductos();
                //LimpiarDatosProducto();
           
                 }
                 
            else
                MessageBox.Show("Error al agregar el venta");
                

        
        dataGridView1.Rows.Clear();

            
        }





        private void CargarVentasCaja()
        {
            /*  MessageBox.Show(txtId.Text + " trono");
              mVenta.codigo = int.Parse(txtId.Text.Trim());
              mVenta.precio = float.Parse(txtPrecio.Text.Trim());
              mVenta.cantidad = int.Parse(txtCantidad.Text.Trim());
              float m = int.Parse(txtCantidad.Text) * float.Parse(txtPrecio.Text);
              mVenta.monto = m;
            */
           
            //MessageBox.Show(dataGridView1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Menus menus = new Menus();

            menus.Show();
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtiva_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
