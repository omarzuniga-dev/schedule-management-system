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
using System.Windows.Forms.DataVisualization.Charting;

namespace proyectoFinalDAE
{
    public partial class formInicio : Form
    {
        Gestor gest = new Gestor();
        public formInicio()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            string textoBusqueda = "Técnico";
            string filtroSeleccionado = "Horario";
            cargarDatosFiltrados(textoBusqueda, filtroSeleccionado);
            ordenarDGVHorarios();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscador.Text.ToLower().Trim();
            string filtroSeleccionado = funcionFiltroSeleccionado();
            cargarDatosFiltrados(textoBusqueda, filtroSeleccionado);
            if (filtroSeleccionado == "Horario")
            {
                ordenarDGVHorarios();
            }
            else if (filtroSeleccionado == "Carreras")
            {
                ordenarDGVCarreras();
            }
            else if (filtroSeleccionado == "Grupos")
            {
                ordenarDGVSecciones();
            }
            else if (filtroSeleccionado == "Ciclos")
            {
                ordenarDGVCiclos();
            }
            else if (filtroSeleccionado == "Materias")
            {
                ordenarDGVMaterias();
            }
            else if (filtroSeleccionado == "Docentes")
            {
                ordenarDGVDocentes();
            }
            else if (filtroSeleccionado == "Aulas")
            {
                ordenarDGVAulas();
            }
        }

        private string funcionFiltroSeleccionado()
        {
            if (cmbFiltro.SelectedIndex == 0)
            {
                return "Horario";
            }
            else if (cmbFiltro.SelectedIndex == 1)
            {
                return "Carreras";
            }
            else if (cmbFiltro.SelectedIndex == 2)
            {
                return "Grupos";
            }
            else if (cmbFiltro.SelectedIndex == 3)
            {
                return "Ciclos";
            }
            else if (cmbFiltro.SelectedIndex == 4)
            {
                return "Materias";
            }
            else if (cmbFiltro.SelectedIndex == 5)
            {
                return "Docentes";
            }
            else
            {
                return "Aulas";
            }
        }
        private void cargarDatosFiltrados(string textoBusqueda, string filtroSeleccionado)
        {
            object dataSourceResult = null;
            if (string.IsNullOrWhiteSpace(textoBusqueda) || textoBusqueda == "Buscar")
            {
                textoBusqueda = "";
            }
            string busqueda = textoBusqueda.ToLower();
            using (var context = new HorarioEscuelaComputacionContext())
            {
                switch (filtroSeleccionado)
                {
                    case "Horario":
                        IQueryable<VwHorariosDetallado> queryHorarios = context.VwHorariosDetallados;
                        queryHorarios = queryHorarios.Where(p =>
                        p.Carrera.ToLower().Contains(busqueda) ||
                        p.Docente.ToLower().Contains(busqueda) ||
                        p.Ciclo.ToLower().Contains(busqueda) ||
                        p.NombreAsignatura.ToLower().Contains(busqueda) ||
                        p.Naturaleza.ToLower().Contains(busqueda) ||
                        p.NombreAsignatura.ToLower().Contains(busqueda) ||
                        p.NombreSeccion.ToLower().Contains(busqueda) ||
                        p.Dia.ToLower().Contains(busqueda) ||
                        p.CodigoAula.ToLower().Contains(busqueda)
                        );
                        dataSourceResult = queryHorarios.ToList();
                        break;
                    case "Carreras":
                        IQueryable<Carrera> queryCarreras = context.Carreras;
                        queryCarreras = queryCarreras.Where(p =>
                        p.NombreCarrera.ToLower().Contains(busqueda) ||
                        p.Tipo.ToLower().Contains(busqueda)
                        );
                        dataSourceResult = queryCarreras.ToList();
                        break;
                    case "Grupos":
                        IQueryable<VwSeccionesDetalle> querySecciones = context.VwSeccionesDetalles;
                        querySecciones = querySecciones.Where(p =>
                        p.GrupoBase.ToLower().Contains(busqueda) ||
                        p.Familia.ToLower().Contains(busqueda) ||
                        p.NombreCarrera.ToLower().Contains(busqueda)
                        );
                        dataSourceResult = querySecciones.ToList();
                        break;
                    case "Ciclos":
                        IQueryable<Periodo> queryCiclos = context.Periodos;
                        queryCiclos = queryCiclos.Where(p =>
                        p.NombrePeriodo.ToLower().Contains(busqueda)
                        );
                        dataSourceResult = queryCiclos.ToList();
                        break;
                    case "Materias":
                        IQueryable<VwAsignaturasActualizadum> queryAsignaturas = context.VwAsignaturasActualizada;
                        queryAsignaturas = queryAsignaturas.Where(p =>
                        p.NombreAsignatura.ToLower().Contains(busqueda) ||
                        p.Naturaleza.ToLower().Contains(busqueda) ||
                        p.CodigoAsignatura.ToLower().Contains(busqueda) ||
                        p.Especialidad.ToLower().Contains(busqueda) ||
                        p.EsTransversal.ToString().ToLower().Contains(busqueda)
                        );
                        dataSourceResult = queryAsignaturas.ToList();
                        break;
                    case "Docentes":
                        IQueryable<Docente> queryDocentes = context.Docentes;
                        queryDocentes = queryDocentes.Where(p =>
                        p.Nombres.ToLower().Contains(busqueda) ||
                        p.Apellidos.ToLower().Contains(busqueda) ||
                        p.Telefono.ToLower().Contains(busqueda) ||
                        p.Categoria.ToLower().Contains(busqueda) ||
                        p.NivelAcademico.ToLower().Contains(busqueda) ||
                        p.Especialidad.ToLower().Contains(busqueda)
                        );
                        dataSourceResult = queryDocentes.ToList();
                        break;
                    case "Aulas":
                        IQueryable<Aula> queryAulas = context.Aulas;
                        queryAulas = queryAulas.Where(p =>
                        p.CodigoAula.ToLower().Contains(busqueda) ||
                        p.Tipo.ToLower().Contains(busqueda)
                        );
                        dataSourceResult = queryAulas.ToList();
                        break;
                    default:
                        break;
                }
            }
            dataGridViewBuscador.DataSource = dataSourceResult;
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
            txtBuscador.Focus();
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox1_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtBuscador_Enter(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "Buscar")
            {
                txtBuscador.Text = "";
            }
        }

