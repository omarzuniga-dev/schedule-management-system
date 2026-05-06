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
    /*
     public string NombreCompleto
    {
        get { return Nombres + " " + Apellidos; }
    }

    public string NombreUsuario
    {
        get { return Nombres + "_" + Apellidos; }
    }
     */
    public partial class OpcionesAvanzadas : Form
    {
        Gestor gest = new Gestor();
        public OpcionesAvanzadas()
        {
            InitializeComponent();
        }

        private void OpcionesAvanzadas_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            cargarDocentes();
        }
        private async void cargarUsuarios()
        {
            var datosUsuarios = await gest.listarUsuarios();
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = datosUsuarios;
            dataGridViewUsuarios.ClearSelection();
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.Columns["IdUsuario"].Visible = false;
            dataGridViewUsuarios.Columns["IdRols"].Visible = false;
            dataGridViewUsuarios.Columns["email"].Visible = false;
            dataGridViewUsuarios.Columns["nombreUsuario"].HeaderText = "Usuario";
            dataGridViewUsuarios.Columns["contraseñaHash"].HeaderText = "Contraseña";
            dataGridViewUsuarios.Columns["Activo"].HeaderText = "Es admin";
        }

        private void dataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!isSwitchOn)
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv != null && dgv.Columns.Contains("contraseñaHash"))
                {
                    int columnIndexContrasena = dgv.Columns["contraseñaHash"].Index;
                    if (e.ColumnIndex == columnIndexContrasena && e.RowIndex >= 0)
                    {
                        e.Value = "*************************";
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        private bool isSwitchOn = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isSwitchOn = !isSwitchOn;
            if (!isSwitchOn)
            {
                pictureBox1.Image = Properties.Resources.icons8_switch_96;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.icons8_switch_96__1_;
            }
            if (dataGridViewUsuarios.Columns.Contains("contraseñaHash"))
            {
                int colIndex = dataGridViewUsuarios.Columns["contraseñaHash"].Index;
                dataGridViewUsuarios.InvalidateColumn(colIndex);
            }
        }
        public static class GeneradorAleatorio
        {
            private static Random random = new Random();
            private const string CARACTERES_PERMITIDOS =
                "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "0123456789" +
                "!*_-";
            public static string GenerarPasswordAleatorio(int longitud)
            {
                StringBuilder password = new StringBuilder();

                for (int i = 0; i < longitud; i++)
                {
                    int index = random.Next(CARACTERES_PERMITIDOS.Length);
                    password.Append(CARACTERES_PERMITIDOS[index]);
                }

                return password.ToString();
            }
        }
        private void btnContraseña_Click(object sender, EventArgs e)
        {
            string contraseña = GeneradorAleatorio.GenerarPasswordAleatorio(12);
            txtContraseña.Text = contraseña;
        }

        private async void btnAñadirMateria_Click(object sender, EventArgs e)
        {
            try
            {
                //validamos que todos los campos esten completos
                if (string.IsNullOrWhiteSpace(cmbUsuarios.Text) || txtContraseña.Text == "Contraseña")
                {
                    MessageBox.Show("Por favor, complete o modifique todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int IdUsuarioAEditar = 0;
                if (dataGridViewUsuarios.SelectedRows.Count > 0)
                {
                    //lo convertimos a entero
                    IdUsuarioAEditar = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
                }//creamos el objeto docente con los datos del formulario
                int idUsuario = IdUsuarioAEditar;
                string nombreUsuario = cmbUsuarios.Text;
                string contraseñaHash = txtContraseña.Text;
                string email = "itca@itca.edu.sv";
                bool estado = chkEsAdmin.Checked;
                Usuario usuario = new Usuario()
                {
                    IdUsuario = idUsuario,
                    NombreUsuario = nombreUsuario,
                    ContraseñaHash = contraseñaHash,
                    Email = email,
                    Activo = estado
                };
                if (IdUsuarioAEditar > 0)
                {
                    bool duplicado = await gest.ExisteRegistro<Usuario>(x =>
                    x.NombreUsuario == nombreUsuario &&
                    x.IdUsuario != IdUsuarioAEditar);

                    if (duplicado)
                    {
                        MessageBox.Show($"El usuario '{nombreUsuario}' ya está registrado.",
                                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detiene el proceso
                    }
                    gest.actualizarUsuario(usuario);
                    await gest.RegistrarLog(
                    "EDITAR",
                    "Usuarios",
                    $"Se modificó el usuario ID {usuario.IdUsuario}. Administrador?: {usuario.Activo}");
                    MessageBox.Show("Usuario Actualizado correctamente");
                }
                else //sino se crea como nuevo
                {
                    bool existe = await gest.ExisteRegistro<Usuario>(x => x.NombreUsuario == nombreUsuario);

                    if (existe)
                    {
                        MessageBox.Show($"El usuario '{nombreUsuario}' ya existe.",
                                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detiene el proceso
                    }
                    gest.agregarUsuario(usuario);
                    await gest.RegistrarLog(
                    "INSERTAR",
                    "Usuarios",
                    $"Se creó el usuario: {usuario.NombreUsuario} con ID {usuario.IdUsuario}");
                    MessageBox.Show("Usuario agregado correctamente");
                }
                //limpiamos los campos y recargamos los datos
                limpiarCampos();
                cargarUsuarios();
                btnAñadirMateria.Text = "Añadir";
            }

            catch (Exception ex)
            {
                //Debugging de errores
                string errorMessage = $"Error al guardar: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nDetalle de la BDD: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "ERROR DE BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiarCampos()
        {
            txtContraseña.Text = "Contraseña";
            cmbUsuarios.SelectedIndex = -1;
            chkEsAdmin.Checked = false;
        }

        private void dataGridViewUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAñadirMateria.Text = "Actualizar";
            txtContraseña.ReadOnly = false;
            if (e.RowIndex >= 0)
            {
                var fila = dataGridViewUsuarios.Rows[e.RowIndex];
                if (fila.Cells["nombreUsuario"].Value.ToString() == "Admin")
                {
                    MessageBox.Show("No se puede modificar el usuario Admin", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(fila.Cells["nombreUsuario"].Value.ToString() == "Transversales")
                {
                    MessageBox.Show("No se puede modificar el usuario Transversales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(fila.Cells["nombreUsuario"].Value.ToString() == "Audiovisuales")
                {
                    MessageBox.Show("No se puede modificar el usuario Audiovisuales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cmbUsuarios.Text = fila.Cells["nombreUsuario"].Value.ToString();
                    txtContraseña.Text = fila.Cells["contraseñaHash"].Value.ToString();
                    chkEsAdmin.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
                    txtContraseña.ReadOnly = true;
                }

            }
        }
        private async void cargarDocentes()
        {
            try
            {
                var datosDocentes = await gest.listarDocentesUsuario();
                cmbUsuarios.DataSource = datosDocentes;
                cmbUsuarios.DisplayMember = "NombreUsuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnResetGrupo_Click(object sender, EventArgs e)
        {
            txtContraseña.ReadOnly = true;
            btnAñadirMateria.Text = "Añadir";
            dataGridViewUsuarios.ClearSelection();
            limpiarCampos();
            cargarDocentes();
        }

        private void dataGridViewUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewUsuarios.CurrentRow != null)
            {
                var usuario = dataGridViewUsuarios.CurrentRow.DataBoundItem as Usuario;
                var confirmar = MessageBox.Show("¿Quitar permisos de admistrador?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    gest.eliminarUsuario(usuario.IdUsuario);
                    cargarUsuarios();
                }
            }
        }
    }
}
