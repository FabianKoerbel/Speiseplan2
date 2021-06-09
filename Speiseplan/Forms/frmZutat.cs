using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Speiseplan.Classes;

namespace Speiseplan.Forms
{
    public partial class frmZutat : Form
    {
        public frmZutat()
        {
            InitializeComponent();
        }

        private void frmZutat_Load(object sender, EventArgs e)
        {

        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (txtEinheit.Text.Equals("") || txtBezeichnung.Text.Equals(""))
            {
                MessageBox.Show("Bitte geben Sie den Name und die Einheit der Zutat ein!");
                return;
            }
            if (this.Text.Equals("Zutat hinzufügen"))
            {
                Zutat z = new Zutat();
                z.ZutatID = Convert.ToInt32(txtZutatID.Text);
                z.Einheit = txtEinheit.Text;
                z.Bezeichnung = txtBezeichnung.Text;
                z.Allergene = txtAllergene.Text;
                frmStart.frmSt.listeZutaten.Add(z);
            }
            else
            {
                foreach (Zutat z in frmStart.frmSt.listeZutaten)
                {
                    if (z.ZutatID == Convert.ToInt32(txtZutatID.Text))
                    {
                        z.ZutatID = Convert.ToInt32(txtZutatID.Text);
                        z.Einheit = txtEinheit.Text;
                        z.Bezeichnung = txtBezeichnung.Text;
                        z.Allergene = txtAllergene.Text;
                        break;
                    }
                }
            }
            frmStart.frmSt.XmlSerialisierenSpeise();
            txtEinheit.Clear();
            txtBezeichnung.Clear();
            txtAllergene.Clear();
            this.Close();
        }

        private void txtAllergene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                MessageBox.Show("Bitte geben Sie Ihre Allergene(Kürzel) ein!", "Information:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
