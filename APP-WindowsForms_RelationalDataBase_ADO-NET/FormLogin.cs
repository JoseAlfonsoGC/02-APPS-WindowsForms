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
        //private void btnMouseLeave(object sender, EventArgs e)
        //{
        //    //pUsuario.Controls.Remove(p);
        //}
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            btnMauseEnter(sender,e);
        }
        
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnMauseEnter(sender, e);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