        private void txtBuscador_Leave(object sender, EventArgs e)
        {

        }

        private void cmbFiltro_Leave(object sender, EventArgs e)
        {

        }
        private void ordenarDGVHorarios()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["IdHorario"].Visible = false;
            dataGridViewBuscador.Columns["NombreAsignatura"].HeaderText = "Asignatura";
            dataGridViewBuscador.Columns["nombreSeccion"].HeaderText = "Sección";
            dataGridViewBuscador.Columns["Dia"].HeaderText = "Día";
            dataGridViewBuscador.Columns["HoraInicio"].HeaderText = "Hora Inicio";
            dataGridViewBuscador.Columns["HoraFin"].HeaderText = "Hora Fin";
            dataGridViewBuscador.Columns["ModalidadClase"].HeaderText = "Modalidad";
            dataGridViewBuscador.Columns["naturaleza"].HeaderText = "Naturaleza";
            dataGridViewBuscador.Columns["Activo"].HeaderText = "Estado";
            dataGridViewBuscador.Columns["familia"].HeaderText = "Familia";
            dataGridViewBuscador.Columns["codigoAula"].HeaderText = "Aula";
        }
        private void ordenarDGVCarreras()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["IdCarrera"].Visible = false;
            dataGridViewBuscador.Columns["NombreCarrera"].HeaderText = "Carrera";
            dataGridViewBuscador.Columns["Tipo"].HeaderText = "Tipo";
            dataGridViewBuscador.Columns["Asignaturas"].Visible = false;
            dataGridViewBuscador.Columns["PlanDeEstudios"].Visible = false;
            dataGridViewBuscador.Columns["Seccions"].Visible = false;
        }
        private void ordenarDGVSecciones()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["idSeccion"].Visible = false;
            dataGridViewBuscador.Columns["turno"].Visible = false;
            dataGridViewBuscador.Columns["nombreCiclo"].Visible = false;
            dataGridViewBuscador.Columns["nombrePeriodo"].HeaderText = "Ciclo";
            dataGridViewBuscador.Columns["nombreCarrera"].HeaderText = "Carrera";
            dataGridViewBuscador.Columns["grupoBase"].HeaderText = "Familia";
            dataGridViewBuscador.Columns["familia"].HeaderText = "Grupo/Sección";
            dataGridViewBuscador.Columns["cupoMax"].HeaderText = "Cupo Máximo";
        }
        private void ordenarDGVCiclos()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["idPeriodo"].Visible = false;
            dataGridViewBuscador.Columns["nombrePeriodo"].HeaderText = "Ciclo";
            dataGridViewBuscador.Columns["fechaInicio"].HeaderText = "Fecha de Inicio";
            dataGridViewBuscador.Columns["fechaFin"].HeaderText = "Fecha de Fin";
            dataGridViewBuscador.Columns["estadoPeriodo"].HeaderText = "Estado";
            dataGridViewBuscador.Columns["CalendarioFeriados"].Visible = false;
            dataGridViewBuscador.Columns["Seccions"].Visible = false;
        }
        private void ordenarDGVMaterias()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["IdAsignatura"].Visible = false;
            dataGridViewBuscador.Columns["codigoAsignatura"].HeaderText = "Código";
            dataGridViewBuscador.Columns["nombreAsignatura"].HeaderText = "Nombre";
            dataGridViewBuscador.Columns["naturaleza"].HeaderText = "Tipo";
            dataGridViewBuscador.Columns["creditos"].HeaderText = "Créditos";
            dataGridViewBuscador.Columns["modalidad"].HeaderText = "Modalidad";
            dataGridViewBuscador.Columns["especialidad"].HeaderText = "Especialidad";
            dataGridViewBuscador.Columns["nombreCarrera"].HeaderText = "Carrera";
            dataGridViewBuscador.Columns["esTransversal"].HeaderText = "Transversal";
        }
        private void ordenarDGVDocentes()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["Iddocente"].Visible = false;
            dataGridViewBuscador.Columns["Horarios"].Visible = false;
            dataGridViewBuscador.Columns["nombreCompleto"].Visible = false;
            dataGridViewBuscador.Columns["idAsignaturas"].Visible = false;
        }
        private void ordenarDGVAulas()
        {
            dataGridViewBuscador.ClearSelection();
            dataGridViewBuscador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBuscador.Columns["IdAula"].Visible = false;
            dataGridViewBuscador.Columns["IdSede"].Visible = false;
            dataGridViewBuscador.Columns["IdSedeNavigation"].Visible = false;
            dataGridViewBuscador.Columns["Horarios"].Visible = false;
            dataGridViewBuscador.Columns["Disponible"].Visible = false;
        }

        private void formInicio_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
            txtBuscador.Focus();
        }
    }
}
