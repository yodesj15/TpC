using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    interface IBoite : IEnumerable<string>,IVisitable<IBoite>
    {
        //IBoite Redimensionner(int largeur, int hauteur);
        int Largeur { get; }
        int Hauteur { get; }
        IEnumerator<string> Enumerator { get; }
        List<string> lst { get; }
        IBoite Cloner(IBoite b);
    }
}
