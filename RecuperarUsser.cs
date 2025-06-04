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

namespace PracticaTres
{
    public partial class RecuperarUsser : Form
    {
        public RecuperarUsser()
        {
            InitializeComponent();
            CbPregunta.Items.Add("PREGUNTA");
            CbPregunta.Items.Add("COLOR");
            CbPregunta.Items.Add("MASCOTA");
            CbPregunta.Items.Add("NOMBRE MADRE");
            CbPregunta.SelectedIndex = 0;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "NOMBRE DE USUARIO" || CbPregunta.Text == "PREGUNTA" || TxtRespuesta.Text == "RESPUESTA")
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
                    string consultasql = " SELECT *FROM Usuarios WHERE NOMBRE ='" + txtUsuario.Text + "'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {
                        if (objtabla.Read())
                        {
                            if (objtabla[4].ToString() == CbPregunta.Text & objtabla[5].ToString() == TxtRespuesta.Text)
                            {
                                string contrasena = objtabla[2].ToString();
                                MessageBox.Show("CONTRASEÑA RECUPERADA CON EXITO! \n LA CLAVE DE: " + objtabla[1].ToString() + " ES :" +
                                contrasena, "RECUPERAR CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                                Login OBJNUEVO = new Login();
                                OBJNUEVO.Show();
                                this.Hide();


                            }
                        }
                        else
                        {
                            MessageBox.Show("DATOS INCORRECTOS INTENTE NUEVAMENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }



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
        private void CbPregunta_Enter(object sender, EventArgs e)
        {
            int selectedIndex = CbPregunta.SelectedIndex;


            if (selectedIndex > 0)
            {
                CbPregunta.Items.Remove("PREGUNTA");
            }
        }
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "NOMBRE DE USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;


            }
        }

        private void txtRespuesta_Leave(object sender, EventArgs e)
        {
            if (TxtRespuesta.Text == "")
            {
                TxtRespuesta.Text = "RESPUESTA";
                TxtRespuesta.ForeColor = Color.DimGray;
            }
        }
        private void txtRespuesta_Enter(object sender, EventArgs e)
        {
            if (TxtRespuesta.Text == "RESPUESTA")
            {
                TxtRespuesta.Text = "";
                TxtRespuesta.ForeColor = Color.Black;


            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "NOMBRE DE USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
