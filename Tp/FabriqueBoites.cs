using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    class FabriqueBoites
    {

        private static char[] separators = new char[] { '\n', '\r'};

        internal Boite Creer(string flux)
        {
            string[] tempTab = flux.Split(separators);

            switch (tempTab[0])
            {
                case "cv":
                    break;
                case "ch":
                    break;
                default:
                    return new Mono(tempTab[0].Substring(4));
            }

            throw new Exception();
        }
    }
}
