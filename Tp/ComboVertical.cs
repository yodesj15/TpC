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
        private int Espace { get; set; }


        //public string Message { get; private set; } = "";

        //public IEnumerateur<string> GetEnumerateur() => new Enumerateur(lstBts[0], lstBts[1]);

        public List<Boite> lstBts { get; set; } = new List<Boite>();

        public List<string> Liste => throw new NotImplementedException();

        public ComboVertical(Boite ba, Boite bb)
        {
            Hauteur = Math.Max(ba.ListeMots.Count(), bb.ListeMots.Count());
            Largeur = ba.ListeMots.Max(str => str.Length) + bb.ListeMots.Max(str => str.Length);
            //Largeur = Math.Max(ba.Largeur, bb.Largeur);
            //Espace = ba.Hauteur + 1;
            //Hauteur = Espace + bb.Hauteur ;
            //lstBts.Add(ba); 
            //lstBts.Add(bb);
            //IEnumerateur<string> enumerateur = GetEnumerateur();
            /*do
            {
                //Message += enumerateur.Current;
            } while (enumerateur.MoveNext());*/
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

        public IBoite Redimensionner(int largeur, int hauteur)
        {
            throw new NotImplementedException();
        }

        public IBoite Cloner(IBoite b)
        {
            throw new NotImplementedException();
        }


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
