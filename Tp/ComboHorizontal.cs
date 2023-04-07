using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    internal class ComboHorizontal : IBoite
    {
        public int Largeur { get; private set; } = 0;
        public int Hauteur { get; private set; } = 0;

        public List<string> lst { get; init; } = new List<string>();
        public IEnumerator<string> Enumerator { get; init; }

        public Boite BoiteCombo1 { get; init; }
        public Boite BoiteCombo2 { get; init; }

        public ComboHorizontal(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
            lst = boite.lst;
            Enumerator = boite.Enumerator;
            BoiteCombo1= boite.BoiteCombo1;
            BoiteCombo2 = boite.BoiteCombo2;

        }
        public ComboHorizontal(Boite ba, Boite bb)
        {

            Hauteur = Math.Max(ba.contenu.Count(), bb.contenu.Count());

            Largeur = ba.contenu.Max(str => str.Length) + bb.contenu.Max(str => str.Length);


            if (ContientCombo(ba.contenu) || ContientCombo(bb.contenu))
            {
                lst = ModifierListe(GetComboList(ba.contenu, bb.contenu));
                Enumerator = lst.GetEnumerator();
            }
            else
            {
                lst = GetComboList(ba.contenu, bb.contenu);
                Enumerator = lst.GetEnumerator();
            }

            BoiteCombo1 = ba.Cloner();
            BoiteCombo2 = bb.Cloner();


        }

        private List<string> GetComboList(List<string> lstBa, List<string> lstBb)
        {
            var enumeratorBa = lstBa.GetEnumerator();
            var enumeratorBb = lstBb.GetEnumerator();

            string strBa;
            string strBb;

            int maxLargeurBa = lstBa.Max(str => str.Length);
            int maxLargeurBb = lstBb.Max(str => str.Length);
            int nbEspaceBa = 0;
            int nbEspaceBb = 0;

            List<string> tempLst = new();

            enumeratorBa.MoveNext();
            enumeratorBb.MoveNext();

            do
            {
                strBa = enumeratorBa.Current;
                strBb = enumeratorBb.Current;

                if (string.IsNullOrEmpty(strBa))
                {
                    nbEspaceBa = 0;
                    strBa = new string(' ', maxLargeurBa);
                }
                else
                    nbEspaceBa = maxLargeurBa - strBa.Length;

                if (string.IsNullOrEmpty(strBb))
                {
                    nbEspaceBb = 0;
                    strBb = new string(' ', maxLargeurBb);
                }
                else
                    nbEspaceBb = maxLargeurBb - strBb.Length;

                //Gestion boites vides
                if (string.IsNullOrEmpty(strBa) && string.IsNullOrEmpty(strBb))
                {
                    tempLst.Add(strBa + strBb);
                }
                else
                    tempLst.Add(strBa + new string(' ', nbEspaceBa) + "|" + strBb + new string(' ', nbEspaceBb));

                enumeratorBa.MoveNext();
                enumeratorBb.MoveNext();
            } while (enumeratorBa.Current != null || enumeratorBb.Current != null);

            return tempLst;
        }

        private bool ContientCombo(List<string> list)
        {
            foreach (string str in list)
            {
                if (str.Contains('-') || str.Contains('|'))
                    return true;

            }
            return false;
        }

        private int NbOccurrenceMots(string str, string occ)
        {
            int count;
            count = str.Split(new string[] { occ }, StringSplitOptions.None).Length - 1;
            return count;
        }

        private int NbOccurenceListe(List<string> list, string occ)
        {
            int max = 0;
            foreach (string str in list)
            {
                if (str.Split(new string[] { occ }, StringSplitOptions.None).Length - 1 > max)
                {
                    max = str.Split(new string[] { occ }, StringSplitOptions.None).Length - 1;
                }
            }
            return max;
        }

        private List<string> ModifierListe(List<string> lstA)
        {
            List<string> tempLst = new List<string>();

            int nbDésiré = NbOccurenceListe(lstA, "|");
            int dernierIndex = 0;
            for (int i = 0; i < lstA.Count; i++)
            {
                if (NbOccurrenceMots(lstA[i], "|") < nbDésiré && i != 0)
                {
                    int index = lstA[dernierIndex].LastIndexOf("|");
                    string newStr = lstA[i].Substring(0, index) + new string('|', nbDésiré - NbOccurrenceMots(lstA[i], "|")) + lstA[i].Substring(index + 1);
                    tempLst.Add(newStr);
                }
                else
                {
                    tempLst.Add(lstA[i]);

                }
                if (i != 0 && NbOccurrenceMots(lstA[i], "|") > nbDésiré)
                {

                    dernierIndex++;

                }
            }

            return tempLst;

        }

        public IEnumerator<string> GetEnumerator() => lst.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IBoite Cloner() => new ComboHorizontal(this);

        public void Accepter(IVisiteur<IBoite> viz)
        {
            Console.WriteLine();
            if (BoiteCombo1.contenu.Count() > 0 && BoiteCombo2.contenu.Count() > 0)
            {
                Console.WriteLine($"        Mono {Hauteur} x {BoiteCombo1.contenu.Max(str => str.Length)}");
                Console.WriteLine($"        Mono {Hauteur} x {BoiteCombo2.contenu.Max(str => str.Length)}");

            }
        }
    }
}
