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
    public partial class AgregarPro : Form
    {
        public AgregarPro()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {



            if (txtNombre.Text == "NOMBRE PRODUCTO" || txtPrecio.Text == "PRECIO" || txtCantidad.Text == "CANTIDAD")
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
                    string consultasql = " INSERT INTO Productos (PRODUCTO, PRECIO, STOCK)" +
                    "VALUES" + "('" + txtNombre.Text + "'," + txtPrecio.Text + "," + txtCantidad.Text + ")";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);

                    try
                    {
                        SqlDataReader objtabla = objconsulta.ExecuteReader();
                        MessageBox.Show("PRODUCTO INGRESADO CON EXITO!", "NUEVO PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE PRODUCTO")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;


            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE PRODUCTO";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "PRECIO";
                txtPrecio.ForeColor = Color.DimGray;
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "PRECIO")
            {
                txtPrecio.Text = "";
                txtPrecio.ForeColor = Color.Black;


            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.Text = "CANTIDAD";
                txtCantidad.ForeColor = Color.DimGray;
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "CANTIDAD")
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.Black;


            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
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

