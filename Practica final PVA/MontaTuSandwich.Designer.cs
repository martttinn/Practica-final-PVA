namespace Practica_final_PVA
{
    partial class MontaTuSandwich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MontaTuSandwich));
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lvSandwich = new System.Windows.Forms.ListView();
            this.Ingrediente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Precio_Unidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAnadir = new System.Windows.Forms.Button();
            this.udSalsa = new System.Windows.Forms.NumericUpDown();
            this.udQueso = new System.Windows.Forms.NumericUpDown();
            this.udVerdura = new System.Windows.Forms.NumericUpDown();
            this.udProteina = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSalsa = new System.Windows.Forms.ComboBox();
            this.cbqueso = new System.Windows.Forms.ComboBox();
            this.cbVerdura = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProteina = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udSalsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQueso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udVerdura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udProteina)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(660, 454);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(191, 30);
            this.btnPagar.TabIndex = 50;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(36, 450);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(191, 30);
            this.btnEliminar.TabIndex = 49;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Audi Type", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.lblPrecioTotal.Location = new System.Drawing.Point(520, 455);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(25, 25);
            this.lblPrecioTotal.TabIndex = 48;
            this.lblPrecioTotal.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Audi Type", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(335, 455);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 25);
            this.label11.TabIndex = 47;
            this.label11.Text = "PRECIO TOTAL: €";
            // 
            // lvSandwich
            // 
            this.lvSandwich.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ingrediente,
            this.Cantidad,
            this.Precio_Unidad});
            this.lvSandwich.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSandwich.FullRowSelect = true;
            this.lvSandwich.HideSelection = false;
            this.lvSandwich.Location = new System.Drawing.Point(340, 94);
            this.lvSandwich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvSandwich.Name = "lvSandwich";
            this.lvSandwich.Size = new System.Drawing.Size(509, 342);
            this.lvSandwich.TabIndex = 46;
            this.lvSandwich.UseCompatibleStateImageBehavior = false;
            this.lvSandwich.View = System.Windows.Forms.View.Details;
            // 
            // Ingrediente
            // 
            this.Ingrediente.Text = "Ingrediente";
            this.Ingrediente.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.Text = "Cantidad";
            this.Cantidad.Width = 120;
            // 
            // Precio_Unidad
            // 
            this.Precio_Unidad.Text = "Precio unitario";
            this.Precio_Unidad.Width = 130;
            // 
            // btnAnadir
            // 
            this.btnAnadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnadir.Location = new System.Drawing.Point(36, 406);
            this.btnAnadir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(191, 30);
            this.btnAnadir.TabIndex = 45;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // udSalsa
            // 
            this.udSalsa.Location = new System.Drawing.Point(185, 361);
            this.udSalsa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udSalsa.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.udSalsa.Name = "udSalsa";
            this.udSalsa.Size = new System.Drawing.Size(41, 22);
            this.udSalsa.TabIndex = 44;
            // 
            // udQueso
            // 
            this.udQueso.Location = new System.Drawing.Point(185, 292);
            this.udQueso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udQueso.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.udQueso.Name = "udQueso";
            this.udQueso.Size = new System.Drawing.Size(41, 22);
            this.udQueso.TabIndex = 43;
            // 
            // udVerdura
            // 
            this.udVerdura.Location = new System.Drawing.Point(185, 224);
            this.udVerdura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udVerdura.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.udVerdura.Name = "udVerdura";
            this.udVerdura.Size = new System.Drawing.Size(41, 22);
            this.udVerdura.TabIndex = 42;
            // 
            // udProteina
            // 
            this.udProteina.Location = new System.Drawing.Point(185, 159);
            this.udProteina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.udProteina.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.udProteina.Name = "udProteina";
            this.udProteina.Size = new System.Drawing.Size(41, 22);
            this.udProteina.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.label10.Location = new System.Drawing.Point(32, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 21);
            this.label10.TabIndex = 40;
            this.label10.Text = "Salsa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.label9.Location = new System.Drawing.Point(32, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 21);
            this.label9.TabIndex = 39;
            this.label9.Text = "Queso";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.label8.Location = new System.Drawing.Point(32, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 21);
            this.label8.TabIndex = 38;
            this.label8.Text = "Verdura";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Audi Type", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(96)))), ((int)(((byte)(19)))));
            this.label7.Location = new System.Drawing.Point(32, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "Proteina";
            // 
            // cbSalsa
            // 
            this.cbSalsa.FormattingEnabled = true;
            this.cbSalsa.Location = new System.Drawing.Point(36, 358);
            this.cbSalsa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSalsa.Name = "cbSalsa";
            this.cbSalsa.Size = new System.Drawing.Size(129, 24);
            this.cbSalsa.TabIndex = 36;
            // 
            // cbqueso
            // 
            this.cbqueso.FormattingEnabled = true;
            this.cbqueso.Location = new System.Drawing.Point(35, 292);
            this.cbqueso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbqueso.Name = "cbqueso";
            this.cbqueso.Size = new System.Drawing.Size(129, 24);
            this.cbqueso.TabIndex = 35;
            // 
            // cbVerdura
            // 
            this.cbVerdura.FormattingEnabled = true;
            this.cbVerdura.Location = new System.Drawing.Point(35, 224);
            this.cbVerdura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVerdura.Name = "cbVerdura";
            this.cbVerdura.Size = new System.Drawing.Size(129, 24);
            this.cbVerdura.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Audi Type", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(173)))), ((int)(((byte)(45)))));
            this.label6.Location = new System.Drawing.Point(31, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ingredientes:";
            // 
            // cbProteina
            // 
            this.cbProteina.FormattingEnabled = true;
            this.cbProteina.Location = new System.Drawing.Point(35, 158);
            this.cbProteina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbProteina.Name = "cbProteina";
            this.cbProteina.Size = new System.Drawing.Size(129, 24);
            this.cbProteina.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell Condensed", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(234)))));
            this.label5.Location = new System.Drawing.Point(24, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(321, 40);
            this.label5.TabIndex = 32;
            this.label5.Text = "MONTA TU SANDWICH";
            // 
            // MontaTuSandwich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(11)))));
            this.ClientSize = new System.Drawing.Size(887, 539);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lvSandwich);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.udSalsa);
            this.Controls.Add(this.udQueso);
            this.Controls.Add(this.udVerdura);
            this.Controls.Add(this.udProteina);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSalsa);
            this.Controls.Add(this.cbqueso);
            this.Controls.Add(this.cbVerdura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbProteina);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MontaTuSandwich";
            this.Text = "Sandwich Sprint - Monta tu sandwich";
            ((System.ComponentModel.ISupportInitialize)(this.udSalsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQueso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udVerdura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udProteina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lvSandwich;
        private System.Windows.Forms.ColumnHeader Ingrediente;
        private System.Windows.Forms.ColumnHeader Cantidad;
        private System.Windows.Forms.ColumnHeader Precio_Unidad;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.NumericUpDown udSalsa;
        private System.Windows.Forms.NumericUpDown udQueso;
        private System.Windows.Forms.NumericUpDown udVerdura;
        private System.Windows.Forms.NumericUpDown udProteina;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSalsa;
        private System.Windows.Forms.ComboBox cbqueso;
        private System.Windows.Forms.ComboBox cbVerdura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProteina;
        private System.Windows.Forms.Label label5;
    }
}