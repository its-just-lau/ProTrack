using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProTrack
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string actual = txtActual.Text.Trim();
            string nueva = txtNueva.Text.Trim();
            string repetir = txtRepetir.Text.Trim();

            if (string.IsNullOrWhiteSpace(actual) || string.IsNullOrWhiteSpace(nueva) || string.IsNullOrWhiteSpace(repetir))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nueva != repetir)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mensaje = new
            {
                accion = "cambiar_contrasena",
                datos = new
                {
                    actual = actual,
                    nueva = nueva
                }
            };

            try
            {
                await ClienteWS.EnviarAsync(mensaje);

                MessageBox.Show("Contraseña actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar datos al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
