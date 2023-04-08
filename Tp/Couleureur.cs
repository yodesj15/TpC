using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Couleureur : IVisiteur<IBoite>
    {
        private List<ConsoleColor> LstCouleur = new() { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow };
        public Couleureur() { }
        public void Entrer()
        {
            Random rdm = new Random();
            Console.ForegroundColor = LstCouleur[rdm.Next(LstCouleur.Count)];
        }
        public void Sortir() { }
        public void Visiter(IBoite p, Action opt) { }

    }
}
