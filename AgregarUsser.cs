using MiCajero3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiAlmacen
{
    public partial class AgregarUsser : Form
    {
        public AgregarUsser()
        {
            InitializeComponent();
            CbPregunta.Items.Add("PREGUNTA");
            CbPregunta.Items.Add("COLOR");
            CbPregunta.Items.Add("MASCOTA");
            CbPregunta.Items.Add("NOMBRE MADRE");
            CbPregunta.SelectedIndex = 0;

            CbRol.Items.Add("ROL");
            CbRol.Items.Add("ADMINISTRADOR");
            CbRol.Items.Add("CAJERO");
            CbRol.SelectedIndex = 0;
            btnRegistro.Focus();
        }
        private void btnRegistro_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "USUARIO" || txtContrasena.Text == "CONTRASEÑA" 
                || CbRol.Text == "ROL"||CbPregunta.Text=="PREGUNTA"||TxtRespuesta.Text=="RESPUESTA")
            {

                MessageBox.Show("INGRESE TODOS LOS DATOS", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                SqlConnection objconector = new SqlConnection("" +
           "Data Source=localhost;Initial Catalog=MiAlmacen;Integrated Security=True; ");
                try
                {
                    objconector.Open();
                    string consultasql = " INSERT INTO Usuarios(NOMBRE, CONTRASEÑA, ROL, PREGUNTA, RESPUESTA)" +
                    "VALUES" + "('" + txtUsuario.Text + "'," + txtContrasena.Text + ",'" + CbRol.Text + "'," + "'" + CbPregunta.Text + "'," + "'" + TxtRespuesta.Text + "')";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {

                        MessageBox.Show("USUARIO REGISTRADO CON EXITO!", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (SqlException error)
                    {
                        MessageBox.Show("Fallo la operacion " + error.Message);
                    }

                }
                catch (SqlException er)

                {
                    MessageBox.Show("Fallo la conexion " + er.Message);
                }
            }
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 3, pic.Size.Height + 3);
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 3, pic.Size.Height - 3);
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;


            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")

            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.UseSystemPasswordChar = true;

            }

        }
        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA";
                txtContrasena.ForeColor = Color.DimGray;
                txtContrasena.UseSystemPasswordChar = false;
            }

        }
        private void CbPregunta_Leave(object sender, EventArgs e)
        {
            if (CbPregunta.Text == "")
            {
                CbPregunta.Text = "PREGUNTA";
                CbPregunta.ForeColor = Color.DimGray;
              
            }
        }

        private void CbPregunta_Enter(object sender, EventArgs e)
        {
            int selectedIndex = CbPregunta.SelectedIndex;


            if (selectedIndex > 0)
            {
                CbPregunta.Items.Remove("PREGUNTA");
            }
        }

        private void TxtRespuesta_Leave(object sender, EventArgs e)
        {
            if (TxtRespuesta.Text == "")
            {
                TxtRespuesta.Text = "RESPUESTA";
                TxtRespuesta.ForeColor = Color.DimGray;
            }
        }

        private void TxtRespuesta_Enter(object sender, EventArgs e)
        {
            if (TxtRespuesta.Text == "RESPUESTA")
            {
                TxtRespuesta.Text = "";
                TxtRespuesta.ForeColor = Color.Black;


            }
        }

        private void CbRol_Enter(object sender, EventArgs e)
        {
            int selectedIndex = CbRol.SelectedIndex;


            if (selectedIndex > 0)
            {
                CbRol.Items.Remove("ROL");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void eventoClose(object sender, FormClosedEventArgs e)
        {
            Principal mainForm = (Principal)this.MdiParent;
            mainForm.activarB();
            mainForm.mostrarMenu();
        }
    }


}
