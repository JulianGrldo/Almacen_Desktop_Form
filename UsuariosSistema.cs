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
    public partial class UsuariosSistema : Form
    {
        public UsuariosSistema()
        {
            InitializeComponent();
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
        private void eventoClose(object sender, FormClosedEventArgs e)
        {
            Principal mainForm = (Principal)this.MdiParent;
            mainForm.activarB();
            mainForm.mostrarMenu();
        }

        private void UsuariosSistema_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'miAlmacenDataSetTablas.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.miAlmacenDataSetTablas.Usuarios);

        }
    }
}
