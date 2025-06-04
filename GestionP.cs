using MiAlmacen;
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

namespace PracticaTres
{
    public partial class GestionP : Form
    {
        private Principal principal;
        public GestionP(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
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

        private void btnModNom_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModificarNom objmod = new ModificarNom(principal);
            objmod.Show();

        }

        private void btnModPre_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModificarPrecio objmod = new ModificarPrecio(principal);
            objmod.Show();
        }

        private void btnModCant_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModificarCant objmod = new ModificarCant(principal);
            objmod.Show();
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
