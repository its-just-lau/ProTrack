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
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuestaAuditorias;
        }

        public void ManejarRespuestaAuditorias(string estado, object datos)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito")
                {
                    try
                    {
                        string json = datos.ToString();
                        var lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                        if (dgvAuditorias.Columns.Count == 0)
                        {
                            dgvAuditorias.Columns.Add("id_auditoria", "ID");
                            dgvAuditorias.Columns.Add("usuario", "Usuario");
                            dgvAuditorias.Columns.Add("accion", "Acción");
                            dgvAuditorias.Columns.Add("fecha", "Fecha");
                            dgvAuditorias.Columns.Add("descripcion", "Descripción");
                            dgvAuditorias.Columns.Add("id_proyecto", "ID Proyecto");
                        }

                        dgvAuditorias.Rows.Clear();

                        foreach (var a in lista)
                        {
                            dgvAuditorias.Rows.Add(
                                a["id_auditoria"],
                                a["usuario"],
                                a["accion"],
                                a["fecha"],
                                a["descripcion"],
                                a["id_proyecto"]
                            );
                        }

                        dgvAuditorias.Columns[0].Width = 60;
                        dgvAuditorias.Columns[1].Width = 120;
                        dgvAuditorias.Columns[2].Width = 130;
                        dgvAuditorias.Columns[3].Width = 130;
                        dgvAuditorias.Columns[4].Width = 200;
                        dgvAuditorias.Columns[5].Width = 90;

                        dgvAuditorias.EnableHeadersVisualStyles = false;
                        dgvAuditorias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 120, 180);
                        dgvAuditorias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al mostrar auditorías.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void FrmHistorial_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaAuditorias;
        }

        private async void FrmHistorial_Load(object sender, EventArgs e)
        {
            if (Sesion.EsAsesor)
            {
                await CargarAuditorias();
            }
            else
            {
                dgvAuditorias.Visible = false;
                label1.Text = "Bienvenido";
            }
        }

        public async Task CargarAuditorias()
        {
            var solicitud = new
            {
                accion = "auditoria_asesor"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }
    }
}
