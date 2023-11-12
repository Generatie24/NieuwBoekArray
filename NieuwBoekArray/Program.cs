using Microsoft.Win32;
using System;

class Program
{
    static string lijn = new string('-', 50);
    static void Main()
    {
        string[] boekTitels = new string[0];
        bool[] boekUitgeleend = new bool[10];
        string[] boekGebruiker = { "user1", "user2", "user3", "user4","user5","user6","user7","user8","user9","user10" };

        string boektitle1 = "Alchemist";
        string boektitle2 = "new generation ";
        string boektitle3 = "Course on c#";
        string boektitle4 = "Course on SQl";
        string boektitle5 = "Course on MVC";


        VoegBoekToe(ref boekTitels, boektitle1);
        VoegBoekToe(ref boekTitels, boektitle2);
        VoegBoekToe(ref boekTitels, boektitle3);
        VoegBoekToe(ref boekTitels, boektitle4);
        VoegBoekToe(ref boekTitels, boektitle5);

        ToonAlleBoeken(boekTitels);


        LeenBoekUit(boekTitels, boekUitgeleend, boekGebruiker, boektitle1, "user2");
        LeenBoekUit(boekTitels, boekUitgeleend, boekGebruiker, boektitle3, "user6");
        LeenBoekUit(boekTitels, boekUitgeleend, boekGebruiker, boektitle2, "user9");

        ToonUitgeleendeBoeken(boekTitels, boekUitgeleend, boekGebruiker);
        VerwijderBoek(boekTitels, boektitle2);
        ToonBeschikbareBoeken(boekTitels, boekUitgeleend);
    }

    static void ToonAlleBoeken(string[] books)
    {
        Console.WriteLine(lijn);
        Console.WriteLine("*** Alle Boeken ***");
        Console.WriteLine(lijn);
        foreach (var item in books)
        {
            if (item != null && item != "Deleted")
            {
                Console.WriteLine(item);
            }
        }
    }
    static void ToonBeschikbareBoeken(string[] titels, bool[] uitgeleend)
    {
        Console.WriteLine(lijn);
        Console.WriteLine("*** Beschikbare Boeken ***");
        Console.WriteLine(lijn);
        bool isErEenBeschikbaarBoek = false;

        for (int i = 0; i < titels.Length; i++)
        {
            if (!uitgeleend[i])
            {
                Console.WriteLine(titels[i]);
                isErEenBeschikbaarBoek = true;
            }
        }

        if (!isErEenBeschikbaarBoek)
        {
            Console.WriteLine("Er zijn momenteel geen beschikbare boeken.");
        }
    }
    static void VoegBoekToe(ref string[] titels, string nieuwBoek)
    {
        // Vergroot de array met één positie
        Array.Resize(ref titels, titels.Length + 1);

        // Voeg het nieuwe boek toe op de nieuwe positie
        titels[titels.Length-1] = nieuwBoek;
    }

    static void LeenBoekUit(string[] titels, bool[] uitgeleend, string[] gebruikers, string boekTitel, string gebruiker)
    {
        for (int i = 0; i < titels.Length; i++) // Gebruik titels.Length in plaats van boekTitel.Length
        {
            if (titels[i] == boekTitel && !uitgeleend[i])
            {
                uitgeleend[i] = true;
                gebruikers[i] = gebruiker;
            }
        }
        Console.WriteLine(lijn);
        Console.WriteLine($"Boek '{boekTitel}' is niet beschikbaar.");
    }

    static void ToonUitgeleendeBoeken(string[] titels, bool[] uitgeleend, string[] gebruikers)
    {
        Console.WriteLine(lijn);
        Console.WriteLine(" *** Uitgeleende Boeken ***");
        Console.WriteLine(lijn);
        bool isErEenUitgeleendBoek = false;

        for (int i = 0; i < uitgeleend.Length; i++)
        {
            if (uitgeleend[i])
            {
                Console.WriteLine($"Titel: {titels[i]}, Uitgeleend aan: {gebruikers[i]}");
                isErEenUitgeleendBoek = true;
            }
        }

        if (!isErEenUitgeleendBoek)
        {
            Console.WriteLine("Er zijn momenteel geen boeken uitgeleend.");
        }
    }
    static void VerwijderBoek(string[] titels, string boekTitel)
    {
        
        for (int i = 0; i < titels.Length; i++)
        {
            if (titels[i] == boekTitel)
            {
                titels[i] = "Deleted"; // Markeer het boek als verwijderd
                Console.WriteLine($"Boek {boekTitel} is gemarkeerd als verwijderd.");
                return;
            }
        }

        Console.WriteLine($"Boek {boekTitel} niet gevonden.");
    }   

}
