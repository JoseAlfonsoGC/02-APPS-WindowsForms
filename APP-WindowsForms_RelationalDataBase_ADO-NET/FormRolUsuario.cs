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
    public partial class FormRolUsuario : Form
    {
        public FormRolUsuario()
        {
            InitializeComponent();
        }
        Panel p = new Panel();
        private void FormRolUsuario_Load(object sender, EventArgs e)
        {
            
        }
        private void btnMauseEnter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            pNombre.Controls.Add(p);
            p.BackColor = Color.FromArgb(90, 210, 2);
            p.Size = new Size(148, 3);
            p.Location = new
                Point(txt.Location.X, txt.Location.Y + 13);
        }
        private void btnMouseLeave(object sender, EventArgs e)
        {
            pNombre.Controls.Remove(p);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
