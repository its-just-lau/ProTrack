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
    public partial class FrmEntregas : Form
    {
        public FrmEntregas()
        {
            InitializeComponent();
            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuestaEstado;
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

        public void ManejarRespuestaEstado(string estado, string datos)
        {
            if (this.IsDisposed) return;

            this.Invoke((MethodInvoker)(() =>
            {
                try
                {
                    Console.WriteLine("Mensaje recibido: " + datos);

                    JToken datosJson = null;
                    try
                    {
                        datosJson = JToken.Parse(datos);
                    }
                    catch
                    {
                        // Si no es JSON válido, queda null y se puede manejar como texto plano
                    }

                    if (estado == "exito")
                    {
                        if (datosJson != null)
                        {
                            // 1. Si es lista de proyectos
                            if (datosJson is JArray arregloProyectos &&
                                arregloProyectos.Count > 0 &&
                                arregloProyectos[0]["id_proyecto"] != null)
                            {
                                var lista = arregloProyectos.ToObject<List<Dictionary<string, string>>>();
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
                            // 3. Si vienen entregas
                            else if (datosJson is JArray arregloEntregas &&
                                     arregloEntregas.Count > 0 &&
                                     arregloEntregas[0]["id_entrega"] != null)
                            {
                                var entregas = arregloEntregas.ToObject<List<Dictionary<string, string>>>();

                                dgvEntregas.Columns.Clear();
                                dgvEntregas.Rows.Clear();

                                dgvEntregas.Columns.Add("id_entrega", "ID Entrega");
                                dgvEntregas.Columns.Add("nombre_entrega", "Nombre");
                                dgvEntregas.Columns.Add("fecha_programada", "Fecha Programada");
                                dgvEntregas.Columns.Add("fecha_real", "Fecha Real");
                                dgvEntregas.Columns.Add("estatus", "Estatus");

                                foreach (var e in entregas)
                                {
                                    e.TryGetValue("id_entrega", out string idEntrega);
                                    e.TryGetValue("nombre_entrega", out string nombreEntrega);
                                    e.TryGetValue("fecha_programada", out string fechaProgramada);
                                    e.TryGetValue("fecha_real", out string fechaReal);
                                    e.TryGetValue("estatus", out string estatus);

                                    dgvEntregas.Rows.Add(
                                        idEntrega ?? "",
                                        nombreEntrega ?? "",
                                        fechaProgramada ?? "",
                                        fechaReal ?? "",
                                        estatus ?? ""
                                    );
                                }

                                dgvEntregas.EnableHeadersVisualStyles = false;
                                dgvEntregas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                                dgvEntregas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                                dgvEntregas.GridColor = Color.Black;
                            }
                            else
                            {
                                // datosJson es JSON pero no corresponde a proyectos ni entregas, mostrar mensaje genérico
                                MessageBox.Show("No se pudieron interpretar los datos recibidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            // datos no es JSON, tratarlo como texto plano (ejemplo: mensaje de éxito)
                            if (!string.IsNullOrWhiteSpace(datos) && datos.Contains("Entrega registrada."))
                            {
                                MessageBox.Show("Entrega registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (cmbProyectos.SelectedValue != null &&
                                    int.TryParse(cmbProyectos.SelectedValue.ToString(), out int idProyecto))
                                {
                                    _ = CargarEntregasPorProyecto(idProyecto);
                                }

                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show(datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error procesando la respuesta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }


        private void LimpiarCampos()
        {
            txtNombreEntrega.Clear();
            dtpFecha.Value = DateTime.Today;
            cmbEstatus.SelectedIndex = -1;
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbProyectos.SelectedValue == null || string.IsNullOrWhiteSpace(txtNombreEntrega.Text))
            {
                MessageBox.Show("Llena todos los campos requeridos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevaEntrega = new
            {
                accion = "insertar_entrega",
                id_proyecto = Convert.ToInt32(cmbProyectos.SelectedValue),
                nombre_entrega = txtNombreEntrega.Text.Trim(),
                fecha_programada = dtpFecha.Value.ToString("yyyy-MM-dd"),
                estatus = cmbEstatus.SelectedItem?.ToString() ?? "Pendiente"
            };

            await ClienteWS.EnviarAsync(nuevaEntrega);
            LimpiarCampos();

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
            if (cmbProyectos.SelectedValue != null && int.TryParse(cmbProyectos.SelectedValue.ToString(), out int idProyecto))
            {
                await CargarEntregasPorProyecto(idProyecto);
            }
        }

        private void FrmEntregas_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
        }

        private async void FrmEntregas_Load(object sender, EventArgs e)
        {
            if (!Sesion.EsAsesor)
            {
                // Si es estudiante, deshabilitamos el área de registro
                btnRegistrar.Enabled = false;
                txtNombreEntrega.Enabled = false;
                dtpFecha.Enabled = false;
                cmbEstatus.Enabled = false;
            }
            else
            {
                // Asesor tiene todo habilitado
                btnRegistrar.Enabled = true;
                txtNombreEntrega.Enabled = true;
                dtpFecha.Enabled = true;
                cmbEstatus.Enabled = true;
            }

            await ClienteWS.EnviarAsync(new { accion = "proyecto_asesor" });
        }
    }
}
