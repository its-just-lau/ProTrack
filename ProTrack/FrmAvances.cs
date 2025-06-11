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
using Newtonsoft.Json.Linq;

namespace ProTrack
{
    public partial class FrmAvances : Form
    {
        private string ultimaAccion = "";
        public FrmAvances()
        {
            InitializeComponent();
            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuestaEstado;
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            int idProyecto = Convert.ToInt32(cbxProyectos.SelectedValue);
            ultimaAccion = "listar_avances";
            var solicitud = new
            {
                accion = ultimaAccion,
                id_proyecto = idProyecto
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        private async void FrmAvances_Load(object sender, EventArgs e)
        {
            if (Sesion.EsAsesor)
            {
                ultimaAccion = "proyecto_asesor";
                await ClienteWS.EnviarAsync(new { accion = ultimaAccion });
            }
            else
            {
                ultimaAccion = "listar_proyectos_alumno";
                await ClienteWS.EnviarAsync(new { accion = ultimaAccion });
            }

        }

        private void FrmAvances_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
        }

        public void ManejarRespuestaEstado(string estado, object datos)
        {
            if (this.IsDisposed) return;

            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito")
                {
                    try
                    {
                        List<Dictionary<string, string>> lista = null;

                        if (datos is JArray jArray)
                        {
                            lista = jArray.ToObject<List<Dictionary<string, string>>>();
                        }
                        else if (datos is string jsonString)
                        {
                            jsonString = jsonString.Trim();
                            if (jsonString.StartsWith("[") || jsonString.StartsWith("{"))
                            {
                                lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
                            }
                            else
                            {
                                MessageBox.Show(jsonString, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            var json = JsonConvert.SerializeObject(datos);
                            lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                        }

                        if (lista == null || lista.Count == 0)
                        {
                            MessageBox.Show("No se recibieron datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Si la respuesta es de proyectos, llenar el ComboBox
                        if (ultimaAccion == "proyecto_asesor" || ultimaAccion == "listar_proyectos_alumno")
                        {
                            var proyectosAnon = lista.Select(d => new
                            {
                                id_proyecto = d.ContainsKey("id_proyecto") ? d["id_proyecto"] : "",
                                nombre = d.ContainsKey("nombre") ? d["nombre"] : ""
                            }).ToList();

                            cbxProyectos.DataSource = proyectosAnon;
                            cbxProyectos.DisplayMember = "nombre";
                            cbxProyectos.ValueMember = "id_proyecto";
                        }
                        else if (ultimaAccion == "listar_avances")
                        {
                            if (dgvAvances.Columns.Count == 0)
                            {
                                dgvAvances.Columns.Add("id_avance", "ID");
                                dgvAvances.Columns.Add("descripcion", "Descripción");
                                dgvAvances.Columns.Add("fecha_registro", "Fecha");
                                dgvAvances.Columns.Add("porcentaje_completado", "% Completado");
                            }

                            dgvAvances.Rows.Clear();

                            foreach (var a in lista)
                            {
                                dgvAvances.Rows.Add(
                                    a["id_avance"],
                                    a["descripcion"],
                                    a["fecha_registro"],
                                    a["porcentaje_completado"]
                                );
                            }
                            dgvAvances.Columns[1].Width = 200;
                            dgvAvances.EnableHeadersVisualStyles = false;
                            dgvAvances.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                            dgvAvances.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            dgvAvances.GridColor = Color.Black;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar la respuesta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbxProyectos.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            txtDescripcion.Text = "";
            nUpPorcentaje.Value = 0;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbxProyectos.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proyecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción del avance.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nUpPorcentaje.Value <= 0 || nUpPorcentaje.Value > 100)
            {
                MessageBox.Show("Ingrese un porcentaje válido (1-100).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProyecto = Convert.ToInt32(cbxProyectos.SelectedValue);
                string descripcion = txtDescripcion.Text.Trim();
                int porcentaje = (int)nUpPorcentaje.Value;

                var solicitud = new
                {
                    accion = "insertar_avance",
                    id_proyecto = idProyecto,
                    descripcion = descripcion,
                    fecha_registro = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    porcentaje_completado = porcentaje
                };

                await ClienteWS.EnviarAsync(solicitud);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar el avance.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
