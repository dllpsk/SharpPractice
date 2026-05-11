namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Contains
            string word = "Hello";
            Console.WriteLine(word.Contains("ll"));

            if (word.Contains("lo")) Console.WriteLine("Success");
            else Console.WriteLine("Fail");

            char[] example = { 'a', '.', '0'};
            Console.WriteLine(example.Contains(','));

            char[] punc = {'.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            char x = ';';
            if (punc.Contains(x)) Console.WriteLine("The symbol is punc");
            else Console.WriteLine("It's not punc");

            Console.WriteLine();

            //Replace
            string text = "Cat catastrophe dog dog dogs love";
            text = text.Replace("cat", "more cats");
            Console.WriteLine(text);

            string t = "door floor";
            Console.WriteLine(t.Replace("floor", "ceiling"));

            Console.WriteLine();

            //Trim
            string word2 = "!?cat,";
            Console.WriteLine(word2);
            word2 = word2.Trim(punc);
            Console.WriteLine(word2);

            string w2 = " .,word!;";
            Console.WriteLine(w2);
            w2 = w2.Trim(new char[] { ' ', ',', '.', ';' });
            Console.WriteLine(w2);

            Console.WriteLine();

            //Split
            string text2 = "Hello, my dear 2 friends!";
            string[] dirtyWords = text2.Split(punc, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < dirtyWords.Length; i++)
            {
                Console.WriteLine(dirtyWords[i]);
            }

            Console.WriteLine();

            //Join
            string text3 = String.Join(" ", dirtyWords);
            Console.WriteLine(text3);

            Console.WriteLine();

            // IsDigit/IsLetter
            char s = 'a';
            Console.WriteLine(Char.IsDigit(s));
            Console.WriteLine(Char.IsLetter(s));
            Console.WriteLine(Char.IsPunctuation(s));
            Console.WriteLine(Char.IsLower(s));
            Console.WriteLine(Char.IsUpper(s));

            Console.WriteLine();

            // ToUpper/ToLower
            string word3 = "Hello";
            Console.WriteLine(word3.ToLower());
            Console.WriteLine(word3.ToUpper());
            Console.WriteLine();

            string vowels = "уеыаояиюэё";
            vowels += vowels.ToUpper();
            Console.WriteLine(vowels);


            Console.WriteLine();
            string input = "Hello, my dear 2 friends!";
            int count = 0;
            string[] dWords = input.Split(' ');
            string[] cleanWords = new string[0];
            for (int i = 0; i < dWords.Length; i++)
            {
                string trimWord = dWords[i].Trim(punc);
                Console.WriteLine(trimWord);

                bool f = true;
                foreach (char symbol in trimWord)
                {
                    if (char.IsDigit(symbol) || punc.Contains(symbol)) f = false;
                }

                if (f && trimWord != "")
                {
                    count++;
                    Array.Resize(ref cleanWords, cleanWords.Length + 1);
                    cleanWords[cleanWords.Length - 1] = trimWord.ToLower();
                }
            }
            Console.WriteLine();
            Console.WriteLine(count);
            foreach (var cw in cleanWords) Console.Write($"{cw} ");
        }
    }
}

