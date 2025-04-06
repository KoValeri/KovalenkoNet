namespace WordGame
{
    class Game
    {
        private char[] symbolsOfBaseWord;
        private string usedWords;
        private bool player1Turn;


        //Метод для начали игры
        public void Start()
        {
            string baseWord = GetBaseWord();
            symbolsOfBaseWord = baseWord.ToCharArray();
            usedWords = "";
            player1Turn = true;

            while (playerProcess()) { }
        }

        //Метод для игрового процесса
        private bool playerProcess()
        {
            Console.WriteLine(player1Turn ? Strings.Player1Turn : Strings.Player2Turn);
            string inputWord = Console.ReadLine().ToLower();

            if (String.IsNullOrEmpty(inputWord))
            {
                Console.WriteLine(player1Turn ? Strings.Player1Lost : Strings.Player2Lost);
                return false;
            }

            if (usedWords.Split(' ').Contains(inputWord))
            {
                Console.WriteLine(Strings.WordAlreadyUsed);
                return true;
            }

            if (!CanFormWord(inputWord, symbolsOfBaseWord))
            {
                Console.WriteLine(Strings.InvalidWord);
                return true;
            }

            usedWords += inputWord + " "; // Добавляем пробел для разделения слов
            player1Turn = !player1Turn;
            return true;
        }

        //Метод для получения базового слова
        private string GetBaseWord()
        {
            const int minWordLength = 8, maxWordLength = 30;

            Console.WriteLine(Strings.EnterBaseWord);
            string word = Console.ReadLine().ToLower();

            while (word.Length < minWordLength || word.Length > maxWordLength)
            {
                Console.WriteLine(Strings.InvalidLength);
                word = Console.ReadLine().ToLower();
            }
            return word;
        }

        //Метод для проверки на формирование слова
        private bool CanFormWord(string word, char[] availableSymbols)
        {
            char[] cloneAvaliableSymb = (char[])availableSymbols.Clone();
            bool allLettersFound = true;

            foreach (char symbol in word)
            {

                bool letterFound = false;

                for (int i = 0; i < cloneAvaliableSymb.Length; i++)
                {
                    if (cloneAvaliableSymb[i] == symbol)
                    {
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
