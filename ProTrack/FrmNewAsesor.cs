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
    public partial class FrmNewAsesor : Form
    {
        public FrmNewAsesor()
        {
            InitializeComponent();
            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                Console.WriteLine($"Estado: {estado}, Datos: {datos}");
                ManejarRespuestaEstado(estado, datos);
            };
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContra.Text) ||
                string.IsNullOrWhiteSpace(txtNombreReal.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtDepartamento.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto para enviar
            var nuevoAsesor = new
            {
                accion = "insertar_asesor",
                nombre_usuario = txtNombreUsuario.Text.Trim(),
                contrasena = txtContra.Text.Trim(),
                nombre = txtNombreReal.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                departamento = txtDepartamento.Text.Trim()
            };

            try
            {
                await ClienteWS.EnviarAsync(nuevoAsesor);
                MessageBox.Show("Asesor registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando datos al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmNewAsesor_Load(object sender, EventArgs e)
        {

        }

        private void FrmNewAsesor_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
        }

        public void ManejarRespuestaEstado(string estado, object datos)
        {
            if (this.IsDisposed) return;
            Console.WriteLine("Si entro al metodo");

            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito" && datos.ToString().Contains("Asesor registrado correctamente"))
                {
                    MessageBox.Show(datos.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
