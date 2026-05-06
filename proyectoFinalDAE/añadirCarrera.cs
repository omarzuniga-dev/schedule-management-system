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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proyectoFinalDAE
{
    public partial class añadirCarrera : Form
    {
        //Instancia del gestor para pober acceder a la BDD 
        private readonly Gestor _gestor = new Gestor();
        private int? _idEditando = null; // esta variable indica si estoy agregando (null) o editando (tiene id)
        private bool mostrandoInactivas = false; //Esta variable me indica si estoy viendo carreras inactivas
        public añadirCarrera()
        {
            InitializeComponent();
        }

        private async void añadirCarrera_Load(object sender, EventArgs e)
        {
            CargarComboEspecialidadCarrera();          // Llenar combo Técnico / Ingeniería
            await CargarGridAsync(true);               // Cargar activas al inicio
            txtCodigoCarrera.ReadOnly = true;          // Id no se edita
            checkActiva.Checked = true;
        }
        //Método para cargar las opciones del combo de especialidad
        private void CargarComboEspecialidadCarrera()
        {
            combEspecialidadCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
            combEspecialidadCarrera.DisplayMember = "Text";
            combEspecialidadCarrera.ValueMember = "Value";
            //Opciones disponibles para el usuario
            var datos = new[]
            {
        new { Text = "Técnico",    Value = "Técnico" },
        new { Text = "Ingeniería", Value = "Ingeniería" }
         };
            //Asigno la lista al combo
            combEspecialidadCarrera.DataSource = datos.ToList();
            combEspecialidadCarrera.SelectedIndex = -1; // Ninguna seleccionada al inicio
        }


        //metodo para cargar DataGridView 

        private async Task CargarGridAsync(bool soloActivas = true)
        {
            // Obtener lista según estado
            var lista = soloActivas
                ? await _gestor.listarCarrerasEsme()          // activas
                : await _gestor.listarCarrerasInactivas(); // inactivas

            dvgCarreras.DataSource = null;
            dvgCarreras.AutoGenerateColumns = false;

            // Crear columnas solo la primera vez
            if (dvgCarreras.Columns.Count == 0)
            {
                dvgCarreras.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    DataPropertyName = "IdCarrera",
                    HeaderText = "Código",
                    Width = 80,
                    ReadOnly = true
                });

                dvgCarreras.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colNombre",
                    DataPropertyName = "NombreCarrera",
                    HeaderText = "Nombre",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });

                dvgCarreras.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colTipo",
                    DataPropertyName = "Tipo",
                    HeaderText = "Especialidad",
                    Width = 150,
                    ReadOnly = true
                });


                dvgCarreras.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    Name = "colActivo",
                    DataPropertyName = "Estado",
                    HeaderText = "Activo",
                    Width = 60,
                    ReadOnly = true
                });


                dvgCarreras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dvgCarreras.MultiSelect = false;
                dvgCarreras.RowHeadersVisible = false;
                dvgCarreras.ReadOnly = true;
            }


            dvgCarreras.DataSource = lista;

            dvgCarreras.ClearSelection();
        }

        //fin de metodo cargar data gridview
        //tomar carrera del formulario 
        private Carrera TomarCarreraDelFormulario()
        {
            string nombre = (textNombreCarrera.Text ?? "").Trim();
            string tipo = combEspecialidadCarrera.SelectedValue?.ToString() ?? "";
            // Validaciones para el usuario
            if (string.IsNullOrWhiteSpace(nombre))
                throw new InvalidOperationException("El nombre de la carrera es obligatorio.");

            if (string.IsNullOrWhiteSpace(tipo))
                throw new InvalidOperationException("Debes elegir la especialidad (Técnico/Ingeniería).");

            //Armo la entidad
            var entidad = new Carrera
            {
                NombreCarrera = nombre,
                Tipo = tipo,
                Estado = checkActiva.Checked
            };
            //Si estoy editando, agrego el ID
            if (_idEditando.HasValue)
                entidad.IdCarrera = _idEditando.Value;

            return entidad;
        }


        //limpiar formulario 
        private void LimpiarFormulario()
        {
            _idEditando = null;
            txtCodigoCarrera.Text = "";
            textNombreCarrera.Text = "";
            combEspecialidadCarrera.SelectedIndex = -1;
            checkActiva.Checked = true;
            btnAñadirMateria.Text = "Añadir";
            dvgCarreras.ClearSelection();
            textNombreCarrera.Focus();
        }

        private async void btnAñadirMateria_Click(object sender, EventArgs e)
        {
            try
            {
                var carrera = TomarCarreraDelFormulario();
                if (carrera == null) return;

                if (_idEditando == null)
                {
                    bool existe = await _gestor.ExisteRegistro<Carrera>(x => x.NombreCarrera == carrera.NombreCarrera);

                    if (existe)
                    {
                        MessageBox.Show($"La carrera '{carrera.NombreCarrera}' ya existe.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _gestor.agregarCarrera(carrera);
                    await _gestor.RegistrarLog(
                    "INSERTAR",
                    "Carreras",
                    $"Se creó la Carrera: {carrera.NombreCarrera}");
                    MessageBox.Show("Carrera agregada correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bool duplicado = await _gestor.ExisteRegistro<Carrera>(x => x.NombreCarrera == carrera.NombreCarrera &&
                    x.IdCarrera != _idEditando.Value);

                    if (duplicado)
                    {
                        MessageBox.Show($"Ya existe otra carrera con el nombre '{carrera.NombreCarrera}'.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _gestor.actualizarCarrera(carrera);
                    await _gestor.RegistrarLog(
                    "EDITAR",
                    "Carreras",
                    $"Se modificó la carrera ID {carrera.IdCarrera}. Nuevo nombre: {carrera.NombreCarrera}");
                    MessageBox.Show("Carrera actualizada correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarFormulario();
                await CargarGridAsync(true);
                pictureBox1.Image = Properties.Resources.icons8_switch_96;
            }
            catch (InvalidOperationException exVal)
            {
                MessageBox.Show(exVal.Message, "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dvgCarreras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dvgCarreras.Rows[e.RowIndex].DataBoundItem as Carrera;
            if (fila == null) return;

            _idEditando = fila.IdCarrera;


            txtCodigoCarrera.Text = fila.IdCarrera.ToString();
            textNombreCarrera.Text = fila.NombreCarrera;
            combEspecialidadCarrera.SelectedValue = fila.Tipo;

            checkActiva.Checked = fila.Estado;

            btnAñadirMateria.Text = "Actualizar";
        }

        private void dvgCarreras_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvgCarreras.IsCurrentCellDirty)
            {
                dvgCarreras.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dvgCarreras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dvgCarreras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dvgCarreras.CurrentRow != null)
            {
                var carrera = dvgCarreras.CurrentRow.DataBoundItem as Carrera;
                if (carrera == null) return;

                var confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar la carrera?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmar == DialogResult.Yes)
                {
                    try
                    {
                        _gestor.eliminarCarrera(carrera.IdCarrera);
                        await CargarGridAsync(!mostrandoInactivas ? true : false);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la carrera: {ex.Message}",
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }// fin de soft delete con tecla suprimi

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!mostrandoInactivas)
                {
                    pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
                    await CargarGridAsync(false);         // inactivas
                    mostrandoInactivas = true;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.icons8_switch_96;
                    await CargarGridAsync(true);          // activas
                    mostrandoInactivas = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar carreras: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetGrupo_Click(object sender, EventArgs e)
        {
            txtCodigoCarrera.Text = "";
            textNombreCarrera.Text = "";
            combEspecialidadCarrera.SelectedIndex = -1;
            checkActiva.Checked = false;
            btnAñadirMateria.Text = "Añadir";
            dvgCarreras.ClearSelection();
            LimpiarFormulario();
        }

        private void txtCodigoCarrera_MouseEnter(object sender, EventArgs e)
        {
            if (txtCodigoCarrera.ReadOnly)
            {
                ttAyuda.ToolTipTitle = "Campo Bloqueado";
                ttAyuda.SetToolTip(txtCodigoCarrera, "El código de carrera se asigna automáticamente");
            }
            else
            {
                ttAyuda.SetToolTip(txtCodigoCarrera, null);
            }
        }

        private void txtCodigoCarrera_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodigoCarrera_Leave(object sender, EventArgs e)
        {

        }

        private void textNombreCarrera_Enter(object sender, EventArgs e)
        {
            if (textNombreCarrera.Text == "Nombre")
            {
                textNombreCarrera.Text = "";
            }
        }

        private void textNombreCarrera_Leave(object sender, EventArgs e)
        {
            if (textNombreCarrera.Text == "")
            {
                textNombreCarrera.Text = "Nombre";
            }
        }
    }

}
