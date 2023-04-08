using System;
using Boites;

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
}

