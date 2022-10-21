using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_WindowsForms_RelationalDataBase_ADO_NET
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        //Efecto de inimacion
        Panel p = new Panel();
        private void btnMauseEnter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            pUsuario.Controls.Add(p);
            p.BackColor = Color.FromArgb(90, 210, 2);
            p.Size = new Size(180, 3);
            p.Location = new
                Point(txt.Location.X, txt.Location.Y + 13);
        }
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            btnMauseEnter(sender,e);
        }
        
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnMauseEnter(sender, e);
        }
        //programacion de interfaz
        int IdRol, IdUsu;
        string nomUsu;
        private List<usuario>BuscarUsuario(string pUsuario, string pPassword)
        {
            try
            {
                using(dbrolesEntities db = new dbrolesEntities())
                {
                    return db.usuario.Where(usuario => usuario.nombre == pUsuario
                    && usuario.passwordd == pPassword).ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        private bool ValidarCampos()
        {
            var usuario = BuscarUsuario(txtUsuario.Text, txtPassword.Text);
            foreach(var usu in usuario)
            {
                IdRol = usu.rolid;
                IdUsu = usu.id;
                nomUsu = usu.nombre;
            }
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Ingresa usuario");
                txtUsuario.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Ingresa password");
                txtPassword.Focus();
                return false;
            }
            else if (usuario.Count <= 0)
            {
                MessageBox.Show("Usuario no registrado");
                return false;
            }
            return true;
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Form1 frm = new Form1(nomUsu, IdRol, IdUsu);
                frm.Show();
                this.Hide();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
