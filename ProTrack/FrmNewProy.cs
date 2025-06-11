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
    public partial class FrmNewProy : Form
    {
        public FrmNewProy()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e) //btnAgregarProy
        {
            if (!Sesion.EsAsesor)
            {
                MessageBox.Show("Solo los asesores pueden crear proyectos.");
                return;
            }

            var nuevoProyecto = new
            {
                accion = "crear_proyecto",
                datos = new
                {
                    nombre = txtNombre.Text.Trim(),
                    descripcion = txtDesc.Text.Trim(),
                    fecha_inicio = dtpInicio.Value.ToString("yyyy-MM-dd"),
                    fecha_estimada_entrega = dtpEntrega.Value.ToString("yyyy-MM-dd"),
                    estatus = cbxEstatus.SelectedItem?.ToString(),
                    //id_asesor = Sesion.IdUsuario // Eso significa que la id de asesor no hace falta!
                }
            };

            await ClienteWS.EnviarAsync(nuevoProyecto);
        }

        public void ManejarRespuestaEstado(string estado, string datos)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito" && datos.Contains("Proyecto creado"))
                {
                    MessageBox.Show(datos, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            labNombre.Text = txtNombre.Text.Trim();
        }
    }
}
