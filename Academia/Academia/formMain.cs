using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.TabControl;

namespace Academia
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            frmLogin appLogin = new frmLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        Size originalSize;
        String originalText;

        void CustomizeLabel_MouseEnter(object sender, EventArgs e)
        {
            TabControl tabControl = new TabControl();
            originalSize = CustomizeLabel.Size;
            originalText = CustomizeLabel.Text;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(originalText);
            foreach (TabPage tp in tabControl.TabPages)
            {
                sb.AppendLine("    " + tp.Text);
            }

            CustomizeLabel.Text = sb.ToString();
            CustomizeLabel.Height = TextRenderer.MeasureText(CustomizeLabel.Text,
            CustomizeLabel.Font).Height;
        }

        void CustomizeLabel_MouseLeave(object sender, EventArgs e)
        {
            CustomizeLabel.Text = originalText;
            CustomizeLabel.Size = originalSize;
        }
    }
}
