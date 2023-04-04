using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    interface IVisiteur<T>
    {
        void Entrer();
        void Sortir();
        void Visiter(T elem, Action opt);
    }
}
