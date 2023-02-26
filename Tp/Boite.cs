using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    public class Boite : IBoite
    {
        // *******************************************
        // * Source: chatGPT                         *
        // * Explication: The question mark symbol   *
        // * (?) in the code you provided denotes a  *
        // * nullable reference type. This feature   *
        // * was introduced in C# 8.0 and allows you *
        // * to specify whether a reference type can *
        // * contain a null value or not.            *
        // *******************************************
        public string? Message { get; private set; }

        public int Hauteur { get; set; }
        public int Largeur { get; set; }

        private List<string> ListeMots = new List<string>();
        public Boite(string msg)
        {
            Message = msg;
            char[] separators = new char[] { '\n', '\r' };
            ListeMots = Message.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            Hauteur = ListeMots.Count;
            Largeur = ListeMots.Max(str => str.Length);
            //MaxLength = FindMaxLenght();
        }
        public Boite (IBoite boite) { }
        /*
        //À vérifier avec Patrice si 2 IBoite max ou plusieurs IBoite
        public Boite(params IBoite[] boites)
        {

        }*/
        public Boite() { }

        public override string ToString()
        {
            string header = '+' + new string('-',Largeur) + '+'+ "\n" ;
            string messageFinal = header;
            foreach(string s in ListeMots)
            {
                if( s.Length < Largeur)
                {
                    int nb = Largeur - s.Length;
                    messageFinal += $"|{s}" + new string(' ', nb) + "|\n";

                }
                else
                {
                    messageFinal += $"|{s}|" + "\n";

                }

            }

            messageFinal += header;
            return messageFinal;
        }
      

        //public void Afficher()
        //{

        //}

        public IEnumerator<string> GetEnumerator()
        {
            return ListeMots.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ListeMots.GetEnumerator();
        }
    }
}
