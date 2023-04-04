using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Couleureur :IVisiteur<IBoite>
    {
        public Couleureur() { } 
        public void Entrer() { Console.WriteLine("Entre c"); }
        public void Sortir() { Console.WriteLine("Sort c"); }
        public void Visiter(IBoite p , Action opt)
        {
            Console.Write("... je visite c");
            opt();
        }

    }
}
