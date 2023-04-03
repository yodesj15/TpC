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
                    return new Boite(CreerComboVertical(tempTab, 1));

                case "ch":
                    return new Boite(CreerComboHorizontal(tempTab, 1));

                default:
                    return new Boite(tempTab[0].Substring(5));
            }

            throw new InvalidFluxException();
        }

        private IBoite CreerComboHorizontal(string[] tab, int index)
        {
            IBoite ch = null;
            int indexBt = 0;
            int indexCh = 0;

            for(int i = index; i < tab.Length; ++i)
            {
                if (tab[i] == "cv")
                    CreerComboVertical(tab, i);
                else if (tab[i] == "ch")
                    indexCh = i;
                else
                    indexBt = i;
            }

            if(indexBt != 0 && indexCh != 0)
            {
                string msg1 = tab[indexCh + 1].Substring(5);
                string msg2 = tab[indexCh + 2].Substring(5);
                ch = new ComboHorizontal(new Boite(msg1), new Boite(msg2));

                if (indexBt < indexCh)
                    ch = new ComboHorizontal(new Boite(tab[indexBt]), new Boite(ch));
                else
                    ch = new ComboHorizontal(new Boite(ch), new Boite(tab[indexBt]));
            }
            return ch;
        }

        private IBoite CreerComboVertical(string[] tab, int index)
        {
            IBoite cv = null;
            int indexBt = 0;
            int indexCv = 0;

            for (int i = index; i < tab.Length; ++i)
            {
                if (tab[i] == "cv")
                    indexCv = i;
                else if (tab[i] == "ch")
                    CreerComboHorizontal(tab, i);
                else
                    indexBt = i;
            }

            if (indexBt != 0 && indexCv != 0)
            {
                string msg1 = tab[indexCv + 1].Substring(5);
                string msg2 = tab[indexCv + 2].Substring(5);
                cv = new ComboVertical(new Boite(msg1), new Boite(msg2));

                if (indexBt < indexCv)
                    cv = new ComboVertical(new Boite(tab[indexBt]), new Boite(cv));
                else
                    cv = new ComboVertical(new Boite(cv), new Boite(tab[indexBt]));
            }
            return cv;
        }

        //private IBoite CreerCombo(string[] tab, int startIndex)
        //{
        //    string typeBoite = tab[0];

        //    List<IBoite> combos = new(2);

        //    #region Vérifier si combo dans combo
        //    for (int i = startIndex; i < tab.Length; ++i)
        //    {

        //        if (tab[i].Contains("cv"))
        //            combos.Add(CreerComboVertical(tab, i));

        //        if (tab[i].Contains("ch"))
        //            combos.Add(CreerComboHorizontal(tab, i));
        //    }
        //    #endregion

        //    #region Création du combo
        //    if (typeBoite == "cv")
        //    {
        //        if (combos.Count != 0)
        //        {
        //            if (combos.Count == 1)
        //            {
        //                //Faire la modif dans ce bloc
                        
        //                string msg = tab[tab.Length - 1].Substring(5);
        //                return new ComboVertical(new Boite(combos[0]), new Boite(msg));
        //            }
        //            return new ComboVertical(new Boite(combos[0]), new Boite(combos[1]));
        //        }
        //        return new ComboVertical(new Boite(tab[startIndex].Substring(5)), new Boite(tab[startIndex + 1].Substring(5)));
        //    }

        //    else if (typeBoite == "ch")
        //    {
        //        if (combos.Count != 0)
        //        {
        //            if (combos.Count == 1)
        //            {
        //                //Faire la modif aussi dans ce bloc
        //                string msg = tab[tab.Length - 1].Substring(5);
        //                return new ComboHorizontal(new Boite(combos[0]), new Boite(msg));
        //            }
        //            return new ComboHorizontal(new Boite(combos[0]), new Boite(combos[1]));
        //        }
        //        return new ComboHorizontal(new Boite(tab[startIndex].Substring(5)), new Boite(tab[startIndex + 1].Substring(5)));
        //    }
        //    #endregion
        //    throw new InvalidComboTypeException();
        //}
    }
}
