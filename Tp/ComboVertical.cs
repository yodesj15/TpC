using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
     internal class ComboVertical : IBoite
     {
        public int Largeur { get; private set; } = 0;

        public int Hauteur { get; private set; } = 0;

        public List<string> lst { get; init; } = new List<string>();
        public IEnumerator<string> Enumerator { get; init; }

        public Boite BoiteCombo1 { get; init; }
        public Boite BoiteCombo2 { get; init; }

        public ComboVertical(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.contenu.Count(), bb.contenu.Count());
            Largeur = Math.Max(ba.contenu.Max(str => str.Length) , bb.contenu.Max(str => str.Length));

            List<string> tempLst = new();
            tempLst.AddRange(RedimensionnerListe(ba.contenu));
            tempLst.Add(new string('-', Largeur));
            tempLst.AddRange(RedimensionnerListe(bb.contenu));

            lst = tempLst;
            Enumerator = lst.GetEnumerator();

            BoiteCombo1 = ba.Cloner();
            BoiteCombo2 = bb.Cloner();
        }

        protected ComboVertical(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
            lst = boite.lst;
            Enumerator = boite.Enumerator;
            BoiteCombo1 = boite.BoiteCombo1;
            BoiteCombo2 = boite.BoiteCombo2;
        }


        private List<string> RedimensionnerListe(List<string> lst)
        {
            List<string> tempLst = new List<string>();

            foreach(var str in lst)
            {
                if(str.Contains('-') && !str.Contains('|'))
                    tempLst.Add(new string('-', Largeur));
                else
                    tempLst.Add(str);
            }
            return tempLst;
        }

        public IEnumerator<string> GetEnumerator() => Enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IBoite Cloner() => new ComboVertical(this);
        
        public void Accepter(IVisiteur<IBoite> viz)
        {

            Console.WriteLine();
            if (BoiteCombo1.contenu.Count() > 0 && BoiteCombo2.contenu.Count() > 0)
            {
                Console.WriteLine($"        Mono {BoiteCombo1.contenu.Count()} x {Largeur}");
                Console.WriteLine($"        Mono {BoiteCombo2.contenu.Count()} x {Largeur}");

            }

        }

     }
}
