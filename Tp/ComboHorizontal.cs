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

        int Espace { get; set; }

        //public List<string> Liste { get; private set; } = new List<string>();



        //public string Message { get; private set; } = "";

        //public List<Boite> lstBts { get; set; } = new List<Boite>();

        //public IEnumerateur<string> GetEnumerateur() => new Enumerateur(lstBts[0], lstBts[1]);
        public ComboHorizontal(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
            lst = boite.lst;
        }
        public ComboHorizontal(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            Espace = ba.ListeMots.Max(str => str.Length) + 1;
            Largeur = Espace + bb.ListeMots.Max(str => str.Length);
            //Hauteur = Math.Max(ba.Hauteur, bb.Hauteur);
            //Espace = Largeur + 1;
            //Largeur = Espace + Largeur;

            //lstBts.Add(ba);
            //lstBts.Add(bb);
            //IEnumerateur<string> enumerateur = GetEnumerateur();
            //do
            //{
            //    // Message += enumerateur.Current;
            //} while (enumerateur.MoveNext()); 

            //Ajout des liste de mots dans la liste pour donner le contenu à la boîte
            if (ba.ListeMots != null && bb.ListeMots != null)
            {
                List<string> l = EditList(ba.ListeMots, bb.ListeMots);
                lst.AddRange(l);
            }

        }
        List<string> EditList(List<string> lstBa, List<string> lstBb)
        {
            List<string> newList = new List<string>();
            for (int i = 0; i < lstBa.Count; i++)
            {
                int nb = lstBa.Max(str => str.Length) - lstBa[i].Length;
                string m = lstBa[i] + new string(' ', nb) ;
                if (lstBb[0] != "" || lstBa[0] != "")
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

        //public override string ToString()
        //{
        //    IEnumerateur<string> enumerateur = GetEnumerateur();
        //    do
        //    {
        //        Message += enumerateur.Current;
        //    } while (enumerateur.MoveNext());
        //    return Message;
        //}

        public IEnumerable<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

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
