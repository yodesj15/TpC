using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    public interface IBoite : IEnumerable<string>
    {
       int Largeur { get;  }
        int Hauteur { get; }

    }
}
