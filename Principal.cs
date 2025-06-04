using Almacen.Properties;
using MiAlmacen;
using PracticaTres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Hosting;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCajero3
{
    public partial class Principal : Form
    {
        private static DateTime fecha = DateTime.Now;
        string Fecha = fecha.Day + "/" + fecha.Month + "/" + fecha.Year;
        public Principal(string rol,string nombre)
        {
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(Resources.Almacen));
            if (rol.Equals("ADMINISTRADOR"))
            {

            }

            else if (rol.Equals("CAJERO"))
            {
                EliminarPToolStripMenuItem1.Enabled = false;
                UsserToolStripMenuItem.Enabled = false;
                gbUsser.Visible = false;
                gbProduct.Location = new Point(150, 250);
                gbVentas.Location = new Point(600, 250);
                pictureBox5.Visible = false;
            }
            
            lblSaludo.Text = lblSaludo.Text + " "+ nombre;
            lblRol.Text = lblRol.Text + " " + rol;
            lblFecha.Text = Fecha;
        }

        private void NuevoUsserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            AgregarUsser OBJNUEVO = new AgregarUsser();
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
           
            
        }

        private void EliminarUsserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            EliminarUsser OBJNUEVO = new EliminarUsser();
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            UsuariosSistema OBJNUEVO = new UsuariosSistema();
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void DisponiblesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            Productos OBJNUEVO = new Productos();
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void AgregarPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            AgregarPro OBJNUEVO = new AgregarPro();
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            ModificarNom OBJNUEVO = new ModificarNom(this);
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void valorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            ModificarPrecio OBJNUEVO = new ModificarPrecio(this);
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void cantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            ModificarCant OBJNUEVO = new ModificarCant(this);
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void porNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            EliminarPro OBJNUEVO = new EliminarPro(this);
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void porCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            EliminarProCod OBJNUEVO = new EliminarProCod(this);
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            NuevaVenta OBJNUEVO = new NuevaVenta(this);
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void asistenteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            Asistente OBJNUEVO = new Asistente();
            OBJNUEVO.MdiParent = this;
            OBJNUEVO.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
           
           Login objlog = new Login();      
           this.Close();
           objlog.Show(); 
        }


        public void mostrarMenu() 
        {
            PnlMenu.Visible = true;

        }
        public void activarB ()
        {
            BarraApp.Enabled = true;
        }

        public void DesactivarB()
        {
            BarraApp.Enabled = false;
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
        private void MetodoMouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            GestionP objGes = new GestionP(this);
            objGes.MdiParent = this;
            objGes.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DesactivarB();
            PnlMenu.Visible = false;
            Eliminar objElim = new Eliminar(this);
            objElim.MdiParent = this;
            objElim.Show();
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtUsuario.Visible = true;
            
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtUsuario.Visible = false;
           
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtelim.Visible = true;

        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtelim.Visible = false;

        }
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtuss.Visible = true;

        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtuss.Visible = false;

        }
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtagre.Visible = true;

        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtagre.Visible = false;

        }
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txteliminarp.Visible = true;

        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txteliminarp.Visible = false;

        }
        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtact.Visible = true;

        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtact.Visible = false;

        }
        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtdis.Visible = true;

        }
        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtdis.Visible = false;

        }
        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtven.Visible = true;

        }
        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtven.Visible = false;

        }
        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "sobre";
            pic.Size = new Size(pic.Size.Width + 10, pic.Size.Height + 10);
            txtasis.Visible = true;

        }
        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Tag = "normal";
            pic.Size = new Size(pic.Size.Width - 10, pic.Size.Height - 10);
            txtasis.Visible = false;

        }
    }
}
