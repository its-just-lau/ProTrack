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
                    accion = "reporte_avances_proyecto",
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
                                        if (lista.Any() && lista[0].ContainsKey("id_proyecto")) // Carga proyectos al ComboBox
                                        {
                                            cmBoxProyecto.DisplayMember = "nombre";
                                            cmBoxProyecto.ValueMember = "id_proyecto";
                                            cmBoxProyecto.DataSource = lista
                                                .Select(item => new
                                                {
                                                    nombre = item["nombre"],
                                                    id_proyecto = item["id_proyecto"]
                                                })
                                                .ToList();
                                        }
                                        else if (lista.Any() && lista[0].ContainsKey("id_avance")) // Carga avances al DataGrid
                                        {
                                            dgvReporte.Columns.Add("id_avance", "ID");
                                            dgvReporte.Columns.Add("descripcion", "Descripción");
                                            dgvReporte.Columns.Add("fecha", "Fecha");
                                            dgvReporte.Columns.Add("porcentaje_completado", "Porcentaje");

                                            foreach (var item in lista)
                                                dgvReporte.Rows.Add(item["id_avance"], item["descripcion"], item["fecha"], item["porcentaje_completado"]);
                                        }

                                        break;

                                case 2: // Entregas próximas
                                    dgvReporte.Columns.Add("nombre_entrega", "Entrega");
                                    dgvReporte.Columns.Add("fecha_programada", "Fecha Programada");
                                    dgvReporte.Columns.Add("estatus", "Estatus"); // Ya lo tienes, agrégalo visualmente también

                                    foreach (var item in lista)
                                        dgvReporte.Rows.Add(item["nombre_entrega"], item["fecha_programada"], item["estatus"]);
                                    dgvReporte.Columns[0].Width = 315;
                                    dgvReporte.Columns[1].Width = 135;
                                    dgvReporte.Columns[2].Width = 135;

                                    break;

                                case 3: // Proyectos sin avances recientes
                                    dgvReporte.Columns.Add("id_proyecto", "ID Proyecto");
                                    dgvReporte.Columns.Add("nombre", "Nombre");
                                    dgvReporte.Columns.Add("descripcion", "Descripción");
                                    dgvReporte.Columns.Add("estatus", "Estatus");

                                    foreach (var item in lista)
                                        dgvReporte.Rows.Add(item["id_proyecto"], item["nombre"], item["descripcion"], item["estatus"]);

                                    dgvReporte.Columns[0].Width = 55;
                                    dgvReporte.Columns[1].Width = 200;
                                    dgvReporte.Columns[2].Width = 260;
                                    dgvReporte.Columns[3].Width = 100;

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

        public async Task CargarProyectos()
        {
            var solicitud = new
            {
                accion = "proyecto_asesor"
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
                case 1:
                    await CargarProyectos();
                    break;
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
