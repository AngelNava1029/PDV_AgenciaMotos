using CRUD.BD;
using CRUD.Modelo;
using CRUD.Objects;
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

namespace CRUD
{
    public partial class Ventas : Form
    {

        private Commun mCommun;
        private VentaConsultas mVentaConsultas;
        private Venta mVenta;
        private ConexionMySql mConexion;
        private List<Venta> mVentas;
        private VentaDetalle mVentaDetalle;
        private List<VentaDetalle> mVentaDetalles;
        

        public Ventas()
        {
            InitializeComponent();

            mConexion = new ConexionMySql();
            mCommun = new Commun();
            mVentaConsultas = new VentaConsultas();
            mVenta = new Venta();
            mVentas = new List<Venta>();
            mVentaDetalle = new VentaDetalle();
            mVentaDetalles = new List<VentaDetalle>();



        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            string f1 = textBox1.Text;
            //string f2 = textBox2.Text;
            //string f2 = Convert.ToDateTime(dateTimePicker2.Value).ToString("yyyy-MM-dd");
            CargarReporteVentas(f1);
        }

        private void CargarReporteVentas(string f1)
        {

            dGventadetalle.Rows.Clear();
            dGventadetalle.Refresh();
            mVentaDetalles.Clear();
            mVentaDetalles = mVentaConsultas.consultarReporteVentas(f1);
            
            for (int i = 0; i < mVentaDetalles.Count(); i++)
            {

                dGventadetalle.RowTemplate.Height = Commun.ROW_HEIGTH;
                dGventadetalle.Rows.Add(
                    mVentaDetalles[i].IdVenta,
                    mVentaDetalles[i].ProductoId,
                    mVentaDetalles[i].Monto);
                    
           
            }

        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Menus menus = new Menus();

            menus.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;

            // Asignar la fecha al TextBox con el formato deseado
            textBox2.Text = fechaSeleccionada.ToString("dd/MM/yyyy");
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string f2 = textBox2.Text;
            //string f2 = textBox2.Text;
            //string f2 = Convert.ToDateTime(dateTimePicker2.Value).ToString("yyyy-MM-dd");
            CargarReportefecha(f2);
        }
        private void CargarReportefecha(string f2)
        {

            //dGfecha.Rows.Clear();
            dGfecha.Refresh();

            mVentas = mVentaConsultas.consultarReporteVentasfecha(f2);
            dGfecha.DataSource = mVentas;
            for (int i = 0; i < mVentaDetalles.Count(); i++)
            {

                dGventadetalle.RowTemplate.Height = Commun.ROW_HEIGTH;
                dGventadetalle.Rows.Add(
                    mVentas[i].id,
                    mVentas[i].subtotal,
                    mVentas[i].cantidad);


            }

        }
    }
}
