using proyectoFinalDAE.Clases;
using proyectoFinalDAE.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyectoFinalDAE.Form1;

namespace proyectoFinalDAE
{
    public partial class añadirAula : Form
    {
        Gestor gest = new Gestor();
        public añadirAula()
        {
            InitializeComponent();
        }
        //Funcion para añadir o editar un aula
        private async void btnAñadirMateria_Click(object sender, EventArgs e)
        {
            try
            { //Se verifica que los campos no esten vacios
                if (string.IsNullOrWhiteSpace(txtCodigoAula.Text) || string.IsNullOrWhiteSpace(cmbTipoAula.Text))
                {
                    MessageBox.Show("Porfavor complete todos los campos", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } //No tiene sentido que haya mas de un aula NA
                else if (cmbTipoAula.Text == "NA")
                {
                    MessageBox.Show("Solo puede existir un aula NA", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } //La capacidad no puede ser 0 o negativa
                else if (numCapacidad.Value <= 0)
                {
                    MessageBox.Show("Porfavor complete la capacidad del aula", "Campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } //El código no puede ser el valor por defecto
                else if (txtCodigoAula.Text == "Código")
                {
                    MessageBox.Show("Porfavor ingrese un código válido", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //obtenemos el id del aula a editar si es que se selecciono uno
                int idAulaEditar = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idAulaEditar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idAula"].Value);
                }
                int capacidad = Convert.ToInt32(numCapacidad.Value);
                string codigo = txtCodigoAula.Text;
                string tipo = cmbTipoAula.Text;
                Aula aula = new Aula()
                {
                    IdAula = idAulaEditar,
                    Capacidad = (short)capacidad,
                    CodigoAula = codigo,
                    Tipo = tipo,
                    Disponible = true,
                    IdSede = 1
                };
                //Si el id es mayor a 0, significa que se esta editando un docente
                if (idAulaEditar > 0)
                {
                    bool duplicado = await gest.ExisteRegistro<Aula>(x => x.CodigoAula == codigo && x.IdAula != idAulaEditar);
                    if (duplicado)
                    {
                        MessageBox.Show($"El código de aula '{codigo}' ya está siendo usado por otra aula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                    gest.actualizarAula(aula);
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Aulas",
                    $"Se modificó el aula ID {aula.IdAula}. Nuevo nombre: {aula.CodigoAula}");
                    MessageBox.Show("Aula editada exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bool existe = await gest.ExisteRegistro<Aula>(x => x.CodigoAula == codigo);

                    if (existe)
                    {
                        MessageBox.Show($"El código de aula '{codigo}' ya existe en el sistema.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                    gest.agregarAulas(aula);
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Aulas",
                    $"Se creó el aula ID {aula.IdAula}. Nombre: {aula.CodigoAula}");
                    MessageBox.Show("Aula agregada exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                limpiarCampos();
                cargarDatosAula();
                btnAñadirMateria.Text = "Añadir";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void añadirAula_Load(object sender, EventArgs e)
        {
            cargarDatosAula();
        }
        private void limpiarCampos()
        {
            txtCodigoAula.Text = "Código";
            cmbTipoAula.SelectedIndex = -1;
            numCapacidad.Value = 0;

        }
        //metodo para cargar los datos de las aulas en el datagridview
        private async void cargarDatosAula()
        {
            var gestor = new Gestor();
            var datosAula = await gestor.listarAulas();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = datosAula;
            dataGridView1.ClearSelection();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["IdAula"].Visible = false;
            dataGridView1.Columns["IdSede"].Visible = false;
            dataGridView1.Columns["IdSedeNavigation"].Visible = false;
            dataGridView1.Columns["Horarios"].Visible = false;
            dataGridView1.Columns["Disponible"].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAñadirMateria.Text = "Actualizar";
            if (e.RowIndex >= 0)
            {
                var fila = dataGridView1.Rows[e.RowIndex];
                numCapacidad.Value = fila.Cells["Capacidad"].Value != null ? Convert.ToDecimal(fila.Cells["Capacidad"].Value) : 0;
                txtCodigoAula.Text = fila.Cells["CodigoAula"].Value.ToString();
                cmbTipoAula.Text = fila.Cells["Tipo"].Value.ToString();
            }
        }

        private void btnResetGrupo_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            btnAñadirMateria.Text = "Añadir";
            limpiarCampos();
        }

        private void txtCodigoAula_Enter(object sender, EventArgs e)
        {
            if (txtCodigoAula.Text == "Código")
            {
                txtCodigoAula.Text = "";
            }
        }

        private void txtCodigoAula_Leave(object sender, EventArgs e)
        {
            if (txtCodigoAula.Text == "")
            {
                txtCodigoAula.Text = "Código";
            }
        }

        private void txtCodigoAula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoAula.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoAula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numCapacidad.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
    }
}
