namespace proyectoFinalDAE
{
    partial class añadirForm
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
            btnAñadirMateria = new Button();
            cmbNombreMateria = new ComboBox();
            cmbCarrera = new ComboBox();
            cmbAula = new ComboBox();
            dataGridViewHorarios = new DataGridView();
            cmbFamilia = new ComboBox();
            cmbDia = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label1 = new Label();
            cmbDocente = new ComboBox();
            label2 = new Label();
            cmbNaturaleza = new ComboBox();
            chkHorario = new CheckBox();
            panel1 = new Panel();
            txtTipoAula = new TextBox();
            label10 = new Label();
            cmbModalidad = new ComboBox();
            label11 = new Label();
            cmbCiclo = new ComboBox();
            label8 = new Label();
            label12 = new Label();
            label13 = new Label();
            cmbSeccion = new ComboBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            btnReset = new Button();
            dtpInicio = new ComboBox();
            dtpFin = new ComboBox();
            lblDtpInicio = new Label();
            lblDtpFin = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHorarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            btnAñadirMateria.Location = new Point(777, 246);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(321, 75);
            btnAñadirMateria.TabIndex = 26;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // cmbNombreMateria
            // 
            cmbNombreMateria.Anchor = AnchorStyles.None;
            cmbNombreMateria.BackColor = Color.White;
            cmbNombreMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNombreMateria.FlatStyle = FlatStyle.Flat;
            cmbNombreMateria.ForeColor = Color.Black;
            cmbNombreMateria.FormattingEnabled = true;
            cmbNombreMateria.Location = new Point(24, 160);
            cmbNombreMateria.Name = "cmbNombreMateria";
            cmbNombreMateria.Size = new Size(321, 28);
            cmbNombreMateria.TabIndex = 29;
            cmbNombreMateria.SelectedIndexChanged += cmbNombreMateria_SelectedIndexChanged;
            cmbNombreMateria.KeyDown += cmbNombreMateria_KeyDown;
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
            cmbCarrera.Location = new Point(24, 38);
            cmbCarrera.Name = "cmbCarrera";
            cmbCarrera.Size = new Size(321, 28);
            cmbCarrera.TabIndex = 30;
            cmbCarrera.SelectedIndexChanged += cmbCarrera_SelectedIndexChanged;
            cmbCarrera.KeyDown += cmbCarrera_KeyDown;
            // 
            // cmbAula
            // 
            cmbAula.Anchor = AnchorStyles.None;
            cmbAula.BackColor = Color.White;
            cmbAula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAula.FlatStyle = FlatStyle.Flat;
            cmbAula.ForeColor = Color.Black;
            cmbAula.FormattingEnabled = true;
            cmbAula.Location = new Point(403, 227);
            cmbAula.Name = "cmbAula";
            cmbAula.Size = new Size(321, 28);
            cmbAula.TabIndex = 31;
            cmbAula.SelectedIndexChanged += cmbAula_SelectedIndexChanged;
            cmbAula.KeyDown += cmbAula_KeyDown;
            // 
            // dataGridViewHorarios
            // 
            dataGridViewHorarios.BorderStyle = BorderStyle.None;
            dataGridViewHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHorarios.Location = new Point(25, 344);
            dataGridViewHorarios.Name = "dataGridViewHorarios";
            dataGridViewHorarios.ReadOnly = true;
            dataGridViewHorarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHorarios.Size = new Size(1129, 372);
            dataGridViewHorarios.TabIndex = 32;
            dataGridViewHorarios.CellDoubleClick += dataGridViewHorarios_CellDoubleClick;
            dataGridViewHorarios.KeyDown += dataGridViewHorarios_KeyDown;
            // 
            // cmbFamilia
            // 
            cmbFamilia.Anchor = AnchorStyles.None;
            cmbFamilia.BackColor = Color.White;
            cmbFamilia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFamilia.FlatStyle = FlatStyle.Flat;
            cmbFamilia.ForeColor = Color.Black;
            cmbFamilia.FormattingEnabled = true;
            cmbFamilia.Items.AddRange(new object[] { "GRP.A", "GRP.B", "GRP.UNICO" });
            cmbFamilia.Location = new Point(403, 38);
            cmbFamilia.Name = "cmbFamilia";
            cmbFamilia.Size = new Size(321, 28);
            cmbFamilia.TabIndex = 33;
            cmbFamilia.KeyDown += cmbFamilia_KeyDown;
            // 
            // cmbDia
            // 
            cmbDia.Anchor = AnchorStyles.None;
            cmbDia.BackColor = Color.White;
            cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDia.FlatStyle = FlatStyle.Flat;
            cmbDia.ForeColor = Color.Black;
            cmbDia.FormattingEnabled = true;
            cmbDia.Items.AddRange(new object[] { "LUN", "MAR", "MIE", "JUE", "VIE", "SAB", "DOM" });
            cmbDia.Location = new Point(403, 160);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(321, 28);
            cmbDia.TabIndex = 39;
            cmbDia.KeyDown += cmbDia_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(24, 17);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 40;
            label4.Text = "Carrera";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(24, 139);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 41;
            label5.Text = "Materia";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(403, 206);
            label6.Name = "label6";
            label6.Size = new Size(115, 20);
            label6.TabIndex = 42;
            label6.Text = "Código de aula";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(403, 17);
            label7.Name = "label7";
            label7.Size = new Size(54, 20);
            label7.TabIndex = 43;
            label7.Text = "Grupo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(403, 139);
            label9.Name = "label9";
            label9.Size = new Size(33, 20);
            label9.TabIndex = 45;
            label9.Text = "Dia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(777, 80);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 47;
            label1.Text = "Docente";
            // 
            // cmbDocente
            // 
            cmbDocente.Anchor = AnchorStyles.None;
            cmbDocente.BackColor = Color.White;
            cmbDocente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDocente.FlatStyle = FlatStyle.Flat;
            cmbDocente.ForeColor = Color.Black;
            cmbDocente.FormattingEnabled = true;
            cmbDocente.Location = new Point(777, 101);
            cmbDocente.Name = "cmbDocente";
            cmbDocente.Size = new Size(321, 28);
            cmbDocente.TabIndex = 46;
            cmbDocente.SelectedIndexChanged += cmbDocente_SelectedIndexChanged;
            cmbDocente.KeyDown += cmbDocente_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(25, 204);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 49;
            label2.Text = "Tipo";
            label2.Click += label2_Click;
            // 
            // cmbNaturaleza
            // 
            cmbNaturaleza.Anchor = AnchorStyles.None;
            cmbNaturaleza.BackColor = Color.White;
            cmbNaturaleza.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNaturaleza.FlatStyle = FlatStyle.Flat;
            cmbNaturaleza.ForeColor = Color.Black;
            cmbNaturaleza.FormattingEnabled = true;
            cmbNaturaleza.Items.AddRange(new object[] { "Teórica", "Práctica", "Asíncrona" });
            cmbNaturaleza.Location = new Point(24, 227);
            cmbNaturaleza.Name = "cmbNaturaleza";
            cmbNaturaleza.Size = new Size(321, 28);
            cmbNaturaleza.TabIndex = 48;
            cmbNaturaleza.SelectedIndexChanged += cmbNaturaleza_SelectedIndexChanged;
            cmbNaturaleza.KeyDown += cmbNaturaleza_KeyDown;
            // 
            // chkHorario
            // 
            chkHorario.AutoSize = true;
            chkHorario.Location = new Point(777, 147);
            chkHorario.Name = "chkHorario";
            chkHorario.Size = new Size(71, 24);
            chkHorario.TabIndex = 56;
            chkHorario.Text = "Activo";
            chkHorario.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(206, 146, 18);
            panel1.Enabled = false;
            panel1.Location = new Point(404, 319);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 2);
            panel1.TabIndex = 60;
            // 
            // txtTipoAula
            // 
            txtTipoAula.Anchor = AnchorStyles.None;
            txtTipoAula.BackColor = Color.FromArgb(235, 210, 153);
            txtTipoAula.BorderStyle = BorderStyle.None;
            txtTipoAula.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTipoAula.ForeColor = Color.Black;
            txtTipoAula.Location = new Point(403, 294);
            txtTipoAula.Name = "txtTipoAula";
            txtTipoAula.ReadOnly = true;
            txtTipoAula.Size = new Size(321, 19);
            txtTipoAula.TabIndex = 59;
            txtTipoAula.Text = "Tipo de aula";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(777, 17);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 64;
            label10.Text = "Modalidad";
            // 
            // cmbModalidad
            // 
            cmbModalidad.Anchor = AnchorStyles.None;
            cmbModalidad.BackColor = Color.White;
            cmbModalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidad.FlatStyle = FlatStyle.Flat;
            cmbModalidad.ForeColor = Color.Black;
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.Items.AddRange(new object[] { "Presencial", "Semi-presencial", "Virtual" });
            cmbModalidad.Location = new Point(777, 38);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(321, 28);
            cmbModalidad.TabIndex = 63;
            cmbModalidad.KeyDown += cmbModalidad_KeyDown;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(24, 76);
            label11.Name = "label11";
            label11.Size = new Size(43, 20);
            label11.TabIndex = 66;
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
            cmbCiclo.Location = new Point(24, 97);
            cmbCiclo.Name = "cmbCiclo";
            cmbCiclo.Size = new Size(321, 28);
            cmbCiclo.TabIndex = 65;
            cmbCiclo.KeyDown += cmbCiclo_KeyDown;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(403, 76);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 68;
            label8.Text = "Inicio";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.Black;
            label12.Location = new Point(599, 76);
            label12.Name = "label12";
            label12.Size = new Size(31, 20);
            label12.TabIndex = 70;
            label12.Text = "Fin";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Black;
            label13.Location = new Point(25, 268);
            label13.Name = "label13";
            label13.Size = new Size(59, 20);
            label13.TabIndex = 72;
            label13.Text = "Familia";
            // 
            // cmbSeccion
            // 
            cmbSeccion.Anchor = AnchorStyles.None;
            cmbSeccion.BackColor = Color.White;
            cmbSeccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeccion.FlatStyle = FlatStyle.Flat;
            cmbSeccion.ForeColor = Color.Black;
            cmbSeccion.FormattingEnabled = true;
            cmbSeccion.Location = new Point(24, 291);
            cmbSeccion.Name = "cmbSeccion";
            cmbSeccion.Size = new Size(321, 28);
            cmbSeccion.TabIndex = 71;
            cmbSeccion.SelectedIndexChanged += cmbSeccion_SelectedIndexChanged;
            cmbSeccion.KeyDown += cmbSeccion_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_switch_96;
            pictureBox1.Location = new Point(776, 188);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 73;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(853, 204);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 74;
            label3.Text = "Mostrar ocultos";
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.None;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 12F);
            btnReset.ForeColor = Color.Black;
            btnReset.Location = new Point(995, 151);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(103, 75);
            btnReset.TabIndex = 75;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // dtpInicio
            // 
            dtpInicio.Anchor = AnchorStyles.None;
            dtpInicio.BackColor = Color.White;
            dtpInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpInicio.FlatStyle = FlatStyle.Flat;
            dtpInicio.ForeColor = Color.Black;
            dtpInicio.FormattingEnabled = true;
            dtpInicio.Items.AddRange(new object[] { "07:00", "07:40", "07:50", "08:00", "08:40", "08:50", "09:00", "09:40", "09:50", "10:00", "10:40", "10:50", "11:00", "11:40", "11:50", "12:00", "12:40", "12:50", "13:00", "13:40", "13:50", "14:00", "14:40", "14:50", "15:00", "15:40", "15:50", "16:00", "16:40", "16:50", "17:00", "17:40", "17:50" });
            dtpInicio.Location = new Point(403, 97);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(127, 28);
            dtpInicio.TabIndex = 76;
            // 
            // dtpFin
            // 
            dtpFin.Anchor = AnchorStyles.None;
            dtpFin.BackColor = Color.White;
            dtpFin.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpFin.FlatStyle = FlatStyle.Flat;
            dtpFin.ForeColor = Color.Black;
            dtpFin.FormattingEnabled = true;
            dtpFin.Items.AddRange(new object[] { "07:00", "07:40", "07:50", "08:00", "08:40", "08:50", "09:00", "09:40", "09:50", "10:00", "10:40", "10:50", "11:00", "11:40", "11:50", "12:00", "12:40", "12:50", "13:00", "13:40", "13:50", "14:00", "14:40", "14:50", "15:00", "15:40", "15:50", "16:00", "16:40", "16:50", "17:00", "17:40", "17:50" });
            dtpFin.Location = new Point(599, 97);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(127, 28);
            dtpFin.TabIndex = 77;
            // 
            // lblDtpInicio
            // 
            lblDtpInicio.AutoSize = true;
            lblDtpInicio.ForeColor = Color.Black;
            lblDtpInicio.Location = new Point(497, 74);
            lblDtpInicio.Name = "lblDtpInicio";
            lblDtpInicio.Size = new Size(33, 20);
            lblDtpInicio.TabIndex = 78;
            lblDtpInicio.Text = "AM";
            lblDtpInicio.Click += lblDtpInicio_Click;
            // 
            // lblDtpFin
            // 
            lblDtpFin.AutoSize = true;
            lblDtpFin.ForeColor = Color.Black;
            lblDtpFin.Location = new Point(693, 74);
            lblDtpFin.Name = "lblDtpFin";
            lblDtpFin.Size = new Size(33, 20);
            lblDtpFin.TabIndex = 79;
            lblDtpFin.Text = "AM";
            // 
            // añadirForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(lblDtpFin);
            Controls.Add(lblDtpInicio);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(btnReset);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label13);
            Controls.Add(cmbSeccion);
            Controls.Add(label12);
            Controls.Add(label8);
            Controls.Add(label11);
            Controls.Add(cmbCiclo);
            Controls.Add(label10);
            Controls.Add(cmbModalidad);
            Controls.Add(panel1);
            Controls.Add(txtTipoAula);
            Controls.Add(chkHorario);
            Controls.Add(label2);
            Controls.Add(cmbNaturaleza);
            Controls.Add(label1);
            Controls.Add(cmbDocente);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cmbDia);
            Controls.Add(cmbFamilia);
            Controls.Add(dataGridViewHorarios);
            Controls.Add(cmbAula);
            Controls.Add(cmbCarrera);
            Controls.Add(cmbNombreMateria);
            Controls.Add(btnAñadirMateria);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "añadirForm";
            Text = "añadirForm";
            Load += añadirForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHorarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAñadirMateria;
        private ComboBox cmbNombreMateria;
        private ComboBox cmbCarrera;
        private ComboBox cmbAula;
        private DataGridView dataGridViewHorarios;
        private ComboBox cmbFamilia;
        private ComboBox cmbDia;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label1;
        private ComboBox cmbDocente;
        private Label label2;
        private ComboBox cmbNaturaleza;
        private CheckBox chkHorario;
        private Panel panel1;
        private TextBox txtTipoAula;
        private Label label10;
        private ComboBox cmbModalidad;
        private Label label11;
        private ComboBox cmbCiclo;
        private Label label8;
        private Label label12;
        private Label label13;
        private ComboBox cmbSeccion;
        private PictureBox pictureBox1;
        private Label label3;
        private Button btnReset;
        private ComboBox dtpInicio;
        private ComboBox dtpFin;
        private Label lblDtpInicio;
        private Label lblDtpFin;
    }
}