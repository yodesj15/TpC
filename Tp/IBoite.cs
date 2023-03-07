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
        //IEnumerable<string> Enumerateur { get; }
        //List<string> ListeMots { get; }

        int Largeur { get; }
        int Hauteur { get; }

        List<Boite> lstBts { get; }
        IEnumerateur<string> GetEnumerateur();

    }
}
