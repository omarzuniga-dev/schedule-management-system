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
    public partial class añadirForm : Form
    {
        Gestor gest = new Gestor(); // metodo contrusctor que inicia el formulacio 
        public añadirForm()
        {
            InitializeComponent();
        }

        private async void btnAñadirMateria_Click(object sender, EventArgs e) // evento boton añador materia 
        {
            try
            {   //verificamos que los campos no esten vacios
                if (string.IsNullOrWhiteSpace(cmbNombreMateria.Text) || string.IsNullOrWhiteSpace(cmbCarrera.Text) ||
                    string.IsNullOrWhiteSpace(cmbNaturaleza.Text) || string.IsNullOrWhiteSpace(cmbDocente.Text) ||
                    string.IsNullOrWhiteSpace(cmbDia.Text) || string.IsNullOrWhiteSpace(cmbFamilia.Text) || string.IsNullOrWhiteSpace(cmbModalidad.Text) &&
                    chkHorario.Checked)
                { //Error si alguno esta vacio
                    MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Validamos el formato de las horas
                string cmbHoraInicio = dtpInicio.SelectedItem.ToString();
                string cmbHoraFin = dtpFin.SelectedItem.ToString();
                string formato = "HH:mm";
                DateTime horaInicio;
                bool inicioValido = DateTime.TryParseExact(
                    cmbHoraInicio,
                    formato,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out horaInicio);
                //Si no es valido se muestra un error
                if (!inicioValido)
                {
                    // Manejar el error si la hora de inicio no está en el formato correcto
                    MessageBox.Show("Error: El formato de la Hora de Inicio es inválido (ej. 14:30).");
                    return; 
                }
                DateTime horaFin;
                bool finValido = DateTime.TryParseExact(
                    cmbHoraFin,
                    formato,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out horaFin);
                //Si no es valido se muestra un error
                if (!finValido)
                {
                    // Manejar el error si la hora de fin no está en el formato correcto
                    MessageBox.Show("Error: El formato de la Hora de Fin es inválido (ej. 16:00).");
                    return; 
                }
                //Verificamos que la hora de fin sea mayor a la de inicio
                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("Error: La Hora de Fin debe ser posterior a la Hora de Inicio.");
                    return;
                }
                //obtenemos el id del horario a editar si es que se selecciono uno
                int IdHorarioEditar = 0;
                if (dataGridViewHorarios.SelectedRows.Count > 0)
                {
                    //lo convertimos a entero
                    IdHorarioEditar = Convert.ToInt32(dataGridViewHorarios.SelectedRows[0].Cells["idHorario"].Value);
                }
                //Se obtienen los valores seleccionados en los combobox
                int idSeccionSeleccionada = Convert.ToInt32(cmbSeccion.SelectedValue);
                int idAulaSeleccionada = Convert.ToInt32(cmbAula.SelectedValue);
                int idMateriaSeleccionada = Convert.ToInt32(cmbNombreMateria.SelectedValue);
                string naturaleza = cmbNaturaleza.Text;
                int idCarreraSeleccionada = Convert.ToInt32(cmbCarrera.SelectedValue);
                int idDocenteSeleccionado = Convert.ToInt32(cmbDocente.SelectedValue);
                string semanaRango = "1-16"; //No se usa en este contexto
                bool estado = chkHorario.Checked;
                string modalidad = cmbModalidad.Text;
                string dia = cmbDia.Text;
                DateTime horaInicioConvertida = horaInicio;
                DateTime horaFinConvertida = horaFin;
                string ciclo = cmbCiclo.Text;
                string familia = cmbFamilia.Text;
                string codigoAula = cmbAula.Text;
                //se instancia el objeto horario con los datos obtenidos
                Horario horario = new Horario()
                {
                    IdHorario = IdHorarioEditar,
                    IdSeccion = idSeccionSeleccionada,
                    IdAsignatura = idMateriaSeleccionada,
                    IdDocente = idDocenteSeleccionado,
                    TipoClase = naturaleza,
                    SemanaRango = semanaRango,
                    Estado = estado ? "Activo" : "Inactivo",
                    ModalidadClase = modalidad,
                    Dia = dia,
                    HoraInicio = TimeOnly.FromDateTime(horaInicioConvertida),
                    HoraFin = TimeOnly.FromDateTime(horaFinConvertida),
                    Carrera = cmbCarrera.Text,
                    Ciclo = ciclo,
                    Naturaleza = naturaleza,
                    CodigoAula = codigoAula,
                    Familia = familia,
                };

                //Si el id es mayor a 0, significa que se esta editando
                if (IdHorarioEditar > 0)
                {
                    //Realizamos la verificacion, si pasa se actualiza
                    string resultado = await gest.actualizarHorario(horario);
                    //Si hay un error se muestra
                    if (resultado.StartsWith("Error"))
                    {
                        MessageBox.Show(resultado, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Horarios",
                    $"Se modificó el horario ID {horario.IdHorario}.");
                    MessageBox.Show("Horario actualizado correctamente");
                }
                else //sino se crea como nuevo
                {
                    //e igual se hacen las verificaciones
                    string resultado = await gest.agregarHorario(horario);

                    if (resultado.StartsWith("Error"))
                    {
                        MessageBox.Show(resultado, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(resultado);
                    }
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Horarios",
                    $"Se creó el horario ID {horario.IdHorario}.");
                }
                //Dependiendo del estado del switch se recargan los datos
                //Los datos no se limpian a menos que se presione el boton de reset
                if (isSwitchOn)
                {
                    pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
                    CargarDatosHorarios(true);
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.icons8_switch_96;
                    CargarDatosHorarios(false);
                }
                //Se cambia el texto del boton
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
        //Funcion para limpiar campos (duh)
        private void limpiarCampos()
        {
            cmbCarrera.SelectedIndex = -1;
            cmbCiclo.SelectedIndex = -1;
            cmbDocente.SelectedIndex = -1;
            cmbNombreMateria.SelectedIndex = -1;
            cmbSeccion.SelectedIndex = -1;
            cmbAula.SelectedIndex = -1;
            cmbNaturaleza.SelectedIndex = 0;
            cmbDia.SelectedIndex = 0;
            cmbModalidad.SelectedIndex = 0;
            chkHorario.Checked = false;
        }
        //Al cargar el formulario se cargan todos los datos de los combobox y el datagridview
        private void añadirForm_Load(object sender, EventArgs e)
        {
            dtpInicio.SelectedIndex = 0;
            dtpFin.SelectedIndex = 0;
            cmbCarrera.Focus();
            bloquearTransversales();
            limpiarCampos();
            cargarCarreras();
            cargarDocentes();
            cargarCiclos();
            if (isSwitchOn)
            {
                pictureBox1.Image = Properties.Resources.icons8_switch_96;
                isSwitchOn = false;
                CargarDatosHorarios(false);
            }
            else
            {
                pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
                isSwitchOn = true;
                CargarDatosHorarios(true);
            }
            cargarMaterias();
            cargarSeccion();
            cargarAulas();
            cmbNaturaleza.SelectedIndex = 0;
            cmbDia.SelectedIndex = 0;
            cmbModalidad.SelectedIndex = 0;

        }
        //Cargamos datos al datagridview
        public async void CargarDatosHorarios(bool mostrarInactivos)
        {
            var gestor = new Gestor();
            try
            {
                List<VwHorariosDetallado> datosHorario = await gest.listarHorario(mostrarInactivos);
                dataGridViewHorarios.DataSource = null;
                dataGridViewHorarios.DataSource = datosHorario;
                dataGridViewHorarios.ClearSelection();
                dataGridViewHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewHorarios.Columns["IdHorario"].Visible = false;
                dataGridViewHorarios.Columns["NombreAsignatura"].HeaderText = "Asignatura";
                dataGridViewHorarios.Columns["nombreSeccion"].HeaderText = "Sección";
                dataGridViewHorarios.Columns["Dia"].HeaderText = "Día";
                dataGridViewHorarios.Columns["HoraInicio"].HeaderText = "Hora Inicio";
                dataGridViewHorarios.Columns["HoraFin"].HeaderText = "Hora Fin";
                dataGridViewHorarios.Columns["ModalidadClase"].HeaderText = "Modalidad";
                dataGridViewHorarios.Columns["naturaleza"].HeaderText = "Naturaleza";
                dataGridViewHorarios.Columns["Activo"].HeaderText = "Estado";
                dataGridViewHorarios.Columns["familia"].HeaderText = "Familia";
                dataGridViewHorarios.Columns["codigoAula"].HeaderText = "Aula";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar horarios: {ex.Message}");
            }

        }
        //Cargamos datos docentes
        private async void cargarDocentes()
        {
            try
            {
                List<Docente> datosDocentes = await gest.listarDocentes();
                cmbDocente.DataSource = datosDocentes;
                cmbDocente.DisplayMember = "NombreCompleto";
                cmbDocente.ValueMember = "IdDocente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //Cargamos datos carreras
        private async void cargarCarreras()
        {
            try
            {
                List<Carrera> datosCarrera = await gest.listarCarreras();
                cmbCarrera.DataSource = datosCarrera;
                cmbCarrera.DisplayMember = "NombreCarrera";
                cmbCarrera.ValueMember = "IdCarrera";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //Cargamos datos ciclos
        private async void cargarCiclos()
        {
            try
            {
                List<Periodo> datosCiclos = await gest.listarCiclos();
                cmbCiclo.DataSource = datosCiclos;
                cmbCiclo.DisplayMember = "nombrePeriodo";
                cmbCiclo.ValueMember = "IdPeriodo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en ciclos: {ex.Message}");
            }
        }
        //Cargamos datos materias
        private async void cargarMaterias()
        {
            try
            {
                List<Asignatura> datosMaterias = await gest.listarMateriasConId();
                cmbNombreMateria.DataSource = datosMaterias;
                cmbNombreMateria.DisplayMember = "NombreAsignatura";
                cmbNombreMateria.ValueMember = "IdAsignatura";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Materias: {ex.Message}");
            }
        }
        //Cargamos datos secciones y dependiendo de la carrera seleccionada aparecen unos u otros
        private async void cargarSeccion()
        {
            try
            {
                List<Seccion> datosSeccion = await gest.listarSeccion();
                List<Seccion> seccionesFiltradas = new List<Seccion>();
                string filtro = string.Empty;
                if (cmbCarrera.Text == "Técnico en Desarrollo de Software")
                {
                    filtro = "TDS";
                }
                else if (cmbCarrera.Text == "Ingeniería en Desarrollo de Software")
                {
                    filtro = "IDS";
                }
                else if (cmbCarrera.Text == "Técnico en Redes")
                {
                    filtro = "TIR";
                }
                if (!string.IsNullOrEmpty(filtro))
                {
                    seccionesFiltradas = datosSeccion
                        .Where(s => s.GrupoBase.StartsWith(filtro))
                        .ToList();
                }
                else
                {
                    seccionesFiltradas = datosSeccion;
                }
                cmbSeccion.DataSource = seccionesFiltradas;
                cmbSeccion.DisplayMember = "grupoBase";
                cmbSeccion.ValueMember = "IdSeccion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Seccion: {ex.Message}");
            }
        }
        //Cargamos datos aulas
        private async void cargarAulas()
        {
            try
            {
                var datosAulas = await gest.listarAulas();
                cmbAula.DataSource = datosAulas;
                cmbAula.DisplayMember = "codigoAula";
                cmbAula.ValueMember = "IdAula";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Funciones de los combobox para obtener los id seleccionados
        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSeccion();
            if (cmbCarrera.SelectedItem != null && cmbCarrera.SelectedItem is Carrera carreraSeleccionada)
            {
                int idCarrera = carreraSeleccionada.IdCarrera;
            }
        }
        //Funcion para obtener el id del docente seleccionado
        private void cmbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocente.SelectedItem != null && cmbDocente.SelectedItem is Docente docenteSeleccionado)
            {
                int idDocente = docenteSeleccionado.IdDocente;
            }
        }
        //Funcion para obtener el id del ciclo seleccionado
        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeccion.SelectedItem != null && cmbSeccion.SelectedItem is Seccion SeccionSeleccionada)
            {
                int idSeccion = SeccionSeleccionada.IdSeccion;
            }
        }
        //Funcion para obtener el id de la materia seleccionada
        private void cmbNombreMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreMateria.SelectedItem != null && cmbNombreMateria.SelectedItem is Asignatura MateriaSeleccionada)
            {
                int idNombreMateria = MateriaSeleccionada.IdAsignatura;
            }
        }
        //Fin de las funciones para ids
        //Funcion para cambiar el valor del combobox familia segun la naturaleza seleccionada
        private void cmbNaturaleza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNaturaleza.Text == "Teórica")
            {
                cmbFamilia.Text = "GRP.UNICO";
            }
        }
        //Funcion para definir el tipo de aula segun el prefijo del codigo del aula seleccionado
        private void cmbAula_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> prefijosAula = new List<string> { "A-", "B-", "C-", "D-", "E-", "F-", "G-" };
            if (cmbAula.SelectedItem != null && cmbAula.SelectedItem is Aula AulaSeleccionada)
            {
                int idAula = AulaSeleccionada.IdAula;
            }

            if (cmbAula.Text.StartsWith("LAB"))
            {
                txtTipoAula.Text = "Laboratorio";
            }
            else if (prefijosAula.Any(p => cmbAula.Text.StartsWith(p)))
            {
                txtTipoAula.Text = "Aula";
            }
            else
            {
                txtTipoAula.Text = "NA";
            }
        }
        //Funcion de doble click en el datagridview para cargar los datos en los campos y poder editarlos
        private void dataGridViewHorarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAñadirMateria.Text = "Actualizar";
            if (e.RowIndex >= 0)
            {
                var fila = dataGridViewHorarios.Rows[e.RowIndex];
                int IdHorarioEditar = Convert.ToInt32(fila.Cells["idHorario"].Value);
                object valorFamilia = fila.Cells["Familia"].Value;
                object valorDocente = fila.Cells["Docente"].Value;
                object valorAula = fila.Cells["codigoAula"].Value;
                cmbCarrera.Text = fila.Cells["Carrera"].Value.ToString();
                cmbCiclo.Text = fila.Cells["Ciclo"].Value.ToString();
                if (valorDocente == DBNull.Value || valorDocente == null)
                {
                    cmbDocente.Text = "";
                }
                else
                {
                    cmbDocente.Text = valorDocente.ToString();
                }
                if (valorAula == DBNull.Value || valorAula == null)
                {
                    cmbAula.Text = "";
                }
                else
                {
                    cmbAula.Text = valorAula.ToString();
                }
                if (valorFamilia == DBNull.Value || valorFamilia == null)
                {
                    cmbFamilia.Text = "";
                }
                else
                {
                    cmbFamilia.Text = valorFamilia.ToString();
                }
                cmbNombreMateria.Text = fila.Cells["NombreAsignatura"].Value.ToString();
                cmbSeccion.Text = fila.Cells["nombreSeccion"].Value.ToString();
                cmbNaturaleza.Text = fila.Cells["naturaleza"].Value.ToString();
                cmbDia.Text = fila.Cells["Dia"].Value.ToString();
                dtpInicio.Text = fila.Cells["HoraInicio"].Value.ToString();
                dtpFin.Text = fila.Cells["HoraFin"].Value.ToString();
                cmbModalidad.Text = fila.Cells["ModalidadClase"].Value.ToString();
                string estado = fila.Cells["Activo"].Value.ToString() ?? "Inactivo";
                chkHorario.Checked = estado == "Activo";
            }
        }
        //Funcion de softdelete al presionar la tecla suprimir en el datagridview
        private void dataGridViewHorarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewHorarios.CurrentRow != null)
            {
                if (dataGridViewHorarios.CurrentRow.Cells["Activo"].Value.ToString() == "Inactivo")
                {
                    MessageBox.Show("El horario ya está inactivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var horario = dataGridViewHorarios.CurrentRow.DataBoundItem as VwHorariosDetallado;
                var confirmar = MessageBox.Show("¿Está seguro de eliminar el horario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    gest.eliminarHorario(horario.IdHorario);
                    if (isSwitchOn)
                    {
                        pictureBox1.Image = Properties.Resources.icons8_switch_96;
                        isSwitchOn = false;
                        CargarDatosHorarios(false);
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
                        isSwitchOn = true;
                        CargarDatosHorarios(true);
                    }
                }
            }
        }
        //Manejo del switch para mostrar u ocultar horarios inactivos
        private bool isSwitchOn = true;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (!isSwitchOn)
            {
                pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
                isSwitchOn = true;
                CargarDatosHorarios(true);
            }
            else
            {
                pictureBox1.Image = Properties.Resources.icons8_switch_96;
                isSwitchOn = false;
                CargarDatosHorarios(false);
            }

        }
        //Funciones para navegar entre los campos con la tecla enter
        private void cmbCarrera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCiclo.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbCiclo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbNombreMateria.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbNombreMateria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbNaturaleza.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbNaturaleza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSeccion.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbSeccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbFamilia.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpInicio.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dtpInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFin.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dtpFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDia.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbDia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAula.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbAula_KeyDown(object sender, KeyEventArgs e)
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
                cmbDocente.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cmbDocente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkHorario.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        //Fin de las funciones para navegar entre campos
        //funcion para resetear los campos al presionar el boton reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridViewHorarios.ClearSelection();
            btnAñadirMateria.Text = "Añadir";
            cmbCarrera.SelectedIndex = 0;
            cmbCiclo.SelectedIndex = 0;
            cmbDocente.SelectedIndex = 0;
            cmbNombreMateria.SelectedIndex = 0;
            cmbSeccion.SelectedIndex = 0;
            cmbAula.SelectedIndex = 0;
            cmbNaturaleza.SelectedIndex = 0;
            cmbDia.SelectedIndex = 0;
            cmbModalidad.SelectedIndex = 0;
            chkHorario.Checked = false;
            dtpFin.SelectedIndex = 0;
            dtpInicio.SelectedIndex = 0;
        }
        //Le di por accidente XD
        private void lblDtpInicio_Click(object sender, EventArgs e)
        {

        }
        private void bloquearTransversales()
        {
            if(SesionUsuario.EsTransversal == true)
            {
                cmbAula.Enabled = false;
            }
            else if (SesionUsuario.EsAudiovisuales)
            {
                cmbCarrera.Enabled = false;
                cmbCiclo.Enabled = false;
                cmbDocente.Enabled = false;
                cmbNombreMateria.Enabled = false;
                cmbSeccion.Enabled = false;
                cmbNaturaleza.Enabled = false;
                cmbDia.Enabled = false;
                cmbModalidad.Enabled = false;
                cmbFamilia.Enabled = false;
                cmbDocente.Enabled = false;
                chkHorario.Enabled = false;
                cmbAula.Enabled = true;
            }
        }
    }
}