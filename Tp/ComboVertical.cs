using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
     internal class ComboVertical : IBoite
     {
        public int Largeur { get; private set; } = 0;

        public int Hauteur { get; private set; } = 0;
        //private int Espace { get; set; }
        //public string Message { get; private set; } = "";

        public List<string> lst { get; init; } = new List<string>();

        public ComboVertical(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            Largeur = ba.ListeMots.Max(str => str.Length) + bb.ListeMots.Max(str => str.Length);

            //Ajout des liste de mots dans la liste pour donner le contenu à la boîte
            lst.AddRange(ba.ListeMots);
            lst.Add(new string('-', Largeur));
            lst.AddRange(bb.ListeMots);
        }

        public ComboVertical(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur += boite.Largeur;
            lst = boite.lst;
        }

        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

        public IEnumerator<string> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IBoite Redimensionner(int largeur, int hauteur)
        {
            throw new NotImplementedException();
        }

        public IBoite Cloner(IBoite b) => new ComboVertical(b);


        //class Enumerateur : IEnumerateur<string>
        //{
        //    public Boite Cur { get; set; }

        //    public string Current => Cur.ToString();
        //    object IEnumerator.Current => throw new NotImplementedException();

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
