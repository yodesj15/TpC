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

        //private int Espace { get; set; }
        //public string Message { get; private set; } = "";

        public List<string> lst { get; init; } = new List<string>();

        public IEnumerator<string> Enumerator { get; init; }

        public ComboVertical(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            Largeur = Math.Max(ba.ListeMots.Max(str => str.Length) , bb.ListeMots.Max(str => str.Length));

            List<string> tempLst = new();
            tempLst.AddRange(RedimensionnerListe(ba.ListeMots));
            tempLst.Add(new string('-', Largeur));
            tempLst.AddRange(RedimensionnerListe(bb.ListeMots));
            Enumerator = tempLst.GetEnumerator();

            lst = tempLst;

            //Ajout des liste de mots dans la liste pour donner le contenu à la boîte
            //lst.AddRange(RedimensionnerListe(ba.ListeMots));
            //lst.Add(new string('-', Largeur));
            //lst.AddRange(RedimensionnerListe(bb.ListeMots));
        }

        protected ComboVertical(IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
            Enumerator = boite.Enumerator;
            lst = boite.lst;
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

        public IEnumerator<string> GetEnumerator() => Enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public IBoite Redimensionner(int largeur, int hauteur)
        //{
        //    Largeur = largeur; 
        //    Hauteur = hauteur;

        //    return this;
        //}

        public IBoite Cloner(IBoite b) => new ComboVertical(b);
        
         public void Accepter(IVisiteur<IBoite> viz)
        {

            //Action a = delegate () { Console.Write("   " + ToString().Substring(7)); };
            //viz.Entrer();
            //viz.Visiter(this, a);
            //viz.Sortir(); 
            Console.WriteLine();
            Console.WriteLine("     Boite");
            Console.WriteLine($"       {Hauteur} x {Largeur} ");

        }


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
