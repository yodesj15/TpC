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
        public int Largeur { get; private set; }
        public List<IEnumerable<string>> lst { get; private set; }
        public IEnumerateur<string> enumerateur { get; private set; }
        public int Hauteur { get; private set; }

        public List<Boite> lstBts => throw new NotImplementedException();

        public ComboHorizontal(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.Hauteur, bb.Hauteur);
            Largeur = ba.Largeur + bb.Largeur;
            lst = new List<IEnumerable<string>>();
            //lst.Add();
            //lst.Add(bb.Message.GetEnumerator().Current);
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerateur<string> GetEnumerateur()
        {
            throw new NotImplementedException();
        }

        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

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
