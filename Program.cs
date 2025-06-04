using MiCajero3;
using System;
using System.Windows.Forms;

namespace Almacen
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string rol = "ADMINISTRADOR";
            string nombre = "JULIO";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
