namespace proyectoFinalDAE
{
    partial class añadirMateria
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
            label4 = new Label();
            cmbTipoMateria = new ComboBox();
            panel1 = new Panel();
            txtNombreMateria = new TextBox();
            dataGridViewMaterias = new DataGridView();
            panel2 = new Panel();
            txtCodigoMateria = new TextBox();
            btnAñadirMateria = new Button();
            NmrCreditos = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            cmbModalidad = new ComboBox();
            label3 = new Label();
            cmbEspecialidad = new ComboBox();
            label5 = new Label();
            cmbCarrera = new ComboBox();
            chkTransversal = new CheckBox();
            btnResetGrupo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMaterias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmrCreditos).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(24, 120);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 66;
            label4.Text = "Tipo";
            // 
            // cmbTipoMateria
            // 
            cmbTipoMateria.Anchor = AnchorStyles.None;
            cmbTipoMateria.BackColor = Color.White;
            cmbTipoMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMateria.FlatStyle = FlatStyle.Flat;
            cmbTipoMateria.ForeColor = Color.Black;
            cmbTipoMateria.FormattingEnabled = true;
            cmbTipoMateria.ImeMode = ImeMode.NoControl;
            cmbTipoMateria.Items.AddRange(new object[] { "Técnico en desarrollo de software", "Ingenieria en desarrollo de software" });
            cmbTipoMateria.Location = new Point(25, 141);
            cmbTipoMateria.Name = "cmbTipoMateria";
            cmbTipoMateria.Size = new Size(321, 28);
            cmbTipoMateria.TabIndex = 65;
            cmbTipoMateria.SelectedIndexChanged += cmbTipoMateria_SelectedIndexChanged;
            cmbTipoMateria.KeyDown += cmbTipoMateria_KeyDown;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(206, 146, 18);
            panel1.Enabled = false;
            panel1.Location = new Point(27, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 2);
            panel1.TabIndex = 58;
            // 
            // txtNombreMateria
            // 
            txtNombreMateria.Anchor = AnchorStyles.None;
            txtNombreMateria.BackColor = Color.FromArgb(235, 210, 153);
            txtNombreMateria.BorderStyle = BorderStyle.None;
            txtNombreMateria.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreMateria.ForeColor = Color.Black;
            txtNombreMateria.Location = new Point(26, 84);
            txtNombreMateria.Name = "txtNombreMateria";
            txtNombreMateria.Size = new Size(321, 19);
            txtNombreMateria.TabIndex = 57;
            txtNombreMateria.Text = "Nombre";
            txtNombreMateria.Enter += txtNombreMateria_Enter;
            txtNombreMateria.KeyDown += txtNombreMateria_KeyDown;
            txtNombreMateria.Leave += txtNombreMateria_Leave;
            // 
            // dataGridViewMaterias
            // 
            dataGridViewMaterias.BorderStyle = BorderStyle.None;
            dataGridViewMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMaterias.Location = new Point(25, 289);
            dataGridViewMaterias.Name = "dataGridViewMaterias";
            dataGridViewMaterias.ReadOnly = true;
            dataGridViewMaterias.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMaterias.Size = new Size(1129, 423);
            dataGridViewMaterias.TabIndex = 56;
            dataGridViewMaterias.CellDoubleClick += dataGridViewMaterias_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(26, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 2);
            panel2.TabIndex = 55;
            // 
            // txtCodigoMateria
            // 
            txtCodigoMateria.Anchor = AnchorStyles.None;
            txtCodigoMateria.BackColor = Color.FromArgb(235, 210, 153);
            txtCodigoMateria.BorderStyle = BorderStyle.None;
            txtCodigoMateria.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigoMateria.ForeColor = Color.Black;
            txtCodigoMateria.Location = new Point(25, 24);
            txtCodigoMateria.Name = "txtCodigoMateria";
            txtCodigoMateria.Size = new Size(321, 19);
            txtCodigoMateria.TabIndex = 54;
            txtCodigoMateria.Text = "Código";
            txtCodigoMateria.Enter += txtCodigoMateria_Enter;
            txtCodigoMateria.KeyDown += txtCodigoMateria_KeyDown;
            txtCodigoMateria.Leave += txtCodigoMateria_Leave;
            txtCodigoMateria.Validated += txtCodigoMateria_Validated;
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
            btnAñadirMateria.Location = new Point(822, 21);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(332, 75);
            btnAñadirMateria.TabIndex = 53;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // NmrCreditos
            // 
            NmrCreditos.Location = new Point(26, 211);
            NmrCreditos.Name = "NmrCreditos";
            NmrCreditos.Size = new Size(321, 26);
            NmrCreditos.TabIndex = 67;
            NmrCreditos.KeyDown += NmrCreditos_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(25, 188);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 68;
            label1.Text = "Créditos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(420, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 69;
            label2.Text = "Modalidad";
            // 
            // cmbModalidad
            // 
            cmbModalidad.Anchor = AnchorStyles.None;
            cmbModalidad.BackColor = Color.White;
            cmbModalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidad.FlatStyle = FlatStyle.Flat;
            cmbModalidad.ForeColor = Color.Black;
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.ImeMode = ImeMode.NoControl;
            cmbModalidad.Items.AddRange(new object[] { "Semi-presencial", "Presencial", "Virtual" });
            cmbModalidad.Location = new Point(421, 21);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(321, 28);
            cmbModalidad.TabIndex = 68;
            cmbModalidad.KeyDown += cmbModalidad_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(420, 120);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 71;
            label3.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.Anchor = AnchorStyles.None;
            cmbEspecialidad.BackColor = Color.White;
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecialidad.FlatStyle = FlatStyle.Flat;
            cmbEspecialidad.ForeColor = Color.Black;
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.ImeMode = ImeMode.NoControl;
            cmbEspecialidad.Location = new Point(421, 141);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(321, 28);
            cmbEspecialidad.TabIndex = 70;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(419, 63);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 73;
            label5.Text = "Carrera";
            // 
            // cmbCarrera
            // 
            cmbCarrera.Anchor = AnchorStyles.None;
            cmbCarrera.BackColor = Color.White;
            cmbCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCarrera.FlatStyle = FlatStyle.Flat;
            cmbCarrera.ForeColor = Color.Black;
            cmbCarrera.FormattingEnabled = true;
            cmbCarrera.ImeMode = ImeMode.NoControl;
            cmbCarrera.Location = new Point(420, 84);
            cmbCarrera.Name = "cmbCarrera";
            cmbCarrera.Size = new Size(321, 28);
            cmbCarrera.TabIndex = 72;
            cmbCarrera.SelectedIndexChanged += cmbCarrera_SelectedIndexChanged;
            cmbCarrera.KeyDown += cmbCarrera_KeyDown;
            // 
            // chkTransversal
            // 
            chkTransversal.AutoSize = true;
            chkTransversal.Location = new Point(421, 212);
            chkTransversal.Name = "chkTransversal";
            chkTransversal.Size = new Size(109, 24);
            chkTransversal.TabIndex = 74;
            chkTransversal.Text = "Transversal";
            chkTransversal.UseVisualStyleBackColor = true;
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
            btnResetGrupo.Location = new Point(821, 162);
            btnResetGrupo.Margin = new Padding(3, 4, 3, 4);
            btnResetGrupo.Name = "btnResetGrupo";
            btnResetGrupo.Size = new Size(333, 75);
            btnResetGrupo.TabIndex = 86;
            btnResetGrupo.Text = "Reset";
            btnResetGrupo.UseVisualStyleBackColor = true;
            btnResetGrupo.Click += btnResetGrupo_Click;
            // 
            // añadirMateria
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(btnResetGrupo);
            Controls.Add(chkTransversal);
            Controls.Add(label5);
            Controls.Add(cmbCarrera);
            Controls.Add(label3);
            Controls.Add(cmbEspecialidad);
            Controls.Add(label2);
            Controls.Add(cmbModalidad);
            Controls.Add(label1);
            Controls.Add(NmrCreditos);
            Controls.Add(label4);
            Controls.Add(cmbTipoMateria);
            Controls.Add(panel1);
            Controls.Add(txtNombreMateria);
            Controls.Add(dataGridViewMaterias);
            Controls.Add(panel2);
            Controls.Add(txtCodigoMateria);
            Controls.Add(btnAñadirMateria);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "añadirMateria";
            Text = "añadirMateria";
            Load += añadirMateria_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMaterias).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmrCreditos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private ComboBox cmbTipoMateria;
        private Panel panel1;
        private TextBox txtNombreMateria;
        private DataGridView dataGridViewMaterias;
        private Panel panel2;
        private TextBox txtCodigoMateria;
        private Button btnAñadirMateria;
        private NumericUpDown NmrCreditos;
        private Label label1;
        private Label label2;
        private ComboBox cmbModalidad;
        private Label label3;
        private ComboBox cmbEspecialidad;
        private Label label5;
        private ComboBox cmbCarrera;
        private CheckBox chkTransversal;
        private Button btnResetGrupo;
    }
}