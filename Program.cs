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
            Console.WriteLine($"Problem 6: {SolveProblem6()}");
            Console.WriteLine($"Problem 7: {SolveProblem7()}");
            Console.WriteLine($"Problem 8: {SolveProblem8()}");
            Console.WriteLine($"Problem 9: {SolveProblem9()}");
            Console.WriteLine($"Problem 10: {SolveProblem10()}");
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

        // Problem 6: Summe-Quadrat-Differenz
        static long SolveProblem6()
        {
            long quadratDerSumme = 0;
            long summeDerQuadrate = 0;
            
            for (int n = 1; n <= 100; n++)
            {
                quadratDerSumme += n;
                summeDerQuadrate += n * n;
            }
            
            quadratDerSumme = quadratDerSumme * quadratDerSumme;
            
            return quadratDerSumme - summeDerQuadrate;
        }

        // Problem 7: Die 10001. Primzahl
        static long SolveProblem7()
        {
            int gefundene = 0;
            int kandidat = 2;
            
            while (true)
            {
                if (IstPrimzahl(kandidat))
                {
                    gefundene++;
                    if (gefundene == 10001)
                        return kandidat;
                }
                kandidat++;
            }
        }

        static bool IstPrimzahl(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            
            int wurzel = (int)Math.Sqrt(n);
            for (int teiler = 3; teiler <= wurzel; teiler += 2)
            {
                if (n % teiler == 0)
                    return false;
            }
            return true;
        }

        // Problem 8: Größtes Produkt in einer Reihe
        static long SolveProblem8()
        {
            string ziffernfolge = 
                "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            long maxProdukt = 0;
            int fensterGroesse = 13;
            
            for (int startPos = 0; startPos <= ziffernfolge.Length - fensterGroesse; startPos++)
            {
                long produktAktuell = 1;
                bool hatNull = false;
                
                for (int offset = 0; offset < fensterGroesse; offset++)
                {
                    int ziffer = ziffernfolge[startPos + offset] - '0';
                    if (ziffer == 0)
                    {
                        hatNull = true;
                        break;
                    }
                    produktAktuell *= ziffer;
                }
                
                if (!hatNull && produktAktuell > maxProdukt)
                    maxProdukt = produktAktuell;
            }
            
            return maxProdukt;
        }

        // Problem 9: Pythagoräisches Tripel
        static int SolveProblem9()
        {
            // Suche a < b < c wo a + b + c = 1000 und a² + b² = c²
            for (int a = 1; a < 1000; a++)
            {
                for (int b = a + 1; b < 1000; b++)
                {
                    int c = 1000 - a - b;
                    
                    if (c > b && a * a + b * b == c * c)
                        return a * b * c;
                }
            }
            
            return -1; // sollte nie passieren
        }

        // Problem 10: Summierung von Primzahlen
        static long SolveProblem10()
        {
            int grenze = 2_000_000;
            bool[] istPrim = new bool[grenze];
            
            // Sieb des Eratosthenes
            for (int i = 2; i < grenze; i++)
                istPrim[i] = true;
            
            for (int p = 2; p * p < grenze; p++)
            {
                if (istPrim[p])
                {
                    for (int vielfaches = p * p; vielfaches < grenze; vielfaches += p)
                        istPrim[vielfaches] = false;
                }
            }
            
            long summe = 0;
            for (int i = 2; i < grenze; i++)
            {
                if (istPrim[i])
                    summe += i;
            }
            
            return summe;
        }
    }
}