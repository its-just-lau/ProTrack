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
using Newtonsoft.Json.Linq;
using ProTrack;

namespace ProTrack
{
    public partial class FrmAsiganrProy : Form
    {
        public FrmAsiganrProy()
        {
            InitializeComponent();
        }

        private async void FrmAsiganrProy_Load(object sender, EventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuesta;

            await ClienteWS.EnviarAsync(new { accion = "listar_estudiantes" });
            await ClienteWS.EnviarAsync(new { accion = "listar_proyectos_asesor" });

        }

        private void ManejarRespuesta(string estado, object datos)
        {
            if (this.IsDisposed) return;

            this.Invoke((MethodInvoker)(() =>
            {
                if (estado == "exito")
                {
                    List<Dictionary<string, string>> lista = null;

                    try
                    {
                        if (datos is JArray jArray)
                        {
                            lista = jArray.ToObject<List<Dictionary<string, string>>>();
                        }
                        else if (datos is string jsonString)
                        {
                            // Intentar deserializar solo si parece JSON (empieza con [ o {)
                            jsonString = jsonString.Trim();
                            if (jsonString.StartsWith("[") || jsonString.StartsWith("{"))
                            {
                                lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
                            }
                            else
                            {
                                // No es JSON, mostrar mensaje o ignorar
                                MessageBox.Show(jsonString, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            var json = JsonConvert.SerializeObject(datos);
                            lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (lista == null || lista.Count == 0)
                    {
                        MessageBox.Show("No se recibieron datos.");
                        return;
                    }

                    if (lista[0].ContainsKey("id_estudiante"))
                    {
                        var estudiantes = lista
                            .Select(e => new
                            {
                                id_estudiante = e["id_estudiante"],
                                nombre = e["nombre"]
                            })
                            .ToList();

                        cbxEstudiantes.DataSource = estudiantes;
                        cbxEstudiantes.DisplayMember = "nombre";
                        cbxEstudiantes.ValueMember = "id_estudiante";
                    }
                    else if (lista[0].ContainsKey("id_proyecto"))
                    {
                        var proyectos = lista
                            .Select(p => new
                            {
                                id_proyecto = p["id_proyecto"],
                                nombre = p["nombre"]
                            })
                            .ToList();

                        cbxProyectos.DataSource = proyectos;
                        cbxProyectos.DisplayMember = "nombre";
                        cbxProyectos.ValueMember = "id_proyecto";
                    }
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }


        private void FrmAsiganrProy_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuesta;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (cbxEstudiantes.SelectedItem is null || cbxProyectos.SelectedItem is null)
            {
                MessageBox.Show("Selecciona un estudiante y un proyecto.");
                return;
            }

            int idEst = Convert.ToInt32(cbxEstudiantes.SelectedValue);
            int idProy = Convert.ToInt32(cbxProyectos.SelectedValue);

            var solicitud = new
            {
                accion = "asignar_proyecto_estudiante",
                datos = new
                {
                    id_estudiante = idEst,
                    id_proyecto = idProy
                }
            };

            await ClienteWS.EnviarAsync(solicitud);
        }
    }
}
