using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

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
			Console.WriteLine($"Problem 11: {SolveProblem11()}");
			Console.WriteLine($"Problem 12: {SolveProblem12()}");
			Console.WriteLine($"Problem 13: {SolveProblem13()}");
			Console.WriteLine($"Problem 14: {SolveProblem14()}");
			Console.WriteLine($"Problem 15: {SolveProblem15()}");
			Console.WriteLine($"Problem 16: {SolveProblem16()}");
			Console.WriteLine($"Problem 17: {SolveProblem17()}");
			Console.WriteLine($"Problem 18: {SolveProblem18()}");
			Console.WriteLine($"Problem 19: {SolveProblem19()}");
			Console.WriteLine($"Problem 20: {SolveProblem20()}");
			Console.WriteLine($"Problem 21: {SolveProblem21()}");
			Console.WriteLine($"Problem 22: {SolveProblem22()}");
            Console.WriteLine($"Problem 23: {SolveProblem23()}");
            Console.WriteLine($"Problem 24: {SolveProblem24()}");
            Console.WriteLine($"Problem 25: {SolveProblem25()}");
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

		// Problem 11: Größtes Produkt in einem Gitter
		static long SolveProblem11()
		{
			int[,] grid = new int[20, 20]
			{
				{08,02,22,97,38,15,00,40,00,75,04,05,07,78,52,12,50,77,91,08},
				{49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,04,56,62,00},
				{81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,03,49,13,36,65},
				{52,70,95,23,04,60,11,42,69,24,68,56,01,32,56,71,37,02,36,91},
				{22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80},
				{24,47,32,60,99,03,45,02,44,75,33,53,78,36,84,20,35,17,12,50},
				{32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70},
				{67,26,20,68,02,62,12,20,95,63,94,39,63,08,40,91,66,49,94,21},
				{24,55,58,05,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72},
				{21,36,23,09,75,00,76,44,20,45,35,14,00,61,33,97,34,31,33,95},
				{78,17,53,28,22,75,31,67,15,94,03,80,04,62,16,14,09,53,56,92},
				{16,39,05,42,96,35,31,47,55,58,88,24,00,17,54,24,36,29,85,57},
				{86,56,00,48,35,71,89,07,05,44,44,37,44,60,21,58,51,54,17,58},
				{19,80,81,68,05,94,47,69,28,73,92,13,86,52,17,77,04,89,55,40},
				{04,52,08,83,97,35,99,16,07,97,57,32,16,26,26,79,33,27,98,66},
				{88,36,68,87,57,62,20,72,03,46,33,67,46,55,12,32,63,93,53,69},
				{04,42,16,73,38,25,39,11,24,94,72,18,08,46,29,32,40,62,76,36},
				{20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,04,36,16},
				{20,73,35,29,78,31,90,01,74,31,49,71,48,86,81,16,23,57,05,54},
				{01,70,54,71,83,51,54,69,16,92,33,48,61,43,52,01,89,19,67,48}
			};

			long maxProdukt = 0;
			for (int r = 0; r < 20; r++)
			{
				for (int c = 0; c < 20; c++)
				{
					if (c + 3 < 20)
					{
						long p = 1L * grid[r, c] * grid[r, c + 1] * grid[r, c + 2] * grid[r, c + 3];
						if (p > maxProdukt) maxProdukt = p;
					}
					if (r + 3 < 20)
					{
						long p = 1L * grid[r, c] * grid[r + 1, c] * grid[r + 2, c] * grid[r + 3, c];
						if (p > maxProdukt) maxProdukt = p;
					}
					if (r + 3 < 20 && c + 3 < 20)
					{
						long p = 1L * grid[r, c] * grid[r + 1, c + 1] * grid[r + 2, c + 2] * grid[r + 3, c + 3];
						if (p > maxProdukt) maxProdukt = p;
					}
					if (r + 3 < 20 && c - 3 >= 0)
					{
						long p = 1L * grid[r, c] * grid[r + 1, c - 1] * grid[r + 2, c - 2] * grid[r + 3, c - 3];
						if (p > maxProdukt) maxProdukt = p;
					}
				}
			}
			return maxProdukt;
		}

		// Problem 12: Hochgradig teilbare Dreieckszahl (>500 Teiler)
		static long SolveProblem12()
		{
			long n = 1;
			long dreieck = 1;
			while (AnzahlTeiler(dreieck) <= 500)
			{
				n++;
				dreieck += n;
			}
			return dreieck;
		}

		static int AnzahlTeiler(long x)
		{
			int count = 0;
			long wurzel = (long)Math.Sqrt(x);
			for (long d = 1; d <= wurzel; d++)
			{
				if (x % d == 0)
				{
					count += 2;
				}
			}
			if (wurzel * wurzel == x) count--;
			return count;
		}

		// Problem 13: Große Summe – erste 10 Ziffern
		static string SolveProblem13()
		{
			string[] numbers = new string[]
			{
				"37107287533902102798797998220837590246510135740250",
				"46376937677490009712648124896970078050417018260538",
				"74324986199524741059474233309513058123726617309629",
				"91942213363574161572522430563301811072406154908250",
				"23067588207539346171171980310421047513778063246676",
				"89261670696623633820136378418383684178734361726757",
				"28112879812849979408065481931592621691275889832738",
				"44274228917432520321923589422876796487670272189318",
				"47451445736001306439091167216856844588711603153276",
				"70386486105843025439939619828917593665686757934951",
				"62176457141856560629502157223196586755079324193331",
				"64906352462741904929101432445813822663347944758178",
				"92575867718337217661963751590579239728245598838407",
				"58203565325359399008402633568948830189458628227828",
				"80181199384826282014278194139940567587151170094390",
				"35398664372827112653829987240784473053190104293586",
				"86515506006295864861532075273371959191420517255829",
				"71693888707715466499115593487603532921714970056938",
				"54370070576826684624621495650076471787294438377604",
				"53282654108756828443191190634694037855217779295145",
				"36123272525000296071075082563815656710885258350721",
				"45876576172410976447339110607218265236877223636045",
				"17423706905851860660448207621209813287860733969412",
				"81142660418086830619328460811191061556940512689692",
				"51934325451728388641918047049293215058642563049483",
				"62467221648435076201727918039944693004732956340691",
				"15732444386908125794514089057706229429197107928209",
				"55037687525678773091862540744969844508330393682126",
				"18336384825330154686196124348767681297534375946515",
				"80386287592878490201521685554828717201219257766954",
				"78182833757993103614740356856449095527097864797581",
				"16726320100436897842553539920931837441497806860984",
				"48403098129077791799088218795327364475675590848030",
				"87086987551392711854517078544161852424320693150332",
				"59959406895756536782107074926966537676326235447210",
				"69793950679652694742597709739166693763042633987085",
				"41052684708299085211399427365734116182760315001271",
				"65378607361501080857009149939512557028198746004375",
				"35829035317434717326932123578154982629742552737307",
				"94953759765105305946966067683156574377167401875275",
				"88902802571733229619176668713819931811048770190271",
				"25267680276078003013678680992525463401061632866526",
				"36270218540497705585629946580636237993140746255962",
				"24074486908231174977792365466257246923322810917141",
				"91430288197103288597806669760892938638285025333403",
				"34413065578016127815921815005561868836468420090470",
				"23053081172816430487623791969842487255036638784583",
				"11487696932154902810424020138335124462181441773470",
				"63783299490636259666498587618221225225512486764533",
				"67720186971698544312419572409913959008952310058822",
				"95548255300263520781532296796249481641953868218774",
				"76085327132285723110424803456124867697064507995236",
				"37774242535411291684276865538926205024910326572967",
				"23701913275725675285653248258265463092207058596522",
				"29798860272258331913126375147341994889534765745501",
				"18495701454879288984856827726077713721403798879715",
				"38298203783031473527721580348144513491373226651381",
				"34829543829199918180278916522431027392251122869539",
				"40957953066405232632538044100059654939159879593635",
				"29746152185502371307642255121183693803580388584903",
				"41698116222072977186158236678424689157993532961922",
				"62467957194401269043877107275048102390895523597457",
				"23189706772547915061505504953922979530901129967519",
				"86188088225875314529584099251203829009407770775672",
				"11306739708304724483816533873502340845647058077308",
				"82959174767140363198008187129011875491310547126581",
				"97623331044818386269515456334926366572897563400500",
				"42846280183517070527831839425882145521227251250327",
				"55121603546981200581762165212827652751691296897789",
				"32238195734329339946437501907836945765883352399886",
				"75506164965184775180738168837861091527357929701337",
				"62177842752192623401942399639168044983993173312731",
				"32924185707147349566916674687634660915035914677504",
				"99518671430235219628894890102423325116913619626622",
				"73267460800591547471830798392868535206946944540724",
				"76841822524674417161514036427982273348055556214818",
				"97142617910342598647204516893989422179826088076852",
				"87783646182799346313767754307809363333018982642090",
				"10848802521674670883215120185883543223812876952786",
				"71329612474782464538636993009049310363619763878039",
				"62184073572399794223406235393808339651327408011116",
				"66627891981488087797941876876144230030984490851411",
				"60661826293682836764744779239180335110989069790714",
				"85786944089552990653640447425576083659976645795096",
				"66024396409905389607120198219976047599490197230297",
				"64913982680032973156037120041377903785566085089252",
				"16730939319872750275468906903707539413042652315011",
				"94809377245048795150954100921645863754710598436791",
				"78639167021187492431995700641917969777599028300699",
				"15368713711936614952811305876380278410754449733078",
				"40789923115535562561142322423255033685442488917353",
				"44889911501440648020369068063960672322193204149535",
				"41503128880339536053299340368006977710650566631954",
				"81234880673210146739058568557934581403627822703280",
				"82616570773948327592232845941706525094512325230608",
				"22918802058777319719839450180888072429661980811197",
				"77158542502016545090413245809786882778948721859617",
				"72107838435069186155435662884062257473692284509516",
				"20849603980134001723930671666823555245252804609722",
				"53503534226472524250874054075591789781264330331690"
			};

			BigInteger sum = BigInteger.Zero;
			foreach (var s in numbers)
				sum += BigInteger.Parse(s);
			string digits = sum.ToString();
			return digits.Substring(0, 10);
		}

		// Problem 14: Längste Collatz-Folge unter 1 Million
		static long SolveProblem14()
		{
			const int limit = 1_000_000;
			var cache = new Dictionary<long, int>();
			cache[1] = 1;
			int bestLen = 0;
			long bestStart = 1;
			for (int i = 1; i < limit; i++)
			{
				int len = CollatzLaenge(i, cache);
				if (len > bestLen)
				{
					bestLen = len;
					bestStart = i;
				}
			}
			return bestStart;
		}

		static int CollatzLaenge(long n, Dictionary<long, int> cache)
		{
			if (cache.TryGetValue(n, out int v)) return v;
			long next = (n % 2 == 0) ? (n / 2) : (3 * n + 1);
			int len = 1 + CollatzLaenge(next, cache);
			cache[n] = len;
			return len;
		}

		// Problem 15: Gitterwege 20x20
		static BigInteger SolveProblem15()
		{
			// Anzahl Wege = C(40, 20)
			return BinomialCoefficient(40, 20);
		}

		static BigInteger BinomialCoefficient(int n, int k)
		{
			if (k < 0 || k > n) return BigInteger.Zero;
			if (k == 0 || k == n) return BigInteger.One;
			k = Math.Min(k, n - k);
			BigInteger result = BigInteger.One;
			for (int i = 1; i <= k; i++)
			{
				result = result * (n - (k - i)) / i;
			}
			return result;
		}

		// Problem 16: Quersumme von 2^1000
		static int SolveProblem16()
		{
			BigInteger x = BigInteger.One;
			for (int i = 0; i < 1000; i++) x *= 2;
			return x.ToString().Sum(ch => ch - '0');
		}

		// Problem 17: Anzahl Buchstaben 1..1000 (britisches Englisch)
		static int SolveProblem17()
		{
			int sum = 0;
			for (int i = 1; i <= 1000; i++)
				sum += WortlaengeEnglisch(i);
			return sum;
		}

		static int WortlaengeEnglisch(int n)
		{
			// ohne Leerzeichen und Bindestriche
			if (n == 1000) return "onethousand".Length;
			int length = 0;
			int hundreds = n / 100;
			int rest = n % 100;
			if (hundreds > 0)
			{
				length += new[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }[hundreds].Length;
				length += "hundred".Length;
				if (rest != 0) length += "and".Length;
			}
			if (rest >= 20)
			{
				int tens = rest / 10;
				length += new[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" }[tens].Length;
				int ones = rest % 10;
				length += new[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }[ones].Length;
			}
			else if (rest >= 10)
			{
				string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
				length += teens[rest - 10].Length;
			}
			else
			{
				length += new[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }[rest].Length;
			}
			return length;
		}

		// Problem 18: Maximale Pfadsumme I
		static int SolveProblem18()
		{
			int[][] triangle = new int[][]
			{
				new[]{75},
				new[]{95,64},
				new[]{17,47,82},
				new[]{18,35,87,10},
				new[]{20,04,82,47,65},
				new[]{19,01,23,75,03,34},
				new[]{88,02,77,73,07,63,67},
				new[]{99,65,04,28,06,16,70,92},
				new[]{41,41,26,56,83,40,80,70,33},
				new[]{41,48,72,33,47,32,37,16,94,29},
				new[]{53,71,44,65,25,43,91,52,97,51,14},
				new[]{70,11,33,28,77,73,17,78,39,68,17,57},
				new[]{91,71,52,38,17,14,91,43,58,50,27,29,48},
				new[]{63,66,04,68,89,53,67,30,73,16,69,87,40,31},
				new[]{04,62,98,27,23,09,70,98,73,93,38,53,60,04,23}
			};

			// Bottom-up DP
			int[] dp = (int[])triangle[^1].Clone();
			for (int r = triangle.Length - 2; r >= 0; r--)
			{
				int[] next = new int[triangle[r].Length];
				for (int c = 0; c < triangle[r].Length; c++)
				{
					next[c] = triangle[r][c] + Math.Max(dp[c], dp[c + 1]);
				}
				dp = next;
			}
			return dp[0];
		}

		// Problem 19: Anzahl Sonntage am Ersten des Monats (1901-2000)
		static int SolveProblem19()
		{
			int anzahlSonntage = 0;

			// Schleife durch alle Jahre von 1901 bis 2000
			for (int jahr = 1901; jahr <= 2000; jahr++)
			{
				// Schleife durch alle Monate (1-12)
				for (int monat = 1; monat <= 12; monat++)
				{
					DateTime ersterDesMonats = new DateTime(jahr, monat, 1);

					// Prüfe, ob der erste Tag des Monats ein Sonntag ist
					if (ersterDesMonats.DayOfWeek == DayOfWeek.Sunday)
						anzahlSonntage++;
				}
			}

			return anzahlSonntage;
		}

		// Problem 20: Quersumme von 100!
		static int SolveProblem20()
		{
			// Berechne 100! (Fakultät)
			BigInteger fakultaet = BigInteger.One;

			for (int i = 1; i <= 100; i++)
			{
				fakultaet *= i;
			}

			// Berechne die Quersumme aller Ziffern
			return fakultaet.ToString().Sum(ziffer => ziffer - '0');
		}
			// Problem 21: Befreundete Zahlen (Amicable Numbers)
		static int SolveProblem21()
		{
			int summe = 0;
			
			for (int a = 2; a < 10000; a++)
			{
				int b = SummeEchterTeiler(a);
				
				// Prüfe ob b != a und ob d(b) = a (befreundetes Paar)
				if (b != a && b < 10000 && SummeEchterTeiler(b) == a)
				{
					summe += a;
				}
			}
			
			// Division durch 2, da jedes Paar doppelt gezählt wird
			return summe / 2;
		}

		static int SummeEchterTeiler(int n)
		{
			if (n <= 1) return 0;
			
			int summe = 1; // 1 ist immer ein Teiler
			int wurzel = (int)Math.Sqrt(n);
			
			for (int i = 2; i <= wurzel; i++)
			{
				if (n % i == 0)
				{
					summe += i;
					// Füge auch den komplementären Teiler hinzu
					if (i != n / i && n / i != n)
						summe += n / i;
				}
			}
			
			return summe;
		}

		// Problem 22: Namen-Scores
		static long SolveProblem22()
		{
			// Namen aus der Datei (oder direkt im Code für Demo)
			string[] namen;
			
			// Versuche die Datei zu lesen, falls vorhanden
			string dateipfad = "p022_names.txt";
			if (File.Exists(dateipfad))
			{
				string inhalt = File.ReadAllText(dateipfad);
				// Entferne Anführungszeichen und teile bei Kommas
				namen = inhalt.Replace("\"", "").Split(',');
			}
			else
			{
				// Fallback: Beispieldaten
				Console.WriteLine("Warnung: names.txt nicht gefunden. Verwend Beispieldaten.");
				namen = new[] { "MARY", "PATRICIA", "LINDA", "BARBARA", "ELIZABETH" };
			}
			
			// Sortiere alphabetisch
			Array.Sort(namen);
			
			long gesamtsumme = 0;
			
			for (int i = 0; i < namen.Length; i++)
			{
				int alphabetischePosition = i + 1;
				int namenswert = BerechneNamenswert(namen[i]);
				gesamtsumme += alphabetischePosition * namenswert;
			}
			
			return gesamtsumme;
		}

		static int BerechneNamenswert(string name)
		{
			int summe = 0;
			foreach (char buchstabe in name.ToUpper())
			{
				if (buchstabe >= 'A' && buchstabe <= 'Z')
				{
					summe += buchstabe - 'A' + 1;
				}
			}
			return summe;
		}


        // Problem 23: Nicht-abundante Summen
        static int SolveProblem23()
        {
            const int grenze = 28123;

            // Finde alle abundanten Zahlen bis zur Grenze
            List<int> abundanteZahlen = new List<int>();
            for (int n = 1; n <= grenze; n++)
            {
                if (IstAbundant(n))
                    abundanteZahlen.Add(n);
            }

            // Markiere alle Zahlen, die als Summe zweier abundanter Zahlen dargestellt werden können
            bool[] kannAlsSummeDargestelltWerden = new bool[grenze + 1];

            for (int i = 0; i < abundanteZahlen.Count; i++)
            {
                for (int j = i; j < abundanteZahlen.Count; j++)
                {
                    int summe = abundanteZahlen[i] + abundanteZahlen[j];
                    if (summe <= grenze)
                        kannAlsSummeDargestelltWerden[summe] = true;
                    else
                        break; // Alle weiteren Summen wären zu groß
                }
            }

            // Summiere alle Zahlen, die NICHT als Summe dargestellt werden können
            int gesamtsumme = 0;
            for (int n = 1; n <= grenze; n++)
            {
                if (!kannAlsSummeDargestelltWerden[n])
                    gesamtsumme += n;
            }

            return gesamtsumme;
        }

        static bool IstAbundant(int n)
        {
            return SummeEchterTeiler(n) > n;
        }

        // Problem 24: Lexikographische Permutationen
        static string SolveProblem24()
        {
            // Finde die millionste Permutation von 0-9
            char[] ziffern = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int zielPosition = 1_000_000 - 1; // 0-basiert

            // Verwende Faktorial-Zahlen-System
            int[] fakultaeten = new int[10];
            fakultaeten[0] = 1;
            for (int i = 1; i < 10; i++)
                fakultaeten[i] = fakultaeten[i - 1] * i;

            List<char> verfuegbar = new List<char>(ziffern);
            string ergebnis = "";

            for (int stelle = 9; stelle >= 0; stelle--)
            {
                int index = zielPosition / fakultaeten[stelle];
                ergebnis += verfuegbar[index];
                verfuegbar.RemoveAt(index);
                zielPosition %= fakultaeten[stelle];
            }

            return ergebnis;
        }

        // Problem 25: 1000-stellige Fibonacci-Zahl
        static int SolveProblem25()
        {
            BigInteger vorige = BigInteger.One;
            BigInteger aktuelle = BigInteger.One;
            int index = 2;

            while (aktuelle.ToString().Length < 1000)
            {
                BigInteger naechste = vorige + aktuelle;
                vorige = aktuelle;
                aktuelle = naechste;
                index++;
            }

            return index;
        }



    }
}