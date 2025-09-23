using System;
using System.Linq;
using System.Collections.Generic;

namespace EulerChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project Euler Lösungen\n");
            
            Console.WriteLine($"Problem 1: {SolveProblem1()}");
            Console.WriteLine($"Problem 2: {SolveProblem2()}");
            Console.WriteLine($"Problem 3: {SolveProblem3()}");
            Console.WriteLine($"Problem 4: {SolveProblem4()}");
            Console.WriteLine($"Problem 5: {SolveProblem5()}");
        }

        // Problem 1: Vielfache von 3 oder 5
        static int SolveProblem1()
        {
            int summe = 0;
            for (int zahl = 1; zahl < 1000; zahl++)
            {
                if (zahl % 3 == 0 || zahl % 5 == 0)
                    summe += zahl;
            }
            return summe;
        }

        // Problem 2: Gerade Fibonacci-Zahlen
        static int SolveProblem2()
        {
            int vorige = 1, aktuelle = 2;
            int gesamtsumme = 0;

            while (aktuelle <= 4_000_000)
            {
                if (aktuelle % 2 == 0)
                    gesamtsumme += aktuelle;

                int naechste = vorige + aktuelle;
                vorige = aktuelle;
                aktuelle = naechste;
            }
            
            return gesamtsumme;
        }

        // Problem 3: Größter Primfaktor
        static long SolveProblem3()
        {
            long zielZahl = 600851475143L;
            long größterFaktor = 0;
            long teiler = 2;

            while (teiler * teiler <= zielZahl)
            {
                if (zielZahl % teiler == 0)
                {
                    größterFaktor = teiler;
                    while (zielZahl % teiler == 0)
                        zielZahl /= teiler;
                }
                teiler++;
            }

            if (zielZahl > 1)
                größterFaktor = zielZahl;

            return größterFaktor;
        }

        // Problem 4: Größtes Palindrom-Produkt
        static int SolveProblem4()
        {
            int maxPalindrom = 0;
            
            for (int a = 999; a >= 100; a--)
            {
                for (int b = a; b >= 100; b--)
                {
                    int produkt = a * b;
                    if (produkt <= maxPalindrom)
                        break; // Optimierung: keine bessere Lösung mehr möglich
                    
                    if (IstPalindrom(produkt))
                        maxPalindrom = produkt;
                }
            }
            
            return maxPalindrom;
        }

        static bool IstPalindrom(int zahl)
        {
            string s = zahl.ToString();
            int laenge = s.Length;
            
            for (int i = 0; i < laenge / 2; i++)
            {
                if (s[i] != s[laenge - 1 - i])
                    return false;
            }
            return true;
        }

        // Problem 5: Kleinstes gemeinsames Vielfaches
        static long SolveProblem5()
        {
            long kgv = 1;
            
            for (int n = 2; n <= 20; n++)
            {
                kgv = KgvZweierZahlen(kgv, n);
            }
            
            return kgv;
        }

        static long KgvZweierZahlen(long x, long y)
        {
            return (x * y) / GgtBerechnen(x, y);
        }

        static long GgtBerechnen(long x, long y)
        {
            while (y != 0)
            {
                long rest = x % y;
                x = y;
                y = rest;
            }
            return x;
        }
    }
}