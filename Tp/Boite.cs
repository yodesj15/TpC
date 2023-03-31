using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    class Boite : IEnumerable<string>
    {
        private IEnumerator<string> enumerator;

        public string Message { get; init; } = "";

        private char[] separators = new char[] { '\n', '\r' };

        public List<string> ListeMots { get; init; }

        IBoite IB { get; init; }

        public Boite(string msg)
        {
            Message = msg;
            ListeMots = Message.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            enumerator = ListeMots.GetEnumerator();

            IB = new Mono(ListeMots.Max(str => str.Length), ListeMots.Count);

        }

        public Boite(IBoite boite)
        {
            IB = boite.Cloner(boite);
            //IB = boite.Redimensionner(IB.Largeur, IB.Hauteur);
            enumerator = boite.GetEnumerator();
            ListeMots = IB.lst;
        }

        public Boite()
        {
            ListeMots = new List<string>() { Message };
            enumerator = ListeMots.GetEnumerator();
            IB = new Mono();
        }

        public override string ToString()
        {
            string header = '+' + new string('-', IB.Largeur) + '+';
            string messageFinal = header + "\n";

            // Marche en debug
            //if (ListeMots != null)
            //{
            //    foreach (string s in ListeMots)
            //    {
            //        if (s != "")
            //        {
            //            if (s.Contains('-') && s.Length < IB.Largeur)
            //            {
            //                int nb = IB.Largeur - s.Length;

            //                messageFinal += $"|{new string('-', nb)}|" + "\n";

            //            }
            //            if (s.Length < IB.Largeur)
            //            {
            //                int nb = IB.Largeur - s.Length;
            //                messageFinal += $"|{s}" + new string(' ', nb) + "|\n";

            //            }
            //            else
            //            {
            //                messageFinal += $"|{s}|" + "\n";

            //            }

            //        }


            //    }
            //}

            if (enumerator != null)
            {
                enumerator.MoveNext();
                do
                {
                    string str = enumerator.Current;
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str.Length < IB.Largeur)
                        {
                            int nb = IB.Largeur - str.Length;
                            messageFinal += $"|{str}" + new string(' ', nb) + "|\n";
                        }
                        else
                            messageFinal += $"|{str}|" + "\n";

                    }
                } while (enumerator.MoveNext());

                if (IB.Largeur == 0)
                    messageFinal += "||\n";
            }

            messageFinal += header;
            return messageFinal;
        }

        public IEnumerator<string> GetEnumerator() => enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
