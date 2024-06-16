using System;

namespace HomeWork_1_MasterMind_Tuning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            Console.WriteLine("Üdvözöllek a számkitalálós játékban!");

            while (playAgain)
            {
                // Deklarálások
                Random rnd = new Random();
                int gn = 0;
                bool b = true;
                int tips = 0;
                string nextPlay = "";
                string valasz = "";

// UI kommunikáció a nehézségi szint kiválasztásához
                string message = "\nKérlek válassz nehézségi szintet:" +
                                "  Gyenge: gy   " +
                                "Közepes: k   " +
                                "Erős: e";

// UI kommunikáció kiiratása
                Write(message);
                Console.WriteLine();
                valasz = Console.ReadLine().ToLower();

                switch (valasz)
                {
                    case "gy":
                        Write("Gyenge játékmódot választottál!(1-10-g tippelj)");
                        gn = rnd.Next(1, 11);
                        break;
                    case "k":
                        Write("Közepes játékmódot választottál.(1-100-g tippelj)");
                        gn = rnd.Next(1, 101);
                        break;
                    case "e":
                        Write("Erős játékmódot választottál.(1-1000-g tippelj)");
                        gn = rnd.Next(1, 1001);
                        break;
                    default:
                        Write("Helytelen válasz! Válassz a gy, k vagy e közül!");
                        b = false;
                        break;
                }

                if (b)
                {
                    Write("Tippelj egy számot:");
                }

                while (b)
                {
                    int tipp;

// Ellenőrizzük, hogy számot adott-e meg a felhasználó
                    if (!int.TryParse(Console.ReadLine(), out tipp))
                    {
                        Write("Ez nem szám volt, próbáld újra:");
                        continue;
                    }
                    else if (valasz == "e" && tipp > 1000)
                    {
                        Write("Ez nem megfelelő szám volt, próbáld újra! (1-1000 között)");
                        continue;
                    }
                    else if (valasz == "k" && tipp > 100)
                    {
                        Write("Ez nem megfelelő szám volt, próbáld újra!");
                        continue;
                    }
                    else if (valasz == "gy" && tipp > 10)
                    {
                        Write("Ez nem megfelelő szám volt, próbáld újra! (1-10 között)");
                        continue;
                    }

                    // If-else ág bevezetése
                    tips++;

                    if (tipp < gn)
                    {
                        Write("Sajnos nagyobb számra gondoltam!");
                        Write("Az új tipped:");
                        Console.WriteLine();
                    }
                    else if (tipp > gn)
                    {
                        Write("Sajnos kisebb számra gondoltam!");
                        Write("Az új tipped:");
                        Console.WriteLine();
                    }
                    else
                    {
                        Write("Gratulálok, nyertél!");
                        Console.WriteLine();
                        Console.WriteLine("A tippeid száma: {0}", tips);
                        Console.WriteLine();
                        Write("Szeretnél még egyet játszani? Igen; Nem");
                        nextPlay = Console.ReadLine().ToLower();
                        if (nextPlay == "igen")
                        {
                            playAgain = true;
                            b = false; 
                        }
                        else
                        {
                            playAgain = false;
                            b = false; 
                        }
                        Write("Köszönjük, hogy játszottál, várunk máskor is!");
                    }
                }
            }
        }

        static void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
