namespace proyectoFinalDAE
{
    partial class añadirAula
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
            dataGridView1 = new DataGridView();
            btnAñadirMateria = new Button();
            cmbTipoAula = new ComboBox();
            label1 = new Label();
            txtCodigoAula = new TextBox();
            panel2 = new Panel();
            numCapacidad = new NumericUpDown();
            label2 = new Label();
            btnResetGrupo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 289);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1129, 423);
            dataGridView1.TabIndex = 74;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
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
            btnAñadirMateria.Location = new Point(821, 22);
            btnAñadirMateria.Margin = new Padding(3, 4, 3, 4);
            btnAñadirMateria.Name = "btnAñadirMateria";
            btnAñadirMateria.Size = new Size(333, 75);
            btnAñadirMateria.TabIndex = 71;
            btnAñadirMateria.Text = "Añadir";
            btnAñadirMateria.UseVisualStyleBackColor = true;
            btnAñadirMateria.Click += btnAñadirMateria_Click;
            // 
            // cmbTipoAula
            // 
            cmbTipoAula.Anchor = AnchorStyles.None;
            cmbTipoAula.BackColor = Color.White;
            cmbTipoAula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoAula.FlatStyle = FlatStyle.Flat;
            cmbTipoAula.ForeColor = Color.Black;
            cmbTipoAula.FormattingEnabled = true;
            cmbTipoAula.ImeMode = ImeMode.NoControl;
            cmbTipoAula.Items.AddRange(new object[] { "NA", "Aula", "Laboratorio" });
            cmbTipoAula.Location = new Point(26, 106);
            cmbTipoAula.Name = "cmbTipoAula";
            cmbTipoAula.Size = new Size(321, 28);
            cmbTipoAula.TabIndex = 83;
            cmbTipoAula.KeyDown += cmbTipoAula_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(25, 85);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 84;
            label1.Text = "Tipo";
            // 
            // txtCodigoAula
            // 
            txtCodigoAula.Anchor = AnchorStyles.None;
            txtCodigoAula.BackColor = Color.FromArgb(235, 210, 153);
            txtCodigoAula.BorderStyle = BorderStyle.None;
            txtCodigoAula.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigoAula.ForeColor = Color.Black;
            txtCodigoAula.Location = new Point(25, 24);
            txtCodigoAula.Name = "txtCodigoAula";
            txtCodigoAula.Size = new Size(321, 19);
            txtCodigoAula.TabIndex = 72;
            txtCodigoAula.Text = "Código";
            txtCodigoAula.Enter += txtCodigoAula_Enter;
            txtCodigoAula.KeyDown += txtCodigoAula_KeyDown;
            txtCodigoAula.Leave += txtCodigoAula_Leave;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(26, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 2);
            panel2.TabIndex = 73;
            // 
            // numCapacidad
            // 
            numCapacidad.Location = new Point(497, 22);
            numCapacidad.Name = "numCapacidad";
            numCapacidad.Size = new Size(66, 26);
            numCapacidad.TabIndex = 91;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(406, 24);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 92;
            label2.Text = "Capacidad";
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
            btnResetGrupo.Location = new Point(821, 165);
            btnResetGrupo.Margin = new Padding(3, 4, 3, 4);
            btnResetGrupo.Name = "btnResetGrupo";
            btnResetGrupo.Size = new Size(333, 75);
            btnResetGrupo.TabIndex = 93;
            btnResetGrupo.Text = "Reset";
            btnResetGrupo.UseVisualStyleBackColor = true;
            btnResetGrupo.Click += btnResetGrupo_Click;
            // 
            // añadirAula
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(btnResetGrupo);
            Controls.Add(label2);
            Controls.Add(numCapacidad);
            Controls.Add(label1);
            Controls.Add(cmbTipoAula);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(txtCodigoAula);
            Controls.Add(btnAñadirMateria);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "añadirAula";
            Text = "añadirAula";
            Load += añadirAula_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button btnAñadirMateria;
        private ComboBox cmbTipoAula;
        private Label label1;
        private TextBox txtCodigoAula;
        private Panel panel2;
        private NumericUpDown numCapacidad;
        private Label label2;
        private Button btnResetGrupo;
    }
}