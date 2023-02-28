using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    class Boite : IBoite
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
        public string? Message { get; init; } = "";

        public int Hauteur { get; set; }
        public int Largeur { get; set; }

        public Boite? Succ { get; set; } = null;
        Boite Tete { get; set; } = null;
        Boite Queue { get; set; } = null;

        public bool EstVide => Tete == null;

        //public IEnumerateur<string> Enumerateur { get; set; }
        public List<string> ListeMots { get; private set; }
        public Boite(string msg)
        {
            Message = msg;
            char[] separators = new char[] { '\n', '\r' };
            ListeMots = Message.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            Hauteur = ListeMots.Count;
            Largeur = ListeMots.Max(str => str.Length);
            //Enumerateur = (IEnumerateur<string>) GetEnumerator();
            //MaxLength = FindMaxLenght();
        }
        public Boite (IBoite boite)
        {
            Hauteur = boite.Hauteur;
            Largeur = boite.Largeur;
        }

        public Boite() { }
        
        /*
        public string Afficher(IEnumerable<string> msg)
        {
            foreach(string str in msg) 
            {
                //...
            }
            return "";
        }*/

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

        public IEnumerator<string> GetEnumerator() => new IBoite.Enumerateur(this);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw new NotImplementedException();


       
    }
}
