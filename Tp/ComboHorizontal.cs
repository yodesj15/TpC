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
        }
        public ComboHorizontal(Boite ba, Boite bb)
        {
            //v1
            //Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            //Largeur = ba.ListeMots.Max(str => str.Length) + bb.ListeMots.Max(str => str.Length) + 1;


            //lst = EditList(ba.ListeMots, bb.ListeMots);
            //Enumerator = lst.GetEnumerator();

            //v2 
            //Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            //Largeur = ba.ListeMots.Max(str => str.Length)+ bb.ListeMots.Max(str => str.Length);

            //List<string> tempLst = new();
            //tempLst.AddRange(RedimensionnerListe(ba.ListeMots));
            ////tempLst.Add(new string('-', Largeur));
            //tempLst.AddRange(RedimensionnerListe(bb.ListeMots));
            //Enumerator = tempLst.GetEnumerator();

            //lst = tempLst;

            //v3
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

            //v4
            //Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            //Largeur = ba.ListeMots.Max(str => str.Length) + bb.ListeMots.Max(str => str.Length);
            //List<string> t = Red(ba.ListeMots,bb.ListeMots);


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
                if(string.IsNullOrEmpty(strBa) && string.IsNullOrEmpty(strBb))
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

        private int NbOccurrenceMots(string str,string occ)
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
                if(str.Split(new string[] { occ }, StringSplitOptions.None).Length - 1 > max)
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
                if (NbOccurrenceMots(lstA[i], "|") < nbDésiré && i != 0 )
                {
                    int index = lstA[dernierIndex].LastIndexOf("|");
                    string newStr = lstA[i].Substring(0, index) + new string('|',nbDésiré - NbOccurrenceMots(lstA[i],"|")) + lstA[i].Substring(index + 1);
                    tempLst.Add(newStr);
                }
                else
                {
                    tempLst.Add(lstA[i]);

                }
                if(i != 0 && NbOccurrenceMots(lstA[i], "|") > nbDésiré)
                {

                    dernierIndex ++;   

                }
            }

            return tempLst;
            
        }


        //public override string ToString()
        //{
        //    IEnumerateur<string> enumerateur = GetEnumerateur();
        //    do
        //    {
        //        Message += enumerateur.Current;
        //    } while (enumerateur.MoveNext());
        //    return Message;
        //}

        public IEnumerator<string> GetEnumerator() => Enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public IBoite Redimensionner(int largeur, int hauteur)
        //{
        //    Largeur = largeur;
        //    Hauteur = hauteur;

        //    return this;
        //}

        public IBoite Cloner(IBoite b) => new ComboHorizontal(b);
        //IEnumerator<string> IEnumerable<string>.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        // IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

        //class Enumerateur : IEnumerateur<string>
        //{
        //    public Boite Cur { get; set; }

        //    public string Current { get
        //        {
        //            string message = null;
        //            return message;
        //        } 
        //    }
        //    object IEnumerator.Current => throw new NotImplementedException();// --> affiche le message et espace si nécessaire

        //    /*public bool HasNext => Cur.Succ == Queue;*/

        //    public Enumerateur(Boite ba, Boite bb)
        //    {
        //        Cur = ba;
        //        Cur.Succ = bb;
        //    }

        //    public bool MoveNext()
        //    {
        //        if (Cur.Succ == null)
        //            return false;
        //        Cur = Cur.Succ;
        //        return true;
        //    }

        //    public void Reset() => throw new NotImplementedException();

        //    public void Dispose() { }
        //}
    }
}
