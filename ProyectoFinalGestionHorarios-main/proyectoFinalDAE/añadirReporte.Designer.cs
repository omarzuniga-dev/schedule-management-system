namespace proyectoFinalDAE
{
    partial class añadirReporte
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
            btnGenerar = new Button();
            comboBoxTipoReporte = new ComboBox();
            lblTipoReporte = new Label();
            dateInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            comboBoxFormato = new ComboBox();
            lblFormato = new Label();
            lblFechaFin = new Label();
            dateFin = new DateTimePicker();
            cmbFiltro = new ComboBox();
            lblFiltro = new Label();
            SuspendLayout();
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.None;
            btnGenerar.BackColor = Color.FromArgb(235, 210, 153);
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatAppearance.MouseDownBackColor = Color.FromArgb(176, 41, 28);
            btnGenerar.FlatAppearance.MouseOverBackColor = Color.FromArgb(176, 41, 28);
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Liberation Mono", 12F);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(427, 561);
            btnGenerar.Margin = new Padding(3, 4, 3, 4);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(333, 75);
            btnGenerar.TabIndex = 54;
            btnGenerar.Text = "Generar reporte";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // comboBoxTipoReporte
            // 
            comboBoxTipoReporte.Anchor = AnchorStyles.None;
            comboBoxTipoReporte.BackColor = Color.White;
            comboBoxTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoReporte.FlatStyle = FlatStyle.Flat;
            comboBoxTipoReporte.ForeColor = Color.Black;
            comboBoxTipoReporte.FormattingEnabled = true;
            comboBoxTipoReporte.ImeMode = ImeMode.NoControl;
            comboBoxTipoReporte.Items.AddRange(new object[] { "Seleccione una opción", "Horarios Docentes", "Reporte por grupos", "Reporte de Materias", "Plan de Carrera", "Detalle de carreras" });
            comboBoxTipoReporte.Location = new Point(287, 189);
            comboBoxTipoReporte.Name = "comboBoxTipoReporte";
            comboBoxTipoReporte.Size = new Size(267, 26);
            comboBoxTipoReporte.TabIndex = 67;
            comboBoxTipoReporte.SelectedIndexChanged += comboBoxTipoReporte_SelectedIndexChanged_1;
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.ForeColor = Color.Black;
            lblTipoReporte.Location = new Point(287, 168);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new Size(158, 18);
            lblTipoReporte.TabIndex = 68;
            lblTipoReporte.Text = "Tipo de reporte";
            // 
            // dateInicio
            // 
            dateInicio.CustomFormat = "";
            dateInicio.Format = DateTimePickerFormat.Short;
            dateInicio.Location = new Point(287, 258);
            dateInicio.Name = "dateInicio";
            dateInicio.RightToLeft = RightToLeft.No;
            dateInicio.Size = new Size(267, 26);
            dateInicio.TabIndex = 69;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.ForeColor = Color.Black;
            lblFechaInicio.Location = new Point(287, 237);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(58, 18);
            lblFechaInicio.TabIndex = 70;
            lblFechaInicio.Text = "Desde";
            // 
            // comboBoxFormato
            // 
            comboBoxFormato.Anchor = AnchorStyles.None;
            comboBoxFormato.BackColor = Color.White;
            comboBoxFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormato.FlatStyle = FlatStyle.Flat;
            comboBoxFormato.ForeColor = Color.Black;
            comboBoxFormato.FormattingEnabled = true;
            comboBoxFormato.ImeMode = ImeMode.NoControl;
            comboBoxFormato.Items.AddRange(new object[] { "Seleccione una opción", "PDF", "Excel", "CSV" });
            comboBoxFormato.Location = new Point(287, 345);
            comboBoxFormato.Name = "comboBoxFormato";
            comboBoxFormato.Size = new Size(633, 26);
            comboBoxFormato.TabIndex = 73;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.ForeColor = Color.Black;
            lblFormato.Location = new Point(286, 324);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(78, 18);
            lblFormato.TabIndex = 74;
            lblFormato.Text = "Formato";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.ForeColor = Color.Black;
            lblFechaFin.Location = new Point(652, 237);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(58, 18);
            lblFechaFin.TabIndex = 76;
            lblFechaFin.Text = "Hasta";
            // 
            // dateFin
            // 
            dateFin.CustomFormat = "";
            dateFin.Format = DateTimePickerFormat.Short;
            dateFin.Location = new Point(652, 258);
            dateFin.Name = "dateFin";
            dateFin.RightToLeft = RightToLeft.No;
            dateFin.Size = new Size(268, 26);
            dateFin.TabIndex = 75;
            // 
            // cmbFiltro
            // 
            cmbFiltro.Anchor = AnchorStyles.None;
            cmbFiltro.BackColor = Color.White;
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.FlatStyle = FlatStyle.Flat;
            cmbFiltro.ForeColor = Color.Black;
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.ImeMode = ImeMode.NoControl;
            cmbFiltro.Items.AddRange(new object[] { "" });
            cmbFiltro.Location = new Point(652, 189);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(268, 26);
            cmbFiltro.TabIndex = 79;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.ForeColor = Color.Black;
            lblFiltro.Location = new Point(652, 168);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(68, 18);
            lblFiltro.TabIndex = 80;
            lblFiltro.Text = "Filtro";
            // 
            // añadirReporte
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(lblFiltro);
            Controls.Add(cmbFiltro);
            Controls.Add(lblFechaFin);
            Controls.Add(dateFin);
            Controls.Add(lblFormato);
            Controls.Add(comboBoxFormato);
            Controls.Add(lblFechaInicio);
            Controls.Add(dateInicio);
            Controls.Add(lblTipoReporte);
            Controls.Add(comboBoxTipoReporte);
            Controls.Add(btnGenerar);
            Font = new Font("Liberation Mono", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "añadirReporte";
            Text = "añadirReporte";
            Load += añadirReporte_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerar;
        private ComboBox comboBoxTipoReporte;
        private Label lblTipoReporte;
        private DateTimePicker dateInicio;
        private Label lblFechaInicio;
        private ComboBox comboBoxFormato;
        private Label lblFormato;
        private Label lblFechaFin;
        private DateTimePicker dateFin;
        private ComboBox cmbFiltro;
        private Label lblFiltro;
    }
}