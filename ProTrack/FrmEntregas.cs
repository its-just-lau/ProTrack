using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProTrack
{
    public partial class FrmEntregas : Form
    {
        public FrmEntregas()
        {
            InitializeComponent();      
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async Task CargarEntregasPorProyecto(int idProyecto)
        {
            await ClienteWS.EnviarAsync(new
            {
                accion = "listar_entregas",
                id_proyecto = idProyecto
            });
        }

        public void ManejarRespuestaEstado(string estado, object datos)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                try
                {
                    if (estado == "exito")
                    {
                        string json = datos.ToString();

                        if (json.Contains("id_proyecto"))
                        {
                            // Llenar ComboBox con proyectos
                            var lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                            cmbProyectos.DisplayMember = "nombre";
                            cmbProyectos.ValueMember = "id_proyecto";
                            cmbProyectos.DataSource = lista
                                .Select(p => new
                                {
                                    nombre = p["nombre"],
                                    id_proyecto = p["id_proyecto"]
                                }).ToList();

                            if (cmbProyectos.Items.Count > 0)
                                cmbProyectos.SelectedIndex = 0;
                        }
                        else if (json.Contains("Entrega registrada."))
                        {
                            MessageBox.Show("Entrega registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (cmbProyectos.SelectedValue != null)
                                _ = CargarEntregasPorProyecto(Convert.ToInt32(cmbProyectos.SelectedValue));

                            // 🔄 Limpiar campos del formulario
                            txtNombreEntrega.Clear();
                            dtpFecha.Value = DateTime.Today;
                            cmbEstatus.SelectedIndex = -1;
                            cmbProyectos.SelectedIndex = 0;
                        }
                        else
                        {
                            var entregas = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                            dgvEntregas.Columns.Clear();
                            dgvEntregas.Rows.Clear();

                            dgvEntregas.Columns.Add("id_entrega", "ID Entrega");
                            dgvEntregas.Columns.Add("nombre_entrega", "Nombre");
                            dgvEntregas.Columns.Add("fecha_programada", "Fecha Programada");
                            dgvEntregas.Columns.Add("fecha_real", "Fecha Real");
                            dgvEntregas.Columns.Add("estatus", "Estatus");

                            foreach (var e in entregas)
                            {
                                dgvEntregas.Rows.Add(
                                    e["id_entrega"],
                                    e["nombre_entrega"],
                                    e["fecha_programada"],
                                    e["fecha_real"],
                                    e["estatus"]
                                );
                            }

                            dgvEntregas.EnableHeadersVisualStyles = false;
                            dgvEntregas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                            dgvEntregas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            dgvEntregas.GridColor = Color.Black;
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error procesando la respuesta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbProyectos.SelectedValue == null || string.IsNullOrWhiteSpace(txtNombreEntrega.Text))
            {
                MessageBox.Show("Llena todos los campos requeridos.");
                return;
            }

            var nuevaEntrega = new
            {
                accion = "insertar_entrega",
                id_proyecto = Convert.ToInt32(cmbProyectos.SelectedValue),
                nombre_entrega = txtNombreEntrega.Text.Trim(),
                fecha_programada = dtpFecha.Value.ToString("yyyy-MM-dd"),
                fecha_real = DateTime.Now.ToString("yyyy-MM-dd"),
            estatus = cmbEstatus.SelectedItem?.ToString() ?? "Pendiente"
            };

            await ClienteWS.EnviarAsync(nuevaEntrega);
            // 🔄 Limpiar campos del formulario
            txtNombreEntrega.Clear();
            dtpFecha.Value = DateTime.Today;
            cmbEstatus.SelectedIndex = -1;

            // Recargar entregas si hay proyecto seleccionado
            if (cmbProyectos.SelectedValue != null)
                _ = CargarEntregasPorProyecto(Convert.ToInt32(cmbProyectos.SelectedValue));
            txtNombreEntrega.Focus();
        }

        public void ProcesarRegistroEntrega(string mensaje)
        {
            if (mensaje.Contains("Entrega registrada"))
            {
                MessageBox.Show("Entrega registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private async void cmbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProyectos.SelectedValue != null)
                await CargarEntregasPorProyecto(Convert.ToInt32(cmbProyectos.SelectedValue));
        }

        private void FrmEntregas_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
        }

        private async void FrmEntregas_Load(object sender, EventArgs e)
        {
            if (!Sesion.EsAsesor)
            {
                MessageBox.Show("Solo los asesores pueden gestionar entregas.");
                Close();
                return;
            }

            await ClienteWS.EnviarAsync(new { accion = "proyecto_asesor" });
        }
    }
}
