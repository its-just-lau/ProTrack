namespace ProTrack
{
    partial class FRMLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chBoxMostrar = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(497, 200);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(283, 26);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(497, 261);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '•';
            this.txtContraseña.Size = new System.Drawing.Size(283, 26);
            this.txtContraseña.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(600, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(585, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(573, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Iniciar Sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 457);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProTrack.Properties.Resources.mdi__user_box;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(563, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 151);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // chBoxMostrar
            // 
            this.chBoxMostrar.AutoSize = true;
            this.chBoxMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBoxMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chBoxMostrar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxMostrar.Location = new System.Drawing.Point(633, 298);
            this.chBoxMostrar.Name = "chBoxMostrar";
            this.chBoxMostrar.Size = new System.Drawing.Size(169, 25);
            this.chBoxMostrar.TabIndex = 7;
            this.chBoxMostrar.Text = "Mostrar Contraseña";
            this.chBoxMostrar.UseVisualStyleBackColor = true;
            this.chBoxMostrar.CheckedChanged += new System.EventHandler(this.chBoxMostrar_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(482, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Eres un Asesor sin cuenta?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.label4.Location = new System.Drawing.Point(685, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Registrate";
            this.label4.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(772, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "aquí";
            // 
            // FRMLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(853, 457);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chBoxMostrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Name = "FRMLogin";
            this.Text = "Iniciar Sesión";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chBoxMostrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

