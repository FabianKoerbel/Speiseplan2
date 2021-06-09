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
using Speiseplan.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Speiseplan
{
    public partial class frmStart : Form
    {
        internal static frmStart frmSt;
        public frmStart()
        {
            frmSt = this;
            InitializeComponent();
        }

        #region Variabeln
        internal XmlSerializer serializierAllergene;
        internal XmlSerializer serializierZutat;
        internal XmlSerializer serilaizierSpeise;

        frmSpeise frmSp = new frmSpeise();
        frmZutat frmZu = new frmZutat();
        frmauswaehlen frmAus = new frmauswaehlen();

        internal List<Speise> listeSpeise = new List<Speise>();
        internal List<Zutat> listeZutaten = new List<Zutat>();
        internal List<Allergene> listeAllergene;

        internal ListViewItem lvItem;
        internal ListViewItem lvItemR;
        internal int inde;
        internal Speise speiseAktuell;

        internal Random r = new Random();
        internal List<string> vorspeise = new List<string>();
        internal List<string> hauptspeise = new List<string>();
        internal List<string> nachspeise = new List<string>();

        internal string wort;
        internal string tag;
        internal string art;
        #endregion

        #region Form
        private void frmStart_Load(object sender, EventArgs e)
        {
            this.Width = 1099;
            this.Height = 408;
            panel1.Visible = false;
            
            lvAllergene.FullRowSelect = true;
            lvRezept.FullRowSelect = true;
            lvSpeise.FullRowSelect = true;
            lvZutaten.FullRowSelect = true;

            #region Allergene hinzufügen
            listeAllergene = new List<Allergene>();
            //listeAllergene.Add(new Allergene("A", "Gluten"));
            //listeAllergene.Add(new Allergene("B", "Krebstiere"));
            //listeAllergene.Add(new Allergene("C", "Eier"));
            //listeAllergene.Add(new Allergene("D", "Fisch"));
            //listeAllergene.Add(new Allergene("E", "Erdnüsse"));
            //listeAllergene.Add(new Allergene("F", "Soja"));
            //listeAllergene.Add(new Allergene("G", "Milch und Lactose"));
            //listeAllergene.Add(new Allergene("H", "Schalenfrüchte"));
            //listeAllergene.Add(new Allergene("L", "Sellerie"));
            //listeAllergene.Add(new Allergene("M", "Senf"));
            //listeAllergene.Add(new Allergene("N", "Sesamsamen"));
            //listeAllergene.Add(new Allergene("O", "Schwefeldioxid und Sulfite"));
            //listeAllergene.Add(new Allergene("P", "Lupine"));
            //listeAllergene.Add(new Allergene("R", "Weichtiere"));
            #endregion

            XmlDeserialisierenAllergene();
            XmlDeserialisierenSpeise();
            XmlDeserialisierenZutat();

            IDsetzen();

            einlesenLvAllergene();
            einlesenLvSpeisen();
            einlesenLvZutaten();
            einlesencbBewertung();
        }

        private void frmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerialisierenAllergene();
            XmlSerialisierenSpeise();
            XmlSerialisierenZutat();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.Width = 1099;
                this.Height = 408;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                this.Width = 1292;
                this.Height = 445;
            }

            if (tabControl1.SelectedIndex == 2)
            {
                this.Width = 842;
                this.Height = 482;
            }
        }

        #endregion

        #region Methoden
        #region De/Serialisieren
        internal void XmlSerialisierenSpeise()
        {
            try
            {
                serilaizierSpeise = new XmlSerializer(typeof(List<Speise>));
                FileStream fs = new FileStream(Application.StartupPath + "\\Speise.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                serilaizierSpeise.Serialize(fs, listeSpeise);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Serialisieren: " + ex.Message);
            }
        }

        internal void XmlSerialisierenZutat()
        {
            try
            {
                serializierZutat = new XmlSerializer(typeof(List<Zutat>));
                FileStream fs = new FileStream(Application.StartupPath + "\\Zutat.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                serializierZutat.Serialize(fs, listeZutaten);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Serialisieren: " + ex.Message);
            }
        }

        internal void XmlSerialisierenAllergene()
        {
            try
            {
                serializierAllergene = new XmlSerializer(typeof(List<Allergene>));
                FileStream fs = new FileStream(Application.StartupPath + "\\Allergene.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                serializierAllergene.Serialize(fs, listeAllergene);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Serialisieren: " + ex.Message);
            }
        }

        internal void XmlDeserialisierenSpeise()
        {
            try
            {
                serilaizierSpeise = new XmlSerializer(typeof(List<Speise>));
                FileStream fs = new FileStream(Application.StartupPath + "\\Speise.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                listeSpeise = (List<Speise>)serilaizierSpeise.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Deserialisieren: " + ex.Message);
            }
        }

        internal void XmlDeserialisierenZutat()
        {
            try
            {
                serializierZutat = new XmlSerializer(typeof(List<Zutat>));
                FileStream fs = new FileStream(Application.StartupPath + "\\Zutat.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                listeZutaten = (List<Zutat>)serializierZutat.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Deserialisieren: " + ex.Message);
            }
        }

        internal void XmlDeserialisierenAllergene()
        {
            try
            {
                serializierAllergene = new XmlSerializer(typeof(List<Allergene>));
                FileStream fs = new FileStream(Application.StartupPath + "\\Allergene.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                listeAllergene = (List<Allergene>)serializierAllergene.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Deserialisieren: " + ex.Message);
            }
        }
        #endregion

        #region einlesen
        internal void einlesenLvAllergene()
        {
            listeAllergene = listeAllergene.OrderBy(c => c.Abkuerzung).ToList();
            lvAllergene.Items.Clear();
            foreach (Allergene a in listeAllergene)
            {
                lvItem = new ListViewItem(a.Abkuerzung);
                lvItem.SubItems.Add(a.Bezeichung);

                lvAllergene.Items.Add(lvItem);

                lvAllergene.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvAllergene.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        internal void einlesenLvZutaten()
        {
            listeZutaten = listeZutaten.OrderBy(c => c.ZutatID).ToList();
            lvZutaten.Items.Clear();
            foreach (Zutat z in listeZutaten)
            {
                lvItem = new ListViewItem(z.ZutatID.ToString());
                lvItem.SubItems.Add(z.Einheit);
                lvItem.SubItems.Add(z.Bezeichnung);
                lvItem.SubItems.Add(z.Allergene);

                lvZutaten.Items.Add(lvItem);

                lvZutaten.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvZutaten.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        internal void einlesenLvSpeisen()
        {
            listeSpeise = listeSpeise.OrderBy(c => c.SpeiseID).ToList();
            showImages();
            lvSpeise.Items.Clear();
            for (int i = 0; i < listeSpeise.Count; i++)
            {
                if (rbAlleSpeisen.Checked)
                {
                    lvItem = new ListViewItem();
                    lvItem.ImageIndex = i;
                    lvItem.SubItems.Add(listeSpeise[i].SpeiseID.ToString());
                    lvItem.SubItems.Add(listeSpeise[i].Name);
                    lvItem.SubItems.Add(listeSpeise[i].Speiseart.ToString());
                    lvItem.SubItems.Add(listeSpeise[i].Bewertung);
                    lvItem.SubItems.Add(listeSpeise[i].Bildpfad);
                    lvSpeise.Items.Add(lvItem);
                }
                if (rbVorspeisen.Checked)
                {
                    if (listeSpeise[i].Speiseart.ToString().Equals("V"))
                    {
                        lvItem = new ListViewItem();
                        lvItem.ImageIndex = i;
                        lvItem.SubItems.Add(listeSpeise[i].SpeiseID.ToString());
                        lvItem.SubItems.Add(listeSpeise[i].Name);
                        lvItem.SubItems.Add(listeSpeise[i].Speiseart.ToString());
                        lvItem.SubItems.Add(listeSpeise[i].Bewertung);
                        lvItem.SubItems.Add(listeSpeise[i].Bildpfad);
                        lvSpeise.Items.Add(lvItem);
                    }
                }
                if (rbHauptspeisen.Checked)
                {
                    if (listeSpeise[i].Speiseart.ToString().Equals("H"))
                    {
                        lvItem = new ListViewItem();
                        lvItem.ImageIndex = i;
                        lvItem.SubItems.Add(listeSpeise[i].SpeiseID.ToString());
                        lvItem.SubItems.Add(listeSpeise[i].Name);
                        lvItem.SubItems.Add(listeSpeise[i].Speiseart.ToString());
                        lvItem.SubItems.Add(listeSpeise[i].Bewertung);
                        lvItem.SubItems.Add(listeSpeise[i].Bildpfad);
                        lvSpeise.Items.Add(lvItem);
                    }
                }
                if (rbNachspeise.Checked)
                {
                    if (listeSpeise[i].Speiseart.ToString().Equals("N"))
                    {
                        lvItem = new ListViewItem();
                        lvItem.ImageIndex = i;
                        lvItem.SubItems.Add(listeSpeise[i].SpeiseID.ToString());
                        lvItem.SubItems.Add(listeSpeise[i].Name);
                        lvItem.SubItems.Add(listeSpeise[i].Speiseart.ToString());
                        lvItem.SubItems.Add(listeSpeise[i].Bewertung);
                        lvItem.SubItems.Add(listeSpeise[i].Bildpfad);
                        lvSpeise.Items.Add(lvItem);
                    }
                }
                lvSpeise.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvSpeise.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        
        internal void einlesenLvRezept()
        {
            try
            {
                listeZutaten = listeZutaten.OrderBy(c => c.ZutatID).ToList();
                lvRezept.Items.Clear();
                foreach (Zutat z in speiseAktuell.ListeZutaten)
                {
                    lvItemR = new ListViewItem(z.ZutatID.ToString());
                    lvItemR.SubItems.Add(z.Menge.ToString());
                    lvItemR.SubItems.Add(z.Einheit);
                    lvItemR.SubItems.Add(z.Bezeichnung);
                    lvItemR.SubItems.Add(z.Allergene);

                    lvRezept.Items.Add(lvItemR);

                    lvRezept.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvRezept.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch { }
        }

        internal void einlesencbBewertung()
        {
            cbBewertungSpeise.Items.Clear();
            foreach(Speise s in listeSpeise)
            {
                cbBewertungSpeise.Items.Add(s.Name);
            }
        }
        #endregion

        internal void showImages()
        {
            ImageList bilderListe = new ImageList();
            bilderListe.ColorDepth = ColorDepth.Depth32Bit; //damit Bilder nicht so pixelig sind
            bilderListe.ImageSize = new System.Drawing.Size(32, 32);
            bilderListe.Images.Clear();

            foreach (Speise s in listeSpeise)
            {
                try
                {
                    bilderListe.Images.Add(Image.FromFile(s.Bildpfad));
                }
                catch
                {
                    bilderListe.Images.Add(Image.FromFile(Application.StartupPath + "\\img\\default.jpg"));
                    continue; //????
                }
            }
            lvSpeise.SmallImageList = bilderListe;
        }

        internal void IDsetzen()
        {
            int temp = 1000;
            foreach (Speise s in listeSpeise)
            {
                if (s.SpeiseID > temp)
                {
                    temp = s.SpeiseID;
                }
            }
            Speise.Autonum = temp + 1;
        }
        
        internal void mischen()
        {
            vorspeise.Clear();
            for (int i = 0; i < listeSpeise.Count; i++)
            {
                if (listeSpeise[i].Speiseart.ToString().Equals("V"))
                    vorspeise.Add(listeSpeise[i].Name);
            }
            if (vorspeise.Count < 5)
            {
                MessageBox.Show("Sie haben zu wenige Vorspeisen in ihrer Liste!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            hauptspeise.Clear();
            for (int i = 0; i < listeSpeise.Count; i++)
            {
                if (listeSpeise[i].Speiseart.ToString().Equals("H"))
                    hauptspeise.Add(listeSpeise[i].Name);
            }
            if (hauptspeise.Count < 5)
            {
                MessageBox.Show("Sie haben zu wenige Hauptspeisen in ihrer Liste!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nachspeise.Clear();
            for (int i = 0; i < listeSpeise.Count; i++)
            {
                if (listeSpeise[i].Speiseart.ToString().Equals("N"))
                    nachspeise.Add(listeSpeise[i].Name);
            }
            if (nachspeise.Count < 5)
            {
                MessageBox.Show("Sie haben zu wenige Nachspeisen in ihrer Liste!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vorspeise = vorspeise.OrderBy(name => r.Next()).ToList();
            hauptspeise = hauptspeise.OrderBy(name => r.Next()).ToList();
            nachspeise = nachspeise.OrderBy(name => r.Next()).ToList();
        }
        #endregion

        #region Speiseplan
        #region Mischen
        private void btnAllesNeuMischen_Click(object sender, EventArgs e)
        {
            mischen();
            txtVMontag.Text = vorspeise[0];
            txtVDienstag.Text = vorspeise[1];
            txtVMittwoch.Text = vorspeise[2];
            txtVDonnerstag.Text = vorspeise[3];
            txtVFreitag.Text = vorspeise[4];

            txtHMontag.Text = hauptspeise[0];
            txtHDienstag.Text = hauptspeise[1];
            txtHMittwoch.Text = hauptspeise[2];
            txtHDonnerstag.Text = hauptspeise[3];
            txtHFreitag.Text = hauptspeise[4];

            txtNMontag.Text = nachspeise[0];
            txtNDienstag.Text = nachspeise[1];
            txtNMittwoch.Text = nachspeise[2];
            txtNDonnerstag.Text = nachspeise[3];
            txtNFreitag.Text = nachspeise[4];
        }

        private void btnTagNeuMischen_Click(object sender, EventArgs e)
        {
            wort = "Tag";
            frmAus.ShowDialog();
            mischen();
            try
            {
                if (tag.Equals("Montag"))
                {
                    txtVMontag.Text = vorspeise[0];
                    txtHMontag.Text = hauptspeise[0];
                    txtNMontag.Text = nachspeise[0];
                }
                if (tag.Equals("Dienstag"))
                {
                    txtVDienstag.Text = vorspeise[1];
                    txtHDienstag.Text = hauptspeise[1];
                    txtNDienstag.Text = nachspeise[1];
                }
                if (tag.Equals("Mittwoch"))
                {
                    txtVMittwoch.Text = vorspeise[2];
                    txtHMittwoch.Text = hauptspeise[2];
                    txtNMittwoch.Text = nachspeise[2];
                }
                if (tag.Equals("Donnerstag"))
                {
                    txtVDonnerstag.Text = vorspeise[3];
                    txtHDonnerstag.Text = hauptspeise[3];
                    txtNDonnerstag.Text = nachspeise[3];
                }
                if (tag.Equals("Freitag"))
                {
                    txtVFreitag.Text = vorspeise[4];
                    txtHFreitag.Text = hauptspeise[4];
                    txtNFreitag.Text = nachspeise[4];
                }
            }
            catch { }
        }

        private void btnSpeiseartNeuMischen_Click(object sender, EventArgs e)
        {
            wort = "Art";
            frmAus.ShowDialog();
            mischen();
            try
            {
                if (art.Equals("Vorspeise"))
                {
                    txtVMontag.Text = vorspeise[0];
                    txtVDienstag.Text = vorspeise[1];
                    txtVMittwoch.Text = vorspeise[2];
                    txtVDonnerstag.Text = vorspeise[3];
                    txtVFreitag.Text = vorspeise[4];
                }
                if (art.Equals("Hauptspeise"))
                {
                    txtHMontag.Text = hauptspeise[0];
                    txtHDienstag.Text = hauptspeise[1];
                    txtHMittwoch.Text = hauptspeise[2];
                    txtHDonnerstag.Text = hauptspeise[3];
                    txtHFreitag.Text = hauptspeise[4];
                }
                if (art.Equals("Nachspeise"))
                {
                    txtNMontag.Text = nachspeise[0];
                    txtNDienstag.Text = nachspeise[1];
                    txtNMittwoch.Text = nachspeise[2];
                    txtNDonnerstag.Text = nachspeise[3];
                    txtNFreitag.Text = nachspeise[4];
                }
            }
            catch { }
        }
        #endregion

        #region Drucken
        private void btnSpeiseplanDrucken_Click(object sender, EventArgs e)
        {

        }

        private void btnWochentagDrucken_Click(object sender, EventArgs e)
        {
            wort = "Tag";
            frmAus.ShowDialog();
        }
        #endregion

        private void btnSpeiseNeuWählen_Click(object sender, EventArgs e)
        {
            frmAus.cbAendernSpeise.Items.Clear();
            foreach (Speise s in listeSpeise)
            {
                frmAus.cbAendernSpeise.Items.Add(s.Name);
            }
            wort = "Ändern";
            frmAus.ShowDialog();
            try
            {

            }
            catch { }
        }
        #endregion

        #region Speise
        private void speisenHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSp.Text = "Speise hinzufügen";
            frmSp.txtSpeiseID.Text = Speise.Autonum.ToString();
            frmSp.ShowDialog();
            einlesenLvSpeisen();
            einlesencbBewertung();
        }

        private void speisenBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSpeise.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Speise aus!");
                return;
            }
            frmSpeise frmSp = new frmSpeise();
            frmSp.Text = "Speise bearbeiten";
            lvItem = lvSpeise.SelectedItems[0];
            frmSp.txtSpeiseID.Text = lvItem.SubItems[1].Text;
            frmSp.txtName.Text = lvItem.SubItems[2].Text;
            frmSp.cbSpeiseart.Text = lvItem.SubItems[3].Text;

            try
            {
                if (!lvItem.SubItems[5].Text.Equals(""))
                {
                    frmSp.pictureBox1.Image = Image.FromFile(lvItem.SubItems[5].Text);
                    frmSp.txtBildpfad.Text = lvItem.SubItems[5].Text;
                    frmSp.bildpfad = lvItem.SubItems[5].Text;
                }
                else
                {
                    frmSp.pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\img\\default.jpg");
                    frmSp.bildpfad = Application.StartupPath + "\\img\\default.jpg";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Das Bild konnte nicht gefunden werden!");
                frmSp.pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\img\\default.jpg");
                frmSp.bildpfad = Application.StartupPath + "\\img\\default.jpg";
            }
            frmSp.ShowDialog();
            einlesenLvSpeisen();
            einlesencbBewertung();
        }

        private void speisenLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSpeise.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen sie eine Speise aus!");
                return;
            }
            lvItem = lvSpeise.SelectedItems[0];
            inde = lvItem.Index;

            DialogResult antwort = MessageBox.Show("Wollen Sie diese Speise wirklich löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (antwort == DialogResult.Yes)
            {
                listeSpeise.RemoveAt(inde);
                einlesenLvSpeisen();
                einlesenLvRezept();
                einlesencbBewertung();
            }
        }

        private void zutatZuDerSpeiseHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSpeise.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Speise aus!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lvItem = lvSpeise.SelectedItems[0];
            panel1.Visible = true;
            tabControl1.SelectedIndex = 2;
            if (tabControl1.SelectedIndex == 2)
            {
                this.Width = 1123;
            }
        }
        #endregion

        #region Zutatat
        private void zutatHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZu.Text = "Zutat hinzufügen";
            frmZu.txtZutatID.Text = Zutat.Autonum.ToString();
            frmZu.ShowDialog();
            einlesenLvZutaten();
        }

        private void zutatBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvZutaten.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Zutat aus!");
                return;
            }
            frmZutat frmZu = new frmZutat();
            frmZu.Text = "Zutat bearbeiten";
            lvItem = lvZutaten.SelectedItems[0];
            frmZu.txtZutatID.Text = lvItem.SubItems[0].Text;
            frmZu.txtEinheit.Text = lvItem.SubItems[1].Text;
            frmZu.txtBezeichnung.Text = lvItem.SubItems[2].Text;
            frmZu.txtAllergene.Text = lvItem.SubItems[3].Text;
            frmZu.ShowDialog();
            einlesenLvZutaten();
        }

        private void zutatLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvZutaten.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen sie eine Zutat aus!");
                return;
            }
            lvItem = lvZutaten.SelectedItems[0];
            inde = lvItem.Index;
            
            DialogResult antwort = MessageBox.Show("Wollen Sie diese Zutat wirklich löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (antwort == DialogResult.Yes)
            {
                listeZutaten.RemoveAt(inde);
                einlesenLvZutaten();
            }
        }

        private void btnZutatHinzufuegen_Click(object sender, EventArgs e)
        {
            if (lvZutaten.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Zutat aus!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMenge.Clear();
                return;
            }
            if(txtMenge.Text.Equals(""))
            {
                MessageBox.Show("Bitte geben Sie die Richtige Menge ein!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                lvItem = lvZutaten.SelectedItems[0];
                foreach (Zutat z in listeZutaten)
                {
                    z.Menge = Convert.ToInt16(txtMenge.Text);
                    if (z.ZutatID == Convert.ToInt32(lvItem.SubItems[0].Text))
                    {
                        bool gefunden = false;
                        if (speiseAktuell.ListeZutaten != null)
                        {
                            foreach (Zutat zu in speiseAktuell.ListeZutaten)
                            {
                                if (zu.ZutatID == z.ZutatID)
                                    gefunden = true;
                            }
                        }
                        if (gefunden)
                        {
                            MessageBox.Show("Diese Zutat ist breits in dieser Speise vorhanden!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        else
                        {
                            speiseAktuell.ListeZutaten.Add(z);
                            einlesenLvRezept();
                            txtMenge.Clear();
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bitte geben Sie nur Zahlen als Menge ein!", "Hinweis!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnZurück_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        #endregion

        #region Rezept
        private void lvSpeise_Click(object sender, EventArgs e)
        {
            lvRezept.Items.Clear();
            if (lvSpeise.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Speise aus!");
                return;
            }
            lvItem = lvSpeise.SelectedItems[0];
            foreach (Speise s in listeSpeise)
            {
                if (s.SpeiseID == Convert.ToInt32(lvItem.SubItems[1].Text))
                {
                    speiseAktuell = s;
                    if (s.ListeZutaten != null)
                    {
                        foreach (Zutat z in s.ListeZutaten)
                        {
                            lvItemR = new ListViewItem(z.ZutatID.ToString());
                            lvItemR.SubItems.Add(z.Menge.ToString());
                            lvItemR.SubItems.Add(z.Einheit);
                            lvItemR.SubItems.Add(z.Bezeichnung);
                            lvItemR.SubItems.Add(z.Allergene);
                            lvRezept.Items.Add(lvItemR);
                        }
                    }
                    break;
                }
            }
        }

        private void dieseZutatEntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvRezept.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie die zu löschende Zutat aus!", "Hinweiß!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lvItem = lvRezept.SelectedItems[0];
            int inde = 0;

            DialogResult antwort = MessageBox.Show("Wollen Sie diese Zutat wirklich aus der Speise löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (antwort == DialogResult.Yes)
            {
                for (int i = 0; i < speiseAktuell.ListeZutaten.Count; i++)
                {
                    if (speiseAktuell.ListeZutaten[i].ZutatID == Convert.ToInt32(lvItem.SubItems[0].Text))
                    {
                        inde = i;
                        break;
                    }
                }
                speiseAktuell.ListeZutaten.RemoveAt(inde);
                einlesenLvRezept();
                einlesenLvSpeisen();
                XmlSerialisierenSpeise();
            }
        }

        private void alleZutatenEntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult antwort = MessageBox.Show("Wollen Sie wirklich alle Zutaten aus der Speise löschen?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (antwort == DialogResult.Yes)
            {
                speiseAktuell.ListeZutaten.Clear();
                lvRezept.Items.Clear();
                XmlSerialisierenSpeise();
            }
        }
        #endregion

        #region Bewertung
        private void btnBewertungSpeichern_Click(object sender, EventArgs e)
        {
            bool gefunden = false;
            string bewertung ="*";
            foreach (Speise s in listeSpeise)
            {
                if (s.Name == cbBewertungSpeise.Text)
                {
                    if (rb1.Checked)
                        bewertung = "*";
                    if (rb2.Checked)
                        bewertung = "**";
                    if (rb3.Checked)
                        bewertung = "***";
                    if (rb4.Checked)
                        bewertung = "****";
                    if (rb5.Checked)
                        bewertung = "*****";
                    s.Bewertung = bewertung;
                    einlesenLvSpeisen();
                    gefunden = true;
                    break;
                }
            }
            if (gefunden == false)
            {
                MessageBox.Show("Diese Speise existiert nicht mehr", "ACHTUNG!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Bitte geben Sie eine Bewerutng für die Ausgewählte Speise ein. Dabei ist 1 Stern das Schlechteste und 5 Sterne das Beste.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region RadioButtons Speiseart
        private void rbAlleSpeisen_CheckedChanged(object sender, EventArgs e)
        {
            einlesenLvSpeisen();
        }

        private void rbVorspeisen_CheckedChanged(object sender, EventArgs e)
        {
            einlesenLvSpeisen();
        }

        private void rbHauptspeisen_CheckedChanged(object sender, EventArgs e)
        {
            einlesenLvSpeisen();
        }

        private void rbNachspeise_CheckedChanged(object sender, EventArgs e)
        {
            einlesenLvSpeisen();
        }
        #endregion
    }
}
