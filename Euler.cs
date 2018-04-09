using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	class Euler 
	{
		public Euler() {
			int n = 50;
			Console.WriteLine("The sum of the digits in 100! is: " + FactorialDigitSum(100));
			Console.WriteLine("The product abc of the pythagorean triplet with sum 1000 is: " + PythagoreanTriplet());
			Console.WriteLine("Between 1 and " + n + ", the amount of wins for player 1 are: " + PaperStrip(n));
			Console.WriteLine("UnitOrderIn: " + (UnitOrderIn)3);
		}

		private long FactorialDigitSum(int factorial) {
			long sum = 0;
			System.Numerics.BigInteger total = 1;
			
			for(int i = 2; i <= factorial; i++) {
				total *= i;
			}
			string numeral = "" + total;

			for (int i = 0; i < numeral.Length; i++) {
				int num = 0;
				int.TryParse(numeral.Substring(i, 1), out num);
				sum += num;
			}
			return sum;
		}

		private int PythagoreanTriplet() {
			int a = 1;
			int b = 2;
			int c = 997;
			bool done = false;

			while(!done) {
				b--;
				c++;
				if(Pythagorean(a, b, c)) {
					done = true;
				}
				if(b < a)
				{
					a++;
					b = 1000 - a;
					c = 1000 - (b + a);
				}
			}
			return a*b*c;
		}

		private bool Pythagorean(int a, int b, int c) {
			//Console.WriteLine(a + "**2 + " + b + "**2 = " + c + "**2");
			return a * a + b * b == c * c;
		}

		private int PaperStrip(int n) {
			int wins = 3;

			List<bool> winTable = new List<bool>();
			winTable.Add(false);
			winTable.Add(false);
			winTable.Add(true);
			winTable.Add(true);
			winTable.Add(true);
			winTable.Add(false);
			for (int i = 6; i <= n; i++) {			
				if((winTable[i - 4] && winTable[i - 5])  || (winTable[i - 5] && winTable[i - 6])) {
					winTable.Add(true);
					wins++;
				} else {
					winTable.Add(false);
				}
			}
			return wins;
		}

		public enum UnitOrderIn
		{
			Undefined = 0,
			Each = 1,
			Kg = 2,
			Metre = 3
		}
	}
}
