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
    public partial class FrmNewAlumno : Form
    {
        public FrmNewAlumno()
        {
            InitializeComponent();
        }

        private void FrmNewAlumno_Activated(object sender, EventArgs e)
        {

        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar que el usuario sea ADMIN o el rol que corresponda
            if (!Sesion.EsAsesor)
            {
                MessageBox.Show("Solo los administradores pueden agregar estudiantes.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preparar el objeto con la acción y datos
            var nuevoEstudiante = new
            {
                accion = "insertar_estudiante",
                nombre_usuario = txtNombreUsuario.Text.Trim(),
                contrasena = txtContra.Text.Trim(),
                nombre = txtNombreReal.Text.Trim(),
                carrera = txtCarrera.Text.Trim(),
                semestre = int.TryParse(txtSemestre.Text.Trim(), out int sem) ? sem : 1,
                correo = txtCorreo.Text.Trim()
            };

            try
            {
                await ClienteWS.EnviarAsync(nuevoEstudiante);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando datos al servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ManejarRespuestaEstado(string estado, string datos)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito" && datos.Contains("Alumno"))
                {
                    MessageBox.Show(datos, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }
    }
}
