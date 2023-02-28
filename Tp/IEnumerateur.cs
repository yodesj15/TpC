using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp
{
    interface IEnumerateur<string> : IEnumerator<string>
    {
        //La propriété Filling, dont je me sers si j'ai besoin de lignes alors que le contenu dans la boîte a été épuisé, et
        //La propriété HasNext, qui s'avère seulement si l'énumérateur ne mène pas déjà au dernier élément de la séquence d'origine
    }
}
