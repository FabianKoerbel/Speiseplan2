using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan.Classes
{
    public class Speise
    {
        //Objektvariablen
        private int speiseID;
        private string name;
        private char speiseart;
        private string bewertung;
        private List<Zutat> listeZutaten;
        private string bildpfad;

        //Klassenvariable
        private static int autonum = 1001;

        //Konsturktor
        public Speise()
        {
            speiseID = autonum;
            autonum++;
        }

        public Speise(string name, char speiseart, string bewertung, List<Zutat> listeZutaten, string bildpfad)
        {
            speiseID = autonum;
            autonum++;
            this.name = name;
            this.speiseart = speiseart;
            this.bewertung = bewertung;
            this.listeZutaten = listeZutaten;
            this.bildpfad = bildpfad;
        }

        public int SpeiseID { get; set; }

        public string Name { get; set; }

        public char Speiseart { get; set; }

        public string Bewertung { get; set; }

        public List<Zutat> ListeZutaten { get; set; }

        public string Bildpfad { get; set; }

        public static int Autonum
        {
            get { return autonum; }
            set { autonum = value; }
        }

    }
}
