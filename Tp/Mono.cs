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
        public int Largeur { get; private set; }

        public int Hauteur { get; private set; }

        public List<Boite> lstBts { get; set; } = new List<Boite>();

        public IEnumerateur<string> GetEnumerateur() => new Enumerateur(this);

        public Mono(Boite boite)
        {
            lstBts.Add(boite);
        }

        public override string ToString()   
        {
            IEnumerateur<string> enumerateur = GetEnumerateur();
            do
            {
                return enumerateur.Current;
            } while (enumerateur.MoveNext());
        }

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

        class Enumerateur : IEnumerateur<string>
        {
            public Boite Cur { get; set; }
            Boite? Tete { get; set; } = null;
            Boite? Queue { get; set; } = null;

            public string Current => Cur.ToString();
            object IEnumerator.Current => throw new NotImplementedException();

            public bool EstVide => Tete == null;

            /*public bool HasNext => Cur.Succ == Queue;*/

            public Enumerateur(IBoite bt)
            {
                Cur = bt.lstBts[0];
                //Cur.Succ = null;
            }

            public bool MoveNext()
            {
                if (Cur.Succ == null)
                    return false;
                Cur = Cur.Succ;
                return true;
            }

            public void Reset() => throw new NotImplementedException();

            public void Dispose() { }
        }
    }
}
