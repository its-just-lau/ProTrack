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
            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuestaEstado;
        }

        public async Task CargarEstudiantes()
        {
            var solicitud = new
            {
                accion = "listar_estudiantes",
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        private async void FrmViewAlumnos_Load(object sender, EventArgs e)
        {
            if (Sesion.EsAsesor)
            {
                await CargarEstudiantes();
            }
            else if (Sesion.EsEstudiante)
            {
                await CargarEstudiantes(); // Hacer una funcion exclusiva para los estudiantes???
            }
        }

        public void ManejarRespuestaEstado(string estado, object datos)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito")
                {
                    try
                    {
                        string json = datos.ToString();
                        var lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

                        if (dgvEstudiantes.Columns.Count == 0)
                        {
                            dgvEstudiantes.Columns.Add("id_estudiante", "ID");
                            dgvEstudiantes.Columns.Add("nombre", "Nombre");
                            dgvEstudiantes.Columns.Add("carrera", "Carrera");
                            dgvEstudiantes.Columns.Add("semestre", "Semestre");
                            dgvEstudiantes.Columns.Add("correo", "Correo");
                        }

                        dgvEstudiantes.Rows.Clear();

                        foreach (var e in lista)
                        {
                            dgvEstudiantes.Rows.Add(
                                e["id_estudiante"],
                                e["nombre"],
                                e["carrera"],
                                e["semestre"],
                                e["correo"]
                            );
                        }

                        dgvEstudiantes.Columns[0].Width = 55;
                        dgvEstudiantes.Columns[1].Width = 145;
                        dgvEstudiantes.EnableHeadersVisualStyles = false;
                        dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 120, 180);
                        dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al mostrar estudiantes.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void FrmViewAlumnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
        }
    }
}
