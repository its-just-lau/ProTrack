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
    public partial class FrmAvances : Form
    {
        public FrmAvances()
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
                            var avances = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                            if (dgvAvances.Columns.Count == 0)
                            {
                                dgvAvances.Columns.Add("id_avance", "ID Avance");
                                dgvAvances.Columns.Add("descripcion", "Descripción");
                                dgvAvances.Columns.Add("fecha_registro", "Fecha Registro");
                                dgvAvances.Columns.Add("porcentaje_completado", "% Completado");
                            }

                            dgvAvances.Rows.Clear();

                            foreach (var a in avances)
                            {
                                dgvAvances.Rows.Add(
                                    a["id_avance"],
                                    a["descripcion"],
                                    a["fecha_registro"],
                                    a["porcentaje_completado"]
                                );
                            }

                            dgvAvances.EnableHeadersVisualStyles = false;
                            dgvAvances.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                            dgvAvances.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            dgvAvances.GridColor = Color.Black;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar los avances.\n" + ex.Message);
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };
        }

        public async Task CargarAvances(int idProyecto)
        {
            var solicitud = new
            {
                accion = "listar_avances",
                id_proyecto = idProyecto
            };

            await ClienteWS.EnviarAsync(solicitud);
        }
    }
}
