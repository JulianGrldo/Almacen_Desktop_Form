using MiCajero3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiAlmacen
{
    public partial class NuevaVenta : Form
    {
        private Principal principal;
        public NuevaVenta(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NuevoCliente OBJNUEVO = new NuevoCliente(principal);
            OBJNUEVO.Show();
           
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
            this.Hide();
            Venta OBJNUEVO = new Venta(principal);
            OBJNUEVO.MdiParent = this.MdiParent;
            OBJNUEVO.Show();
            
        }
        private void eventoClose(object sender, FormClosedEventArgs e)
        {
            Principal mainForm = (Principal)this.MdiParent;
            mainForm.activarB();
            mainForm.mostrarMenu();
        }
    }
}
