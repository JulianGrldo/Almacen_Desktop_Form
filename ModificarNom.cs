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
    public partial class ModificarNom : Form
    {
        private Principal principal;
        public ModificarNom(Principal principal)
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

        private void txtNuevoNom_Leave(object sender, EventArgs e)
        {
            if (txtNuevoNom.Text == "")
            {
                txtNuevoNom.Text = "NUEVO NOMBRE";
                txtNuevoNom.ForeColor = Color.DimGray;
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
        private void txtNuevoNom_Enter(object sender, EventArgs e)
        {
            if (txtNuevoNom.Text == "NUEVO NOMBRE")
            {
                txtNuevoNom.Text = "";
                txtNuevoNom.ForeColor = Color.Black;


            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text== "NOMBRE PRODUCTO A MODIFICAR" || txtNuevoNom.Text== "NUEVO NOMBRE") 
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
                    string consultasql = "SELECT *FROM Transaccion WHERE NOMBRE_PRODUCTO = '" + txtNombre.Text+"'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {
                        if (objtabla.Read())
                        {
                            objtabla.Close();
                            string consultasql2 = "ALTER TABLE Transaccion NOCHECK CONSTRAINT ALL; " +
                                " UPDATE Productos SET PRODUCTO = '"+txtNuevoNom.Text+"' WHERE ID_PRODUCTO = (SELECT ID_PRODUCTO FROM Productos" +
                                " WHERE PRODUCTO = '"+txtNombre.Text+"'); " +
                                " UPDATE Transaccion SET NOMBRE_PRODUCTO = '"+txtNuevoNom.Text+"'"+
                                " WHERE ID_PRODUCTO = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = '"+txtNombre.Text+"');" +
                                " ALTER TABLE Transaccion CHECK CONSTRAINT ALL;";
                                
                            SqlCommand objconsulta2 = new SqlCommand(consultasql2, objconector);
                            SqlDataReader objtabla2 = objconsulta2.ExecuteReader();
                            if (objtabla2.Read())
                            {

                                MessageBox.Show("PRODUCTO MODIFICADO CON EXITO!", "CAMBIAR NOMBRE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                objtabla2.Close();
                                this.Close();
                            }
                            else {

                                MessageBox.Show("PRODUCTO NO ENCONTRADO!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtNombre.Text = "NOMBRE PRODUCTO A MODIFICAR";
                                txtNuevoNom.Text = "NUEVO NOMBRE";
                            }
                      

                        }
                        else {

                            objtabla.Close();
                            string consultasql3 = "SELECT * FROM Productos WHERE PRODUCTO = '"+txtNombre.Text+"'";

                            SqlCommand objconsulta3 = new SqlCommand(consultasql3, objconector);
                            SqlDataReader objtabla3 = objconsulta3.ExecuteReader();
                            if (objtabla3.Read())
                            {

                                string consultasql4 = "UPDATE Productos SET PRODUCTO = '" + txtNuevoNom.Text + "' WHERE ID_PRODUCTO = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = '" + txtNombre.Text + "')";

                                SqlCommand objconsulta4 = new SqlCommand(consultasql4, objconector);
                                SqlDataReader objtabla4 = objconsulta4.ExecuteReader();

                                objtabla3.Close();
                                MessageBox.Show("PRODUCTO MODIFICADO CON EXITO!", "CAMBIAR NOMBRE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();

                            }
                            else 
                            {
                                MessageBox.Show("PRODUCTO NO ENCONTRADO!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtNombre.Text = "NOMBRE PRODUCTO A MODIFICAR";
                                txtNuevoNom.Text = "NUEVO NOMBRE";
                            }

                       



                           
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
