using CRUD.Modelo;
using CRUD.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FRMProductos : Form
    {
        private Commun mCommun;
        private ProductoConsultas mProductoConsultas;
        private Producto mProducto;
        private List<Producto> mProductos;

        public FRMProductos()
        {
            InitializeComponent();
            mCommun = new Commun();
            mProductoConsultas = new ProductoConsultas();
            mProducto = new Producto();
            mProductos = new List<Producto>();

            CargarProductos();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(txtBusqueda.Text.Trim());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
                return;

            CargarDatosProducto();

            if (mProductoConsultas.agregarProducto(mProducto))
            {
                MessageBox.Show("Producto agregado");
                CargarProductos();
                LimpiarDatosProducto();
            }
            else
                MessageBox.Show("Error al agregar el producto");

        }

        private bool datosCorrectos()
        {
            
            if (txtNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el nombre del producto");
                return false;
            }

            
            if (txtPrecio.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el precio del producto");
                return false;
            }

            if (!float.TryParse(txtPrecio.Text.Trim(), out float precio))
            {
                MessageBox.Show("Ingrese un precio correcto");
                return false;
            }

            
            if (txtCantidad.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese la cantidad");
                return false;
            }

            
            if (txtTipo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el tipo");
                return false;
            }

            
            if (txtMarca.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese la marca");
                return false;
            }

            
            if (txtSerie.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese la serie");
                return false;
            }

            
            if (txtColor.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el color");
                return false;
            }




            if (!int.TryParse(txtCantidad.Text.Trim(), out int cant))
            {
                MessageBox.Show("Ingrese una cantidad correcta");
                return false;
            }

            return true;
        }

        private void CargarDatosProducto()
        {
            mProducto.id = getFolioIfExist();
            mProducto.nombre = txtNombre.Text.Trim();
            mProducto.precio = float.Parse(txtPrecio.Text.Trim());
            mProducto.cantidad = int.Parse(txtCantidad.Text.Trim());
            mProducto.tipo = txtTipo.Text.Trim();
            mProducto.marca = txtMarca.Text.Trim();
            mProducto.serie = txtSerie.Text.Trim();
            mProducto.color = txtColor.Text.Trim();
            mProducto.imagen = mCommun.ImageToByteArray(pbImage.Image);
        }

        private void LimpiarDatosProducto()
        {
            txtFolio.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtTipo.Text = "";
            txtMarca.Text = "";
            txtSerie.Text = "";
            txtColor.Text = "";
            pbImage.Image = CRUD.Properties.Resources.agregar_imagen;
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog.FileName;
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (!datosCorrectos())
                return;

            CargarDatosProducto();

            if (mProductoConsultas.modificarProducto(mProducto))
            {
                MessageBox.Show("Producto modificado");
                CargarProductos();
                LimpiarDatosProducto();
            }
            else
                MessageBox.Show("Error al modificar el producto");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatosProducto();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();

            Menus menus = new Menus();

            menus.Show();
        }

        private void CargarProductos(string filtro = "")
        {
 
            dgvProductos.Rows.Clear();
            dgvProductos.Refresh();
            mProductos.Clear();
            mProductos = mProductoConsultas.consultarProductos(filtro);

            for (int i = 0; i < mProductos.Count(); i++) { 

                dgvProductos.RowTemplate.Height = Commun.ROW_HEIGTH;
                dgvProductos.Rows.Add(
                    mProductos[i].id,
                    mProductos[i].nombre,
                    mProductos[i].precio,
                    mProductos[i].cantidad,
                    mProductos[i].tipo,
                    mProductos[i].marca,
                    mProductos[i].serie,
                    mProductos[i].color,
                    Image.FromStream(new MemoryStream(mProductos[i].imagen)));
            }
        }

 

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (getFolioIfExist() == -1)
                return;

            if (MessageBox.Show("¿Desea eliminar el producto?", "Eliminar producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                    CargarDatosProducto();
                    if (mProductoConsultas.eliminarProducto(mProducto))
                    {
                        MessageBox.Show("Producto eliminado con éxito.");
                        CargarProductos();
                        LimpiarDatosProducto();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.");
                    }

              

            }
        }

        private int getFolioIfExist()
        {
            if (!txtFolio.Text.Trim().Equals(""))
            {
                if (int.TryParse(txtFolio.Text.Trim(), out int folio))
                    return folio;
                else
                    return -1;
            } else 
                return -1;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            txtFolio.Text = Convert.ToString(fila.Cells["Folio"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtPrecio.Text = Convert.ToString(fila.Cells["Precio"].Value);
            txtCantidad.Text = Convert.ToString(fila.Cells["Cantidad"].Value);
            txtTipo.Text = Convert.ToString(fila.Cells["Tipo"].Value);
            txtMarca.Text = Convert.ToString(fila.Cells["Marca"].Value);
            txtSerie.Text = Convert.ToString(fila.Cells["Serie"].Value);
            txtColor.Text = Convert.ToString(fila.Cells["Color"].Value);

            MemoryStream ms = new MemoryStream();
            Bitmap img = (Bitmap) dgvProductos.CurrentRow.Cells[8].Value;
            //img.Save(ms, ImageFormat.Png);
           // pbImage.Image = Image.FromStream(ms);

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
