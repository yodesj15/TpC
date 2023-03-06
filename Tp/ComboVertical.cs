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

        public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
