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
    public partial class FrmReportes : Form
    {
        int opc;
        public FrmReportes(int opc)
        {
            InitializeComponent();
            this.opc = opc;
            if (opc == 1)
            {
                labProyecto.Visible = true;
                cmBoxProyecto.Visible= true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
