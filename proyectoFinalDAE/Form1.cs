using System.Runtime.InteropServices;
using BCrypt.Net;
using proyectoFinalDAE.Clases;
using proyectoFinalDAE.Modelos;
namespace proyectoFinalDAE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Gestor gest = new Gestor();
        //Metodo que vi en un video para mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //fin del metodo

        //Si el usuario entra al textbox y el texto es USUARIO, se borra el texto
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
            }
        }

        //Si el usuario sale del textbox y el texto esta vacio, se pone el texto USUARIO
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
            }
        }

        //Si el usuario entra al textbox y el texto es CONTRASEÑA, se borra el texto y se activa el modo password
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        //Si el usuario sale del textbox y el texto esta vacio, se pone el texto CONTRASEÑA y se desactiva el modo password
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

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

        //Metodo para mover la ventana
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Fin del metodo

        //Boton para acceder al menu principal si el usuario y la contraseña son correctos
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = gest.ValidarLogin(txtUsuario.Text,txtContraseña.Text);
            if (usuarioLogueado != null)
            {
                SesionUsuario.UsuarioActual = usuarioLogueado.NombreUsuario;
                SesionUsuario.EsAdminDB = usuarioLogueado.Activo;
                this.Hide();
                Form2 mainMenu = new Form2();
                mainMenu.Show();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña válidos.");
                txtContraseña.Text = "";
                txtContraseña.UseSystemPasswordChar = true;
            }
        }
        //metodo de verificacion de usuario transversal o admin
        public static class SesionUsuario
        {
            public static string UsuarioActual { get; set; }
            public static bool EsAdminDB { get; set; }
            public static bool EsTransversal => UsuarioActual?.ToLower().Contains("transversal") == true;
            public static bool EsAudiovisuales => UsuarioActual?.ToLower().Contains("audiovisuales") == true;
        }

        //Cambiar color del boton minimizar al pasar el mouse

        private void pcrMinimize_MouseEnter(object sender, EventArgs e)
        {
            pcrMinimize.BackColor = Color.FromArgb(206, 146, 18);
        }

        private void pcrMinimize_MouseLeave(object sender, EventArgs e)
        {
            pcrMinimize.BackColor = Color.FromArgb(235, 210, 153);
        }
        //fin del metodo
        //Cambiar color del boton cerrar al pasar el mouse
        private void ptrClose_MouseEnter(object sender, EventArgs e)
        {
            ptrClose.BackColor = Color.FromArgb(206, 146, 18);
        }

        private void ptrClose_MouseLeave(object sender, EventArgs e)
        {
            ptrClose.BackColor = Color.FromArgb(235, 210, 153);
        }
        //fin del metodo
        //Evitar sonidos de sistema al presionar teclas
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        //Permitir presionar enter para acceder
        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcceder.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        //Permitir presionar enter para cambiar de textbox
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContraseña.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private bool mostrandoContraseña = false;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (mostrandoContraseña)
            {
                txtContraseña.UseSystemPasswordChar = true;
                pictureBox2.Image = Properties.Resources.icons8_eye_96Closed;
                mostrandoContraseña = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = false;
                pictureBox2.Image = Properties.Resources.icons8_eye_96;
                mostrandoContraseña = true;
            }
        }
    }
}
