using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    interface IBoite : IEnumerable<string>
    {
        public IBoite Redimensionner(int largeur, int hauteur);
        int Largeur { get; }
        int Hauteur { get; }
        IBoite Cloner(IBoite b);
    }
}
