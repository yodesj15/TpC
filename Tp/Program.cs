using System;
using Boites;
using Boites;

//Boite b = new();
////Console.WriteLine(b);
////Console.WriteLine(new Boite("yo"));
//string texte = @"Man! Hey!!!
//ceci est un test
//multiligne";
//string autTexte = "Ceci\nitou, genre";
//Boite b0 = new(texte);
//Boite b1 = new(autTexte);
//Console.WriteLine(b0);
//Console.WriteLine(b1);
//ComboVertical cv = new(b0, b1);
//Console.WriteLine(new Boite(cv));
//ComboHorizontal ch = new(b0, b1);
//Console.WriteLine(new Boite(ch));
//ComboVertical cvplus = new(new Boite(cv), new Boite(ch));
//Console.WriteLine(new Boite(cvplus));
//ComboHorizontal chplus = new(new Boite(cv), new Boite(ch));
//Console.WriteLine(new Boite(chplus));
//ComboVertical cvv = new(new Boite(chplus), new Boite("coucou"));
//Console.WriteLine(new Boite(cvv));
//Console.WriteLine(new Boite(
//   new ComboHorizontal(
//      new Boite("a\nb\nc\nd\ne"),
//         new Boite(
//            new ComboVertical(
//               new Boite("allo"), new Boite("yo")
//            )
//         )
//      )
//   )
//);
//Console.WriteLine(
//   new Boite(new ComboHorizontal(new Boite("Yo"), new Boite()))
//);
//Console.WriteLine(
//   new Boite(new ComboHorizontal(new Boite(), new Boite("Ya")))
//);
//Console.WriteLine(
//   new Boite(new ComboHorizontal(new Boite(), new Boite()))
//);
//Console.WriteLine(
//   new Boite(new ComboVertical(new Boite(), new Boite()))
//); // a voir 
//Console.WriteLine(
//   new Boite(new ComboVertical(new Boite("Yip"), new Boite()))
//);
//Console.WriteLine(
//   new Boite(new ComboVertical(new Boite(), new Boite("Yap")))
//);
//var p = new FabriqueBoites().Creer("mono J'aime mon \"prof\"");
//Console.WriteLine(p);
//p = new FabriqueBoites().Creer("cv\nmono J'aime mon \"prof\"\nmono moi itou");
//Console.WriteLine(p);
//p = new FabriqueBoites().Creer("ch\nmono J'aime mon \"prof\"\nmono moi itou");
//Console.WriteLine(p);
//p = new FabriqueBoites().Creer(
//   "ch\nmono J'aime mon \"prof\"\ncv\nmono moi itou\nmono eh ben");
//Console.WriteLine(p);
////p = new FabriqueBoites().Creer("ch\ncv\nmc\nmono J'aime mon \"prof\"\nmono moi itou\nmono eh ben");

//Console.Write(p);
TesterVisiteurs();

static void TesterVisiteurs()
{
    static void Tester(Boite b, params IVisiteur<IBoite>[] viz)
    {
        Console.WriteLine(b);
        foreach (var v in viz)
            b.Accepter(v);
    }
    var coul = new Couleureur();
    var mes = new Mesureur();
    Tester(new Boite(), coul, mes);
    Tester(new Boite("yo"), coul, mes);
    string texte = @"Man! Hey!!!
ceci est un test
multiligne";
    string autTexte = "Ceci\nitou, genre";
    Boite b0 = new Boite(texte);
    Boite b1 = new Boite(autTexte);
    Tester(b0, coul, mes);
    Tester(b1, coul, mes);
    ComboVertical cv = new ComboVertical(b0, b1);
    Tester(new Boite(cv), coul, mes);
    ComboHorizontal ch = new ComboHorizontal(b0, b1);
    Tester(new Boite(ch), coul, mes);
    ComboVertical cvplus = new ComboVertical(new Boite(cv), new Boite(ch));
    Tester(new Boite(cvplus), coul, mes);
    ComboHorizontal chplus = new ComboHorizontal(new Boite(cv), new Boite(ch));
    Tester(new Boite(chplus), coul, mes);
    ComboVertical cvv = new ComboVertical(new Boite(chplus), new Boite("coucou"));
    Tester(new Boite(cvv), coul, mes);
    Tester(new Boite(
       new ComboHorizontal(
          new Boite("a\nb\nc\nd\ne"),
             new Boite(
                new ComboVertical(
                   new Boite("allo"), new Boite("yo")
                )
             )
          )
       ), coul, mes
    );
    Tester(
       new Boite(new ComboHorizontal(new Boite("Yo"), new Boite())),
       coul, mes
    );
    Tester(
       new Boite(new ComboHorizontal(new Boite(), new Boite("Ya"))),
       coul, mes
    );
    Tester(
       new Boite(new ComboHorizontal(new Boite(), new Boite())),
       coul, mes
    );
    Tester(
       new Boite(new ComboVertical(new Boite("Yip"), new Boite())),
       coul, mes
    );
    Tester(
       new Boite(new ComboVertical(new Boite(), new Boite("Yap"))),
       coul, mes
    );
    Tester(
       new Boite(new ComboVertical(new Boite(), new Boite())),
       coul, mes
    );
    //Tester(new Boite(new MonoCombo(new Boite("allo"))), coul, mes);
    //Tester(new Boite(
    //   new MonoCombo(new Boite(new MonoCombo(new Boite("allo"))))
    //), coul, mes);
    //Tester(new Boite(
    //   new ComboVertical(
    //      new Boite(new MonoCombo(new Boite(new MonoCombo(new Boite("allo"))))),
    //      new Boite("Eh ben")
    //   )
    //), coul, mes);
    //Tester(new Boite(
    //   new ComboHorizontal(new Boite("a\nb\nc\nd"),
    //                       new Boite(new MonoCombo(new Boite())))
    //), coul, mes);
    //Tester(new Boite(
    //   new ComboHorizontal(new Boite(),
    //                       new Boite(new MonoCombo(new Boite())))
    //), coul, mes);
    //Tester(new Boite(
    //   new ComboHorizontal(
    //      new Boite(new MonoCombo(new Boite(new MonoCombo(new Boite("allo"))))),
    //      new Boite(new ComboVertical(
    //         new Boite("Eh ben"),
    //         new Boite(new MonoCombo(new Boite(
    //            new ComboHorizontal(new Boite("yo"), new Boite("hey"))
    //         )))
    //      ))
    //   )
    //), coul, mes);
    //Console.WriteLine($"\n\nLa plus petite boite est :\n{mes.PlusPetite}");
    //Console.WriteLine($"\n\nLa plus grande boite est :\n{mes.PlusGrande}");
}
