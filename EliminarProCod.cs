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
    public partial class EliminarProCod : Form
    {
        private Principal principal;
        public EliminarProCod(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }


        private void txtCod_Enter(object sender, EventArgs e)
        {
            if (txtCod.Text == "CODIGO PRODUCTO A ELIMINAR")
            {
                txtCod.Text = "";
                txtCod.ForeColor = Color.Black;


            }
        }

        private void txtCod_Leave(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                txtCod.Text = "CODIGO PRODUCTO A ELIMINAR";
                txtCod.ForeColor = Color.DimGray;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnAcceder_Click(object sender, EventArgs e)
        {

            if (txtCod.Text == "CODIGO PRODUCTO A ELIMINAR")
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
                    string consultasql = "SELECT *FROM Productos WHERE ID_PRODUCTO = " + "'" + txtCod.Text + "'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {
                        if (objtabla.Read())
                        {
                            objtabla.Close();
                            string consultasql3 = "SELECT *FROM Transaccion WHERE ID_PRODUCTO = " + "'" + txtCod.Text + "'";

                            SqlCommand objconsulta3 = new SqlCommand(consultasql3, objconector);
                            SqlDataReader objtabla3 = objconsulta3.ExecuteReader();

                            if (objtabla3.Read())
                            {

                                objtabla3.Close();
                                string consultasql2 = "DELETE FROM Transaccion WHERE ID_PRODUCTO = " + txtCod.Text +
                                    "DELETE FROM Productos WHERE ID_PRODUCTO = " + txtCod.Text;
                                SqlCommand objconsulta2 = new SqlCommand(consultasql2, objconector);
                                SqlDataReader objtabla2 = objconsulta2.ExecuteReader();
                                if (objtabla2.Read())
                                {
                                    MessageBox.Show("PRODUCTO ELIMINADO CON EXITO!", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    objtabla2.Close();
                                    this.Close();

                                }
                                else

                                {
                                    MessageBox.Show("PRODUCTO NO ENCONTRADO!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtCod.Text = "CODIGO PRODUCTO A ELIMINAR";
                                }
                            }
                            else 
                            {
                                objtabla3.Close();
                                string consultasql2 ="DELETE FROM Productos WHERE ID_PRODUCTO = " + txtCod.Text;
                                SqlCommand objconsulta2 = new SqlCommand(consultasql2, objconector);
                                SqlDataReader objtabla2 = objconsulta2.ExecuteReader();
                               
                                    MessageBox.Show("PRODUCTO ELIMINADO CON EXITO!", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    objtabla2.Close();
                                    this.Close();
                              
                            }
                   
                        }
                        else
                        {
                            MessageBox.Show("PRODUCTO NO ENCONTRADO!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCod.Text = "CODIGO PRODUCTO A ELIMINAR";

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
        private void eventoClose(object sender, FormClosedEventArgs e)
        {
            principal.activarB();
            principal.mostrarMenu();
        }
    }
}
