using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyectoFinalDAE.Form1;

namespace proyectoFinalDAE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Metodo que vi en un video para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //fin del metodo

        //Cerrar la aplicacion
        private void ptrClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Minimizar la aplicacion
        private void pcrMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Codigo para mover la ventana
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Fin del codigo para mover la ventana

        private void pcrMinimize_MouseHover(object sender, EventArgs e)
        {

        }
        //Cambiar color al boton cerrar al pasar el mouse
        private void pcrMinimize_MouseLeave(object sender, EventArgs e)
        {
            pcrMinimize.BackColor = Color.FromArgb(235, 210, 153);
        }

        private void ptrClose_MouseEnter(object sender, EventArgs e)
        {
            ptrClose.BackColor = Color.FromArgb(206, 146, 18);
        }

        private void ptrClose_MouseLeave(object sender, EventArgs e)
        {
            ptrClose.BackColor = Color.FromArgb(235, 210, 153);
        }

        private void pcrMinimize_MouseEnter(object sender, EventArgs e)
        {
            pcrMinimize.BackColor = Color.FromArgb(206, 146, 18);
        }
        //Fin del codigo para cambiar color de los botones

        //Metodo para cargar formularios dentro del panel
        public void loadForm(object Form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form fh = Form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(fh);
            this.mainPanel.Tag = fh;
            fh.Show();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            loadForm(new añadirForm());
            ActivarBoton(sender);
            lblHeader.Text = "Horario";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bloquearAudiovisuales();
            bloquearTransversales();
            bloquearNoAdmins();
            loadForm(new formInicio());
            lblUsuario.Text = SesionUsuario.UsuarioActual;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadForm(new formInicio());
            ActivarBoton(sender);
            lblHeader.Text = "Inicio";
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            loadForm(new formInicio());
            ActivarBoton(sender);
            lblHeader.Text = "Inicio";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            loadForm(new añadirDocente());
            lblHeader.Text = "Docentes";

        }
        private void btnMateriaInicio_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            loadForm(new añadirMateria());
            lblHeader.Text = "Materias";
        }

        private void btnCarrerasInicio_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            loadForm(new añadirCarrera());
            lblHeader.Text = "Carreras";
        }

        private void btnAulaInicio_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            loadForm(new añadirAula());
            lblHeader.Text = "Aulas";
        }

        private void btnReporteInicio_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            loadForm(new añadirReporte());
            lblHeader.Text = "Reportes";
        }
        //boton de cerrar sesion
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "¿Estás seguro que deseas cerrar sesión?",
            "Cerrar Sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarDatosSesion(); //Limpia los datos de la sesion (el rol)
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }
        private void LimpiarDatosSesion()
        {
            SesionUsuario.UsuarioActual = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnGruposYFamilias_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            loadForm(new GruposYFamiliasForm());
            lblHeader.Text = "Grupos y Ciclos";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loadForm(new OpcionesAvanzadas());
            lblHeader.Text = "Opciones Avanzadas";
        }
        private void ActivarBoton(object btnSender)
        {
            Color colorActivo = Color.FromArgb(176, 41, 28);
            Color colorDefault = Color.FromArgb(206, 146, 18);

            Button btn = (Button)btnSender;
            foreach (Control c in btn.Parent.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = colorDefault;
                }
            }
            btn.BackColor = colorActivo;
        }

        private void lblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void bloquearTransversales()
        {
            if (SesionUsuario.EsTransversal)
            {
                btnCarrerasInicio.Enabled = false;
                btnGruposYFamilias.Enabled = false;
                btnAulaInicio.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox2.Visible = false;
            }
        }
        private void bloquearNoAdmins()
        {
            if (!SesionUsuario.EsAdminDB)
            {
                btnAñadir.Enabled = false;
                btnCarrerasInicio.Enabled = false;
                btnGruposYFamilias.Enabled = false;
                btnAulaInicio.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox2.Visible = false;
                btnDocentes.Enabled = false;
                btnMateriaInicio.Enabled = false;
            }
        }
        private void bloquearAudiovisuales()
        {
            if (SesionUsuario.EsAudiovisuales)
            {
                btnCarrerasInicio.Enabled = false;
                btnGruposYFamilias.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox2.Visible = false;
                btnDocentes.Enabled = false;
                btnMateriaInicio.Enabled = false;
            }
        }
    }
}
