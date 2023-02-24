using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    public class Boite : IBoite
    {
        public string Message { get; private set; }

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
        public Boite()
        {
            


        }

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
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
