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
    public partial class NuevoCliente : Form
    {
        private Principal principal;
        public NuevoCliente(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;

        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE DEL CLIENTE")
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
                    string consultasql = " INSERT INTO Clientes (NOMBRE)" +
                    "VALUES" + "('" + txtNombre.Text + "')";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);

                    try
                    {
                        SqlDataReader objtabla = objconsulta.ExecuteReader();
                        MessageBox.Show("USUARIO REGISTRADO CON EXITO!", "NUEVO PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Venta OBJNUEVO = new Venta(principal);
                        OBJNUEVO.ShowDialog();
                        this.Hide();
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
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE DEL CLIENTE")
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
                txtNombre.Text = "NOMBRE DEL CLIENTE";
                txtNombre.ForeColor = Color.DimGray;
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
