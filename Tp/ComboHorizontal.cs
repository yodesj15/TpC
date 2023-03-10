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
        int Espace { get; set; }

        public List<string> Liste { get; private set; } = new List<string>();



        //public string Message { get; private set; } = "";

        //public List<Boite> lstBts { get; set; } = new List<Boite>();

        //public IEnumerateur<string> GetEnumerateur() => new Enumerateur(lstBts[0], lstBts[1]);

        public ComboHorizontal(Boite ba, Boite bb)
        {
            Hauteur = ba.ListeMots.Count() + bb.ListeMots.Count();
            Largeur = Math.Max(ba.ListeMots.Max(str => str.Length), bb.ListeMots.Max(str => str.Length));
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
            throw new NotImplementedException();
        }

        public IBoite Cloner(IBoite b)
        {
            throw new NotImplementedException();
        }

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
