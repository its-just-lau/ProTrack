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

namespace ProTrack
{
    public partial class FrmAvances : Form
    {
        public FrmAvances()
        {
            InitializeComponent();
            ClienteWS.AlRecibirRespuestaEstado += ManejarRespuestaEstado;
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            var solicitud = new
            {
                accion = "listar_avances"
            };

            await ClienteWS.EnviarAsync(solicitud);
        }

        private async void FrmAvances_Load(object sender, EventArgs e)
        {
            await ClienteWS.EnviarAsync(new { accion = "listar_proyectos_alumno" });
        }

        private void FrmAvances_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClienteWS.AlRecibirRespuestaEstado -= ManejarRespuestaEstado;
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
                        List<Dictionary<string, string>> lista = null;

                        if (datos is JArray jArray)
                        {
                            lista = jArray.ToObject<List<Dictionary<string, string>>>();
                        }
                        else if (datos is string jsonString)
                        {
                            jsonString = jsonString.Trim();
                            if (jsonString.StartsWith("[") || jsonString.StartsWith("{"))
                            {
                                lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
                            }
                            else
                            {
                                MessageBox.Show(jsonString, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            var json = JsonConvert.SerializeObject(datos);
                            lista = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                        }

                        if (lista == null || lista.Count == 0)
                        {
                            MessageBox.Show("No se recibieron datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Aquí creamos una lista de objetos anónimos con propiedades para el ComboBox
                        var proyectosAnon = lista.Select(d => new
                        {
                            id_proyecto = d.ContainsKey("id_proyecto") ? d["id_proyecto"] : "",
                            nombre = d.ContainsKey("nombre") ? d["nombre"] : ""
                        }).ToList();

                        cbxProyectos.DataSource = proyectosAnon;
                        cbxProyectos.DisplayMember = "nombre";
                        cbxProyectos.ValueMember = "id_proyecto";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar la respuesta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (estado == "error")
                {
                    MessageBox.Show(datos.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }



    }
}
