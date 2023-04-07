using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Boite : IEnumerable<string>, IVisitable<IBoite>
    {
        private IEnumerator<string> enumerator;

        public string Message { get; init; } = "";

        private char[] separators = new char[] { '\n', '\r' };

        public List<string> contenu { get; init; }

        public IBoite IB { get; init; }

        public Boite(string msg)
        {
            Message = msg;
            contenu = Message.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            enumerator = contenu.GetEnumerator();

            IB = new Mono(contenu.Max(str => str.Length), contenu.Count);

        }

        public Boite(Boite boite)
        {
            Message = boite.Message;
            contenu = boite.contenu;
            enumerator = boite.GetEnumerator();
            IB = boite.IB;
        }
        public Boite(IBoite boite)
        {
            IB = boite.Cloner();
            enumerator = boite.GetEnumerator();

            if(enumerator != null)
                enumerator.Reset();

            contenu = IB.lst;
        }

        public Boite()
        {
            contenu = new List<string>() { Message };
            enumerator = contenu.GetEnumerator();
            IB = new Mono();
        }

        public Boite Cloner() => new Boite(this);

        public override string ToString()
        {
            string header = '+' + new string('-', IB.Largeur) + '+';
            string messageFinal = header + "\n";

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

        public void Accepter(IVisiteur<IBoite> viz)
        {
            viz.Entrer();
            
            viz.Visiter(IB, () => { Console.Write("   " + IB.ToString().Substring(7)); });
            
            viz.Sortir();
        }
    }
}
