using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        // Checking for word
        static bool IsWord(string hiddenWord, List<char> letterGuessed)
        {
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (!letterGuessed.Contains(hiddenWord[i]))
                {
                    return false;
                }
            }

            return true;
        }
        // main method 
        static void Main(string[] args)
        {
            // Display messages
            Console.WriteLine("Greetings Gamer!!!!");
            Console.WriteLine("Welcome to thee HANGMAN GAME!!!!where you either win or get hanged!!!!!");
            Console.WriteLine("The category of the word list is cars !!!To play follow the given rules!!!!!");
            bool playAgain = true;

            while (playAgain)
            {
                List<char> letterGuessed = new List<char>();
                int attempts = 6;
                int score = 0;
                string[] listWords = { "audi", "volvo", "toyota", "mercedes benz", "porsche", "bmw", "volkswagen", "range rover", "mazda", "lamborghini" };

                // generate random word from above list
                Random random = new Random();
                string hiddenWord = listWords[random.Next(0, listWords.Length)];
                StringBuilder showToPlayer = new StringBuilder(hiddenWord.Length);

                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (hiddenWord[i] == ' ')
                    {
                        showToPlayer.Append(' ');
                    }
                    else
                    {
                        showToPlayer.Append('_');
                    }
                }
                // While loop executes under the condition that the user still has attempts remaining
                while (attempts > 0)
                {
                    Console.WriteLine("Guess the missing letter or enter 'clue' for a hint: ");
                    string playerInput = Console.ReadLine().ToLower();

                    if (playerInput == "clue")
                    {
                        int randomIndex;
                        char randomLetter;

                        do
                        {
                            randomIndex = random.Next(hiddenWord.Length);
                            randomLetter = hiddenWord[randomIndex];
                        }
                      
                        while (letterGuessed.Contains(randomLetter));

                        letterGuessed.Add(randomLetter);
                        score++;
                        Console.WriteLine("Clue: The letter at position {0} is '{1}'", randomIndex + 1, randomLetter);
                        continue;
                    }
                    // If statements for the incorrect input from user
                    if (letterGuessed.Contains(playerInput[0]))
                    {
                        Console.WriteLine("You already guessed that letter. Try again.");
                        continue;
                    }
                    else if (playerInput.Length > 1 || string.IsNullOrWhiteSpace(playerInput))
                    {
                        Console.WriteLine("Please enter only one letter at a time.");
                        continue;
                    }

                    char letter = playerInput[0];
                    letterGuessed.Add(letter);

                    if (hiddenWord.Contains(letter))
                    {
                        for (int i = 0; i < hiddenWord.Length; i++)
                        {
                            if (hiddenWord[i] == letter)
                            {
                                showToPlayer[i] = letter;
                                score++;
                            }
                        }

                        Console.WriteLine(showToPlayer);

                        if (IsWord(hiddenWord, letterGuessed))
                        {
                            Console.WriteLine("CONGRATS!!!!! \n You win !!! \n You found the hidden word: " + hiddenWord);
                            Console.WriteLine("Your score: " + score);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT !!!!\nThat letter is not part of the word.");
                        attempts--;
                        Console.WriteLine("You have {0} attempts remaining.", attempts);
                        
                        // Condition for when the user's attempts are finished
                        if (attempts == 0)
                        {
                            Console.WriteLine("GAME OVER. \n You are gonna get hanged!!! \n The hidden word was: " + hiddenWord);
                            break;
                        }
                    }
                }

                // ask user if they want to play again, if "y" call the playAgain function
                Console.WriteLine("Do you want to continue playing again? (Y/N)");
                string continueplayingInput = Console.ReadLine().ToLower();
                playAgain = (continueplayingInput == "y");
            }
        }
    }
}




