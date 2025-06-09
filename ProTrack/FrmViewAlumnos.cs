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
    public partial class FrmViewAlumnos : Form
    {
        public FrmViewAlumnos()
        {

            InitializeComponent();

            // Suscribirse al evento de respuesta del WebSocket para estudiantes
            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    if (estado == "exito")
                    {
                        try
                        {
                            // Asegurarse que datos es string JSON
                            string json = datos.ToString();

                            // Deserializar lista de estudiantes: List<Dictionary<string,string>>
                            var estudiantes = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                            if (dgvAlumnos.Columns.Count == 0)
                            {
                                dgvAlumnos.Columns.Add("id_estudiante", "ID Estudiante");
                                dgvAlumnos.Columns.Add("nombre", "Nombre");
                                dgvAlumnos.Columns.Add("carrera", "Carrera");
                                dgvAlumnos.Columns.Add("semestre", "Semestre");
                                dgvAlumnos.Columns.Add("correo", "Correo");
                            }

                            dgvAlumnos.Rows.Clear();

                            foreach (var e in estudiantes)
                            {
                                dgvAlumnos.Rows.Add(
                                    e["id_estudiante"],
                                    e["nombre"],
                                    e["carrera"],
                                    e["semestre"],
                                    e["correo"]
                                );
                            }

                            // Opcional: formato visual
                            dgvAlumnos.Columns[1].Width = 150;
                            dgvAlumnos.EnableHeadersVisualStyles = false;
                            dgvAlumnos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                            dgvAlumnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            dgvAlumnos.GridColor = Color.Black;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar los estudiantes.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };
        }

        private void FrmViewAlumnos_Activated(object sender, EventArgs e)
        {

        }

        private async void FrmViewAlumnos_Enter(object sender, EventArgs e)
        {
            var solicitud = new
            {
                accion = "listar_estudiantes"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }
    }
}
