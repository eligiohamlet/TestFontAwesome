using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace TestFontAwesome
{
    public partial class Form1 : Form
    {
        private int i = -1, maximo;
        private List<IconChar> iconosAlfab, iconosOri;
        public Form1()
        {
            InitializeComponent();
            ordena1();
            llenaCombo();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            i++;
            visualiza();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            i--;
            visualiza();
        }
        private void visualiza()
        {
            if (i < 0)
                i = 0;
            if (i > maximo)
                i = maximo;
            if ((i >= 0) && (i <= maximo))
            {
                iconButton1.IconChar = iconosAlfab[i];
                iconButton1.Text = iconosAlfab[i].ToString();
                comboBox1.Text = iconosAlfab[i].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (cmb.SelectedItem != null)
            {
                i = selectedIndex;
                visualiza();
            }
        }

        private void ordena1()
        {
            iconosOri = Enum.GetValues(typeof(IconChar)).Cast<IconChar>().ToList();
            iconosAlfab = iconosOri.OrderBy(l => l.ToString()).ToList();
            maximo = iconosAlfab.Count;
        }
        private void llenaCombo()
        { comboBox1.DataSource = iconosAlfab; }
    }
}
