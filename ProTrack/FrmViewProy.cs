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

namespace ProTrack
{
    public partial class FrmViewProy : Form
    {
        public FrmViewProy()
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
                            var proyectos = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(datos);

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
                        }
                        catch
                        {
                            MessageBox.Show("Error al procesar los proyectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (estado == "error")
                    {
                        MessageBox.Show(datos, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
