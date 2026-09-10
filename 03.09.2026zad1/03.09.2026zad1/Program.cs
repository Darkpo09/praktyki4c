using System;

enum Skutecznosc
{
    TRAGICZNY = -1,
    SLABY = 1,
    DOBRY = 2,
    WYBITNY = 3
}

class Inzynier
{
    
    string imie;
    string nazwisko;
    Skutecznosc skutecznosc;
    int liczbaProjektow;

    
    static int wszystkieProjektyFirmy = 0;

    static int liczbaInzynierow = 0;

    static int rekordProjektow = 0;



    public Inzynier(string imie, string nazwisko, Skutecznosc skutecznosc, int liczbaProjektow)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.skutecznosc = skutecznosc;


        if (liczbaProjektow < 0)
        {
            this.liczbaProjektow = 0;
        }

        else
        {
            this.liczbaProjektow = liczbaProjektow;
        }


        wszystkieProjektyFirmy += this.liczbaProjektow;

        liczbaInzynierow++;
    }

    
    public void buduj()
    {
        int liczbaBudowanychProjektow = (int)skutecznosc;

        if (liczbaBudowanychProjektow == 1)
        {
            Console.WriteLine(imie + " " + nazwisko + " buduje " + liczbaBudowanychProjektow + " projekt.");
        }
        else if (liczbaBudowanychProjektow == 0 || liczbaBudowanychProjektow >= 5)
        {
            Console.WriteLine(imie + " " + nazwisko + " buduje " + liczbaBudowanychProjektow + " projektów.");
        }
        else
        {
            Console.WriteLine(imie + " " + nazwisko + " buduje " + liczbaBudowanychProjektow + " projekty.");
        }

        liczbaProjektow += liczbaBudowanychProjektow;
        wszystkieProjektyFirmy += liczbaBudowanychProjektow;


        if (liczbaProjektow > rekordProjektow)
        {
            rekordProjektow = liczbaProjektow;
        }

        awansuj();

    }


    public void pokaz()
    {
        Console.WriteLine(imie + " " + nazwisko +
            " - skutecznosc: " + skutecznosc +
            " - zrealizowane projekty: " + liczbaProjektow);
    }


    public void porownajZ(Inzynier innyInzynier)
    {
        if (liczbaProjektow > innyInzynier.liczbaProjektow)
        {
            int roznica = liczbaProjektow - innyInzynier.liczbaProjektow;

            Console.WriteLine(
                imie + " " + nazwisko +
                " ma wiecej projektow od " +
                innyInzynier.imie + " " + innyInzynier.nazwisko +
                " o " + roznica
            );
        }
        else if (liczbaProjektow < innyInzynier.liczbaProjektow)
        {
            int roznica = innyInzynier.liczbaProjektow - liczbaProjektow;

            Console.WriteLine(
                innyInzynier.imie + " " + innyInzynier.nazwisko +
                " ma wiecej projektow od " +
                imie + " " + nazwisko +
                " o " + roznica
            );
        }
        else
        {
            Console.WriteLine(
                imie + " " + nazwisko +
                " oraz " +
                innyInzynier.imie + " " + innyInzynier.nazwisko +
                " maja tyle samo projektow."
            );
        }
    }


    public static void pokazGlobalneProjekty()
    {
        Console.WriteLine("Wszystkie projekty wykonane przez firme: " + wszystkieProjektyFirmy);
    }


    public static void pokazLiczbeInzynierow()
    {
        Console.WriteLine("liczba inzynierow: " + liczbaInzynierow);
    }



    public static double sredniaProjektowNaInzyniera()
    {
        if (liczbaInzynierow == 0)
        {
            return 0;
        }

        return (double)wszystkieProjektyFirmy / liczbaInzynierow;

    }


    public static void pokazSredniaProjektow()
    {
        Console.WriteLine("Srednia projektow na inzyniera: " + sredniaProjektowNaInzyniera());
    }

    public static void pokazRekordProjektow()
    {
        Console.WriteLine("Rekord projektow jednego inzyniera: " + rekordProjektow);
    }



    public void awansuj()
    {
        if (liczbaProjektow >= 10 && skutecznosc == Skutecznosc.SLABY)
        {
            Console.WriteLine(imie + " " + nazwisko + " spelnil warunki awansu i awansuje na DOBRY.");
            skutecznosc = Skutecznosc.DOBRY;
        }
        else if (liczbaProjektow > 20 && skutecznosc == Skutecznosc.DOBRY)
        {
            Console.WriteLine(imie + " " + nazwisko + " spelnil warunki awansu i awansuje na WYBITNY.");
            skutecznosc = Skutecznosc.WYBITNY;
        }
    }
}

class Program
{
    static void Main()
    {


        Inzynier inzynier = new Inzynier(
            "Maks",
            "Manczak",
            Skutecznosc.TRAGICZNY,
            0
        );

        Inzynier inzynier1 = new Inzynier(
            "Adam",
            "Kowalski",
            Skutecznosc.SLABY,
            11
        );

        Inzynier inzynier2 = new Inzynier(
            "Weronika",
            "Kotowska",
            Skutecznosc.DOBRY,
            -3
        );


        Inzynier inzynier3 = new Inzynier(
            "Grzegorz",
            "Bielewicz",
            Skutecznosc.WYBITNY,
            0
        );




        inzynier.buduj();
        inzynier.pokaz();

        Console.WriteLine();

        inzynier.porownajZ(inzynier1);

        Console.WriteLine();

        inzynier1.buduj();
        inzynier1.pokaz();

            Console.WriteLine();

        inzynier2.buduj();
        inzynier2.pokaz();

        Console.WriteLine();

        inzynier3.porownajZ(inzynier2);

        Console.WriteLine();

        inzynier3.buduj();
        inzynier3.pokaz();

            Console.WriteLine();

        Inzynier.pokazGlobalneProjekty();

        Inzynier.pokazLiczbeInzynierow();

        Inzynier.pokazSredniaProjektow();

        Inzynier.pokazRekordProjektow();
    }
}