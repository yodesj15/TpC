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

        internal Boite Creer(string flux)
        {
            string[] tempTab = flux.Split(separators);

            switch (tempTab[0])
            {
                case "cv":
                    string str = tempTab[1];
                    if (!str.Contains("cv") || !str.Contains("ch"))
                        return new Boite(CreerCombo(tempTab, 1));
                    return new Boite(CreerCombo(tempTab, 1));

                case "ch":
                    string s = tempTab[1];
                    if (!s.Contains("cv") || !s.Contains("ch"))
                        return new Boite(CreerCombo(tempTab, 1));
                    return new Boite(CreerCombo(tempTab, 1));

                default:
                    return new Boite(tempTab[0].Substring(5));
            }

            throw new InvalidFluxException();
        }

        private IBoite CreerCombo(string[] tab, int startIndex)
        {
            string typeBoite = tab[0];
            List<IBoite> combos = new List<IBoite>(2);

            #region Vérifier si combo dans combo
            for (int i = startIndex; i < tab.Length; ++i)
            {
                string str = tab[i];
                if (str.Contains("cv"))
                {
                    string msg1 = tab[i + 1].Substring(5);
                    string msg2 = tab[i + 2].Substring(5);
                    combos.Add(new ComboVertical(new Boite(msg1), new Boite(msg2)));
                }

                if (str.Contains("ch"))
                {
                    string msg1 = tab[i + 1].Substring(5);
                    string msg2 = tab[i + 2].Substring(5);
                    combos.Add(new ComboHorizontal(new Boite(msg1), new Boite(msg2)));
                }
            }
            #endregion

            #region Création du combo
            if (typeBoite == "cv")
            {
                if (combos.Count != 0)
                {
                    if (combos.Count == 1)
                    {
                        //Faire la modif dans ce bloc
                        string msg = tab[tab.Length - 1].Substring(5);
                        return new ComboVertical(new Boite(combos[0]), new Boite(msg));
                    }
                    return new ComboVertical(new Boite(combos[0]), new Boite(combos[1]));
                }
                return new ComboVertical(new Boite(tab[startIndex].Substring(5)), new Boite(tab[startIndex + 1].Substring(5)));
            }

            else if (typeBoite == "ch")
            {
                if (combos.Count != 0)
                {
                    if (combos.Count == 1)
                    {
                        //Faire la modif aussi dans ce bloc
                        string msg = tab[tab.Length - 1].Substring(5);
                        return new ComboHorizontal(new Boite(combos[0]), new Boite(msg));
                    }
                    return new ComboHorizontal(new Boite(combos[0]), new Boite(combos[1]));
                }
                return new ComboHorizontal(new Boite(tab[startIndex].Substring(5)), new Boite(tab[startIndex + 1].Substring(5)));
            }
            #endregion
            throw new InvalidComboTypeException();
        }
    }
}
