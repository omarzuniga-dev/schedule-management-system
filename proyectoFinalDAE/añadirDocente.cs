using proyectoFinalDAE.Clases;
using proyectoFinalDAE.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyectoFinalDAE.Form1;


namespace proyectoFinalDAE
{
    public partial class añadirDocente : Form
    {
        Form1 Inicio = new Form1();
        //Instancia de la clase gestor
        Gestor gest = new Gestor();
        public añadirDocente()
        {
            InitializeComponent();
        }

        //Metodo para añadir y modificar docentes
        private async void btnAñadirMateria_Click(object sender, EventArgs e)
        {
            try
            {   //validamos que el telefono tenga el formato correcto
                if (!ValidarTelefonoRegex(txtTelefono.Text))
                {
                    MessageBox.Show("El formato del teléfono es incorrecto. Use el formato XXX-XXXX.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //validamos que todos los campos esten completos
                if (string.IsNullOrWhiteSpace(txtNombreDocente.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(cmbNivelAcademico.Text)
                    || string.IsNullOrWhiteSpace(cmbEspecialidad.Text) || string.IsNullOrWhiteSpace(cmbCategoria.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtNombreDocente.Text == "Nombres" || txtApellidos.Text == "Apellidos" || txtTelefono.Text == "Teléfono")
                {
                    MessageBox.Show("Debe modificar los campos antes de agregar un nuevo docente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int IddocenteAEditar = 0;
                if (dataGridViewDocentes.SelectedRows.Count > 0)
                {
                    //lo convertimos a entero
                    IddocenteAEditar = Convert.ToInt32(dataGridViewDocentes.SelectedRows[0].Cells["IdDocente"].Value);
                }//creamos el objeto docente con los datos del formulario
                string nombres = txtNombreDocente.Text;
                string apellidos = txtApellidos.Text;
                string telefono = txtTelefono.Text;
                string nivelAcademico = cmbNivelAcademico.Text;
                string categoria = cmbCategoria.Text;
                string especialidad = cmbEspecialidad.Text;
                bool estado = chkDocente.Checked;
                Docente docente = new Docente()
                {
                    IdDocente = IddocenteAEditar,
                    Nombres = nombres,
                    Apellidos = apellidos,
                    Categoria = categoria,
                    Telefono = telefono,
                    NivelAcademico = nivelAcademico,
                    Especialidad = especialidad,
                    Estado = estado
                };
                //Si el id es mayor a 0, significa que se esta editando un docente
                if (IddocenteAEditar > 0)
                {
                    bool duplicado = await gest.ExisteRegistro<Docente>(x => x.Nombres == txtNombreDocente.Text.Trim() && x.Apellidos == txtApellidos.Text.Trim() &&
                    x.IdDocente != IddocenteAEditar);
                    if (duplicado)
                    {
                        MessageBox.Show("No se puede modificar: Ya existe otro docente con ese nombre.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detiene la edición
                    }
                    gest.actualizarDocente(docente);
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Docentes",
                    $"Se modificó al docente ID {docente.IdDocente}. Nuevo nombre: {docente.Nombres}");
                    MessageBox.Show("Docente Actualizado correctamente");
                }
                else //sino se crea como nuevo
                {
                    bool existe = await gest.ExisteRegistro<Docente>(x => x.Nombres == txtNombreDocente.Text.Trim() &&
                    x.Apellidos == txtApellidos.Text.Trim());
                    if (existe)
                    {
                        MessageBox.Show("¡Error! Ya existe un docente registrado con ese nombre y apellido.",
                                        "Duplicado encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                    gest.agregarDocente(docente);
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Docentes",
                    $"Se agregó al docente: {docente.Nombres} {docente.Apellidos}");
                    MessageBox.Show("Docente agregado correctamente");
                }
                //limpiamos los campos y recargamos los datos
                limpiarCampos();
                CargarDatosDocentes();
                btnAñadirMateria.Text = "Añadir";
            }

            catch (Exception ex)
            {
                //Manejo de errores con detalles especificos (daba muchos problemas JAJAJAJ)
                string errorMessage = $"Error al guardar: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nDetalle de la BDD: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "ERROR DE BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void añadirDocente_Load(object sender, EventArgs e)
        {
            //cargamos datos
            CargarDatosDocentes();
            cargarEspecialidades();
            cargarCategoria();
            cargarNvAcademico();

        }

        //metodo para cargar los datos de los docentes en el datagridview
        private async void CargarDatosDocentes()
        {
            var gestor = new Gestor();
            var datosDocentes = await gestor.listarDocentes();
            dataGridViewDocentes.DataSource = null;
            dataGridViewDocentes.DataSource = datosDocentes;
            dataGridViewDocentes.ClearSelection();
            dataGridViewDocentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDocentes.Columns["Iddocente"].Visible = false;
            dataGridViewDocentes.Columns["Horarios"].Visible = false;
            dataGridViewDocentes.Columns["nombreCompleto"].Visible = false;
            dataGridViewDocentes.Columns["nombreUsuario"].Visible = false;
            dataGridViewDocentes.Columns["idAsignaturas"].Visible = false;
        }


        private void cmbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        //metodos para cargar el combobox especialidades, categorias y niveles academicos
        private async void cargarEspecialidades()
        {
            try
            {
                var datosEspecialidad = await gest.consultarEspecialidad();
                cmbEspecialidad.DataSource = datosEspecialidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void cargarCategoria()
        {
            try
            {
                var datosCategoria = await gest.consultarCategoria();
                cmbCategoria.DataSource = datosCategoria;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void cargarNvAcademico()
        {
            try
            {
                var datosNvAcademico = await gest.consultarNvAcademico();
                cmbNivelAcademico.DataSource = datosNvAcademico;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //metodo para limpiar campos
        private void limpiarCampos()
        {
            txtNombreDocente.Text = "Nombres";
            txtApellidos.Text = "Apellidos";
            txtTelefono.Text = "Teléfono";
            cmbNivelAcademico.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;
            chkDocente.Checked = false;
        }
        //metodo para los placeholders
        private void txtNombreDocente_Enter(object sender, EventArgs e)
        {
            if (txtNombreDocente.Text == "Nombres")
            {
                txtNombreDocente.Text = "";
            }
        }

        private void txtNombreDocente_Leave(object sender, EventArgs e)
        {
            if (txtNombreDocente.Text == "")
            {
                txtNombreDocente.Text = "Nombres";
            }
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "Apellidos")
            {
                txtApellidos.Text = "";
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "")
            {
                txtApellidos.Text = "Apellidos";
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Telefóno")
            {
                txtTelefono.Text = "";
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Telefóno";
            }
        }
        //metodo para validar el telefono con regex
        public bool ValidarTelefonoRegex(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            // Patrón: 3 dígitos + guión + 4 dígitos
            string patron = @"^\d{3}-\d{4}$";
            return Regex.IsMatch(telefono, patron);
        }
        //metodo para cargar los datos del docente seleccionado en los campos al hacer doble click
        private void dataGridViewDocentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAñadirMateria.Text = "Actualizar";
            if (e.RowIndex >= 0)
            {
                var fila = dataGridViewDocentes.Rows[e.RowIndex];
                txtNombreDocente.Text = fila.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                cmbNivelAcademico.Text = fila.Cells["NivelAcademico"].Value.ToString();
                cmbCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                cmbEspecialidad.Text = fila.Cells["Especialidad"].Value.ToString();
                chkDocente.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
            }
        }

        //metodo para eliminar un docente al presionar la tecla suprimir
        private void dataGridViewDocentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewDocentes.CurrentRow != null)
            {
                var docente = dataGridViewDocentes.CurrentRow.DataBoundItem as VwDocente;
                var confirmar = MessageBox.Show("¿Está seguro de eliminar el docente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    gest.eliminarDocente(docente.IdDocente);
                    CargarDatosDocentes();
                }
            }
        }

        private void txtNombreDocente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellidos.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbNivelAcademico.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbNivelAcademico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEspecialidad.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkDocente.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbEspecialidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCategoria.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        

        private void btnResetGrupo_Click(object sender, EventArgs e)
        {
            txtNombreDocente.Text = "Nombres";
            txtApellidos.Text = "Apellidos";
            txtTelefono.Text = "Teléfono";
            cmbNivelAcademico.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;
            chkDocente.Checked = false;
            btnAñadirMateria.Text = "Añadir";
            dataGridViewDocentes.ClearSelection();
            limpiarCampos();
            CargarDatosDocentes();
        }
    }
}
