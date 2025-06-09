using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProTrack;

namespace ProTrack
{
    public partial class FrmHome : Form
    {
        FrmNewProy newProy;
        FrmViewProy viewProy;
        FrmViewAlumnos viewAlumnos;
        FrmViewAsesores viewAsesores;

        // Estados de expansión de menús
        bool PmenuExpand = false;
        bool EmenuExpand = false;
        bool RmenuExpand = false;
        bool AmenuExpand = false;

        public FrmHome()
        {
            InitializeComponent();

            ClienteWS.AlRecibirMensaje += (msg) =>
            {
                Console.WriteLine("Mensaje recibido: " + msg);
            };

            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                Console.WriteLine($"Estado: {estado}, Datos: {datos}");
            };
        }

        // ----- Menú de Proyectos -----
        private void butProyMenu_Click(object sender, EventArgs e)
        {
            PmenuTransition.Start();
        }

        private void PmenuTransition_Tick(object sender, EventArgs e)
        {
            if (!PmenuExpand)
            {
                ProyMenu.Height += 5;
                if (ProyMenu.Height >= 150)
                {
                    PmenuTransition.Stop();
                    PmenuExpand = true;
                }
            }
            else
            {
                ProyMenu.Height -= 5;
                if (ProyMenu.Height <= 50)
                {
                    PmenuTransition.Stop();
                    PmenuExpand = false;
                }
            }
        }

        private void btnNewProy_Click(object sender, EventArgs e)
        {
            // Lo comento pq si no tienen acceso a la base de datos, no pueden meterse jajksdjaskjdjasd
            //if (!Sesion.EsAsesor)
            //{
            //    MessageBox.Show("No tienes permiso para crear proyectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (newProy == null)
            {
                newProy = new FrmNewProy();
                newProy.FormClosed += newProy_FormClosed;
                newProy.MdiParent = this;
                newProy.Dock = DockStyle.Fill;
                newProy.Show();
            }
            else
            {
                newProy.Activate();
            }
        }

        private void newProy_FormClosed(object sender, FormClosedEventArgs e)
        {
            newProy = null;
        }

        private void btnviewProy_Click(object sender, EventArgs e)
        {
            if (viewProy == null)
            {
                viewProy = new FrmViewProy();
                viewProy.FormClosed += viewProy_FormClosed;
                viewProy.MdiParent = this;
                viewProy.Dock = DockStyle.Fill;
                viewProy.Show();
            }
            else
            {
                viewProy.Activate();
            }
        }

        private void viewProy_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewProy = null;
        }

        // ----- Menú de Estudiantes -----
        private void button2_Click(object sender, EventArgs e)
        {
            EmenuTransition.Start();
        }

        private void EmenuTransition_Tick(object sender, EventArgs e)
        {
            if (!EmenuExpand)
            {
                Emenu.Height += 5;
                if (Emenu.Height >= 200)
                {
                    EmenuTransition.Stop();
                    EmenuExpand = true;
                }
            }
            else
            {
                Emenu.Height -= 5;
                if (Emenu.Height <= 50)
                {
                    EmenuTransition.Stop();
                    EmenuExpand = false;
                }
            }
        }

        private void btnViewEst_Click(object sender, EventArgs e)
        {
            if (viewAlumnos == null)
            {
                viewAlumnos = new FrmViewAlumnos();
                viewAlumnos.FormClosed += viewEstu_FormClosed;
                viewAlumnos.MdiParent = this;
                viewAlumnos.Dock = DockStyle.Fill;
                viewAlumnos.Show();
            }
            else
            {
                viewAlumnos.Activate();
            }
        }

        private void viewEstu_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewAlumnos = null;
        }

        // ----- Menú de Reportes -----
        private void butRmenu_Click(object sender, EventArgs e)
        {
            RmenuTransition.Start();
        }

        private void RmenuTransition_Tick(object sender, EventArgs e)
        {
            if (!RmenuExpand)
            {
                Rmenu.Height += 5;
                if (Rmenu.Height >= 250)
                {
                    RmenuTransition.Stop();
                    RmenuExpand = true;
                }
            }
            else
            {
                Rmenu.Height -= 5;
                if (Rmenu.Height <= 50)
                {
                    RmenuTransition.Stop();
                    RmenuExpand = false;
                }
            }
        }

        // ----- Menú de Administración -----
        private void btnAmenu_Click(object sender, EventArgs e)
        {
            AmenuTransition.Start();
        }

        private void AmenuTransition_Tick(object sender, EventArgs e)
        {
            if (!AmenuExpand)
            {
                Amenu.Height += 5;
                if (Amenu.Height >= 150)
                {
                    AmenuTransition.Stop();
                    AmenuExpand = true;
                }
            }
            else
            {
                Amenu.Height -= 5;
                if (Amenu.Height <= 50)
                {
                    AmenuTransition.Stop();
                    AmenuExpand = false;
                }
            }
        }

        private void btnViewAse_Click(object sender, EventArgs e)
        {
            if (viewAsesores == null)
            {
                viewAsesores = new FrmViewAsesores();
                viewAsesores.FormClosed += viewAse_FormClosed;
                viewAsesores.MdiParent = this;
                viewAsesores.Dock = DockStyle.Fill;
                viewAsesores.Show();
            }
            else
            {
                viewAsesores.Activate();
            }
        }

        private void viewAse_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewAsesores = null;
        }

        private async void button3_Click(object sender, EventArgs e) // Boton Conectar
        {
            try
            {
                Config.Cargar(); // Carga IP, puerto, usuario, contraseña

                string url = $"ws://{Config.IP}:{Config.Puerto}";
                bool conectado = await ClienteWS.Conectar(url);


                if (conectado)
                {
                    MessageBox.Show("Conexión establecida con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aquí puedes habilitar botones de login, navegación, etc.
                }

                //ClienteWS.AlRecibirMensaje += ProcesarMensajeDelServidor;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}");
            }

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion();
            config.Show(); 
        }

        private async void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            await ClienteWS.DesconectarAsync();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            FRMLogin sesionVentana = new FRMLogin();
            sesionVentana.Show();
        }
    }
}
