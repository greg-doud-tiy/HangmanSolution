using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GregoryDoud.TIY.Hangman {

	public class Hangman {

		private const string UnknownLetter = "_";
		private const int defGuessesRemaining = 7;
		private string puzzlePhrase = string.Empty;
		private string workPuzzlePhrase = string.Empty;
		private int guessesRemaining = defGuessesRemaining;

		public bool IsGameOver() {
			return IsWinner() || IsLoser();
		}
		public bool IsWinner() {
			return !workPuzzlePhrase.Contains(UnknownLetter) && guessesRemaining > 0;
		}
		public bool IsLoser() {
			return workPuzzlePhrase.Contains(UnknownLetter) && guessesRemaining == 0;
		}
		public string LetterGuess(string ch) {
			ch = ch.ToUpper();
			if (!puzzlePhrase.Contains(ch)) { // ch is not in puzzle
				guessesRemaining--;
			} else {
				var pos = puzzlePhrase.IndexOf(ch);
				while (pos >= 0) {
					if (pos == 0) {
						workPuzzlePhrase = ch + workPuzzlePhrase.Substring(1);
					} else {
						workPuzzlePhrase = workPuzzlePhrase.Substring(0, pos) + ch + workPuzzlePhrase.Substring(pos + 1);
					}
					pos = puzzlePhrase.IndexOf(ch, pos+1);
				}
			}
			var dspPuzzle = string.Empty;
			foreach(char chr in workPuzzlePhrase.ToCharArray()) {
				dspPuzzle += string.Format("{0} ", chr);
			}
			return $"{dspPuzzle} - {guessesRemaining} guesses remaining";
		}

		public string DisplayOrigPuzzle() {
			return DisplayPuzzle(puzzlePhrase);
		}

		public string DisplayWorkPuzzle() {
			return DisplayPuzzle(workPuzzlePhrase);
		}

		private string DisplayPuzzle(string puzzle) { 
			var workPuzzleDisplay = string.Empty;
			for(var idx = 0; idx < puzzle.Length; idx++) {
				string ch = puzzle[idx].ToString();
				workPuzzleDisplay += string.Format("{0} ", ch);
			}
			return workPuzzleDisplay;
		}

		public void SetPuzzle(string puzzlePhrase) {
			this.puzzlePhrase = puzzlePhrase;
			SetWorkPuzzlePhrase();
		}

		public void SetGuessesRemaining(int guessesRemaining) {
			this.guessesRemaining = guessesRemaining;
		}

		private void SetWorkPuzzlePhrase() {
			for(var idx = 0; idx < puzzlePhrase.Length; idx++) {
				string ch = puzzlePhrase[idx].ToString();
				if (char.IsLetter(ch[0])) {
					workPuzzlePhrase += UnknownLetter;
				} else {
					workPuzzlePhrase += ch;
				}
			}
		}

		public Hangman() {
			SetPuzzle(HangmanPuzzles.GetRandomPuzzle());
		}

		public Hangman(int pos) {
			SetPuzzle(HangmanPuzzles.GetSpecificPuzzle(pos));
		}

		public Hangman(string puzzlePhrase) {
			SetPuzzle(puzzlePhrase);
		}
	}
}
