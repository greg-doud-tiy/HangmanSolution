using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud.TIY.Hangman {

	class Program {

		void Run() {
			Hangman hm = new Hangman(9);
			Console.WriteLine();
			Console.WriteLine(hm.DisplayWorkPuzzle());
			while (!hm.IsGameOver()) {
				var letter = AskForLetter();
				var puzzleDisplay = hm.LetterGuess(letter);
				Console.WriteLine(puzzleDisplay);
			}
			Console.WriteLine((hm.IsWinner() ? "Winner!" : "Loser."));
			Console.WriteLine(hm.DisplayOrigPuzzle());
			Console.ReadKey();
		}
		string AskForLetter() {
			Console.Write("Enter a letter: ");
			var letter = Console.ReadLine().Substring(0, 1).ToUpper();
			return letter;
		}

		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
