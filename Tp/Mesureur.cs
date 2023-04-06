using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    class Mesureur : IVisiteur<IBoite>
    {
        public Boite PlusPetite;
        public Boite PlusGrande;
        private int airePlusGrande = 0;
        private int airePlusPetite = int.MaxValue;
        public Mesureur() { }
        public void Entrer()
        {
            Console.WriteLine("Boite");
        }
        public void Sortir()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("Sort m ");
        }
        public void Visiter(IBoite p, Action opt)
        {
            int currentAire = p.Hauteur * p.Largeur;
            if(currentAire > airePlusGrande)
            {
                airePlusGrande = currentAire;
                PlusGrande = new Boite(p);
            }

            if (currentAire < airePlusPetite)
            {
                airePlusPetite = currentAire;
                PlusPetite = new Boite(p);
            }

            opt();
           
            p.Accepter(this);
            //Console.WriteLine($"  {p.Hauteur} x {p.Largeur} ");
        }
    }
}
