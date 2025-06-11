namespace ProTrack
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProyMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butProyMenu = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnviewProy = new System.Windows.Forms.Button();
            this.panAsignarProy = new System.Windows.Forms.Panel();
            this.btnNewProy = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMenuEstudiantes = new System.Windows.Forms.Button();
            this.panAvances = new System.Windows.Forms.Panel();
            this.btnAvances = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnEntregas = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.butRmenu = new System.Windows.Forms.Button();
            this.PmenuTransition = new System.Windows.Forms.Timer(this.components);
            this.Emenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnViewEst = new System.Windows.Forms.Button();
            this.panAsig = new System.Windows.Forms.Panel();
            this.btnAsigProy = new System.Windows.Forms.Button();
            this.panAddEstu = new System.Windows.Forms.Panel();
            this.btnNewEst = new System.Windows.Forms.Button();
            this.EmenuTransition = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.Rmenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnAvProy = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnEntrProx = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnNonAv = new System.Windows.Forms.Button();
            this.RmenuTransition = new System.Windows.Forms.Timer(this.components);
            this.panel19 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProyMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panAsignarProy.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panAvances.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.Emenu.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panAsig.SuspendLayout();
            this.panAddEstu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Rmenu.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel19.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProyMenu
            // 
            this.ProyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.ProyMenu.Controls.Add(this.panel1);
            this.ProyMenu.Controls.Add(this.panel7);
            this.ProyMenu.Controls.Add(this.panAsignarProy);
            this.ProyMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProyMenu.Location = new System.Drawing.Point(3, 85);
            this.ProyMenu.Name = "ProyMenu";
            this.ProyMenu.Size = new System.Drawing.Size(250, 50);
            this.ProyMenu.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butProyMenu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 50);
            this.panel1.TabIndex = 2;
            // 
            // butProyMenu
            // 
            this.butProyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.butProyMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butProyMenu.ForeColor = System.Drawing.Color.White;
            this.butProyMenu.Image = global::ProTrack.Properties.Resources.mdi__book_education_outline__1_;
            this.butProyMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butProyMenu.Location = new System.Drawing.Point(-19, -27);
            this.butProyMenu.Name = "butProyMenu";
            this.butProyMenu.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.butProyMenu.Size = new System.Drawing.Size(291, 102);
            this.butProyMenu.TabIndex = 3;
            this.butProyMenu.Text = "            Proyectos";
            this.butProyMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butProyMenu.UseVisualStyleBackColor = false;
            this.butProyMenu.Click += new System.EventHandler(this.butProyMenu_Click);
            this.butProyMenu.MouseEnter += new System.EventHandler(this.butProyMenu_MouseEnter);
            this.butProyMenu.MouseLeave += new System.EventHandler(this.butProyMenu_MouseLeave);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.panel7.Controls.Add(this.btnviewProy);
            this.panel7.Location = new System.Drawing.Point(0, 50);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(250, 50);
            this.panel7.TabIndex = 4;
            // 
            // btnviewProy
            // 
            this.btnviewProy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnviewProy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewProy.ForeColor = System.Drawing.Color.White;
            this.btnviewProy.Image = global::ProTrack.Properties.Resources.mdi__application;
            this.btnviewProy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewProy.Location = new System.Drawing.Point(-19, -27);
            this.btnviewProy.Name = "btnviewProy";
            this.btnviewProy.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnviewProy.Size = new System.Drawing.Size(291, 102);
            this.btnviewProy.TabIndex = 3;
            this.btnviewProy.Text = "            Ver proyectos";
            this.btnviewProy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewProy.UseVisualStyleBackColor = false;
            this.btnviewProy.Click += new System.EventHandler(this.btnviewProy_Click);
            this.btnviewProy.MouseEnter += new System.EventHandler(this.btnviewProy_MouseEnter);
            this.btnviewProy.MouseLeave += new System.EventHandler(this.btnviewProy_MouseLeave);
            // 
            // panAsignarProy
            // 
            this.panAsignarProy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.panAsignarProy.Controls.Add(this.btnNewProy);
            this.panAsignarProy.Location = new System.Drawing.Point(0, 100);
            this.panAsignarProy.Margin = new System.Windows.Forms.Padding(0);
            this.panAsignarProy.Name = "panAsignarProy";
            this.panAsignarProy.Size = new System.Drawing.Size(250, 50);
            this.panAsignarProy.TabIndex = 5;
            // 
            // btnNewProy
            // 
            this.btnNewProy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnNewProy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProy.ForeColor = System.Drawing.Color.White;
            this.btnNewProy.Image = global::ProTrack.Properties.Resources.mdi__book_plus_outline;
            this.btnNewProy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewProy.Location = new System.Drawing.Point(-19, -27);
            this.btnNewProy.Name = "btnNewProy";
            this.btnNewProy.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNewProy.Size = new System.Drawing.Size(291, 102);
            this.btnNewProy.TabIndex = 3;
            this.btnNewProy.Text = "            Agregar nuevo";
            this.btnNewProy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewProy.UseVisualStyleBackColor = false;
            this.btnNewProy.Click += new System.EventHandler(this.btnNewProy_Click);
            this.btnNewProy.MouseEnter += new System.EventHandler(this.btnNewProy_MouseEnter);
            this.btnNewProy.MouseLeave += new System.EventHandler(this.btnNewProy_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMenuEstudiantes);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 50);
            this.panel2.TabIndex = 3;
            // 
            // btnMenuEstudiantes
            // 
            this.btnMenuEstudiantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.btnMenuEstudiantes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuEstudiantes.ForeColor = System.Drawing.Color.White;
            this.btnMenuEstudiantes.Image = global::ProTrack.Properties.Resources.mdi__account_student;
            this.btnMenuEstudiantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuEstudiantes.Location = new System.Drawing.Point(-19, -27);
            this.btnMenuEstudiantes.Name = "btnMenuEstudiantes";
            this.btnMenuEstudiantes.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnMenuEstudiantes.Size = new System.Drawing.Size(291, 102);
            this.btnMenuEstudiantes.TabIndex = 3;
            this.btnMenuEstudiantes.Text = "            Estudiantes";
            this.btnMenuEstudiantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuEstudiantes.UseVisualStyleBackColor = false;
            this.btnMenuEstudiantes.Click += new System.EventHandler(this.button2_Click);
            this.btnMenuEstudiantes.MouseEnter += new System.EventHandler(this.btnMenuEstudiantes_MouseEnter);
            this.btnMenuEstudiantes.MouseLeave += new System.EventHandler(this.btnMenuEstudiantes_MouseLeave);
            // 
            // panAvances
            // 
            this.panAvances.Controls.Add(this.btnAvances);
            this.panAvances.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panAvances.Location = new System.Drawing.Point(3, 253);
            this.panAvances.Name = "panAvances";
            this.panAvances.Size = new System.Drawing.Size(250, 50);
            this.panAvances.TabIndex = 5;
            // 
            // btnAvances
            // 
            this.btnAvances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.btnAvances.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvances.ForeColor = System.Drawing.Color.White;
            this.btnAvances.Image = global::ProTrack.Properties.Resources.mdi__graph_line;
            this.btnAvances.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvances.Location = new System.Drawing.Point(-19, -27);
            this.btnAvances.Name = "btnAvances";
            this.btnAvances.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAvances.Size = new System.Drawing.Size(291, 102);
            this.btnAvances.TabIndex = 3;
            this.btnAvances.Text = "            Avances";
            this.btnAvances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvances.UseVisualStyleBackColor = false;
            this.btnAvances.Click += new System.EventHandler(this.btnAvances_Click);
            this.btnAvances.MouseEnter += new System.EventHandler(this.btnAvances_MouseEnter);
            this.btnAvances.MouseLeave += new System.EventHandler(this.btnAvances_MouseLeave);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnEntregas);
            this.panel5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 197);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(250, 50);
            this.panel5.TabIndex = 6;
            // 
            // btnEntregas
            // 
            this.btnEntregas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.btnEntregas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregas.ForeColor = System.Drawing.Color.White;
            this.btnEntregas.Image = global::ProTrack.Properties.Resources.mdi__package_variant_closed_delivered;
            this.btnEntregas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntregas.Location = new System.Drawing.Point(-19, -27);
            this.btnEntregas.Name = "btnEntregas";
            this.btnEntregas.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEntregas.Size = new System.Drawing.Size(291, 102);
            this.btnEntregas.TabIndex = 3;
            this.btnEntregas.Text = "            Entregas";
            this.btnEntregas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntregas.UseVisualStyleBackColor = false;
            this.btnEntregas.Click += new System.EventHandler(this.btnEntregas_Click);
            this.btnEntregas.MouseEnter += new System.EventHandler(this.btnEntregas_MouseEnter);
            this.btnEntregas.MouseLeave += new System.EventHandler(this.btnEntregas_MouseLeave);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butRmenu);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(250, 50);
            this.panel6.TabIndex = 7;
            // 
            // butRmenu
            // 
            this.butRmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.butRmenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRmenu.ForeColor = System.Drawing.Color.White;
            this.butRmenu.Image = global::ProTrack.Properties.Resources.mdi__report_bar;
            this.butRmenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRmenu.Location = new System.Drawing.Point(-19, -27);
            this.butRmenu.Name = "butRmenu";
            this.butRmenu.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.butRmenu.Size = new System.Drawing.Size(291, 102);
            this.butRmenu.TabIndex = 3;
            this.butRmenu.Text = "            Reportes";
            this.butRmenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRmenu.UseVisualStyleBackColor = false;
            this.butRmenu.Click += new System.EventHandler(this.butRmenu_Click);
            this.butRmenu.MouseEnter += new System.EventHandler(this.butRmenu_MouseEnter);
            this.butRmenu.MouseLeave += new System.EventHandler(this.butRmenu_MouseLeave);
            // 
            // PmenuTransition
            // 
            this.PmenuTransition.Interval = 10;
            this.PmenuTransition.Tick += new System.EventHandler(this.PmenuTransition_Tick);
            // 
            // Emenu
            // 
            this.Emenu.Controls.Add(this.panel2);
            this.Emenu.Controls.Add(this.panel9);
            this.Emenu.Controls.Add(this.panAsig);
            this.Emenu.Controls.Add(this.panAddEstu);
            this.Emenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emenu.Location = new System.Drawing.Point(3, 141);
            this.Emenu.Name = "Emenu";
            this.Emenu.Size = new System.Drawing.Size(250, 50);
            this.Emenu.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.panel9.Controls.Add(this.btnViewEst);
            this.panel9.Location = new System.Drawing.Point(0, 50);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(250, 50);
            this.panel9.TabIndex = 4;
            // 
            // btnViewEst
            // 
            this.btnViewEst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnViewEst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewEst.ForeColor = System.Drawing.Color.White;
            this.btnViewEst.Image = global::ProTrack.Properties.Resources.mdi__format_list_bulleted;
            this.btnViewEst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewEst.Location = new System.Drawing.Point(-19, -27);
            this.btnViewEst.Name = "btnViewEst";
            this.btnViewEst.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnViewEst.Size = new System.Drawing.Size(291, 102);
            this.btnViewEst.TabIndex = 3;
            this.btnViewEst.Text = "            Ver estudiantes";
            this.btnViewEst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewEst.UseVisualStyleBackColor = false;
            this.btnViewEst.Click += new System.EventHandler(this.btnViewEst_Click);
            this.btnViewEst.MouseEnter += new System.EventHandler(this.btnViewEst_MouseEnter);
            this.btnViewEst.MouseLeave += new System.EventHandler(this.btnViewEst_MouseLeave);
            // 
            // panAsig
            // 
            this.panAsig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.panAsig.Controls.Add(this.btnAsigProy);
            this.panAsig.Location = new System.Drawing.Point(0, 100);
            this.panAsig.Margin = new System.Windows.Forms.Padding(0);
            this.panAsig.Name = "panAsig";
            this.panAsig.Size = new System.Drawing.Size(250, 50);
            this.panAsig.TabIndex = 5;
            // 
            // btnAsigProy
            // 
            this.btnAsigProy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnAsigProy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsigProy.ForeColor = System.Drawing.Color.White;
            this.btnAsigProy.Image = global::ProTrack.Properties.Resources.mdi__book_plus_multiple_outline;
            this.btnAsigProy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsigProy.Location = new System.Drawing.Point(-19, -27);
            this.btnAsigProy.Name = "btnAsigProy";
            this.btnAsigProy.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAsigProy.Size = new System.Drawing.Size(291, 102);
            this.btnAsigProy.TabIndex = 3;
            this.btnAsigProy.Text = "            Asignar proyecto";
            this.btnAsigProy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsigProy.UseVisualStyleBackColor = false;
            this.btnAsigProy.Click += new System.EventHandler(this.btnAsigProy_Click);
            this.btnAsigProy.MouseEnter += new System.EventHandler(this.btnAsigProy_MouseEnter);
            this.btnAsigProy.MouseLeave += new System.EventHandler(this.btnAsigProy_MouseLeave);
            // 
            // panAddEstu
            // 
            this.panAddEstu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.panAddEstu.Controls.Add(this.btnNewEst);
            this.panAddEstu.Location = new System.Drawing.Point(0, 150);
            this.panAddEstu.Margin = new System.Windows.Forms.Padding(0);
            this.panAddEstu.Name = "panAddEstu";
            this.panAddEstu.Size = new System.Drawing.Size(250, 50);
            this.panAddEstu.TabIndex = 6;
            // 
            // btnNewEst
            // 
            this.btnNewEst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnNewEst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEst.ForeColor = System.Drawing.Color.White;
            this.btnNewEst.Image = global::ProTrack.Properties.Resources.mdi__account_multiple_add;
            this.btnNewEst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewEst.Location = new System.Drawing.Point(-19, -27);
            this.btnNewEst.Name = "btnNewEst";
            this.btnNewEst.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNewEst.Size = new System.Drawing.Size(291, 102);
            this.btnNewEst.TabIndex = 3;
            this.btnNewEst.Text = "            Agregar";
            this.btnNewEst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewEst.UseVisualStyleBackColor = false;
            this.btnNewEst.Click += new System.EventHandler(this.btnNewEst_Click);
            this.btnNewEst.MouseEnter += new System.EventHandler(this.btnNewEst_MouseEnter);
            this.btnNewEst.MouseLeave += new System.EventHandler(this.btnNewEst_MouseLeave);
            // 
            // EmenuTransition
            // 
            this.EmenuTransition.Interval = 10;
            this.EmenuTransition.Tick += new System.EventHandler(this.EmenuTransition_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.flowLayoutPanel1.Controls.Add(this.panel11);
            this.flowLayoutPanel1.Controls.Add(this.ProyMenu);
            this.flowLayoutPanel1.Controls.Add(this.Emenu);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panAvances);
            this.flowLayoutPanel1.Controls.Add(this.Rmenu);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 621);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panel11
            // 
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(247, 76);
            this.panel11.TabIndex = 0;
            // 
            // Rmenu
            // 
            this.Rmenu.Controls.Add(this.panel6);
            this.Rmenu.Controls.Add(this.panel12);
            this.Rmenu.Controls.Add(this.panel13);
            this.Rmenu.Controls.Add(this.panel14);
            this.Rmenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rmenu.Location = new System.Drawing.Point(3, 309);
            this.Rmenu.Name = "Rmenu";
            this.Rmenu.Size = new System.Drawing.Size(250, 50);
            this.Rmenu.TabIndex = 10;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnAvProy);
            this.panel12.Location = new System.Drawing.Point(0, 50);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(250, 50);
            this.panel12.TabIndex = 8;
            // 
            // btnAvProy
            // 
            this.btnAvProy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnAvProy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvProy.ForeColor = System.Drawing.Color.White;
            this.btnAvProy.Image = global::ProTrack.Properties.Resources.mdi__report_bar;
            this.btnAvProy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvProy.Location = new System.Drawing.Point(-19, -27);
            this.btnAvProy.Name = "btnAvProy";
            this.btnAvProy.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAvProy.Size = new System.Drawing.Size(291, 102);
            this.btnAvProy.TabIndex = 3;
            this.btnAvProy.Text = "            Avances por proyecto";
            this.btnAvProy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvProy.UseVisualStyleBackColor = false;
            this.btnAvProy.Click += new System.EventHandler(this.btnAvProy_Click);
            this.btnAvProy.MouseEnter += new System.EventHandler(this.btnAvProy_MouseEnter);
            this.btnAvProy.MouseLeave += new System.EventHandler(this.btnAvProy_MouseLeave);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnEntrProx);
            this.panel13.Location = new System.Drawing.Point(0, 100);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(250, 50);
            this.panel13.TabIndex = 9;
            // 
            // btnEntrProx
            // 
            this.btnEntrProx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnEntrProx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrProx.ForeColor = System.Drawing.Color.White;
            this.btnEntrProx.Image = global::ProTrack.Properties.Resources.mdi__report_bar;
            this.btnEntrProx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrProx.Location = new System.Drawing.Point(-19, -27);
            this.btnEntrProx.Name = "btnEntrProx";
            this.btnEntrProx.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEntrProx.Size = new System.Drawing.Size(291, 102);
            this.btnEntrProx.TabIndex = 3;
            this.btnEntrProx.Text = "            Entregas próximas";
            this.btnEntrProx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrProx.UseVisualStyleBackColor = false;
            this.btnEntrProx.Click += new System.EventHandler(this.btnEntrProx_Click);
            this.btnEntrProx.MouseEnter += new System.EventHandler(this.btnEntrProx_MouseEnter);
            this.btnEntrProx.MouseLeave += new System.EventHandler(this.btnEntrProx_MouseLeave);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btnNonAv);
            this.panel14.Location = new System.Drawing.Point(0, 150);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(250, 50);
            this.panel14.TabIndex = 10;
            // 
            // btnNonAv
            // 
            this.btnNonAv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.btnNonAv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonAv.ForeColor = System.Drawing.Color.White;
            this.btnNonAv.Image = global::ProTrack.Properties.Resources.mdi__report_bar;
            this.btnNonAv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNonAv.Location = new System.Drawing.Point(-19, -27);
            this.btnNonAv.Name = "btnNonAv";
            this.btnNonAv.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNonAv.Size = new System.Drawing.Size(291, 102);
            this.btnNonAv.TabIndex = 3;
            this.btnNonAv.Text = "            Sin avances recientes";
            this.btnNonAv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNonAv.UseVisualStyleBackColor = false;
            this.btnNonAv.Click += new System.EventHandler(this.btnNonAv_Click);
            this.btnNonAv.MouseEnter += new System.EventHandler(this.btnNonAv_MouseEnter);
            this.btnNonAv.MouseLeave += new System.EventHandler(this.btnNonAv_MouseLeave);
            // 
            // RmenuTransition
            // 
            this.RmenuTransition.Interval = 10;
            this.RmenuTransition.Tick += new System.EventHandler(this.RmenuTransition_Tick);
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.panel19.Controls.Add(this.menuStrip1);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(250, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(697, 30);
            this.panel19.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userMenu,
            this.historialToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(212, 33);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // userMenu
            // 
            this.userMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.userMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.userMenu.Image = global::ProTrack.Properties.Resources.mdi__user_online__1_;
            this.userMenu.Name = "userMenu";
            this.userMenu.Size = new System.Drawing.Size(87, 29);
            this.userMenu.Text = "User";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Image = global::ProTrack.Properties.Resources.mdi__password_reset__1_;
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = global::ProTrack.Properties.Resources.mdi__logout__1_;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Image = global::ProTrack.Properties.Resources.mdi__history;
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.historialToolStripMenuItem.Text = "Historial";
            this.historialToolStripMenuItem.Click += new System.EventHandler(this.historialToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(947, 621);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.flowLayoutPanel1);
            this.IsMdiContainer = true;
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHome_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHome_FormClosed);
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.ProyMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panAsignarProy.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panAvances.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.Emenu.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panAsig.ResumeLayout(false);
            this.panAddEstu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Rmenu.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel ProyMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butProyMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMenuEstudiantes;
        private System.Windows.Forms.Panel panAvances;
        private System.Windows.Forms.Button btnAvances;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnEntregas;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button butRmenu;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnviewProy;
        private System.Windows.Forms.Panel panAsignarProy;
        private System.Windows.Forms.Button btnNewProy;
        private System.Windows.Forms.Timer PmenuTransition;
        private System.Windows.Forms.FlowLayoutPanel Emenu;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnViewEst;
        private System.Windows.Forms.Panel panAsig;
        private System.Windows.Forms.Button btnAsigProy;
        private System.Windows.Forms.Timer EmenuTransition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.FlowLayoutPanel Rmenu;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnAvProy;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnEntrProx;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btnNonAv;
        private System.Windows.Forms.Timer RmenuTransition;
        private System.Windows.Forms.Panel panAddEstu;
        private System.Windows.Forms.Button btnNewEst;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userMenu;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
    }
}