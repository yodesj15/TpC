using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    internal class Mono : IBoite
    {
        public int Largeur { get; private set; } = 0;

        public int Hauteur { get; private set; } = 0;

        public List<string> lst => throw new NotImplementedException();

        //public List<Boite> lstBts { get; set; } = new List<Boite>();

        //public IEnumerable<string> GetEnumerateur() => new IEnumerable(this);

        //public Mono(Boite boite)
        //{
        //    Largeur = boite.IB.Largeur;
        //    Hauteur = boite.IB.Hauteur;
        //    //lstBts.Add(boite);
        //}

        public Mono() { }

        public Mono(int largeur, int hauteur)
        {
            Largeur = largeur;
            Hauteur = hauteur;
        }

        public Mono(IBoite bt)
        {
            Largeur = bt.Largeur;
            Hauteur = bt.Hauteur;
        }

        public IBoite Cloner(IBoite b) => new Mono(b);


        //public override string ToString()   
        //{
        //    IEnumerateur<string> enumerateur = GetEnumerateur();
        //    do
        //    {
        //        Message += enumerateur.Current;
        //    } while (enumerateur.MoveNext());
        //    return Message;
        //}

        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

        //public List<IEnumerable<string>> lst { get; private set; }

        //public IEnumerable<string> Enumerateur {get; private set; }


        public IEnumerator<string> GetEnumerator()
        {
           
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IBoite Redimensionner(int largeur, int hauteur)
        {
            throw new NotImplementedException();
        }

        //class Enumerateur : IEnumerateur<string>
        //{
        //    public Boite Cur { get; set; }
        //    //Boite? Tete { get; set; } = null;
        //    //Boite? Queue { get; set; } = null;

        //    public string Current => Cur.ToString();
        //    object IEnumerator.Current => throw new NotImplementedException();

        //    //public bool EstVide => Tete == null;

        //    /*public bool HasNext => Cur.Succ == Queue;*/

        //    public Enumerateur(IBoite bt)
        //    {
        //        Cur = bt.lstBts.First();
        //        //Cur.Succ = null;
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
