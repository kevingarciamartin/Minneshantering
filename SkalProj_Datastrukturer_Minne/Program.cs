using System;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /* FRÅGOR
         * 
         * 1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
         * 
         * Stacken är en mängd staplade skolådor där vi använder innehållet i den översta lådan. För att komma åt den undre måste 
         * den ovanstående flyttas bort. Stacken är självunderhållande och behöver inget hjälp med minnet.
         * Heapen är en oorganiseras hög av ren tvätt. Allt finns tillgängligt hela tiden, men tappar du bort vad du letar efter
         * finns det inga garantier på att du hittar det igen. Heapen behöver oroa sig för Garbage Collection.
         * 
         * 
         * 
         * 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
         * 
         * Value Types är typer från System.ValueType. 
         * Reference Types är typer som ärver från System.Object
         * Value Types kan lagras både på stacken och heapen, medan Reference Types alltid lagras på heapen.
         * 
         * 
         * 
         * 3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
         * 
         * Den första metoden använder sig av Value Types (int) där värdet för x inte överskrids när man byter värdet för y.
         * Den andra metoden använder sig av Reference Types (objektet MyInt). x och y pekar på samma objekt, vilket resulterar i att
         * x ändrar värde när man uppdaterar y.
         */

        /// <summary>
        /// The main method, will handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                WriteLine("Please navigate through the menu by inputing the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Calculate the n:th even integer with recursion"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                    Console.WriteLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParenthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        CallRecursiveEven();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static void CallRecursiveEven()
        {
            WriteLine("Please input an integer");

            string input = GetInput();

            try
            {
                int integer = int.Parse(input);

                Console.Write($"RecursiveEven({integer}) = ");
                WriteLine(RecursiveEven(integer));
            }
            catch (Exception ex) { WriteLine(ex.Message); }
        }

        private static int RecursiveEven(int n)
        {
            if (n == 2)
                return 2;

            return (RecursiveEven(n - 1) + 2);
        }

        private static void WriteLine<T>(T message)
        {
            Console.WriteLine($"{message}");
            Console.WriteLine();
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             */

            /* FRÅGOR
             * 
             * 1.2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
             * 
             * Den ökar när listan har nått sin maxkapacitet och man försöker addera ett till element.
             * 
             * 
             * 
             * 1.3. Med hur mycket ökar kapaciteten?
             * 
             * Den ökar med 4.
             * 
             * 
             * 
             * 1.4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
             * 
             * Möjligtvis för att inte behöva öka kapaciteten varje gång man vill addera ett element.
             * 
             * 
             * 
             * 1.5. Minskar kapaciteten när element tas bort ur listan?
             * 
             * Nej, den minskar inte.
             * 
             * 
             * 
             * 1.6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
             * 
             * När man vill ha en maxkapacitet som inte kan överskridas.
             */

            List<string> theList = new();
            char selectedAction;
            const char exitAction = 'm';

            do
            {
                WriteLine("Please navigate through the menu by inputing the character \n(+, -) of your choice"
                    + "\n+. Add the rest of the input to the list"
                    + "\n-. Remove the rest of the input from the list"
                    + "\nm. Return to the main menu");

                string input = GetInput();

                selectedAction = input[0];
                string value = input.Substring(1);

                switch (selectedAction)
                {
                    case '+':
                        theList.Add(value);
                        PrintIEnumerable(theList);
                        break;
                    case '-':
                        theList.Remove(value);
                        PrintIEnumerable(theList);
                        break;
                    case exitAction:
                        break;
                    default:
                        WriteLine("Please enter some valid input (+, -, M)");
                        break;
                }

            } while (selectedAction != exitAction);

        }

        private static string GetInput()
        {
            string input = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            return input;
        }

        private static void PrintIEnumerable<T>(IEnumerable<T> enumerable)
        {
            if (enumerable is List<T>)
                Console.WriteLine("The List:");
            else if (enumerable is Queue<T>)
                Console.WriteLine("The Queue:");

            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new();
            char selectedAction;
            const char exitAction = 'm';

            do {
                WriteLine("Please navigate through the menu by inputing the character \n(+, -) of your choice"
                        + "\n+. Enqueue rest of the input"
                        + "\n-. Dequeue first item in queue"
                        + "\nm. Return to the main menu");

                string input = GetInput();

                selectedAction = input[0];
                string value = input.Substring(1);

                switch (selectedAction)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        PrintIEnumerable(theQueue);
                        break;
                    case '-':
                        try
                        {
                            theQueue.Dequeue();
                            PrintIEnumerable(theQueue);
                        }
                        catch (Exception)
                        {
                            WriteLine("The queue is empty");
                        }
                        break;
                    case exitAction:
                        break;
                    default:
                        WriteLine("Please enter some valid input (+, -, M)");
                        break;
                }

            } while (selectedAction != exitAction);

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            /* FRÅGOR
             * 
             * 3.1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. 
             * Varför är det inte så smart att använda en stack i det här fallet?
             * 
             * Eftersom att en stack implementerar FILO-principen kommer den första kunden aldrig expideras 
             * så länge det kommer nya kunder.
             */

            WriteLine("Please enter a string that you would like to see reversed");

            string input = GetInput();

            ReverseText(input);
        }

        private static void ReverseText(string input)
        {
            Stack<char> theStack = new();

            char[] inputCharArray = input.ToCharArray();

            foreach (var inputChar in inputCharArray)
            {
                theStack.Push(inputChar);
            }

            foreach (var item in theStack)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void CheckParenthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<char> openedParentheses = new();

            WriteLine("Please enter a string inluding some of the following characters: (, ), [, ], {, }");

            string input = GetInput();

            char[] inputCharArray = input.ToCharArray();

            foreach (var inputChar in inputCharArray)
            {
                if (IsOpeningParenthesis(inputChar))
                    openedParentheses.Push(inputChar);

                if (IsCloseningParenthesis(inputChar))
                {
                    if (IsMatchingParenthesis(openedParentheses.Peek(), inputChar))
                        openedParentheses.Pop();
                    else
                        break;
                }
            }

            if (openedParentheses.Count == 0)
                WriteLine("Your string is CORRECT");
            else
                WriteLine("Your string is INCORRECT");
        }

        private static bool IsOpeningParenthesis(char inputChar)
        {
            char[] openingParentheses = ['(', '[', '{'];
            
            return openingParentheses.Contains(inputChar);
        }
        
        private static bool IsCloseningParenthesis(char inputChar)
        {
            char[] closeningParentheses = [')', ']', '}'];
            
            return closeningParentheses.Contains(inputChar);
        }
        
        private static bool IsMatchingParenthesis(char openParenthesis, char closedParenthesis)
        {
            Dictionary<char, char> validParenthesisPairs = new()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            bool isValidPair = validParenthesisPairs[openParenthesis] == closedParenthesis;

            return isValidPair;
        }
    }
}

