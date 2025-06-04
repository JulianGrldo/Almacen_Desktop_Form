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

namespace MiAlmacen
{
    public partial class ModificarPrecio : Form
    {
        private Principal principal;
        public ModificarPrecio(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }


        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE PRODUCTO A MODIFICAR")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;


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
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE PRODUCTO A MODIFICAR";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtNuevoPre_Enter(object sender, EventArgs e)
        {
            if (txtNuevoPre.Text == "NUEVO PRECIO")
            {
                txtNuevoPre.Text = "";
                txtNuevoPre.ForeColor = Color.Black;


            }
        }

        private void txtNuevoPre_Leave(object sender, EventArgs e)
        {
            if (txtNuevoPre.Text == "")
            {
                txtNuevoPre.Text = "NUEVO PRECIO";
                txtNuevoPre.ForeColor = Color.DimGray;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE PRODUCTO A MODIFICAR" || txtNuevoPre.Text == "NUEVO PRECIO")
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
                    string consultasql = " SELECT *FROM Productos WHERE PRODUCTO = '" + txtNombre.Text + "'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);

                    try
                    {

                        SqlDataReader objtabla = objconsulta.ExecuteReader();

                        if (objtabla.Read()) 
                        {
                            objtabla.Close();
                            string consultasql2 = " UPDATE Productos SET PRECIO = '" + txtNuevoPre.Text + "' WHERE PRODUCTO = '" + txtNombre.Text + "'";
                            SqlCommand objconsulta2 = new SqlCommand(consultasql2, objconector);
                            SqlDataReader objtabla2 = objconsulta.ExecuteReader();

                            MessageBox.Show("PRECIO MODIFICADO CON EXITO!", "ACTUALIZAR PRECIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        } 
                        else
                        {
                            MessageBox.Show("PRODUCTO NO ENCONTRADO!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNombre.Text = "NOMBRE PRODUCTO A MODIFICAR";
                            txtNuevoPre.Text = "NUEVO PRECIO";
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void eventoClose(object sender, FormClosedEventArgs e)
        {
            principal.activarB();
            principal.mostrarMenu();
        }
    }
}
