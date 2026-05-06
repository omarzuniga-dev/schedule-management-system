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

namespace proyectoFinalDAE
{
    public partial class GruposYFamiliasForm : Form
    {
        private bool isSwitchOn = true;
        Gestor gest = new Gestor();
        public GruposYFamiliasForm()
        {
            InitializeComponent();
        }


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

        private async void btnAñadirMateria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbCarrera.Text) || string.IsNullOrWhiteSpace(cmbCiclo.Text) || string.IsNullOrWhiteSpace(txtCodigoMateria.Text) ||
                string.IsNullOrWhiteSpace(txtFamilia.Text) || NmrCupo.Value == 0)
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtFamilia.Text == "Familia" || txtCodigoMateria.Text == "Grupo/Sección")
                {
                    MessageBox.Show("Debe modificar los campos antes de agregar un nuevo Grupo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //obtenemos el id del docente a editar si es que se selecciono uno
                int IdSeccionAEditar = 0;
                if (dataGridViewGrupos.SelectedRows.Count > 0)
                {
                    //lo convertimos a entero
                    IdSeccionAEditar = Convert.ToInt32(dataGridViewGrupos.SelectedRows[0].Cells["idSeccion"].Value);
                }//creamos el objeto docente con los datos del formulario
                int idCarreraSeleccionada = Convert.ToInt32(cmbCarrera.SelectedValue);
                int idPeriodoSeleccionado = Convert.ToInt32(cmbCiclo.SelectedValue);
                int idCicloSeleccionado = Convert.ToInt32(cmbCiclo.SelectedValue);
                string codigoSeccion = txtCodigoMateria.Text;
                string familia = txtFamilia.Text;
                string turno = "Matutino";
                short cupoMaximo = (short)Convert.ToInt32(NmrCupo.Value);
                Seccion seccion = new Seccion()
                {
                    IdSeccion = IdSeccionAEditar,
                    GrupoBase = codigoSeccion,
                    IdCiclo = 1,
                    Familia = familia,
                    Turno = turno,
                    CupoMax = cupoMaximo,
                    IdCarrera = idCarreraSeleccionada,
                    IdPeriodo = idCicloSeleccionado
                };
                if (IdSeccionAEditar > 0)
                {
                    bool duplicado = await gest.ExisteRegistro<Seccion>(x => x.GrupoBase == codigoSeccion &&
                    x.IdSeccion != IdSeccionAEditar);
                    if (duplicado)
                    {
                        MessageBox.Show($"El código de sección/grupo '{codigoSeccion}' ya existe.",
                                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    gest.actualizarSecciones(seccion);
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Seccion",
                    $"Se modificó la seccion ID {seccion.IdSeccion}. Nuevo nombre: {seccion.GrupoBase}");
                    MessageBox.Show("Seccion Actualizado correctamente");
                }
                else //sino se crea como nuevo
                {
                    bool existe = await gest.ExisteRegistro<Seccion>(x => x.GrupoBase == codigoSeccion);

                    if (existe)
                    {
                        MessageBox.Show($"El código de sección/grupo '{codigoSeccion}' ya existe.",
                                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    gest.agregarSeccion(seccion);
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Seccion",
                    $"Se creó la seccion: {seccion.GrupoBase} con ID {seccion.IdSeccion}");
                    MessageBox.Show("Seccion agregado correctamente");
                }
                //limpiamos los campos y recargamos los datos
                limpiarCampos();
                CargarDatosSecciones();
                btnAñadirMateria.Text = "Añadir";
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error al guardar: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nDetalle de la BDD: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "ERROR DE BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnAñadirCiclo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCiclo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (txtCiclo.Text == "Nombre Ciclo")
                {
                    MessageBox.Show("Debe modificar los campos antes de agregar un nuevo Ciclo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //obtenemos el id del docente a editar si es que se selecciono uno
                int IdCicloAEditar = 0;
                if (dataGridViewGrupos.SelectedRows.Count > 0)
                {
                    //lo convertimos a entero
                    IdCicloAEditar = Convert.ToInt32(dataGridViewGrupos.SelectedRows[0].Cells["idPeriodo"].Value);
                }//creamos el objeto docente con los datos del formulario
                string nombreCiclo = txtCiclo.Text;
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;
                bool activo = chkCiclo.Checked;
                Periodo periodo = new Periodo()
                {
                    IdPeriodo = IdCicloAEditar,
                    NombrePeriodo = nombreCiclo,
                    FechaInicio = DateOnly.FromDateTime(fechaInicio),
                    FechaFin = DateOnly.FromDateTime(fechaFin),
                    EstadoPeriodo = activo ? "Activo" : "Inactivo"
                };
                if (IdCicloAEditar > 0)
                {
                    gest.actualizarCiclos(periodo);
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Periodo",
                    $"Se modificó el periodo ID {periodo.IdPeriodo}. Nuevo nombre: {periodo.NombrePeriodo}");
                    MessageBox.Show("Ciclo Actualizado correctamente");
                }
                else //sino se crea como nuevo
                {
                    gest.actualizarCiclos(periodo);
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Periodo",
                    $"Se creó el periodo: {periodo.NombrePeriodo} con ID {periodo.IdPeriodo}");
                    MessageBox.Show("Ciclo agregado correctamente");
                }
                //limpiamos los campos y recargamos los datos
                limpiarCamposCiclos();
                CargarDatosCiclos();
                btnAñadirCiclo.Text = "Añadir";
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error al guardar: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nDetalle de la BDD: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "ERROR DE BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GruposYFamiliasForm_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            DateTime FechaBase = DateTime.Today;
            DateTime fechaInicio = FechaBase.AddMonths(6);
            dtpFechaInicio.Value = FechaBase;
            dtpFechaFin.Value = fechaInicio;
            cargarCarreras();
            cargarCiclos();
            CargarDatosSecciones();
            dataSourceActual = "SECCIONES";
        }
        private async void CargarDatosSecciones()
        {
            dataSourceActual = "SECCIONES";
            var gestor = new Gestor();
            var datosDocentes = await gestor.listarVistaSecciones();
            dataGridViewGrupos.DataSource = null;
            dataGridViewGrupos.DataSource = datosDocentes;
            dataGridViewGrupos.ClearSelection();
            dataGridViewGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGrupos.Columns["idSeccion"].Visible = false;
            dataGridViewGrupos.Columns["turno"].Visible = false;
            dataGridViewGrupos.Columns["nombreCiclo"].Visible = false;
            dataGridViewGrupos.Columns["nombrePeriodo"].HeaderText = "Ciclo";
            dataGridViewGrupos.Columns["nombreCarrera"].HeaderText = "Carrera";
            dataGridViewGrupos.Columns["grupoBase"].HeaderText = "Familia";
            dataGridViewGrupos.Columns["familia"].HeaderText = "Grupo/Sección";
            dataGridViewGrupos.Columns["cupoMax"].HeaderText = "Cupo Máximo";
        }

        private async void CargarDatosCiclos()
        {
            dataSourceActual = "CICLOS";
            var gestor = new Gestor();
            var datosCiclos = await gestor.listarCiclos();
            dataGridViewGrupos.DataSource = null;
            dataGridViewGrupos.DataSource = datosCiclos;
            dataGridViewGrupos.ClearSelection();
            dataGridViewGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGrupos.Columns["idPeriodo"].Visible = false;
            dataGridViewGrupos.Columns["nombrePeriodo"].HeaderText = "Ciclo";
            dataGridViewGrupos.Columns["fechaInicio"].HeaderText = "Fecha de Inicio";
            dataGridViewGrupos.Columns["fechaFin"].HeaderText = "Fecha de Fin";
            dataGridViewGrupos.Columns["estadoPeriodo"].HeaderText = "Estado";
            dataGridViewGrupos.Columns["CalendarioFeriados"].Visible = false;
            dataGridViewGrupos.Columns["Seccions"].Visible = false;

        }

        private void limpiarCampos()
        {
            cmbCarrera.SelectedIndex = -1;
            cmbCiclo.SelectedIndex = -1;
            txtCodigoMateria.Text = "Grupo/Sección";
            txtFamilia.Text = "Familia";
            NmrCupo.Value = 0;
        }
        private void limpiarCamposCiclos()
        {
            txtCiclo.Text = "Nombre Ciclo";
            DateTime FechaBase = DateTime.Today;
            DateTime fechaInicio = FechaBase.AddMonths(6);
            dtpFechaInicio.Value = FechaBase;
            dtpFechaFin.Value = fechaInicio;
            chkCiclo.Checked = false;
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCarrera.SelectedItem != null && cmbCarrera.SelectedItem is Carrera carreraSeleccionada)
            {
                int idCarrera = carreraSeleccionada.IdCarrera;
            }
        }

        private void cmbCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCiclo.SelectedItem != null && cmbCiclo.SelectedItem is Periodo CicloSeleccionado)
            {
                int idPeriodo = CicloSeleccionado.IdPeriodo;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (!isSwitchOn)
            {
                dataSourceActual = "CICLOS";
                pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
                isSwitchOn = true;
                CargarDatosCiclos();
            }
            else
            {
                dataSourceActual = "SECCIONES";
                pictureBox1.Image = Properties.Resources.icons8_switch_96;
                isSwitchOn = false;
                CargarDatosSecciones();
            }

        }


        private string dataSourceActual = string.Empty;
        private void dataGridViewGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataSourceActual == "SECCIONES")
            {
                btnAñadirMateria.Text = "Actualizar";
                if (e.RowIndex >= 0)
                {
                    var fila = dataGridViewGrupos.Rows[e.RowIndex];
                    cmbCarrera.Text = fila.Cells["nombreCarrera"].Value.ToString();
                    cmbCiclo.Text = fila.Cells["nombrePeriodo"].Value.ToString();
                    txtCodigoMateria.Text = fila.Cells["grupoBase"].Value.ToString();
                    txtFamilia.Text = fila.Cells["familia"].Value.ToString();
                    NmrCupo.Value = Convert.ToDecimal(fila.Cells["cupoMax"].Value);
                }
            }
            else if (dataSourceActual == "CICLOS")
            {
                btnAñadirCiclo.Text = "Actualizar";
                if (e.RowIndex >= 0)
                {
                    var fila = dataGridViewGrupos.Rows[e.RowIndex];
                    txtCiclo.Text = fila.Cells["nombrePeriodo"].Value.ToString();
                    dtpFechaInicio.Value = fila.Cells["FechaInicio"].Value != DBNull.Value
                       ? ((DateOnly)fila.Cells["FechaInicio"].Value).ToDateTime(TimeOnly.MinValue)
                       : DateTime.Today;

                    dtpFechaFin.Value = fila.Cells["FechaFin"].Value != DBNull.Value
                                        ? ((DateOnly)fila.Cells["FechaFin"].Value).ToDateTime(TimeOnly.MinValue)
                                        : DateTime.Today;
                    chkCiclo.Checked = fila.Cells["estadoPeriodo"].Value.ToString() == "Activo" ? true : false;
                }
            }
        }

        private void txtCodigoMateria_Enter(object sender, EventArgs e)
        {
            if (txtCodigoMateria.Text == "Familia")
            {
                txtCodigoMateria.Text = "";
            }
        }

        private void txtCodigoMateria_Leave(object sender, EventArgs e)
        {
            if (txtCodigoMateria.Text == "")
            {
                txtCodigoMateria.Text = "Familia";
            }
        }

        private void txtFamilia_Enter(object sender, EventArgs e)
        {
            if (txtFamilia.Text == "Grupo/Sección")
            {
                txtFamilia.Text = "";
            }
        }

        private void txtFamilia_Leave(object sender, EventArgs e)
        {
            if (txtFamilia.Text == "")
            {
                txtFamilia.Text = "Grupo/Sección";
            }
        }

        private void btnResetGrupo_Click(object sender, EventArgs e)
        {
            dataGridViewGrupos.ClearSelection();
            btnAñadirMateria.Text = "Añadir";
            cmbCarrera.SelectedIndex = 0;
            cmbCiclo.SelectedIndex = 0;
            //txtCodigoMateria.Text = "Familia";
            //txtFamilia.Text = "Grupo/Sección";
            NmrCupo.Value = 0;
        }

        private void btnResetCiclo_Click(object sender, EventArgs e)
        {
            dataGridViewGrupos.ClearSelection();
            btnAñadirCiclo.Text = "Añadir";
            txtCiclo.Text = "Nombre Ciclo";
            DateTime FechaBase = DateTime.Today;
            DateTime fechaInicio = FechaBase.AddMonths(6);
            dtpFechaInicio.Value = FechaBase;
            dtpFechaFin.Value = fechaInicio;
            chkCiclo.Checked = false;
        }

        private void txtCiclo_Enter(object sender, EventArgs e)
        {
            if (txtCiclo.Text == "Nombre ciclo")
            {
                txtCiclo.Text = "";
            }
        }

        private void txtCiclo_Leave(object sender, EventArgs e)
        {
            if (txtCiclo.Text == "")
            {
                txtCiclo.Text = "Nombre ciclo";
            }
        }
    }
}
