using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    internal class ComboHorizontal : IBoite,IEnumerateur<string>
    {
        public int Largeur { get; private set; }
        public List<IEnumerable<string>> lst { get; private set; }
        public IEnumerateur<string> enumerateur { get; private set; }
        public int Hauteur { get; private set; }

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
    }
}
