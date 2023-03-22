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
        public string Message { get; init; } = "";

        private char[] separators = new char[] { '\n', '\r' };

        public List<string> ListeMots { get; init; }

        IBoite IB { get; init; }

        public Boite(string msg)
        {
            Message = msg;
            ListeMots = Message.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            IB = new Mono(ListeMots.Max(str => str.Length), ListeMots.Count);

        }

        public Boite(IBoite boite)
        {
            IB = boite.Cloner(boite);
            //IB = boite.Redimensionner(IB.Largeur, IB.Hauteur);
            ListeMots = IB.lst;
        }

        public Boite()
        {
            ListeMots = new List<string>() { Message };
            IB = new Mono();
        }

        public override string ToString()
        {
            string header = '+' + new string('-', IB.Largeur) + '+';
            string messageFinal = header + "\n";

            //Gestion des boites vides
            if (ListeMots != null)
            {
                foreach (string s in ListeMots)
                {
                    if (s != "")
                    {
                        //if (s.Contains('-') && s.Length < IB.Largeur)
                        //{
                        //    int nb = IB.Largeur - s.Length;

                        //    messageFinal += $"|{new string('-', nb)}|" + "\n";

                        //}
                        if (s.Length < IB.Largeur)
                        {
                            int nb = IB.Largeur - s.Length;
                            messageFinal += $"|{s}" + new string(' ', nb) + "|\n";

                        }
                        else
                        {
                            messageFinal += $"|{s}|" + "\n";

                        }

                    }

                }
            }

            messageFinal += header;
            return messageFinal;
        }

        public IEnumerable<string> GetEnumerator() => GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw new NotImplementedException();

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => throw new NotImplementedException();
    }
}
