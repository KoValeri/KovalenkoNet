using System;

namespace WordGame 
{
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите слово длинной от 8 до 30 символов:");
        string baseWord = Console.ReadLine().ToLower();

        while (baseWord.Length < 8 || baseWord.Length > 30)
        {
            Console.WriteLine("Неверный длина слова. Введите другое:");
            baseWord = Console.ReadLine().ToLower();
        }

        char[] symbolsOfBaseWord = baseWord.ToCharArray();
        string usedWords = "";
        bool player1Turn = true;

        while (true)
        {
            Console.WriteLine(player1Turn ? "Ход 1 игрока" : "Ход 2 игрока");
            string inputWord = Console.ReadLine().ToLower();

            if (String.IsNullOrEmpty(inputWord)) {
                Console.WriteLine(player1Turn ? "1 игрок не ввёл слово, он проиграл" : "2 игрок не ввёл слово, он проиграл");
                break;
            }

            if (usedWords.Contains(inputWord))
            {
                Console.WriteLine("Это слово уже использовалось. Введите другое слово:");
                continue;
            }

            if (!CanFormWord(inputWord, symbolsOfBaseWord)) {
                Console.WriteLine("Введено неверное слово: такой буквы нет или она уже использована. Введите другое слово:");
                continue;
            }

            usedWords += inputWord;
            player1Turn = !player1Turn;

        }

        static bool CanFormWord(string word, char[] availableSymbols)
        {
            char[] cloneAvaliableSymb = (char[])availableSymbols.Clone();
            bool allLettersFound = true;

            foreach (char symbol in word) {

                bool letterFound = false;

                for (int i = 0; i < cloneAvaliableSymb.Length; i++)
                {
                    if (cloneAvaliableSymb[i] == symbol) {
                        cloneAvaliableSymb[i] = ' ';
                        letterFound = true;
                        break;
                    }
                }
                if (!letterFound)
                {
                    allLettersFound = false;
                    break;
                }
            }

            return allLettersFound;

        }


    }
}

}
