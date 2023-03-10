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
        public int Largeur { get; private set; }

        public int Hauteur { get; private set; }

        //public string Message { get; private set; } = "";

        public IEnumerateur<string> GetEnumerateur() => new Enumerateur(lstBts[0], lstBts[1]);

        public List<Boite> lstBts { get; set; } = new List<Boite>();

        public ComboVertical(Boite ba, Boite bb)
        {
            Largeur = Math.Max(ba.Largeur, bb.Largeur);
            Hauteur = ba.Hauteur + bb.Hauteur;
            lstBts.Add(ba); 
            lstBts.Add(bb);
            IEnumerateur<string> enumerateur = GetEnumerateur();
            do
            {
                //Message += enumerateur.Current;
            } while (enumerateur.MoveNext());
        }

        /*public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }*/

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

            public string Current => Cur.ToString();
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
