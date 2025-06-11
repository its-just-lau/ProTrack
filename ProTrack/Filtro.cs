using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProTrack
{
    public partial class Filtro : Form
    {
        public Filtro()
        {
            InitializeComponent();
            toolTip.SetToolTip(txtClave, "La clave es proporcionado por su respectivo directivo");
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == "itlalaguna13")
            {
                FrmNewAsesor NewAsesor = new FrmNewAsesor();
                NewAsesor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Clave incorrecta vuelva a intentarlo","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void chBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxMostrar.Checked)
            {
                txtClave.PasswordChar = '\0';
            }
            else
            {
                txtClave.PasswordChar = '•';
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
