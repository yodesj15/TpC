using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Boites;

namespace Boites
{
    class FabriqueBoites
    {
        private static char[] separators = new char[] { '\n', '\r' };

        public FabriqueBoites() { }

        internal Boite Creer(string flux)
        {
            string[] tempTab = flux.Split(separators);

            if (string.IsNullOrEmpty(tempTab[0]))
                throw new InvalidFluxException();

            switch (tempTab[0])
            {
                case "cv":
                    return new Boite(CreerCombo(tempTab, 1, tempTab[0]));

                case "ch":
                    return new Boite(CreerCombo(tempTab, 1, tempTab[0]));

                default:
                    return new Boite(tempTab[0].Substring(5));
            }
        }

        private IBoite CreerComboVertical(string[] tab, int posMsg1, int posMsg2)
        {
            string msg1 = tab[posMsg1].Substring(5);
            string msg2 = tab[posMsg2].Substring(5);
            return new ComboVertical(new Boite(msg1), new Boite(msg2));
        }

        private IBoite CreerComboHorizontal(string[] tab, int posMsg1, int posMsg2)
        {
            string msg1 = tab[posMsg1].Substring(5);
            string msg2 = tab[posMsg2].Substring(5);
            return new ComboHorizontal(new Boite(msg1), new Boite(msg2));
        }

        private IBoite CreerCombo(string[] tab, int startIndex, string typeBoite)
        {
            List<Boite> boites = new(2);
            IBoite combo = null;

            for (int i = startIndex; i < tab.Length; ++i)
            {
                if (tab[i].Contains("cv"))
                {
                    boites.Add(new Boite( CreerComboVertical(tab, i + 1, i + 2)) );
                    i = i + 2;
                }
                else if (tab[i].Contains("ch"))
                {
                    boites.Add(new Boite( CreerComboHorizontal(tab, i + 1, i + 2)) );
                    i = i + 2;
                }
                else if (tab[i].Contains("mono"))
                    boites.Add( new Boite(tab[i].Substring(5)) );
            }

            if (typeBoite == "cv")
                combo = new ComboVertical(boites[0], boites[1]);

            else if (typeBoite == "ch")
                combo = new ComboHorizontal(boites[0], boites[1]);
            return combo;
        }
    }
}
