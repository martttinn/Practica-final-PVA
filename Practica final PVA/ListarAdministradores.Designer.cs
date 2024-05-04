namespace Practica_final_PVA
{
    partial class ListarAdministradores
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
            this.lblTotalAdministradores = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cHUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHDNI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHContrasena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalAdministradores
            // 
            this.lblTotalAdministradores.AutoSize = true;
            this.lblTotalAdministradores.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAdministradores.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblTotalAdministradores.Location = new System.Drawing.Point(615, 70);
            this.lblTotalAdministradores.Name = "lblTotalAdministradores";
            this.lblTotalAdministradores.Size = new System.Drawing.Size(72, 52);
            this.lblTotalAdministradores.TabIndex = 17;
            this.lblTotalAdministradores.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(569, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Administradores";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(608, 382);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 32);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHUsuario,
            this.cHDNI,
            this.cHNombre,
            this.cHContrasena});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(537, 324);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cHUsuario
            // 
            this.cHUsuario.Text = "Usuario";
            this.cHUsuario.Width = 70;
            // 
            // cHDNI
            // 
            this.cHDNI.Text = "DNI";
            this.cHDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cHDNI.Width = 140;
            // 
            // cHNombre
            // 
            this.cHNombre.Text = "Nombre";
            this.cHNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cHNombre.Width = 154;
            // 
            // cHContrasena
            // 
            this.cHContrasena.Text = "Contraseña";
            this.cHContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cHContrasena.Width = 170;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 40);
            this.label1.TabIndex = 12;
            this.label1.Text = "Listado de administradores existentes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Practica_final_PVA.Properties.Resources.icono_imagen;
            this.pictureBox1.Location = new System.Drawing.Point(593, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // ListarAdministradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(730, 426);
            this.Controls.Add(this.lblTotalAdministradores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Name = "ListarAdministradores";
            this.Text = "ListarAdministradores";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalAdministradores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader cHUsuario;
        private System.Windows.Forms.ColumnHeader cHDNI;
        private System.Windows.Forms.ColumnHeader cHNombre;
        private System.Windows.Forms.ColumnHeader cHContrasena;
        private System.Windows.Forms.Label label1;
    }
}