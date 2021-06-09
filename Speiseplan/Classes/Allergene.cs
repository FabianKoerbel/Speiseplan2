using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan.Classes
{
    public class Allergene
    {
        //Objektvariablen
        private string abkuerzung;
        private string bezeichnung;

        //Konstruktor
        public Allergene()
        {
        }

        public Allergene(string abkuerzung, string bezeichung)
        {
            this.abkuerzung = abkuerzung;
            this.bezeichnung = bezeichung;
        }

        public string Abkuerzung
        {
            get { return abkuerzung; }
            set { abkuerzung = value; }
        }

        public string Bezeichung
        {
            get { return bezeichnung; }
            set { bezeichnung = value; }
        }
    }
}
