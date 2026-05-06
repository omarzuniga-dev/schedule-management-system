namespace proyectoFinalDAE
{
    partial class GruposYFamiliasForm
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
            dataGridViewGrupos = new DataGridView();
            btnAñadirMateria = new Button();
            label11 = new Label();
            cmbCiclo = new ComboBox();
            label4 = new Label();
            cmbCarrera = new ComboBox();
            panel2 = new Panel();
            txtCodigoMateria = new TextBox();
            panel1 = new Panel();
            txtFamilia = new TextBox();
            label1 = new Label();
            NmrCupo = new NumericUpDown();
            panel3 = new Panel();
            btnResetGrupo = new Button();
            panel4 = new Panel();
            btnResetCiclo = new Button();
            label3 = new Label();
            btnAñadirCiclo = new Button();
            pictureBox1 = new PictureBox();
            chkCiclo = new CheckBox();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            panel5 = new Panel();
            txtCiclo = new TextBox();
            label2 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrupos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmrCupo).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewGrupos
            // 
            dataGridViewGrupos.BorderStyle = BorderStyle.None;
            dataGridViewGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGrupos.Location = new Point(12, 353);
            dataGridViewGrupos.Name = "dataGridViewGrupos";
            dataGridViewGrupos.ReadOnly = true;
            dataGridViewGrupos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGrupos.Size = new Size(1154, 372);
            dataGridViewGrupos.TabIndex = 33;
            dataGridViewGrupos.CellDoubleClick += dataGridViewGrupos_CellDoubleClick;
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
            btnAñadirMateria.Location = new Point(359, 112);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(177, 75);
            btnAñadirMateria.TabIndex = 34;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(3, 66);
            label11.Name = "label11";
            label11.Size = new Size(43, 20);
            label11.TabIndex = 70;
            label11.Text = "Ciclo";
            // 
            // cmbCiclo
            // 
            cmbCiclo.Anchor = AnchorStyles.None;
            cmbCiclo.BackColor = Color.White;
            cmbCiclo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCiclo.FlatStyle = FlatStyle.Flat;
            cmbCiclo.ForeColor = Color.Black;
            cmbCiclo.FormattingEnabled = true;
            cmbCiclo.Location = new Point(8, 89);
            cmbCiclo.Name = "cmbCiclo";
            cmbCiclo.Size = new Size(321, 28);
            cmbCiclo.TabIndex = 69;
            cmbCiclo.SelectedIndexChanged += cmbCiclo_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(8, 7);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 68;
            label4.Text = "Carrera";
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
            cmbCarrera.Location = new Point(8, 30);
            cmbCarrera.Name = "cmbCarrera";
            cmbCarrera.Size = new Size(321, 28);
            cmbCarrera.TabIndex = 67;
            cmbCarrera.SelectedIndexChanged += cmbCarrera_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(9, 164);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 2);
            panel2.TabIndex = 72;
            // 
            // txtCodigoMateria
            // 
            txtCodigoMateria.Anchor = AnchorStyles.None;
            txtCodigoMateria.BackColor = Color.FromArgb(235, 210, 153);
            txtCodigoMateria.BorderStyle = BorderStyle.None;
            txtCodigoMateria.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigoMateria.ForeColor = Color.Black;
            txtCodigoMateria.Location = new Point(8, 139);
            txtCodigoMateria.Name = "txtCodigoMateria";
            txtCodigoMateria.Size = new Size(321, 19);
            txtCodigoMateria.TabIndex = 71;
            txtCodigoMateria.Text = "Familia";
            txtCodigoMateria.Enter += txtCodigoMateria_Enter;
            txtCodigoMateria.Leave += txtCodigoMateria_Leave;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(206, 146, 18);
            panel1.Enabled = false;
            panel1.Location = new Point(10, 209);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 2);
            panel1.TabIndex = 74;
            // 
            // txtFamilia
            // 
            txtFamilia.Anchor = AnchorStyles.None;
            txtFamilia.BackColor = Color.FromArgb(235, 210, 153);
            txtFamilia.BorderStyle = BorderStyle.None;
            txtFamilia.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFamilia.ForeColor = Color.Black;
            txtFamilia.Location = new Point(9, 184);
            txtFamilia.Name = "txtFamilia";
            txtFamilia.Size = new Size(321, 19);
            txtFamilia.TabIndex = 73;
            txtFamilia.Text = "Grupo/Sección";
            txtFamilia.Enter += txtFamilia_Enter;
            txtFamilia.Leave += txtFamilia_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(4, 232);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 76;
            label1.Text = "Cupo Max.";
            // 
            // NmrCupo
            // 
            NmrCupo.Location = new Point(5, 255);
            NmrCupo.Name = "NmrCupo";
            NmrCupo.Size = new Size(321, 26);
            NmrCupo.TabIndex = 75;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnResetGrupo);
            panel3.Controls.Add(cmbCarrera);
            panel3.Controls.Add(btnAñadirMateria);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(NmrCupo);
            panel3.Controls.Add(cmbCiclo);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(txtCodigoMateria);
            panel3.Controls.Add(txtFamilia);
            panel3.Location = new Point(12, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(557, 342);
            panel3.TabIndex = 77;
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
            btnResetGrupo.Location = new Point(359, 209);
            btnResetGrupo.Margin = new Padding(3, 4, 3, 4);
            btnResetGrupo.Name = "btnResetGrupo";
            btnResetGrupo.Size = new Size(177, 75);
            btnResetGrupo.TabIndex = 79;
            btnResetGrupo.Text = "Reset";
            btnResetGrupo.UseVisualStyleBackColor = true;
            btnResetGrupo.Click += btnResetGrupo_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(btnResetCiclo);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(btnAñadirCiclo);
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(chkCiclo);
            panel4.Controls.Add(dtpFechaFin);
            panel4.Controls.Add(dtpFechaInicio);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(txtCiclo);
            panel4.Location = new Point(575, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(591, 342);
            panel4.TabIndex = 78;
            // 
            // btnResetCiclo
            // 
            btnResetCiclo.Anchor = AnchorStyles.None;
            btnResetCiclo.FlatAppearance.BorderSize = 0;
            btnResetCiclo.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnResetCiclo.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnResetCiclo.FlatStyle = FlatStyle.Flat;
            btnResetCiclo.Font = new Font("Microsoft Sans Serif", 12F);
            btnResetCiclo.ForeColor = Color.Black;
            btnResetCiclo.Location = new Point(380, 216);
            btnResetCiclo.Margin = new Padding(3, 4, 3, 4);
            btnResetCiclo.Name = "btnResetCiclo";
            btnResetCiclo.Size = new Size(177, 75);
            btnResetCiclo.TabIndex = 80;
            btnResetCiclo.Text = "Reset";
            btnResetCiclo.UseVisualStyleBackColor = true;
            btnResetCiclo.Click += btnResetCiclo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(90, 271);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 80;
            label3.Text = "Mostrar Ciclos";
            // 
            // btnAñadirCiclo
            // 
            btnAñadirCiclo.Anchor = AnchorStyles.None;
            btnAñadirCiclo.FlatAppearance.BorderSize = 0;
            btnAñadirCiclo.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnAñadirCiclo.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnAñadirCiclo.FlatStyle = FlatStyle.Flat;
            btnAñadirCiclo.Font = new Font("Microsoft Sans Serif", 12F);
            btnAñadirCiclo.ForeColor = Color.Black;
            btnAñadirCiclo.Location = new Point(380, 112);
            btnAñadirCiclo.Margin = new Padding(3, 4, 3, 4);
            btnAñadirCiclo.Name = "btnAñadirCiclo";
            btnAñadirCiclo.Size = new Size(177, 75);
            btnAñadirCiclo.TabIndex = 77;
            btnAñadirCiclo.Text = "Añadir";
            btnAñadirCiclo.UseVisualStyleBackColor = true;
            btnAñadirCiclo.Click += btnAñadirCiclo_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_switch_96;
            pictureBox1.Location = new Point(13, 255);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 79;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // chkCiclo
            // 
            chkCiclo.AutoSize = true;
            chkCiclo.Location = new Point(13, 209);
            chkCiclo.Name = "chkCiclo";
            chkCiclo.Size = new Size(71, 24);
            chkCiclo.TabIndex = 79;
            chkCiclo.Text = "Activo";
            chkCiclo.UseVisualStyleBackColor = true;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(14, 152);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(321, 26);
            dtpFechaFin.TabIndex = 77;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(13, 87);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(322, 26);
            dtpFechaInicio.TabIndex = 75;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BackColor = Color.FromArgb(206, 146, 18);
            panel5.Enabled = false;
            panel5.Location = new Point(14, 45);
            panel5.Name = "panel5";
            panel5.Size = new Size(321, 2);
            panel5.TabIndex = 74;
            // 
            // txtCiclo
            // 
            txtCiclo.Anchor = AnchorStyles.None;
            txtCiclo.BackColor = Color.FromArgb(235, 210, 153);
            txtCiclo.BorderStyle = BorderStyle.None;
            txtCiclo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCiclo.ForeColor = Color.Black;
            txtCiclo.Location = new Point(13, 20);
            txtCiclo.Name = "txtCiclo";
            txtCiclo.Size = new Size(321, 19);
            txtCiclo.TabIndex = 73;
            txtCiclo.Text = "Nombre ciclo";
            txtCiclo.Enter += txtCiclo_Enter;
            txtCiclo.Leave += txtCiclo_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(13, 64);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 80;
            label2.Text = "Fecha Inicio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(14, 129);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 81;
            label5.Text = "Fecha Fin";
            // 
            // GruposYFamiliasForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(dataGridViewGrupos);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "GruposYFamiliasForm";
            Text = "GruposYFamiliasForm";
            Load += GruposYFamiliasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrupos).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmrCupo).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewGrupos;
        private Button btnAñadirMateria;
        private Label label11;
        private ComboBox cmbCiclo;
        private Label label4;
        private ComboBox cmbCarrera;
        private Panel panel2;
        private TextBox txtCodigoMateria;
        private Panel panel1;
        private TextBox txtFamilia;
        private Label label1;
        private NumericUpDown NmrCupo;
        private Panel panel3;
        private Panel panel4;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Panel panel5;
        private TextBox txtCiclo;
        private Button btnAñadirCiclo;
        private CheckBox chkCiclo;
        private Label label3;
        private PictureBox pictureBox1;
        private Button btnResetGrupo;
        private Button btnResetCiclo;
        private Label label5;
        private Label label2;
    }
}