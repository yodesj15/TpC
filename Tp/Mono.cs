using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    internal class Mono : IBoite
    {
        public int Largeur { get; private set; } = 0;

        public int Hauteur { get; private set; } = 0;

        public List<string> lst { get; set; }
        public Boite BoiteCombo1 { get; init; }
        public Boite BoiteCombo2 { get; init; }

        public IEnumerator<string> Enumerator { get; init; }

        public Mono() { }

        public Mono(int largeur, int hauteur)
        {
            Largeur = largeur;
            Hauteur = hauteur;
        }

        public Mono(IBoite bt)
        {
            Largeur = bt.Largeur;
            Hauteur = bt.Hauteur;
        }

        public IBoite Cloner() => new Mono(this);

        public IEnumerator<string> GetEnumerator() => Enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Accepter(IVisiteur<IBoite> viz)
        {
            Console.WriteLine();
            Console.WriteLine($"       {Hauteur} x {Largeur} ");
        }

    }
}
