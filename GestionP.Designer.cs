namespace PracticaTres
{
    partial class GestionP
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnModNom = new System.Windows.Forms.Button();
            this.btnModPre = new System.Windows.Forms.Button();
            this.btnModCant = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(253, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "MODIFICAR PRODUCTO";
            // 
            // btnModNom
            // 
            this.btnModNom.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModNom.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnModNom.FlatAppearance.BorderSize = 0;
            this.btnModNom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModNom.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModNom.ForeColor = System.Drawing.Color.Black;
            this.btnModNom.Location = new System.Drawing.Point(258, 152);
            this.btnModNom.Name = "btnModNom";
            this.btnModNom.Size = new System.Drawing.Size(290, 55);
            this.btnModNom.TabIndex = 7;
            this.btnModNom.Text = "MODIFICAR NOMBRE";
            this.btnModNom.UseVisualStyleBackColor = false;
            this.btnModNom.Click += new System.EventHandler(this.btnModNom_Click);
            // 
            // btnModPre
            // 
            this.btnModPre.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModPre.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnModPre.FlatAppearance.BorderSize = 0;
            this.btnModPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModPre.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModPre.ForeColor = System.Drawing.Color.Black;
            this.btnModPre.Location = new System.Drawing.Point(258, 234);
            this.btnModPre.Name = "btnModPre";
            this.btnModPre.Size = new System.Drawing.Size(290, 55);
            this.btnModPre.TabIndex = 8;
            this.btnModPre.Text = "MODIFICAR PRECIO";
            this.btnModPre.UseVisualStyleBackColor = false;
            this.btnModPre.Click += new System.EventHandler(this.btnModPre_Click);
            // 
            // btnModCant
            // 
            this.btnModCant.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModCant.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnModCant.FlatAppearance.BorderSize = 0;
            this.btnModCant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModCant.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModCant.ForeColor = System.Drawing.Color.Black;
            this.btnModCant.Location = new System.Drawing.Point(258, 319);
            this.btnModCant.Name = "btnModCant";
            this.btnModCant.Size = new System.Drawing.Size(290, 55);
            this.btnModCant.TabIndex = 9;
            this.btnModCant.Text = "MODIFICAR CANTIDAD";
            this.btnModCant.UseVisualStyleBackColor = false;
            this.btnModCant.Click += new System.EventHandler(this.btnModCant_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.btnCerrar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(615, 32);
            this.panel5.TabIndex = 41;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::Almacen.Properties.Resources.Cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(575, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(28, 26);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 449);
            this.panel1.TabIndex = 43;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gray;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(12, 395);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 38);
            this.button4.TabIndex = 42;
            this.button4.Text = "REGRESAR";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Almacen.Properties.Resources.updated;
            this.pictureBox3.Location = new System.Drawing.Point(28, 75);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(107, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 42;
            this.pictureBox3.TabStop = false;
            // 
            // GestionP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(615, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnModCant);
            this.Controls.Add(this.btnModPre);
            this.Controls.Add(this.btnModNom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.eventoClose);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModNom;
        private System.Windows.Forms.Button btnModPre;
        private System.Windows.Forms.Button btnModCant;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
    }
}