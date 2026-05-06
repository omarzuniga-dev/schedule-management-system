namespace proyectoFinalDAE
{
    partial class añadirDocente
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
            dataGridViewDocentes = new DataGridView();
            panel2 = new Panel();
            txtNombreDocente = new TextBox();
            btnAñadirMateria = new Button();
            panel1 = new Panel();
            txtApellidos = new TextBox();
            panel4 = new Panel();
            txtTelefono = new TextBox();
            label4 = new Label();
            cmbNivelAcademico = new ComboBox();
            label1 = new Label();
            cmbEspecialidad = new ComboBox();
            label3 = new Label();
            cmbCategoria = new ComboBox();
            chkDocente = new CheckBox();
            btnResetGrupo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDocentes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDocentes
            // 
            dataGridViewDocentes.AllowUserToAddRows = false;
            dataGridViewDocentes.AllowUserToDeleteRows = false;
            dataGridViewDocentes.AllowUserToResizeColumns = false;
            dataGridViewDocentes.AllowUserToResizeRows = false;
            dataGridViewDocentes.BorderStyle = BorderStyle.None;
            dataGridViewDocentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDocentes.Location = new Point(25, 302);
            dataGridViewDocentes.Name = "dataGridViewDocentes";
            dataGridViewDocentes.ReadOnly = true;
            dataGridViewDocentes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewDocentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDocentes.Size = new Size(1129, 423);
            dataGridViewDocentes.TabIndex = 36;
            dataGridViewDocentes.CellDoubleClick += dataGridViewDocentes_CellDoubleClick;
            dataGridViewDocentes.KeyDown += dataGridViewDocentes_KeyDown;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(26, 62);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 2);
            panel2.TabIndex = 35;
            // 
            // txtNombreDocente
            // 
            txtNombreDocente.Anchor = AnchorStyles.None;
            txtNombreDocente.BackColor = Color.FromArgb(235, 210, 153);
            txtNombreDocente.BorderStyle = BorderStyle.None;
            txtNombreDocente.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreDocente.ForeColor = Color.Black;
            txtNombreDocente.Location = new Point(25, 37);
            txtNombreDocente.Name = "txtNombreDocente";
            txtNombreDocente.Size = new Size(321, 19);
            txtNombreDocente.TabIndex = 34;
            txtNombreDocente.Text = "Nombres";
            txtNombreDocente.Enter += txtNombreDocente_Enter;
            txtNombreDocente.KeyDown += txtNombreDocente_KeyDown;
            txtNombreDocente.Leave += txtNombreDocente_Leave;
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
            btnAñadirMateria.Location = new Point(821, 37);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(333, 75);
            btnAñadirMateria.TabIndex = 33;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(206, 146, 18);
            panel1.Enabled = false;
            panel1.Location = new Point(26, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 2);
            panel1.TabIndex = 38;
            // 
            // txtApellidos
            // 
            txtApellidos.Anchor = AnchorStyles.None;
            txtApellidos.BackColor = Color.FromArgb(235, 210, 153);
            txtApellidos.BorderStyle = BorderStyle.None;
            txtApellidos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.ForeColor = Color.Black;
            txtApellidos.Location = new Point(25, 92);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(321, 19);
            txtApellidos.TabIndex = 37;
            txtApellidos.Text = "Apellidos";
            txtApellidos.Enter += txtApellidos_Enter;
            txtApellidos.KeyDown += txtApellidos_KeyDown;
            txtApellidos.Leave += txtApellidos_Leave;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = Color.FromArgb(206, 146, 18);
            panel4.Enabled = false;
            panel4.Location = new Point(26, 173);
            panel4.Name = "panel4";
            panel4.Size = new Size(321, 2);
            panel4.TabIndex = 44;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.None;
            txtTelefono.BackColor = Color.FromArgb(235, 210, 153);
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.ForeColor = Color.Black;
            txtTelefono.Location = new Point(25, 148);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(321, 19);
            txtTelefono.TabIndex = 43;
            txtTelefono.Text = "Telefóno";
            txtTelefono.Enter += txtTelefono_Enter;
            txtTelefono.KeyDown += txtTelefono_KeyDown;
            txtTelefono.Leave += txtTelefono_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(447, 10);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 48;
            label4.Text = "Nivel academico";
            // 
            // cmbNivelAcademico
            // 
            cmbNivelAcademico.Anchor = AnchorStyles.None;
            cmbNivelAcademico.BackColor = Color.White;
            cmbNivelAcademico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivelAcademico.FlatStyle = FlatStyle.Flat;
            cmbNivelAcademico.ForeColor = Color.Black;
            cmbNivelAcademico.FormattingEnabled = true;
            cmbNivelAcademico.ImeMode = ImeMode.NoControl;
            cmbNivelAcademico.Location = new Point(448, 38);
            cmbNivelAcademico.Name = "cmbNivelAcademico";
            cmbNivelAcademico.Size = new Size(321, 28);
            cmbNivelAcademico.TabIndex = 47;
            cmbNivelAcademico.KeyDown += cmbNivelAcademico_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(446, 74);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 50;
            label1.Text = "Especialidad";
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
            cmbEspecialidad.Location = new Point(446, 100);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(321, 28);
            cmbEspecialidad.TabIndex = 49;
            cmbEspecialidad.SelectedValueChanged += cmbEspecialidad_SelectedValueChanged;
            cmbEspecialidad.KeyDown += cmbEspecialidad_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(447, 136);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 54;
            label3.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Anchor = AnchorStyles.None;
            cmbCategoria.BackColor = Color.White;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.ForeColor = Color.Black;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.ImeMode = ImeMode.NoControl;
            cmbCategoria.Location = new Point(447, 164);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(321, 28);
            cmbCategoria.TabIndex = 53;
            cmbCategoria.KeyDown += cmbCategoria_KeyDown;
            // 
            // chkDocente
            // 
            chkDocente.AutoSize = true;
            chkDocente.Location = new Point(25, 219);
            chkDocente.Name = "chkDocente";
            chkDocente.Size = new Size(71, 24);
            chkDocente.TabIndex = 55;
            chkDocente.Text = "Activo";
            chkDocente.UseVisualStyleBackColor = true;
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
            btnResetGrupo.Location = new Point(821, 168);
            btnResetGrupo.Margin = new Padding(3, 4, 3, 4);
            btnResetGrupo.Name = "btnResetGrupo";
            btnResetGrupo.Size = new Size(333, 75);
            btnResetGrupo.TabIndex = 85;
            btnResetGrupo.Text = "Reset";
            btnResetGrupo.UseVisualStyleBackColor = true;
            btnResetGrupo.Click += btnResetGrupo_Click;
            // 
            // añadirDocente
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(btnResetGrupo);
            Controls.Add(chkDocente);
            Controls.Add(label3);
            Controls.Add(cmbCategoria);
            Controls.Add(label1);
            Controls.Add(cmbEspecialidad);
            Controls.Add(label4);
            Controls.Add(cmbNivelAcademico);
            Controls.Add(panel4);
            Controls.Add(txtTelefono);
            Controls.Add(panel1);
            Controls.Add(txtApellidos);
            Controls.Add(dataGridViewDocentes);
            Controls.Add(panel2);
            Controls.Add(txtNombreDocente);
            Controls.Add(btnAñadirMateria);
            Font = new Font("Microsoft Sans Serif", 12F);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "añadirDocente";
            Text = "añadirDocente";
            Load += añadirDocente_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDocentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewDocentes;
        private Panel panel2;
        private TextBox txtNombreDocente;
        private Button btnAñadirMateria;
        private Panel panel1;
        private TextBox txtApellidos;
        private Panel panel4;
        private TextBox txtTelefono;
        private Label label4;
        private ComboBox cmbNivelAcademico;
        private Label label1;
        private ComboBox cmbEspecialidad;
        private Label label3;
        private ComboBox cmbCategoria;
        private CheckBox chkDocente;
        private Button btnResetGrupo;
    }
}