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
        public ComboVertical(IBoite ba, IBoite bb)
        {
        }

        public int Largeur => throw new NotImplementedException();

        public int Hauteur => throw new NotImplementedException();

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
