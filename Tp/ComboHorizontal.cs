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

        //public List<string> Liste { get; private set; } = new List<string>();



        //public string Message { get; private set; } = "";

        //public List<Boite> lstBts { get; set; } = new List<Boite>();

        //public IEnumerateur<string> GetEnumerateur() => new Enumerateur(lstBts[0], lstBts[1]);
        public ComboHorizontal(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
            Enumerator = boite.GetEnumerator();
            lst = boite.lst;

            BoiteCombo1= boite.BoiteCombo1;
            BoiteCombo2 = boite.BoiteCombo2;

        }
        public ComboHorizontal(Boite ba, Boite bb)
        {

            Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());

            Largeur = ba.ListeMots.Max(str => str.Length) + bb.ListeMots.Max(str => str.Length) + 1;


            if (ContientCombo(ba.ListeMots) || ContientCombo(bb.ListeMots))
            {
                lst = RedimensionnerListe(GetComboList(ba.ListeMots, bb.ListeMots));
                Enumerator = lst.GetEnumerator();

            }
            else
            {
                lst = GetComboList(ba.ListeMots, bb.ListeMots);
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


        //private List<string> EditList(List<string> lstBa, List<string> lstBb)
        //{
        //    List<string> tempLst = new List<string>();
        //    for (int i = 0; i < lstBa.Count; i++)
        //    {
        //        int nb = lstBa.Max(str => str.Length) - lstBa[i].Length;
        //        string str = lstBa[i] + new string(' ', nb);

        //        if (lstBa[i] != "" /*|| lstBa[i] != ""*/)
        //            str += '|';
        //        tempLst.Add(str);

        //    }

        //    for (int i = 0; i < tempLst.Count; i++)
        //    {
        //        if (i < lstBb.Count)
        //        {
        //            int nb = lstBb.Max(str => str.Length) - lstBb[i].Length;
        //            tempLst[i] += lstBb[i] + new string(' ', nb);

        //        }
        //        else
        //            tempLst[i] += new string(' ', lstBb.Max(str => str.Length));

        //    }



        //    return tempLst;
        //}

        private List<string> RedimensionnerListe(List<string> lstA)
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

        public IEnumerator<string> GetEnumerator() => Enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IBoite Cloner() => new ComboHorizontal(this);

        public void Accepter(IVisiteur<IBoite> viz)
        {
            Console.WriteLine();
            if (BoiteCombo1.ListeMots.Count() > 0 && BoiteCombo1.ListeMots.Count() > 0)
            {
                Console.WriteLine($"        Mono {Hauteur} x {BoiteCombo1.ListeMots.Max(str => str.Length)}");
                Console.WriteLine($"        Mono {Hauteur} x {BoiteCombo2.ListeMots.Max(str => str.Length)}");

            }
            //Console.WriteLine($"       {Hauteur} x {Largeur} ");
        }
    }
}
