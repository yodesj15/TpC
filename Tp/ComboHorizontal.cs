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
        //public List<IEnumerable<string>> lst { get; private set; }
        //public IEnumerateur<string> enumerateur { get; private set; }
        public int Hauteur { get; private set; }

        //public string Message { get; private set; } = "";

        public List<Boite> lstBts { get; set; } = new List<Boite>();

        public IEnumerateur<string> GetEnumerateur() => new Enumerateur(lstBts[0], lstBts[1]);

        public ComboHorizontal(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.Hauteur, bb.Hauteur);
            Largeur = ba.Largeur + bb.Largeur;
            lstBts.Add(ba);
            lstBts.Add(bb);
            IEnumerateur<string> enumerateur = GetEnumerateur();
            do
            {
                //Message += enumerateur.Current;
            } while (enumerateur.MoveNext()); 

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

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
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

            public string Current { get
                {
                    string message = null;
                    return message;
                } 
            }
            object IEnumerator.Current => throw new NotImplementedException();

            /*public bool HasNext => Cur.Succ == Queue;*/

            public Enumerateur(Boite ba, Boite bb)
            {
                Cur = ba;
                Cur.Succ = bb;
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
