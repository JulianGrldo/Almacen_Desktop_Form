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
    public partial class ModificarCant : Form
    {
        private Principal principal;
        public ModificarCant(Principal principal)
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

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE PRODUCTO A MODIFICAR";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtNuevaCant_Leave(object sender, EventArgs e)
        {
            if (txtNuevaCant.Text == "")
            {
                txtNuevaCant.Text = "NUEVA CANTIDAD";
                txtNuevaCant.ForeColor = Color.DimGray;
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
        private void txtNuevaCant_Enter(object sender, EventArgs e)
        {
            if (txtNuevaCant.Text == "NUEVA CANTIDAD")
            {
                txtNuevaCant.Text = "";
                txtNuevaCant.ForeColor = Color.Black;


            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE PRODUCTO A MODIFICAR" || txtNuevaCant.Text == "NUEVA CANTIDAD")
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
                    string consultasql = " SELECT * FROM Productos WHERE PRODUCTO ='" + txtNombre.Text + "'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();

                    try
                    {
                        if (objtabla.Read())
                        {
                            objtabla.Close();
                            string consultasql2 = " UPDATE Productos SET STOCK = '" + txtNuevaCant.Text + "' WHERE PRODUCTO = '" + txtNombre.Text + "'";

                            SqlCommand objconsulta2 = new SqlCommand(consultasql2, objconector);
                            SqlDataReader objtabla2 = objconsulta2.ExecuteReader();

                            MessageBox.Show("CANTIDAD MODIFICADA CON EXITO!", "ACTUALIZAR CANTIDAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("PRODUCTO NO ENCONTRADO!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNombre.Text = "NOMBRE PRODUCTO A MODIFICAR";
                            txtNuevaCant.Text = "NUEVA CANTIDAD";
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
