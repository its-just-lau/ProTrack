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
using ProTrack;

namespace ProTrack
{
    public partial class FRMLogin : Form
    {

        private bool loginRealizado = false;

        public FRMLogin()
        {
            InitializeComponent();

            txtUsuario.Focus();
            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                // Solo chequeamos estado "login_ok", "login_fail" o "login_error" para el login
                if (estado.StartsWith("login") && loginRealizado)
                {
                    // Ya inició sesión, no procesar más logins
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Ya has iniciado sesión.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    return;
                }

                if (estado.StartsWith("login"))
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (estado == "login_ok")
                        {
                            loginRealizado = true;

                            var info = JsonConvert.DeserializeObject<Dictionary<string, string>>(datos);

                            if (info != null)
                            {
                                if (info.TryGetValue("id_usuario", out string idStr) &&
                                    int.TryParse(idStr, out int idUsuario))
                                {
                                    Sesion.IdUsuario = idUsuario;
                                }
                                if (info.TryGetValue("nombre_usuario", out string nombreUsuario))
                                {
                                    Sesion.NombreUsuario = nombreUsuario;
                                }
                                if (info.TryGetValue("rol", out string rol))
                                {
                                    Sesion.Rol = rol;
                                }
                            }

                            MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Sesion.Rol == "ASESOR")
                            {
                                // Mostrar menú principal para asesor
                                FrmHome home = new FrmHome(true);
                                home.Show();
                                this.Hide();
                            }
                            else if (Sesion.Rol == "ESTUDIANTE")
                            {
                                // Mostrar menú principal para estudiante
                                FrmHome home = new FrmHome(false);
                                home.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Rol no reconocido: " + Sesion.Rol, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            // Aquí abre el formulario principal o cierra el login, etc.
                        }
                        else if (estado == "login_fail" || estado == "login_error")
                        {
                            MessageBox.Show("Credenciales inválidas", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }));
                }
                else
                {
                    // Aquí podrías manejar otros estados no relacionados con login si quieres
                }
            };


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ClienteWS.EstaConectado)
            {
                MessageBox.Show("No estás conectado al servidor.");
                return;
            }

            var mensajeLogin = new
            {
                accion = "login",
                datos = new
                {
                    usuario = txtUsuario.Text.Trim(),
                    contrasena = txtContraseña.Text.Trim()
                }
            };

            await ClienteWS.EnviarAsync(mensajeLogin);

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(100, 130, 200);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(60, 85, 165);
        }

        private void chBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxMostrar.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '•';
            }
        }

        public void Clear()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Focus();
            chBoxMostrar.Checked = false;
        }
    }
}
