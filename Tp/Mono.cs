using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    internal class Mono : IBoite
    {
        public int Largeur { get; private set; }

        public int Hauteur { get; private set; }

        public IBoite.Enumerateur GetEnumerateur()
        {
            return new IBoite.Enumerateur(new Boite(this));
        }

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
    }
}
