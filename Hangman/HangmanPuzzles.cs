using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud.TIY.Hangman {

	public class HangmanPuzzles {

		const string hangmanPuzzlesFile = "HangmanPuzzles.txt";
		static IEnumerable<string> puzzles = null;
		static Random rnd = new Random(DateTime.Now.GetHashCode());

		public static string GetRandomPuzzle() {
			var nbrPuzzles = puzzles.Count();
			return puzzles.ElementAt(rnd.Next(nbrPuzzles)).ToUpper();
		}

		public static string GetSpecificPuzzle(int pos) {
			return puzzles.ElementAt(pos).ToUpper();
		}

		static HangmanPuzzles() {
#if DEBUG
			puzzles = System.IO.File.ReadAllLines(@"..\..\" + hangmanPuzzlesFile);
#else
			puzzles = System.IO.File.ReadAllLines(hangmanPuzzlesFile);
#endif
		}
	}
}
