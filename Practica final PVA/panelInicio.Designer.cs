﻿namespace Practica_final_PVA
{
    partial class panelInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panelInicio));
            this.ilTopVentas1 = new System.Windows.Forms.ImageList(this.components);
            this.lblTopVentas = new System.Windows.Forms.Label();
            this.ilTopVentas2 = new System.Windows.Forms.ImageList(this.components);
            this.ilTopVentas3 = new System.Windows.Forms.ImageList(this.components);
            this.timerImagenes = new System.Windows.Forms.Timer(this.components);
            this.gbTopVentas1 = new System.Windows.Forms.GroupBox();
            this.lbTopVentas1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbTopVentas1 = new System.Windows.Forms.PictureBox();
            this.gbTopVentas2 = new System.Windows.Forms.GroupBox();
            this.lbTopVentas2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbTopVentas2 = new System.Windows.Forms.PictureBox();
            this.gbTopVentas3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTopVentas3 = new System.Windows.Forms.ListBox();
            this.pbTopVentas3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblEligeSandwich = new System.Windows.Forms.Label();
            this.gbTopVentas1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopVentas1)).BeginInit();
            this.gbTopVentas2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopVentas2)).BeginInit();
            this.gbTopVentas3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopVentas3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTopVentas1
            // 
            this.ilTopVentas1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTopVentas1.ImageStream")));
            this.ilTopVentas1.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTopVentas1.Images.SetKeyName(0, "sandwich 1.jpeg");
            this.ilTopVentas1.Images.SetKeyName(1, "sandwich 2.jpeg");
            this.ilTopVentas1.Images.SetKeyName(2, "sandwich 3.jpeg");
            // 
            // lblTopVentas
            // 
            this.lblTopVentas.AutoSize = true;
            this.lblTopVentas.Font = new System.Drawing.Font("Rockwell Condensed", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.lblTopVentas.Location = new System.Drawing.Point(12, 21);
            this.lblTopVentas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopVentas.Name = "lblTopVentas";
            this.lblTopVentas.Size = new System.Drawing.Size(347, 40);
            this.lblTopVentas.TabIndex = 1;
            this.lblTopVentas.Text = "NUESTROS SANDWICHES";
            // 
            // ilTopVentas2
            // 
            this.ilTopVentas2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTopVentas2.ImageStream")));
            this.ilTopVentas2.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTopVentas2.Images.SetKeyName(0, "sandwich 4.jpeg");
            this.ilTopVentas2.Images.SetKeyName(1, "sandwich 6.jpeg");
            this.ilTopVentas2.Images.SetKeyName(2, "sandwich 8.jpeg");
            // 
            // ilTopVentas3
            // 
            this.ilTopVentas3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTopVentas3.ImageStream")));
            this.ilTopVentas3.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTopVentas3.Images.SetKeyName(0, "sandwich 5.jpeg");
            this.ilTopVentas3.Images.SetKeyName(1, "sandwich 7.jpeg");
            this.ilTopVentas3.Images.SetKeyName(2, "sandwich 9.jpeg");
            // 
            // timerImagenes
            // 
            this.timerImagenes.Interval = 5000;
            this.timerImagenes.Tick += new System.EventHandler(this.cambiar_imagenes);
            // 
            // gbTopVentas1
            // 
            this.gbTopVentas1.BackColor = System.Drawing.Color.Transparent;
            this.gbTopVentas1.Controls.Add(this.lbTopVentas1);
            this.gbTopVentas1.Controls.Add(this.label2);
            this.gbTopVentas1.Controls.Add(this.label1);
            this.gbTopVentas1.Controls.Add(this.pbTopVentas1);
            this.gbTopVentas1.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTopVentas1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.gbTopVentas1.Location = new System.Drawing.Point(40, 111);
            this.gbTopVentas1.Margin = new System.Windows.Forms.Padding(2);
            this.gbTopVentas1.Name = "gbTopVentas1";
            this.gbTopVentas1.Padding = new System.Windows.Forms.Padding(2);
            this.gbTopVentas1.Size = new System.Drawing.Size(215, 401);
            this.gbTopVentas1.TabIndex = 4;
            this.gbTopVentas1.TabStop = false;
            this.gbTopVentas1.Text = "Sandwich jamon york";
            // 
            // lbTopVentas1
            // 
            this.lbTopVentas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(11)))));
            this.lbTopVentas1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTopVentas1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.lbTopVentas1.FormattingEnabled = true;
            this.lbTopVentas1.ItemHeight = 21;
            this.lbTopVentas1.Items.AddRange(new object[] {
            "Lechuga",
            "Jamon York",
            "Tomate",
            "Queso Edam"});
            this.lbTopVentas1.Location = new System.Drawing.Point(11, 269);
            this.lbTopVentas1.Margin = new System.Windows.Forms.Padding(2);
            this.lbTopVentas1.Name = "lbTopVentas1";
            this.lbTopVentas1.Size = new System.Drawing.Size(188, 105);
            this.lbTopVentas1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 252);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.label1.Location = new System.Drawing.Point(8, 245);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingredientes:";
            // 
            // pbTopVentas1
            // 
            this.pbTopVentas1.Location = new System.Drawing.Point(19, 51);
            this.pbTopVentas1.Margin = new System.Windows.Forms.Padding(2);
            this.pbTopVentas1.Name = "pbTopVentas1";
            this.pbTopVentas1.Size = new System.Drawing.Size(180, 180);
            this.pbTopVentas1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTopVentas1.TabIndex = 0;
            this.pbTopVentas1.TabStop = false;
            // 
            // gbTopVentas2
            // 
            this.gbTopVentas2.Controls.Add(this.lbTopVentas2);
            this.gbTopVentas2.Controls.Add(this.label3);
            this.gbTopVentas2.Controls.Add(this.pbTopVentas2);
            this.gbTopVentas2.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTopVentas2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.gbTopVentas2.Location = new System.Drawing.Point(334, 111);
            this.gbTopVentas2.Margin = new System.Windows.Forms.Padding(2);
            this.gbTopVentas2.Name = "gbTopVentas2";
            this.gbTopVentas2.Padding = new System.Windows.Forms.Padding(2);
            this.gbTopVentas2.Size = new System.Drawing.Size(215, 401);
            this.gbTopVentas2.TabIndex = 5;
            this.gbTopVentas2.TabStop = false;
            this.gbTopVentas2.Text = "Sandwich de cebolla";
            // 
            // lbTopVentas2
            // 
            this.lbTopVentas2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(11)))));
            this.lbTopVentas2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTopVentas2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.lbTopVentas2.FormattingEnabled = true;
            this.lbTopVentas2.ItemHeight = 21;
            this.lbTopVentas2.Items.AddRange(new object[] {
            "Lechuga",
            "Cebolla",
            "Tomate",
            "Queso Edam"});
            this.lbTopVentas2.Location = new System.Drawing.Point(11, 269);
            this.lbTopVentas2.Margin = new System.Windows.Forms.Padding(2);
            this.lbTopVentas2.Name = "lbTopVentas2";
            this.lbTopVentas2.Size = new System.Drawing.Size(188, 105);
            this.lbTopVentas2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.label3.Location = new System.Drawing.Point(8, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingredientes:";
            // 
            // pbTopVentas2
            // 
            this.pbTopVentas2.BackColor = System.Drawing.Color.Transparent;
            this.pbTopVentas2.Location = new System.Drawing.Point(19, 51);
            this.pbTopVentas2.Margin = new System.Windows.Forms.Padding(2);
            this.pbTopVentas2.Name = "pbTopVentas2";
            this.pbTopVentas2.Size = new System.Drawing.Size(180, 180);
            this.pbTopVentas2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTopVentas2.TabIndex = 2;
            this.pbTopVentas2.TabStop = false;
            // 
            // gbTopVentas3
            // 
            this.gbTopVentas3.BackColor = System.Drawing.Color.Transparent;
            this.gbTopVentas3.Controls.Add(this.label4);
            this.gbTopVentas3.Controls.Add(this.lbTopVentas3);
            this.gbTopVentas3.Controls.Add(this.pbTopVentas3);
            this.gbTopVentas3.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTopVentas3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.gbTopVentas3.Location = new System.Drawing.Point(615, 111);
            this.gbTopVentas3.Margin = new System.Windows.Forms.Padding(2);
            this.gbTopVentas3.Name = "gbTopVentas3";
            this.gbTopVentas3.Padding = new System.Windows.Forms.Padding(2);
            this.gbTopVentas3.Size = new System.Drawing.Size(215, 401);
            this.gbTopVentas3.TabIndex = 6;
            this.gbTopVentas3.TabStop = false;
            this.gbTopVentas3.Text = "Sandwich de jamon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.label4.Location = new System.Drawing.Point(8, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ingredientes:";
            // 
            // lbTopVentas3
            // 
            this.lbTopVentas3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(11)))));
            this.lbTopVentas3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTopVentas3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.lbTopVentas3.FormattingEnabled = true;
            this.lbTopVentas3.ItemHeight = 21;
            this.lbTopVentas3.Items.AddRange(new object[] {
            "Jamon serrano ",
            "Aceite de oliva",
            "Queso Edam"});
            this.lbTopVentas3.Location = new System.Drawing.Point(11, 269);
            this.lbTopVentas3.Margin = new System.Windows.Forms.Padding(2);
            this.lbTopVentas3.Name = "lbTopVentas3";
            this.lbTopVentas3.Size = new System.Drawing.Size(188, 105);
            this.lbTopVentas3.TabIndex = 5;
            // 
            // pbTopVentas3
            // 
            this.pbTopVentas3.BackColor = System.Drawing.Color.Transparent;
            this.pbTopVentas3.Location = new System.Drawing.Point(19, 51);
            this.pbTopVentas3.Margin = new System.Windows.Forms.Padding(2);
            this.pbTopVentas3.Name = "pbTopVentas3";
            this.pbTopVentas3.Size = new System.Drawing.Size(180, 180);
            this.pbTopVentas3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTopVentas3.TabIndex = 3;
            this.pbTopVentas3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Rockwell Condensed", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.label5.Location = new System.Drawing.Point(12, 620);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(321, 40);
            this.label5.TabIndex = 32;
            this.label5.Text = "MONTA TU SANDWICH";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPerfil.Font = new System.Drawing.Font("Rockwell Condensed", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.lblPerfil.Location = new System.Drawing.Point(702, 21);
            this.lblPerfil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(167, 40);
            this.lblPerfil.TabIndex = 33;
            this.lblPerfil.Text = "MI PERFIL";
            this.lblPerfil.Click += new System.EventHandler(this.lblPerfil_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 723);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 33);
            this.button1.TabIndex = 34;
            this.button1.Text = "Cerrar sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Practica_final_PVA.Properties.Resources.flecha_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(334, 589);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(471, 589);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(92, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // lblEligeSandwich
            // 
            this.lblEligeSandwich.AutoSize = true;
            this.lblEligeSandwich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEligeSandwich.Font = new System.Drawing.Font("Rockwell Condensed", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEligeSandwich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.lblEligeSandwich.Location = new System.Drawing.Point(568, 620);
            this.lblEligeSandwich.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEligeSandwich.Name = "lblEligeSandwich";
            this.lblEligeSandwich.Size = new System.Drawing.Size(306, 40);
            this.lblEligeSandwich.TabIndex = 37;
            this.lblEligeSandwich.Text = "ELIGE UN SANDWICH";
            this.lblEligeSandwich.Click += new System.EventHandler(this.lblEligeSandwich_Click);
            // 
            // panelInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(885, 781);
            this.Controls.Add(this.lblEligeSandwich);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbTopVentas3);
            this.Controls.Add(this.gbTopVentas2);
            this.Controls.Add(this.gbTopVentas1);
            this.Controls.Add(this.lblTopVentas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "panelInicio";
            this.Text = "Sandwich sprint - panel inicio";
            this.gbTopVentas1.ResumeLayout(false);
            this.gbTopVentas1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopVentas1)).EndInit();
            this.gbTopVentas2.ResumeLayout(false);
            this.gbTopVentas2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopVentas2)).EndInit();
            this.gbTopVentas3.ResumeLayout(false);
            this.gbTopVentas3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopVentas3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTopVentas1;
        private System.Windows.Forms.ImageList ilTopVentas1;
        private System.Windows.Forms.Label lblTopVentas;
        private System.Windows.Forms.PictureBox pbTopVentas2;
        private System.Windows.Forms.PictureBox pbTopVentas3;
        private System.Windows.Forms.ImageList ilTopVentas2;
        private System.Windows.Forms.ImageList ilTopVentas3;
        private System.Windows.Forms.Timer timerImagenes;
        private System.Windows.Forms.GroupBox gbTopVentas1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTopVentas1;
        private System.Windows.Forms.GroupBox gbTopVentas2;
        private System.Windows.Forms.ListBox lbTopVentas2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbTopVentas3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbTopVentas3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblEligeSandwich;
    }
}