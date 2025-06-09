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

            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    if (estado == "exito")
                    {
                        try
                        {
                            string json = datos.ToString();
                            var entregas = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                            if (dgvEntregas.Columns.Count == 0)
                            {
                                dgvEntregas.Columns.Add("id_entrega", "ID Entrega");
                                dgvEntregas.Columns.Add("nombre_entrega", "Nombre");
                                dgvEntregas.Columns.Add("fecha_programada", "Fecha Programada");
                                dgvEntregas.Columns.Add("fecha_real", "Fecha Real");
                                dgvEntregas.Columns.Add("estatus", "Estatus");
                            }

                            dgvEntregas.Rows.Clear();

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
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar las entregas.\n" + ex.Message);
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };
        }

        public async Task CargarEntregas(int idProyecto)
        {
            var solicitud = new
            {
                accion = "listar_entregas",
                id_proyecto = idProyecto
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
