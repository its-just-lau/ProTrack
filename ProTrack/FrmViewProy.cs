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

            // Suscribirse al evento de respuesta del WebSocket
            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    if (estado == "exito")
                    {
                        try
                        {
                            // Asegurarse de que datos es string
                            string json = datos.ToString();

                            // Deserializar lista de proyectos
                            var proyectos = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

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
                                    p["id_proyecto"],
                                    p["nombre"],
                                    p["descripcion"],
                                    p["fecha_inicio"],
                                    p["fecha_estimada_entrega"],
                                    p["estatus"]
                                );
                            }

                            dgvProy.Columns[1].Width = 153;
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
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };
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

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
