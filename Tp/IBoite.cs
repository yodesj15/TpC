using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    interface IBoite : IEnumerable<string>
    {
        //IEnumerable<string> Enumerateur { get; }
        //List<string> ListeMots { get; }

        int Largeur { get; }
        int Hauteur { get; }

        class Enumerateur : IEnumerateur<string>
        {
            public Boite Cur { get; set; }

            public string Current => Cur.Message;
            object IEnumerator.Current => throw new NotImplementedException();

            public Enumerateur(Boite bt) 
            {
                Cur = new();
                Cur.Succ = bt;
            }

            public bool MoveNext()
            {
                if(Cur.Succ == null)
                    return false;
                Cur = Cur.Succ;
                return true;
            }

            public void Reset() => throw new NotImplementedException();

            public void Dispose() { }
        }

    }
}
