using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Security.Principal;
using PracticaTres;
using Almacen.Properties;

namespace MiCajero3
{


    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(Resources.Login));
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO" || txtContrasena.Text == "CONTRASEÑA")
            {
                MessageBox.Show("Debe de ingresar toda la información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtUsuario.Text == "ADMIN" & txtContrasena.Text == "1234")
            {

                this.Hide();//oculta el form
                string rol = "ADMIN";
                string nombre = "ADMINISTRADOR";
                Principal objprincipal = new Principal(rol, nombre);
                objprincipal.Show();
            }

            else
            {

                SqlConnection objconector = new SqlConnection("" +
                "Data Source=localhost;Initial Catalog=MiAlmacen;Integrated Security=True; ");
                try
                {
                    objconector.Open();
                    string consultasql = "SELECT * FROM Usuarios WHERE " +
                        "NOMBRE = '" + txtUsuario.Text + "'";
                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {
                        if (objtabla.Read())
                        {
                            if (txtContrasena.Text == objtabla[2].ToString().Trim().ToUpper())
                            {
                                this.Hide();//oculta el form
                                string rol = objtabla[3].ToString().Trim().ToUpper();
                                string nombre = objtabla[1].ToString().Trim().ToUpper();
                                Principal objprincipal = new Principal(rol, nombre);
                                objprincipal.Show();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o Clave incorrecta ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Usuario no Existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException er)
                    {
                        MessageBox.Show("Error Conexion a la Bases de Datos" + er.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException er)
                {
                    MessageBox.Show("Error Conexion a la Bases de Datos" + er.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



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
            if (txtUsuario.Text=="USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor= Color.LightGray;

            
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor= Color.DimGray;
            }
            if (txtUsuario.Text == "Admin"|| txtUsuario.Text == "ADMIN")
            {
                txtContrasena.Text = "1234";
                txtUsuario.ForeColor = Color.DimGray;
                btnAcceder_Click(sender, new EventArgs());
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")

            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.LightGray;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
        
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            
          
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
           
        }

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            RecuperarUsser objrecuperar = new RecuperarUsser();
            objrecuperar.Show();




        }

    }
}
