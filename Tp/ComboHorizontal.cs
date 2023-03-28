using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
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
            if(ListeDoitEtreModifier(ba.ListeMots) || ListeDoitEtreModifier(bb.ListeMots)) 
            {
                lst = RedimensionnerListe(EditList(ba.ListeMots, bb.ListeMots));
                Enumerator = lst.GetEnumerator();

            }
            else
            {
                lst = EditList(ba.ListeMots, bb.ListeMots);
                Enumerator = lst.GetEnumerator();

            }

            //v4
            //Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            //Largeur = ba.ListeMots.Max(str => str.Length) + bb.ListeMots.Max(str => str.Length);
            //List<string> t = Red(ba.ListeMots,bb.ListeMots);


        }

        private bool ListeDoitEtreModifier(List<string> list)
        {
            foreach (string str in list)
            {
                if (str.Contains('-') || str.Contains('|'))
                {
                    return true;
                }
            }
            return false;
        }

        private int NbOccurrenceMots(string str,string occ)
        {
            int count = 0;
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

        private List<string> EditList(List<string> lstBa, List<string> lstBb)
        {
            List<string> newList = new List<string>();
            for (int i = 0; i < lstBa.Count; i++)
            {
                int nb = lstBa.Max(str => str.Length) - lstBa[i].Length;
                string m = lstBa[i] + new string(' ', nb) ;
                if (lstBa[i] != "" /*|| lstBa[i] != ""*/)
                {
                    m += '|';
                }
                newList.Add(m);

            }

            for (int i = 0; i < newList.Count; i++)
            {
                if (i < lstBb.Count)
                {
                    int nb = lstBb.Max(str => str.Length) - lstBb[i].Length;
                    string m = lstBb[i] + new string(' ', nb) ;
                    newList[i] += m;

                }
                else
                {
                    newList[i] += new string(' ', lstBb.Max(str => str.Length));

                }
            }



            return newList;
        }

        private List<string> RedimensionnerListe(List<string> lsta)
        {
            List<string> newList = new List<string>();
            int newMax = lsta.Max(str => str.Length);  
            int nbDésiré = NbOccurenceListe(lsta,"|");
            int dernierIndex = 0;
            for (int i = 0; i < lsta.Count; i++)
            { 
                if (NbOccurrenceMots(lsta[i], "|") < nbDésiré && i != 0 )
                {
                    int index = lsta[dernierIndex].LastIndexOf("|");
                    string newStr = lsta[i].Substring(0, index) + new string('|',nbDésiré - NbOccurrenceMots(lsta[i],"|")) + lsta[i].Substring(index + 1);
                    newList.Add(newStr);
                }
                else
                {
                    newList.Add(lsta[i]);

                }
                if(i != 0 && NbOccurrenceMots(lsta[i], "|") > nbDésiré)
                {

                    dernierIndex ++;   

                }
            }

            return newList;
            
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

        public IBoite Redimensionner(int largeur, int hauteur)
        {
            Largeur = largeur;
            Hauteur = hauteur;

            return this;
        }

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
