using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

                    string str = tempTab[1];

                    if(!str.Contains("cv") || !str.Contains("ch"))
                        return new Boite(CreerCombo(tempTab, 0, 0));
                    break;
                case "ch":
                    Boite b1 = new Boite(tempTab[1].Substring(4));
                    Boite b2 = new Boite(tempTab[2].Substring(4));
                    return new Boite(new ComboHorizontal(b1, b2));
                    break;
                default:
                    return new Boite(tempTab[0].Substring(5));
            }

            throw new Exception();
        }

        private IBoite CreerCombo(string[] tab, int indexTypeCombo, int startIndex) 
        {
            Boite ba;
            Boite bb;

            //0 : ComboVertical
            if (indexTypeCombo == 0)
            {
                ba = new Boite(tab[++startIndex].Substring(5));
                bb = new Boite(tab[++startIndex].Substring(5));
                return new ComboVertical(ba, bb);
            }
            //1 : ComboHorizontal
            else if(indexTypeCombo == 1) 
            {
                ba = new Boite(tab[++startIndex].Substring(5));
                bb = new Boite(tab[++startIndex].Substring(5));
                return new ComboHorizontal(ba, bb);
            }
            throw new Exception();
        }
    }
}
