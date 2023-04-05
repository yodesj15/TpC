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
        public void Entrer()
        {
            Console.WriteLine("Boite");
        }
        public void Sortir()
        {
            Console.WriteLine("Sort m ");
        }
        public void Visiter(IBoite p, Action opt)
        {

            opt();
            Console.WriteLine($"  {p.Hauteur} x {p.Largeur} ");
        }
    }
}
