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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }
        private List<rol> ComboRol()
        {
            using(dbrolesEntities db = new dbrolesEntities())
            {
                return db.rol.ToList();
            }
        }
        private void CargarCombo()
        {
            try
            {
                var Lst = ComboRol();
                comboBoxRol.DataSource = Lst;
                comboBoxRol.DisplayMember = "nombre";
                comboBoxRol.ValueMember = "id";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GuardarUsuario(usuario pUsuario)
        {
            try
            {
                using(dbrolesEntities db = new dbrolesEntities())
                {
                    db.usuario.Add(pUsuario);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            usuario usuarioEnt = new usuario();
            usuarioEnt.nombre = txtUsuario.Text;
            usuarioEnt.passwordd = txtPassword.Text;
            usuarioEnt.rolid = (int)comboBoxRol.SelectedValue;
            GuardarUsuario(usuarioEnt);
            MessageBox.Show("Usuario guardado");
        }

        
    }
}
