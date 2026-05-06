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
    public partial class añadirMateria : Form
    {
        Gestor gest = new Gestor();
        public añadirMateria()
        {
            InitializeComponent();
        }
        //Al cargar el formulario se cargan los datos
        private void añadirMateria_Load(object sender, EventArgs e)
        {
            CargarDatosMaterias();
            cargarTipoMateria();
            cargarCarreras();
        }
        //Verificacion para bloquear campos si el usuario es transversal

        private async void btnAñadirMateria_Click(object sender, EventArgs e)
        {
            try
            { //Verificamos que los campos no esten vacios
                if (string.IsNullOrWhiteSpace(txtCodigoMateria.Text) || string.IsNullOrWhiteSpace(txtNombreMateria.Text) ||
                string.IsNullOrWhiteSpace(cmbTipoMateria.Text) && NmrCreditos.Value >= 0)
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } //Verificamos que los campos no tengan los textos por defecto
                else if (txtCodigoMateria.Text == "Código" || txtNombreMateria.Text == "Nombre")
                {
                    MessageBox.Show("Debe modificar los campos antes de agregar una nueva materia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } //Verificamos que se haya seleccionado una carrera
                if (cmbCarrera.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione una carrera.");
                    return;
                }
                //Obtenemos el id de la carrera seleccionada y materia a editar si aplica
                int idCarreraSeleccionada = Convert.ToInt32(cmbCarrera.SelectedValue);
                int IdMateriaEditar = 0;
                if (dataGridViewMaterias.SelectedRows.Count > 0)
                {
                    //lo convertimos a entero
                    IdMateriaEditar = Convert.ToInt32(dataGridViewMaterias.SelectedRows[0].Cells["IdAsignatura"].Value);
                }
                string codigo = txtCodigoMateria.Text;
                string nombreMateria = txtNombreMateria.Text;
                string naturaleza = cmbTipoMateria.Text;
                int creditos = Convert.ToInt32(NmrCreditos.Value);
                string modalidad = cmbModalidad.Text;
                string especialidad = cmbEspecialidad.Text;
                int idCarrera = idCarreraSeleccionada;
                bool esTransversal = chkTransversal.Checked;
                Asignatura asignatura = new Asignatura()
                {
                    IdAsignatura = IdMateriaEditar,
                    CodigoAsignatura = codigo,
                    NombreAsignatura = nombreMateria,
                    Naturaleza = naturaleza,
                    Creditos = (byte)creditos,
                    Modalidad = modalidad,
                    Especialidad = especialidad,
                    IdCarrera = idCarrera,
                    EsTransversal = esTransversal
                };
                //Si el id es mayor a 0, significa que se esta editando un docente
                if (IdMateriaEditar > 0)
                {
                    bool duplicado = await gest.ExisteRegistro<Asignatura>(x => x.CodigoAsignatura == codigo &&
                    x.IdAsignatura != IdMateriaEditar); 
                    if (duplicado)
                    {
                        MessageBox.Show($"El código de materia '{codigo}' ya está en uso.",
                                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    gest.actualizarMateria(asignatura);
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Asignaturas",
                    $"Se modificó la materia ID {asignatura.IdAsignatura}. Nuevo nombre: {asignatura.NombreAsignatura}");
                    MessageBox.Show("Materia Actualizada correctamente");
                }
                else //sino se crea como nuevo
                {
                    bool existe = await gest.ExisteRegistro<Asignatura>(x => x.CodigoAsignatura == codigo);

                    if (existe)
                    {
                        MessageBox.Show($"El código de materia '{codigo}' ya existe.",
                                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                    gest.agregarMateria(asignatura);
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Asignaturas",
                    $"Se creó la materia: {asignatura.NombreAsignatura} con código {asignatura.CodigoAsignatura}");
                    MessageBox.Show("Materia agregada correctamente");
                }
                //limpiamos los campos y recargamos los datos
                limpiarCampos();
                CargarDatosMaterias();
                btnAñadirMateria.Text = "Añadir";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir o modificar la materia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Metodo para cargar los datos en el datagridview
        private async void CargarDatosMaterias()
        {
            var gestor = new Gestor();
            var datosMaterias = await gestor.listarMaterias();
            dataGridViewMaterias.DataSource = null;
            dataGridViewMaterias.DataSource = datosMaterias;
            dataGridViewMaterias.ClearSelection();
            dataGridViewMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMaterias.Columns["IdAsignatura"].Visible = false;
            dataGridViewMaterias.Columns["codigoAsignatura"].HeaderText = "Código";
            dataGridViewMaterias.Columns["nombreAsignatura"].HeaderText = "Nombre";
            dataGridViewMaterias.Columns["naturaleza"].HeaderText = "Tipo";
            dataGridViewMaterias.Columns["creditos"].HeaderText = "Créditos";
            dataGridViewMaterias.Columns["modalidad"].HeaderText = "Modalidad";
            dataGridViewMaterias.Columns["especialidad"].HeaderText = "Especialidad";
            dataGridViewMaterias.Columns["nombreCarrera"].HeaderText = "Carrera";
            dataGridViewMaterias.Columns["esTransversal"].HeaderText = "Transversal";
        }
        //metodo para cargar los tipos de materia en el combobox
        private async void cargarTipoMateria()
        {
            try
            {
                var datosTipo = await gest.consultarTipoMaterias();
                cmbTipoMateria.DataSource = datosTipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //metodo para cargar las carreras en el combobox
        private async void cargarCarreras()
        {
            try
            {
                List<Carrera> datosCarrera = await gest.listarCarreras();
                cmbCarrera.DataSource = datosCarrera;
                cmbCarrera.DisplayMember = "NombreCarrera";
                cmbCarrera.ValueMember = "IdCarrera";
                var datosTipoCarrera = await gest.listarEspecialidades();
                cmbEspecialidad.DataSource = datosTipoCarrera;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //metodo para limpiar los campos despues de agregar o modificar una materia
        private void limpiarCampos()
        {
            txtCodigoMateria.Text = "Código";
            txtNombreMateria.Text = "Nombre";
            cmbTipoMateria.SelectedIndex = -1;
            NmrCreditos.Value = 0;
            cmbModalidad.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;
            cmbCarrera.SelectedIndex = -1;
            chkTransversal.Checked = false;
        }

        private void txtCodigoMateria_Enter(object sender, EventArgs e)
        {
            if (txtCodigoMateria.Text == "Código")
            {
                txtCodigoMateria.Text = "";
            }
        }

        private void txtCodigoMateria_Validated(object sender, EventArgs e)
        {

        }

        private void txtCodigoMateria_Leave(object sender, EventArgs e)
        {
            if (txtCodigoMateria.Text == "")
            {
                txtCodigoMateria.Text = "Código";
            }
        }

        private void txtNombreMateria_Enter(object sender, EventArgs e)
        {
            if (txtNombreMateria.Text == "Nombre")
            {
                txtNombreMateria.Text = "";
            }
        }

        private void txtNombreMateria_Leave(object sender, EventArgs e)
        {
            if (txtNombreMateria.Text == "")
            {
                txtNombreMateria.Text = "Nombre";
            }
        }
        //metodo para cargar los datos en los campos al hacer doble click en una fila del datagridview
        private void dataGridViewMaterias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAñadirMateria.Text = "Actualizar";
            if (e.RowIndex >= 0)
            {
                var fila = dataGridViewMaterias.Rows[e.RowIndex];
                txtCodigoMateria.Text = fila.Cells["codigoAsignatura"].Value.ToString();
                txtNombreMateria.Text = fila.Cells["nombreAsignatura"].Value.ToString();
                cmbTipoMateria.Text = fila.Cells["naturaleza"].Value.ToString();
                NmrCreditos.Value = Convert.ToDecimal(fila.Cells["creditos"].Value);
                cmbModalidad.Text = fila.Cells["modalidad"].Value.ToString();
                cmbEspecialidad.Text = fila.Cells["especialidad"].Value.ToString();
                cmbCarrera.Text = fila.Cells["nombreCarrera"].Value.ToString();
                chkTransversal.Checked = Convert.ToBoolean(fila.Cells["esTransversal"].Value);
            }
        }

        private void txtCodigoMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombreMateria.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NmrCreditos.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombreMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoMateria.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> prefijosCarreras = new List<string> { "Ing", "ING", "Téc", "TÉC"};
            if (cmbCarrera.SelectedItem != null && cmbCarrera.SelectedItem is Carrera carreraSeleccionada)
            {
                int idCarrera = carreraSeleccionada.IdCarrera;
            }
            if (cmbCarrera.Text.StartsWith("Ing"))
            {
                cmbEspecialidad.Text = "Ingeniería";
                cmbEspecialidad.Enabled = false;
            }
            else if (prefijosCarreras.Any(p => cmbCarrera.Text.StartsWith(p)))
            {
                cmbEspecialidad.Text = "Técnico";
                cmbEspecialidad.Enabled = false;
            }
        }

        private void NmrCreditos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbModalidad.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbModalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCarrera.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbCarrera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEspecialidad.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        //boton para resetear los campos
        private void btnResetGrupo_Click(object sender, EventArgs e)
        {
            txtCodigoMateria.Text = "Código";
            txtNombreMateria.Text = "Nombre";
            cmbTipoMateria.SelectedIndex = -1;
            NmrCreditos.Value = 0;
            cmbModalidad.SelectedIndex = -1;
            cmbCarrera.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;
            chkTransversal.Checked = false;
            btnAñadirMateria.Text = "Añadir";
            dataGridViewMaterias.ClearSelection();
            limpiarCampos();
            CargarDatosMaterias();
        }

        private void cmbTipoMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoMateria.Text == "Transversal")
            {
                chkTransversal.Checked = true;
                chkTransversal.Enabled = false;
            }
            else
            {
                chkTransversal.Checked = false; 
                chkTransversal.Enabled = false;
            }
        }
        
    }
}
