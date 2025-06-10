using System;
using System.Collections;
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
    public partial class FrmReportes : Form
    {
        int opc;
        public FrmReportes(int opc)
        {
            this.opc = opc;
            InitializeComponent();
            if (opc == 1)
            {
                labProyecto.Visible = true;
                cmBoxProyecto.Visible = true;
            }

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBoxProyecto.SelectedValue != null)
            {
                int idProyecto = Convert.ToInt32(cmBoxProyecto.SelectedValue);
                await ClienteWS.EnviarAsync(new
                {
                    accion = "reporte_avances_por_proyecto",
                    id_proyecto = idProyecto
                });
            }
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
                            string json = datos.ToString();
                            var lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                            dgvReporte.Rows.Clear();
                            dgvReporte.Columns.Clear();

                            switch (opc)
                            {
                                case 1: // Avances por proyecto
                                    dgvReporte.Columns.Add("id_avance", "ID");
                                    dgvReporte.Columns.Add("descripcion", "Descripción");
                                    dgvReporte.Columns.Add("fecha", "Fecha");
                                    dgvReporte.Columns.Add("estatus", "Estatus");

                                    foreach (var item in lista)
                                        dgvReporte.Rows.Add(item["id_avance"], item["descripcion"], item["fecha"], item["estatus"]);
                                    break;

                                case 2: // Entregas próximas
                                    dgvReporte.Columns.Add("id_entrega", "ID");
                                    dgvReporte.Columns.Add("nombre_entrega", "Entrega");
                                    dgvReporte.Columns.Add("fecha_programada", "Fecha Programada");
                                    dgvReporte.Columns.Add("proyecto", "Proyecto");

                                    foreach (var item in lista)
                                        dgvReporte.Rows.Add(item["id_entrega"], item["nombre_entrega"], item["fecha_programada"], item["proyecto"]);
                                    break;

                                case 3: // Proyectos sin avances recientes
                                    dgvReporte.Columns.Add("id_proyecto", "ID Proyecto");
                                    dgvReporte.Columns.Add("nombre", "Nombre");
                                    dgvReporte.Columns.Add("descripcion", "Descripción");
                                    dgvReporte.Columns.Add("estatus", "Estatus");

                                    foreach (var item in lista)
                                        dgvReporte.Rows.Add(item["id_proyecto"], item["nombre"], item["descripcion"], item["estatus"]);
                                    break;
                            }

                            dgvReporte.EnableHeadersVisualStyles = false;
                            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            dgvReporte.GridColor = Color.Black;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar los datos.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
        }

        public async Task CargarEntregasProximas()
        {
            var solicitud = new
            {
                accion = "reporte_entregas_proximas"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        public async Task CargarProyectosSinAvances()
        {
            var solicitud = new
            {
                accion = "reporte_proyectos_sin_avances"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            switch (opc)
            {
                case 2:
                    await CargarEntregasProximas();
                    break;
                case 3:
                    await CargarProyectosSinAvances();
                    break;
            }
        }

        private void FrmReportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
        }
    }
}
