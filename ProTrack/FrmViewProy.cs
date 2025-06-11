using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProTrack
{
    public partial class FrmViewProy : Form
    {
        public FrmViewProy()
        {
            InitializeComponent();

            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuestaEstado;

            // Suscribirse al evento de respuesta del WebSocket
            //ClienteWS.AlRecibirRespuestaEstado += ClienteWS_RespuestaProyectos;

            //// Desuscribirse cuando se cierre
            //this.FormClosed += FrmViewProy_FormClosed;
        }

        public async Task CargarProyectosAsesor()
        {
            var solicitud = new
            {
                accion = "listar_proyectos_asesor"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        public async Task CargarProyectosAlumno()
        {
            var solicitud = new
            {
                accion = "listar_proyectos_alumno"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        private async void FrmViewProy_Load(object sender, EventArgs e)
        {
            if (Sesion.EsAsesor)
            {
                await CargarProyectosAsesor();
            }
            else if (Sesion.EsEstudiante)
            {
                await CargarProyectosAlumno();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            
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
                        // Si 'datos' ya viene como JArray o List<object>, primero lo convertimos a JSON string
                        string json;

                        if (datos is JToken jtoken)
                        {
                            json = jtoken.ToString(Formatting.None);
                        }
                        else if (datos is string str)
                        {
                            json = str;
                        }
                        else
                        {
                            // Intentamos serializar el objeto recibido
                            json = JsonConvert.SerializeObject(datos);
                        }

                        var proyectos = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                        if (proyectos == null)
                        {
                            MessageBox.Show("No se encontraron proyectos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Agregar columnas sólo si no existen
                        if (dgvProy.Columns.Count == 0)
                        {
                            dgvProy.Columns.Add("id_proyecto", "ID Proyecto");
                            dgvProy.Columns.Add("nombre", "Nombre");
                            dgvProy.Columns.Add("descripcion", "Descripción");
                            dgvProy.Columns.Add("fecha_inicio", "Fecha Inicio");
                            dgvProy.Columns.Add("fecha_estimada_entrega", "Fecha Estimada Entrega");
                            dgvProy.Columns.Add("estatus", "Estatus");
                        }

                        dgvProy.Rows.Clear();

                        foreach (var p in proyectos)
                        {
                            dgvProy.Rows.Add(
                                p.TryGetValue("id_proyecto", out var idProyecto) ? idProyecto : "",
                                p.TryGetValue("nombre", out var nombre) ? nombre : "",
                                p.TryGetValue("descripcion", out var descripcion) ? descripcion : "",
                                p.TryGetValue("fecha_inicio", out var fechaInicio) ? fechaInicio : "",
                                p.TryGetValue("fecha_estimada_entrega", out var fechaEstimada) ? fechaEstimada : "",
                                p.TryGetValue("estatus", out var estatus) ? estatus : ""
                            );
                        }

                        dgvProy.Columns[0].Width = 55;
                        dgvProy.Columns[1].Width = 145;
                        dgvProy.EnableHeadersVisualStyles = false;
                        dgvProy.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                        dgvProy.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                        dgvProy.GridColor = Color.Black;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los proyectos.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos?.ToString() ?? "Error desconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }


        private void FrmViewProy_FormClosed(object sender   , FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;

        }
    }
}
