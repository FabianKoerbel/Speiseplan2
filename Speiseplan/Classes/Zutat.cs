using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan.Classes
{
    public class Zutat
    {
        //Objektvariablen
        private int zutatID;
        private int menge;
        private string einheit;
        private string bezeichnung;
        private string allergene;

        //Klassenvariablen
        private static int autonum = 1001;

        //Konstruktor
        public Zutat()
        {
            zutatID = autonum;
            autonum++;
        }

        public Zutat(int menge, string einheit, string bezeichnung, string allergene)
        {
            zutatID = autonum;
            autonum++;
            this.menge = menge;
            this.einheit = einheit;
            this.bezeichnung = bezeichnung;
            this.allergene = allergene;
        }

        public int ZutatID { get; set; }

        public int Menge { get; set; }

        public string Einheit { get; set; }

        public string Bezeichnung { get; set; }

        public string Allergene { get; set; }


        public static int Autonum
        {
            get { return autonum; }
            set { autonum = value; }
        }
    }
}
