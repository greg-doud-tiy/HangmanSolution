using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud.TIY.Hangman {

	public class Program {

		void PlayHangman() {
			Hangman hm = new Hangman();
			Display();
			Display(hm.DisplayWorkPuzzle());
			while (!hm.IsGameOver()) {
				var letter = AskForLetter();
				var puzzleDisplay = hm.LetterGuess(letter);
				Display();
				Display(puzzleDisplay);
			}
			Display((hm.IsWinner() ? "Winner!" : "Loser."));
			Display(hm.DisplayOrigPuzzle());
		}
		string AskForLetter() {
			Console.Write("Enter a letter: ");
			var letter = string.Empty;
			do {
				letter = Console.ReadLine();
			} while (letter.Length == 0);
			letter = letter.Substring(0, 1).ToUpper();
			return letter;
		}

		void Display(string message = " ") {
			Console.WriteLine(message);
			Debug.WriteLine(message);
		}

		void Pause() {
			Display("press any key ...");
			Console.ReadKey();
		}

		void Run() {
			var quit = false;
			do {
				PlayHangman();
				quit = AskToQuit();
			} while (!quit);
		}

		bool AskToQuit() {
			Display("Do you want to quit? y/N: ");
			return Console.ReadLine().ToUpper().StartsWith("Y");
		}
		
		public static void Main(string[] args) {
			new Program().Run();
		}


	}
}
