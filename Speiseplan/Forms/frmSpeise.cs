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
    public partial class frmSpeise : Form
    {
        public frmSpeise()
        {
            InitializeComponent();
        }

        #region Variablen
        internal string bildpfad;
        internal string bewertung = "*";
        #endregion

        private void frmSpeise_Load(object sender, EventArgs e)
        {
            cbSpeiseart.SelectedIndex = 0;
        }

        internal void bewertungeinlesen()
        {
            if (rbB1.Checked)
                bewertung = "*";
            if (rbB2.Checked)
                bewertung = "**";
            if (rbB3.Checked)
                bewertung = "***";
            if (rbB4.Checked)
                bewertung = "****";
            if (rbB5.Checked)
                bewertung = "*****";
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            bewertungeinlesen();
            if (txtName.Text.Equals("") || cbSpeiseart.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte geben Sie den Name und die Art der Speise ein!");
                return;
            }
            if (this.Text.Equals("Speise hinzufügen"))
            {
                Speise s = new Speise();
                s.SpeiseID = Convert.ToInt32(txtSpeiseID.Text);
                s.Name = txtName.Text;
                s.Speiseart = Convert.ToChar(cbSpeiseart.Text);
                s.Bewertung = bewertung;
                s.Bildpfad = txtBildpfad.Text;
                frmStart.frmSt.listeSpeise.Add(s);
            }
            else
            {
                foreach (Speise s in frmStart.frmSt.listeSpeise)
                {
                    if (s.SpeiseID == Convert.ToInt32(txtSpeiseID.Text))
                    {
                        s.SpeiseID = Convert.ToInt32(txtSpeiseID.Text);
                        s.Name = txtName.Text;
                        s.Speiseart = Convert.ToChar(cbSpeiseart.Text);
                        s.Bewertung = bewertung;
                        s.Bildpfad = txtBildpfad.Text;
                        break;
                    }
                }
            }
            frmStart.frmSt.XmlSerialisierenSpeise();
            txtSpeiseID.Clear();
            txtName.Clear();
            bildpfad = Application.StartupPath + "\\img\\default.jpg";
            txtBildpfad.Text = bildpfad;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\img\\default.jpg");
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Image File (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *jpeg; *.gif; *.bmp; *.png|All Files (*.*)|*.*";
                ofd.InitialDirectory = "C:/Schule\03Hak/Ap/C#\01-Hü/6. Speiseplan/Speiseplan/Speiseplan\bin/Debug/img";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    bildpfad = ofd.FileName;
                    txtBildpfad.Text = bildpfad;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Bitte geben Sie eine Bewerutng für die Ausgewählte Speise ein. Dabei ist 1 Stern das Schlechteste und 5 Sterne das Beste.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
