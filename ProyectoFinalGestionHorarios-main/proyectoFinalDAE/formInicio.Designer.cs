namespace proyectoFinalDAE
{
    partial class formInicio
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
            cmbFiltro = new ComboBox();
            txtBuscador = new TextBox();
            panel2 = new Panel();
            dataGridViewBuscador = new DataGridView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBuscador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(761, 31);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 51;
            label4.Text = "Filtro";
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
            cmbFiltro.Items.AddRange(new object[] { "Horarios", "Carreras", "Grupos", "Ciclos", "Materias", "Docentes", "Aulas" });
            cmbFiltro.Location = new Point(761, 54);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(393, 28);
            cmbFiltro.TabIndex = 50;
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;
            cmbFiltro.Leave += cmbFiltro_Leave;
            // 
            // txtBuscador
            // 
            txtBuscador.Anchor = AnchorStyles.None;
            txtBuscador.BackColor = Color.FromArgb(235, 210, 153);
            txtBuscador.BorderStyle = BorderStyle.None;
            txtBuscador.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscador.ForeColor = Color.Black;
            txtBuscador.Location = new Point(25, 57);
            txtBuscador.Name = "txtBuscador";
            txtBuscador.Size = new Size(636, 19);
            txtBuscador.TabIndex = 49;
            txtBuscador.Text = "Buscar";
            txtBuscador.TextChanged += txtBuscador_TextChanged;
            txtBuscador.Enter += txtBuscador_Enter;
            txtBuscador.KeyDown += txtBuscador_KeyDown;
            txtBuscador.Leave += txtBuscador_Leave;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(206, 146, 18);
            panel2.Enabled = false;
            panel2.Location = new Point(25, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(636, 2);
            panel2.TabIndex = 52;
            // 
            // dataGridViewBuscador
            // 
            dataGridViewBuscador.AllowUserToAddRows = false;
            dataGridViewBuscador.AllowUserToDeleteRows = false;
            dataGridViewBuscador.AllowUserToResizeColumns = false;
            dataGridViewBuscador.AllowUserToResizeRows = false;
            dataGridViewBuscador.BorderStyle = BorderStyle.None;
            dataGridViewBuscador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBuscador.Location = new Point(25, 153);
            dataGridViewBuscador.Name = "dataGridViewBuscador";
            dataGridViewBuscador.ReadOnly = true;
            dataGridViewBuscador.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewBuscador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBuscador.Size = new Size(1129, 572);
            dataGridViewBuscador.TabIndex = 53;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_search_96;
            pictureBox1.Location = new Point(685, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 54;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // formInicio
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 210, 153);
            ClientSize = new Size(1178, 737);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridViewBuscador);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(cmbFiltro);
            Controls.Add(txtBuscador);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximumSize = new Size(1178, 737);
            MinimumSize = new Size(1178, 737);
            Name = "formInicio";
            Text = "formInicio";
            Load += formInicio_Load;
            Click += formInicio_Click;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBuscador).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private ComboBox cmbFiltro;
        private TextBox txtBuscador;
        private Panel panel2;
        private DataGridView dataGridViewBuscador;
        private PictureBox pictureBox1;
    }
}