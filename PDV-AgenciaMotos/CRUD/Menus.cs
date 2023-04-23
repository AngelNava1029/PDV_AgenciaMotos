using CRUD.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Menus : Form
    {
        public Menus()
        {
            InitializeComponent();
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Caja caja = new Caja();

            caja.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Usuarios usuarios = new Usuarios();

            usuarios.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            FRMProductos productos = new FRMProductos();

            productos.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Usuarios usuarios = new Usuarios();

            usuarios.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            FRMProductos productos = new FRMProductos();

            productos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Caja caja = new Caja();

            caja.Show();
        }

        private void Menus_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Ventas v = new Ventas();

            v.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
