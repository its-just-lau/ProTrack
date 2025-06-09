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

            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    if (estado == "exito")
                    {
                        try
                        {
                            string json = datos.ToString();
                            var estudiantes = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                            if (dgvEstudiantes.Columns.Count == 0)
                            {
                                dgvEstudiantes.Columns.Add("id_estudiante", "ID Estudiante");
                                dgvEstudiantes.Columns.Add("nombre", "Nombre");
                                dgvEstudiantes.Columns.Add("carrera", "Carrera");
                                dgvEstudiantes.Columns.Add("semestre", "Semestre");
                                dgvEstudiantes.Columns.Add("correo", "Correo");
                            }

                            dgvEstudiantes.Rows.Clear();

                            foreach (var est in estudiantes)
                            {
                                dgvEstudiantes.Rows.Add(
                                    est["id_estudiante"],
                                    est["nombre"],
                                    est["carrera"],
                                    est["semestre"],
                                    est["correo"]
                                );
                            }

                            dgvEstudiantes.EnableHeadersVisualStyles = false;
                            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 200);
                            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                            dgvEstudiantes.GridColor = Color.Black;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar los estudiantes.\n" + ex.Message);
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            };
        }

        public async Task CargarEstudiantes(int idProyecto)
        {
            var solicitud = new
            {
                accion = "listar_estudiantes",
                id_proyecto = idProyecto
            };

            await ClienteWS.EnviarAsync(solicitud);
        }
    }
}
