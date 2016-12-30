using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud.TIY.Hangman {

	public class HangmanPuzzles {

		const string hangmanPuzzlesFile = "HangmanPuzzles.txt";
		static Random rnd = new Random(DateTime.Now.GetHashCode());

		public static string GetRandomPuzzle() {
#if DEBUG
			var puzzles = System.IO.File.ReadAllLines(@"..\..\" + hangmanPuzzlesFile);
#else
			var puzzles = System.IO.File.ReadAllLines(hangmanPuzzlesFile);
#endif
			var nbrPuzzles = puzzles.Length;
			return puzzles.ElementAt(rnd.Next(nbrPuzzles)).ToUpper();
		}

		public static string GetSpecificPuzzle(int pos) {
#if DEBUG
			var puzzles = System.IO.File.ReadAllLines(@"..\..\" + hangmanPuzzlesFile);
#else
			var puzzles = System.IO.File.ReadAllLines(hangmanPuzzlesFile);
#endif
			return puzzles.ElementAt(pos).ToUpper();
		}
	}
}
