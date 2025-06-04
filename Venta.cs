using MiCajero3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiAlmacen
{
    public partial class Venta : Form
    {
        private Principal principal;
        public Venta(Principal principal)
        {
            
            InitializeComponent();
            this.principal = principal;



        }
        private void btnVender_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "NOMBRE DEL CLIENTE")
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
                    string consultasql = " SELECT * FROM Productos WHERE PRODUCTO ='" + CbProducto.Text + "'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {

                        DateTime Fecha = DateTime.Now;
                        string fecha = Fecha.Day+"/"+Fecha.Month + "/" + Fecha.Year;

                        if (objtabla.Read()) {
                            if ((int)numericUpDown1.Value < (int)objtabla[3]) {
                                txtPrecio.Text = objtabla[2].ToString();
                                objtabla.Close();
                                string consultasql2 = "ALTER TABLE Transaccion NOCHECK CONSTRAINT ALL; "+
                                    "DECLARE @id_cliente int, @Nombre nvarchar(50), @id_producto int, @cantidad int, @total money, @Producto nvarchar(50); " +
                                "SET @id_cliente = (SELECT ID_CLIENTE FROM Clientes WHERE NOMBRE ='" + CbNombre.Text + "'); " +
                                "SET @id_producto = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = '" + CbProducto.Text + "'); " +
                                "SET @cantidad = " + numericUpDown1.Value + "; " +
                                "SET @total = @cantidad * (SELECT PRECIO FROM Productos WHERE ID_PRODUCTO = @id_producto); " +
                                "SET @Producto = (SELECT PRODUCTO FROM Productos WHERE ID_PRODUCTO = @id_producto); " +
                                "SET @Nombre = (SELECT NOMBRE FROM Clientes WHERE ID_CLIENTE = @id_cliente); " +
                                "INSERT INTO Transaccion (FECHA, ID_CLIENTE, NOMBRE, ID_PRODUCTO, NOMBRE_PRODUCTO, CANTIDAD, TOTAL) " +
                                "VALUES ('" + fecha + "', @id_cliente, @Nombre, @id_producto, @Producto, @cantidad, @total); " +
                                "UPDATE Productos " +
                                "SET STOCK = STOCK - @cantidad " +
                                "WHERE ID_PRODUCTO = @id_producto; " +
                                "SELECT @total; " +
                                "ALTER TABLE Transaccion CHECK CONSTRAINT ALL;";

                                using (SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=MiAlmacen;Integrated Security=True; "))
                                {
                                    conexion.Open();
                                    using (SqlCommand comando = new SqlCommand(consultasql2, conexion))
                                    {
                                        decimal total = (decimal)comando.ExecuteScalar();
                                        MessageBox.Show("VENTA REALIZADA CON EXITO!\n\nEL TOTAL FUE: " + (int)total + "$", "VENTA REALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    conexion.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERROR NO TENEMOS DICHA CANTIDAD DEL PRODUCTO", "AGOTADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       


        private void CbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbProducto.Text)
            {

                default:
                    SqlConnection objconector = new SqlConnection("" +
         "Data Source=localhost;Initial Catalog=MiAlmacen;Integrated Security=True; ");

                    objconector.Open();
                    string consultasql = " SELECT * FROM Productos WHERE PRODUCTO = '" + CbProducto.Text + "'";

                    SqlCommand objconsulta = new SqlCommand(consultasql, objconector);
                    SqlDataReader objtabla = objconsulta.ExecuteReader();
                    try
                    {

                        if (objtabla.Read() && objtabla[1].ToString()==CbProducto.Text)
                        {
                            //error
                            txtPrecio.Text = objtabla[2].ToString();
                        }
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("Fallo la conexion " + err.Message);

                    }

                    break;
            }

        }

        private void Venta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'miAlmacenDataSetTablas.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.miAlmacenDataSetTablas.Productos);
            // TODO: esta línea de código carga datos en la tabla 'miAlmacenDataSetTablas.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.miAlmacenDataSetTablas.Clientes);

        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            btnVender.Focus();
        }
    }
  }

        
