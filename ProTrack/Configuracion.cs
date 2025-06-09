using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;

namespace ProTrack
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e) // Boton Guardar***
        {
            var lineas = new List<string>
            {
                $"ip={txtIP.Text}",
                $"puerto={txtPuerto.Text}"
            };

            File.WriteAllLines("config.txt", lineas);
            MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            Config.Cargar(); // ya tienes esta función
            txtIP.Text = Config.IP;
            txtPuerto.Text = Config.Puerto.ToString();
        }
    }
}
