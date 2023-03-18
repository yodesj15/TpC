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
            //lst = new List<string>();
            Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            Largeur = Math.Max(ba.ListeMots.Max(str => str.Length) , bb.ListeMots.Max(str => str.Length));

            //Ajout des liste de mots dans la liste pour donner le contenu à la boîte
            lst.AddRange(ba.ListeMots);
            lst.Add(new string('-', Largeur));
            lst.AddRange(bb.ListeMots);
        }

        protected ComboVertical(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
            lst = boite.lst;
        }
        //public ComboVertical(IBoite boiteA, IBoite boiteB)
        //{
        //    Hauteur = Math.Max(boiteA.lst.Count(), boiteB.lst.Count());
        //    Largeur = Math.Max(boiteA.lst.Max(str => str.Length), boiteB.lst.Max(str => str.Length));
            
        //    //Hauteur = boite.Hauteur;
        //    //Largeur = boite.Largeur;
        //    //lst = boite.lst;
        //}
        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

        public IEnumerator<string> GetEnumerator() => lst.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IBoite Redimensionner(int largeur, int hauteur)
        {
            Largeur = largeur; 
            Hauteur = hauteur; 

            return this;
        }

        public IBoite Cloner(IBoite b) => new ComboVertical(b);


        //class Enumerateur : IEnumerateur<string>
        //{
        //    //public Boite Cur { get; set; }

        //    public IEnumerator<string> enuGauche, enuDroite;

        //    public string Current => enuGauche.Current + '|' + enuDroite.Current;
        //    object IEnumerator.Current => throw new NotImplementedException();

        //    /*public bool HasNext => Cur.Succ == Queue;*/

        //    public Enumerateur(Boite ba, Boite bb)
        //    {
        //        enuGauche = ba.ListeMots.GetEnumerator();
        //        enuDroite = bb.ListeMots.GetEnumerator();
        //    }

        //    public bool MoveNext()
        //    {
        //        /*if (Cur.Succ == null)
        //            return false;
        //        Cur = Cur.Succ;
        //        return true;*/
        //        return false;
        //    }

        //    public void Reset() => throw new NotImplementedException();

        //    public void Dispose() { }
        //}
     }
}
