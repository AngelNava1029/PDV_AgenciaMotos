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
    public partial class Usuarios : Form
    {

        private Commun mCommun;
        private UsuariosConsultas mUsuarioConsultas;
        private Usuario mUsuario;
        private List<Usuario> mUsuarios;


        public Usuarios()
        {
            InitializeComponent();
            mCommun = new Commun();
            mUsuarioConsultas = new UsuariosConsultas();
            mUsuario = new Usuario();
            mUsuarios = new List<Usuario>();

            CargarUsuarios();

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
            txtId.Text = Convert.ToString(fila.Cells["Id"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtUsuario.Text = Convert.ToString(fila.Cells["Usuario"].Value);
            txtContrasena.Text = Convert.ToString(fila.Cells["Contrasena"].Value);

            MemoryStream ms = new MemoryStream();
            Bitmap img = (Bitmap)dgvUsuarios.CurrentRow.Cells[4].Value;
            //img.Save(ms, ImageFormat.Png);
           // pbImage.Image = Image.FromStream(ms);

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
                return;

            CargarDatosUsuario();

            if (mUsuarioConsultas.agregarUsuario(mUsuario))
            {
                MessageBox.Show("Usuario agregado");
                CargarUsuarios();
                LimpiarDatosUsuario();
            }
            else
                MessageBox.Show("Error al agregar el usuario");
        }

        private bool datosCorrectos()
        {
    
            if (txtNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el nombre del usuario");
                return false;
            }

            if (txtUsuario.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese un nombre de usuario");
                return false;
            }


            if (txtContrasena.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese una contraseña");
                return false;
            }



            return true;
        }

        private void LimpiarDatosUsuario()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            pbImage.Image = CRUD.Properties.Resources.agregar_imagen;
        }



        private void CargarDatosUsuario()
        {
            //mUsuario.id = Int32.Parse(txtId.Text); 
            mUsuario.nombre = txtNombre.Text.Trim();
            mUsuario.usuario = txtUsuario.Text.Trim();
            mUsuario.contrasena = txtContrasena.Text.Trim();
            mUsuario.imagen = mCommun.ImageToByteArray(pbImage.Image);
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

        private void CargarUsuarios(string filtro = "")
        {

            dgvUsuarios.Rows.Clear();
            dgvUsuarios.Refresh();
            mUsuarios.Clear();
            mUsuarios = mUsuarioConsultas.consultarUsuarios(filtro);

            for (int i = 0; i < mUsuarios.Count(); i++)
            {

                dgvUsuarios.RowTemplate.Height = Commun.ROW_HEIGTH;
                dgvUsuarios.Rows.Add(
                    mUsuarios[i].id,
                    mUsuarios[i].nombre,
                    mUsuarios[i].usuario,
                    mUsuarios[i].contrasena,
                Image.FromStream(new MemoryStream(mUsuarios[i].imagen)));
        }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           if (!datosCorrectos())
                return;

            CargarDatosUsuario();

            if (mUsuarioConsultas.modificarUsuario(mUsuario))
            {
                MessageBox.Show("usuario modificado");
                CargarUsuarios();
                LimpiarDatosUsuario();
            }
            else
                MessageBox.Show("Error al modificar el usuario");
        }

        private int getFolioIfExist()
        {
            if (!txtId.Text.Trim().Equals(""))
            {
                if (int.TryParse(txtId.Text.Trim(), out int folio))
                    return folio;
                else
                    return -1;
            }
            else
                return -1;
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {


            mUsuarioConsultas.eliminarUsuario(int.Parse(txtId.Text.Trim()));
                
                    LimpiarDatosUsuario() ;
  
                    CargarUsuarios() ;
               
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();

            Menus menus = new Menus();

            menus.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatosUsuario();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void lblImagen_Click(object sender, EventArgs e)
        {
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios(textBox1.Text.Trim());
        }
    }
}
