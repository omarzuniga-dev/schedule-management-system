namespace proyectoFinalDAE
{
    partial class añadirCarrera
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
            components = new System.ComponentModel.Container();
            dvgCarreras = new DataGridView();
            checkActiva = new CheckBox();
            label2 = new Label();
            combEspecialidadCarrera = new ComboBox();
            panel1 = new Panel();
            textNombreCarrera = new TextBox();
            panel2 = new Panel();
            txtCodigoCarrera = new TextBox();
            btnAñadirMateria = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btnResetGrupo = new Button();
            ttAyuda = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dvgCarreras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dvgCarreras
            // 
            dvgCarreras.BorderStyle = BorderStyle.None;
            dvgCarreras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgCarreras.Location = new Point(25, 289);
            dvgCarreras.Name = "dvgCarreras";
            dvgCarreras.ReadOnly = true;
            dvgCarreras.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dvgCarreras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgCarreras.Size = new Size(1129, 423);
            dvgCarreras.TabIndex = 56;
            dvgCarreras.CellDoubleClick += dvgCarreras_CellDoubleClick;
            dvgCarreras.CellValueChanged += dvgCarreras_CellValueChanged;
            dvgCarreras.CurrentCellDirtyStateChanged += dvgCarreras_CurrentCellDirtyStateChanged;
            dvgCarreras.KeyDown += dvgCarreras_KeyDown;
            // 
            // checkActiva
            // 
            checkActiva.AutoSize = true;
            checkActiva.Checked = true;
            checkActiva.CheckState = CheckState.Checked;
            checkActiva.Location = new Point(372, 150);
            checkActiva.Name = "checkActiva";
            checkActiva.Size = new Size(71, 24);
            checkActiva.TabIndex = 81;
            checkActiva.Text = "Activa";
            checkActiva.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(25, 127);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 80;
            label2.Text = "Especialidad";
            // 
            // combEspecialidadCarrera
            // 
            combEspecialidadCarrera.Anchor = AnchorStyles.None;
            combEspecialidadCarrera.BackColor = Color.White;
            combEspecialidadCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
            combEspecialidadCarrera.FlatStyle = FlatStyle.Flat;
            combEspecialidadCarrera.ForeColor = Color.Black;
            combEspecialidadCarrera.FormattingEnabled = true;
            combEspecialidadCarrera.ImeMode = ImeMode.NoControl;
            combEspecialidadCarrera.Location = new Point(26, 150);
            combEspecialidadCarrera.Name = "combEspecialidadCarrera";
            combEspecialidadCarrera.Size = new Size(321, 28);
            combEspecialidadCarrera.TabIndex = 79;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(206, 146, 18);
            panel1.Enabled = false;
            panel1.Location = new Point(372, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 2);
            panel1.TabIndex = 77;
            // 
            // textNombreCarrera
            // 
            textNombreCarrera.Anchor = AnchorStyles.None;
            textNombreCarrera.BackColor = Color.FromArgb(235, 210, 153);
            textNombreCarrera.BorderStyle = BorderStyle.None;
            textNombreCarrera.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textNombreCarrera.ForeColor = Color.Black;
            textNombreCarrera.Location = new Point(371, 56);
            textNombreCarrera.Name = "textNombreCarrera";
            textNombreCarrera.Size = new Size(322, 19);
            textNombreCarrera.TabIndex = 76;
            textNombreCarrera.Text = "Nombre";
            textNombreCarrera.Enter += textNombreCarrera_Enter;
            textNombreCarrera.Leave += textNombreCarrera_Leave;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(26, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 2);
            panel2.TabIndex = 75;
            // 
            // txtCodigoCarrera
            // 
            txtCodigoCarrera.Anchor = AnchorStyles.None;
            txtCodigoCarrera.BackColor = Color.FromArgb(235, 210, 153);
            txtCodigoCarrera.BorderStyle = BorderStyle.None;
            txtCodigoCarrera.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigoCarrera.ForeColor = Color.Black;
            txtCodigoCarrera.Location = new Point(25, 56);
            txtCodigoCarrera.Name = "txtCodigoCarrera";
            txtCodigoCarrera.ReadOnly = true;
            txtCodigoCarrera.Size = new Size(321, 19);
            txtCodigoCarrera.TabIndex = 74;
            txtCodigoCarrera.TabStop = false;
            txtCodigoCarrera.Text = "Codigo";
            txtCodigoCarrera.Enter += txtCodigoCarrera_Enter;
            txtCodigoCarrera.Leave += txtCodigoCarrera_Leave;
            txtCodigoCarrera.MouseEnter += txtCodigoCarrera_MouseEnter;
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
            btnAñadirMateria.Location = new Point(821, 29);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(333, 75);
            btnAñadirMateria.TabIndex = 73;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(102, 228);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 84;
            label3.Text = "Mostrar ocultos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_switch_96;
            pictureBox1.Location = new Point(25, 212);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 83;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            btnResetGrupo.Location = new Point(821, 178);
            btnResetGrupo.Margin = new Padding(3, 4, 3, 4);
            btnResetGrupo.Name = "btnResetGrupo";
            btnResetGrupo.Size = new Size(333, 75);
            btnResetGrupo.TabIndex = 86;
            btnResetGrupo.Text = "Reset";
            btnResetGrupo.UseVisualStyleBackColor = true;
            btnResetGrupo.Click += btnResetGrupo_Click;
            // 
            // añadirCarrera
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(btnResetGrupo);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(checkActiva);
            Controls.Add(label2);
            Controls.Add(combEspecialidadCarrera);
            Controls.Add(panel1);
            Controls.Add(textNombreCarrera);
            Controls.Add(panel2);
            Controls.Add(txtCodigoCarrera);
            Controls.Add(btnAñadirMateria);
            Controls.Add(dvgCarreras);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "añadirCarrera";
            Text = "añadirCarrera";
            Load += añadirCarrera_Load;
            ((System.ComponentModel.ISupportInitialize)dvgCarreras).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dvgCarreras;
        private CheckBox checkActiva;
        private Label label2;
        private ComboBox combEspecialidadCarrera;
        private Panel panel1;
        private TextBox textNombreCarrera;
        private Panel panel2;
        private TextBox txtCodigoCarrera;
        private Button btnAñadirMateria;
        private Label label3;
        private PictureBox pictureBox1;
        private Button btnResetGrupo;
        private ToolTip ttAyuda;
    }
}