namespace proyectoFinalDAE
{
    partial class OpcionesAvanzadas
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
            dataGridViewUsuarios = new DataGridView();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            cmbUsuarios = new ComboBox();
            panel2 = new Panel();
            txtContraseña = new TextBox();
            btnAñadirMateria = new Button();
            btnContraseña = new Button();
            chkEsAdmin = new CheckBox();
            btnResetGrupo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.BorderStyle = BorderStyle.None;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(12, 353);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.Size = new Size(1154, 372);
            dataGridViewUsuarios.TabIndex = 36;
            dataGridViewUsuarios.CellDoubleClick += dataGridViewUsuarios_CellDoubleClick;
            dataGridViewUsuarios.CellFormatting += dataGridViewUsuarios_CellFormatting;
            dataGridViewUsuarios.KeyDown += dataGridViewUsuarios_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(1003, 312);
            label3.Name = "label3";
            label3.Size = new Size(155, 20);
            label3.TabIndex = 76;
            label3.Text = "Mostrar contraseñas";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_switch_96;
            pictureBox1.Location = new Point(926, 296);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 75;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 78;
            label1.Text = "Nombre de Usuario";
            // 
            // cmbUsuarios
            // 
            cmbUsuarios.Anchor = AnchorStyles.None;
            cmbUsuarios.BackColor = Color.White;
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarios.FlatStyle = FlatStyle.Flat;
            cmbUsuarios.ForeColor = Color.Black;
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.ImeMode = ImeMode.NoControl;
            cmbUsuarios.Location = new Point(12, 62);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(321, 28);
            cmbUsuarios.TabIndex = 77;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(13, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 2);
            panel2.TabIndex = 80;
            // 
            // txtContraseña
            // 
            txtContraseña.Anchor = AnchorStyles.None;
            txtContraseña.BackColor = Color.FromArgb(235, 210, 153);
            txtContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.Location = new Point(12, 131);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.ReadOnly = true;
            txtContraseña.Size = new Size(321, 19);
            txtContraseña.TabIndex = 79;
            txtContraseña.Text = "Contraseña";
            // 
            // btnAñadirMateria
            // 
            btnAñadirMateria.Anchor = AnchorStyles.None;
            btnAñadirMateria.FlatAppearance.BorderSize = 0;
            btnAñadirMateria.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnAñadirMateria.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnAñadirMateria.FlatStyle = FlatStyle.Flat;
            btnAñadirMateria.Font = new Font("Microsoft Sans Serif", 12F);
            btnAñadirMateria.ForeColor = Color.Black;
            btnAñadirMateria.Location = new Point(825, 104);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(333, 75);
            btnAñadirMateria.TabIndex = 81;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // btnContraseña
            // 
            btnContraseña.Anchor = AnchorStyles.None;
            btnContraseña.FlatAppearance.BorderSize = 0;
            btnContraseña.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnContraseña.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnContraseña.FlatStyle = FlatStyle.Flat;
            btnContraseña.Font = new Font("Microsoft Sans Serif", 12F);
            btnContraseña.ForeColor = Color.Black;
            btnContraseña.Location = new Point(373, 118);
            btnContraseña.Margin = new Padding(3, 4, 3, 4);
            btnContraseña.Name = "btnContraseña";
            btnContraseña.Size = new Size(171, 46);
            btnContraseña.TabIndex = 82;
            btnContraseña.Text = "Generar contraseña";
            btnContraseña.UseVisualStyleBackColor = true;
            btnContraseña.Click += btnContraseña_Click;
            // 
            // chkEsAdmin
            // 
            chkEsAdmin.AutoSize = true;
            chkEsAdmin.Location = new Point(12, 219);
            chkEsAdmin.Name = "chkEsAdmin";
            chkEsAdmin.Size = new Size(94, 24);
            chkEsAdmin.TabIndex = 83;
            chkEsAdmin.Text = "Es admin";
            chkEsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnResetGrupo
            // 
            btnResetGrupo.Anchor = AnchorStyles.None;
            btnResetGrupo.FlatAppearance.BorderSize = 0;
            btnResetGrupo.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnResetGrupo.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnResetGrupo.FlatStyle = FlatStyle.Flat;
            btnResetGrupo.Font = new Font("Microsoft Sans Serif", 12F);
            btnResetGrupo.ForeColor = Color.Black;
            btnResetGrupo.Location = new Point(825, 187);
            btnResetGrupo.Margin = new Padding(3, 4, 3, 4);
            btnResetGrupo.Name = "btnResetGrupo";
            btnResetGrupo.Size = new Size(333, 75);
            btnResetGrupo.TabIndex = 84;
            btnResetGrupo.Text = "Reset";
            btnResetGrupo.UseVisualStyleBackColor = true;
            btnResetGrupo.Click += btnResetGrupo_Click;
            // 
            // OpcionesAvanzadas
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(btnResetGrupo);
            Controls.Add(chkEsAdmin);
            Controls.Add(btnContraseña);
            Controls.Add(btnAñadirMateria);
            Controls.Add(panel2);
            Controls.Add(txtContraseña);
            Controls.Add(label1);
            Controls.Add(cmbUsuarios);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridViewUsuarios);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "OpcionesAvanzadas";
            Text = "OpcionesAvanzadas";
            Load += OpcionesAvanzadas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewUsuarios;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label1;
        private ComboBox cmbUsuarios;
        private Panel panel2;
        private TextBox txtContraseña;
        private Button btnAñadirMateria;
        private Button btnContraseña;
        private CheckBox chkEsAdmin;
        private Button btnResetGrupo;
    }
}