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
        public ComboVertical(Boite ba, Boite bb)
        {
            Largeur = Math.Max(ba.Largeur, bb.Largeur);
            Hauteur = ba.Hauteur + bb.Hauteur;
            
        }

        public int Largeur { get; private set; }

        public int Hauteur { get; private set; }

        int IBoite.Largeur => throw new NotImplementedException();

        int IBoite.Hauteur => throw new NotImplementedException();

        List<Boite> IBoite.lstBts => throw new NotImplementedException();

        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerateur<string> IBoite.GetEnumerateur()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        class Enumerateur : IEnumerateur<string>
        {
            public Boite Cur { get; set; }

            public string Current => Cur.Message;
            object IEnumerator.Current => throw new NotImplementedException();

            /*public bool HasNext => Cur.Succ == Queue;*/

            public Enumerateur(Boite bt)
            {
                Cur = new();
                Cur.Succ = bt;
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
