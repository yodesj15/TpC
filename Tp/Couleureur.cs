using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Couleureur : IVisiteur<IBoite>
    {
        public Couleureur() { }
        public void Entrer()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void Sortir()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Visiter(IBoite p, Action opt)
        {
            Console.Write("");
            //opt();
        }

    }
}
