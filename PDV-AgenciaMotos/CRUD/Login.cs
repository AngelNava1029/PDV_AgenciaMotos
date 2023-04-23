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
    public partial class Login : Form
    {

        private Commun mCommun;
        private UsuariosConsultas mUsuarioConsultas;
        private Producto mProducto;
        private List<Producto> mProductos;
        private Usuario mUsuario;
        private List<Usuario> mUsuarios;
        public Login()
        {
            InitializeComponent();
            mCommun = new Commun();
            mUsuarioConsultas = new UsuariosConsultas();
            mUsuario = new Usuario ();
            mUsuarios = new List<Usuario>();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CargarUser(txtUsuario.Text.Trim());


        }

        private void CargarUser(string filtro = "")
        {

            mUsuarios.Clear();
            mUsuarios = mUsuarioConsultas.consultarUser(filtro);

            txtUsuario.Text = mUsuarios[0].usuario;

            if(txtUsuario.Text == mUsuarios[0].usuario && txtContrasena.Text == mUsuarios[0].contrasena)
            {
                MessageBox.Show("Usuario valido");
                this.Hide();

                Menus menus = new Menus();

                menus.Show();
            }
            else
            {
                MessageBox.Show("Usuario no  valido");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
