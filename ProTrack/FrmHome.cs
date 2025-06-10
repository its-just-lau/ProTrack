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
        //Formularios
        FrmNewProy newProy;
        FrmNewAlumno newAlu;
        FrmViewProy viewProy;
        FrmViewAlumnos viewAlumnos;
        FrmAvances avances;
        FrmEntregas entregas;
        FrmReportes reporte1, reporte2, reporte3;
        FrmHistorial historial;

        // Estados de expansión de menús
        bool PmenuExpand = false;
        bool EmenuExpand = false;
        bool RmenuExpand = false;
        bool opc;
        public FrmHome(bool opc)
        {
            InitializeComponent();

            ClienteWS.AlRecibirMensaje += (msg) =>
            {
                Console.WriteLine("Mensaje recibido: " + msg);
            };

            ClienteWS.AlRecibirRespuestaEstado += (estado, datos) =>
            {
                Console.WriteLine($"Estado: {estado}, Datos: {datos}");
                viewProy?.ManejarRespuestaEstado(estado, datos);
                newProy?.ManejarRespuestaEstado(estado, datos);
                newAlu?.ManejarRespuestaEstado (estado, datos); 
                entregas?.ManejarRespuestaEstado(estado, datos);
            };

            viewHistorial();
            this.opc = opc;
            if ( !opc )
            {
                panAddEstu.Visible = false;
                panAsig.Visible = false;
                panAsignarProy.Visible = false;
            }
        }

        private void viewHistorial()
        {
            CerrarFormsHijos();
            if (historial == null)
            {
                historial = new FrmHistorial();
                historial.FormClosed += viewHistorial_FormClosed;
                historial.MdiParent = this;
                historial.Dock = DockStyle.Fill;
                historial.Show();
            }
            else
            {
                historial.Activate();
            }
        }

        private void viewHistorial_FormClosed(object sender, FormClosedEventArgs e)
        {
            historial = null;
        }

        // ----- Menú de Proyectos -----
        private void butProyMenu_Click(object sender, EventArgs e)
        {
            PmenuTransition.Start();
        }

        private void PmenuTransition_Tick(object sender, EventArgs e)
        {
            int tam;
            if (opc)
            {
                tam = 150;
            }
            else
            {
                tam = 100;
            }
            if (!PmenuExpand)
            {
                ProyMenu.Height += 5;
                if (ProyMenu.Height >= tam)
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
            CerrarFormsHijos();

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
            CerrarFormsHijos();
            if (viewProy == null || viewProy.IsDisposed)
            {
                viewProy = new FrmViewProy();
                viewProy.FormClosed += (s, args) => viewProy = null;  // Limpiar referencia al cerrar
                viewProy.MdiParent = this;
                viewProy.Dock = DockStyle.Fill;
                viewProy.Show();
            }
            else
            {
                // Si ya está abierto, solo traerlo al frente
                viewProy.BringToFront();
                viewProy.Focus();
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
            int tam;
            if (opc)
            {
                tam = 200;
            }
            else
            {
                tam = 100;
            }

            if (!EmenuExpand)
            {
                Emenu.Height += 5;
                if (Emenu.Height >= tam)
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
            CerrarFormsHijos();
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
                if (Rmenu.Height >= 200)
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

        //private async void button3_Click(object sender, EventArgs e) // Boton Conectar
        //{
        //    try
        //    {
        //        Config.Cargar(); // Carga IP, puerto, usuario, contraseña

        //        string url = $"ws://{Config.IP}:{Config.Puerto}";
        //        bool conectado = await ClienteWS.Conectar(url);


        //        if (conectado)
        //        {
        //            MessageBox.Show("Conexión establecida con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            // Aquí puedes habilitar botones de login, navegación, etc.
        //        }

        //        //ClienteWS.AlRecibirMensaje += ProcesarMensajeDelServidor;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al conectar: {ex.Message}");
        //    }

        //}

        //private void btnConfig_Click(object sender, EventArgs e)
        //{
        //    Configuracion config = new Configuracion();
        //    config.Show(); 
        //}

        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            var logoutAudit = new
            {
                accion = "auditoria_logout",
                datos = new
                {
                    usuario = Sesion.NombreUsuario,
                }
            };

            // Send the audit log to the server via WebSocket
            _ = ClienteWS.EnviarAsync(logoutAudit);

            Application.Exit();
            //await ClienteWS.DesconectarAsync();
        }

        //private void btnIniciarSesion_Click(object sender, EventArgs e)
        //{
        //    FRMLogin sesionVentana = new FRMLogin();
        //    sesionVentana.Show();
        //}

        private void btnNewEst_Click(object sender, EventArgs e)
        {
            CerrarFormsHijos();
            if (newAlu == null)
            {
                newAlu = new FrmNewAlumno();
                newAlu.FormClosed += newAlu_FormClosed;
                newAlu.MdiParent = this;
                newAlu.Dock = DockStyle.Fill;
                newAlu.Show();
            }
            else
            {
                newAlu.Activate();
            }
        }

        private void newAlu_FormClosed(object sender, FormClosedEventArgs e)
        {
            newAlu = null;
        }

        private void btnAvances_Click(object sender, EventArgs e)
        {
            CerrarFormsHijos();
            if (avances == null)
            {
                avances = new FrmAvances();
                avances.FormClosed += avances_FormClosed;
                avances.MdiParent = this;
                avances.Dock = DockStyle.Fill;
                avances.Show();
            }
            else
            {
                avances.Activate();
            }
        }

        private void avances_FormClosed(object sender, FormClosedEventArgs e)
        {
            avances = null;
        }

        private void btnAvProy_Click(object sender, EventArgs e)
        {
            CerrarFormsHijos();
            if (reporte1 == null)
            {
                reporte1 = new FrmReportes(1);
                reporte1.FormClosed += viewRep1_FormClosed;
                reporte1.MdiParent = this;
                reporte1.Dock = DockStyle.Fill;
                reporte1.Show();
            }
            else
            {
                reporte1.Activate();
            }
        }

        private void viewRep1_FormClosed(object sender, FormClosedEventArgs e)
        {
            reporte1 = null;
        }

        private void btnEntrProx_Click(object sender, EventArgs e)
        {
            CerrarFormsHijos();
            if (reporte2 == null)
            {
                reporte2 = new FrmReportes(2);
                reporte2.FormClosed += viewRep2_FormClosed;
                reporte2.MdiParent = this;
                reporte2.Dock = DockStyle.Fill;
                reporte2.Show();
            }
            else
            {
                reporte2.Activate();
            }
        }

        private void viewRep2_FormClosed(object sender, FormClosedEventArgs e)
        {
            reporte2 = null;
        }

        private void btnNonAv_Click(object sender, EventArgs e)
        {
            CerrarFormsHijos();
            if (reporte3 == null)
            {
                reporte3 = new FrmReportes(3);
                reporte3.FormClosed += viewRep3_FormClosed;
                reporte3.MdiParent = this;
                reporte3.Dock = DockStyle.Fill;
                reporte3.Show();
            }
            else
            {
                reporte3.Activate();
            }
        }

        private void btnEntregas_Click(object sender, EventArgs e)
        {
            CerrarFormsHijos();
            if (entregas == null)
            {
                entregas = new FrmEntregas();
                entregas.FormClosed += viewEnt_FormClosed;
                entregas.MdiParent = this;
                entregas.Dock = DockStyle.Fill;
                entregas.Show();
            }
            else
            {
                entregas.Activate();
            }
        }

        private void viewEnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            entregas = null;
        }

        private void butProyMenu_MouseEnter(object sender, EventArgs e)
        {
            butProyMenu.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void butProyMenu_MouseLeave(object sender, EventArgs e)
        {
            butProyMenu.BackColor = Color.FromArgb(35, 60, 105);
        }

        private void btnMenuEstudiantes_MouseEnter(object sender, EventArgs e)
        {
            btnMenuEstudiantes.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnMenuEstudiantes_MouseLeave(object sender, EventArgs e)
        {
            btnMenuEstudiantes.BackColor = Color.FromArgb(35, 60, 105);
        }


        private void btnAvances_MouseEnter(object sender, EventArgs e)
        {
            btnAvances.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnAvances_MouseLeave(object sender, EventArgs e)
        {
            btnAvances.BackColor = Color.FromArgb(35, 60, 105);
        }

        private void btnEntregas_MouseEnter(object sender, EventArgs e)
        {
            btnEntregas.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnEntregas_MouseLeave(object sender, EventArgs e)
        {
            btnEntregas.BackColor = Color.FromArgb(35, 60, 105);
        }

        private void butRmenu_MouseEnter(object sender, EventArgs e)
        {
            butRmenu.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void butRmenu_MouseLeave(object sender, EventArgs e)
        {
            butRmenu.BackColor = Color.FromArgb(35, 60, 105);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewHistorial();
        }

        private void btnviewProy_MouseEnter(object sender, EventArgs e)
        {
            btnviewProy.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnviewProy_MouseLeave(object sender, EventArgs e)
        {
            btnviewProy.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void btnNewProy_MouseEnter(object sender, EventArgs e)
        {
            btnNewProy.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnNewProy_MouseLeave(object sender, EventArgs e)
        {
            btnNewProy.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void btnViewEst_MouseEnter(object sender, EventArgs e)
        {
            btnViewEst.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnViewEst_MouseLeave(object sender, EventArgs e)
        {
            btnViewEst.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void btnAsigProy_Click(object sender, EventArgs e)
        {
            FrmAsiganrProy asiganrProy = new FrmAsiganrProy();
            asiganrProy.Show();
        }

        private void btnAsigProy_MouseEnter(object sender, EventArgs e)
        {
            btnAsigProy.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnAsigProy_MouseLeave(object sender, EventArgs e)
        {
            btnAsigProy.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void btnNewEst_MouseEnter(object sender, EventArgs e)
        {
            btnNewEst.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnNewEst_MouseLeave(object sender, EventArgs e)
        {
            btnNewEst.BackColor = Color.FromArgb(60, 85, 165);
        }


        private void btnAvProy_MouseEnter(object sender, EventArgs e)
        {
            btnAvProy.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnAvProy_MouseLeave(object sender, EventArgs e)
        {
            btnAvProy.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void btnEntrProx_MouseEnter(object sender, EventArgs e)
        {
            btnEntrProx.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnEntrProx_MouseLeave(object sender, EventArgs e)
        {
            btnEntrProx.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void btnNonAv_MouseEnter(object sender, EventArgs e)
        {
            btnNonAv.BackColor = Color.FromArgb(100, 130, 200);
        }

        private void btnNonAv_MouseLeave(object sender, EventArgs e)
        {
            btnNonAv.BackColor = Color.FromArgb(60, 85, 165);
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword changePassword = new FrmChangePassword();
            changePassword.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logoutAudit = new
            {
                accion = "auditoria_logout",
                datos = new
                {
                    usuario = Sesion.NombreUsuario,
                }
            };

            // Send the audit log to the server via WebSocket
            _ = ClienteWS.EnviarAsync(logoutAudit);

            Application.Restart(); // Como le hago para que corra el logout en restart?
            // Usar restart no funciona. La app deja de jalar.
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void viewRep3_FormClosed(object sender, FormClosedEventArgs e)
        {
            reporte3 = null;
        }

        private void CerrarFormsHijos()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // También limpia las referencias, por si quieres reusarlas
            newProy = null;
            newAlu = null;
            viewProy = null;
            viewAlumnos = null;
            avances = null;
            entregas = null;
            reporte1 = null;
            reporte2 = null;
            reporte3 = null;
            historial = null;
        }


    }
}