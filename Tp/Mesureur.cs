using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Mesureur : IVisiteur<IBoite>
    {
        public Mesureur() { }
        public void Entrer() { Console.WriteLine("Entre m"); }
        public void Sortir() { Console.WriteLine("Sort m "); }
        public void Visiter(IBoite p, Action opt)
        {
            Console.Write("... je visite m");
            opt();
        }
    }
}
