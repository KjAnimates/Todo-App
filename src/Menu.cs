using System;
using static System.Console;

namespace TodoApp
{
    public class Menu
    {
        // The list of options that will be displayed.
        public List<string> Options = new();
        public string? Prompt;
        public string SelectedText;
        public bool ShowNumbers = true;
        public int SelectedIndex = 0;

        public Menu() 
        {
            SelectedIndex = 0;
            SelectedText = "";
        }

        public Menu(List<string> options) : this()
        {
            this.Options = options;
        }

        public Menu(List<string> options, string prompt) : this(options)
        {
            this.Prompt = prompt;
        }

        private int _Start(int startingIndex)
        {
            bool running = true;
            SelectedIndex = startingIndex;

            while(running)
            {
                Clear();

                // If we can use the prompt, then use it.
                if (Prompt != null) WriteLine(Prompt);

                for(int i = 0; i < Options.Count; i++)
                {
                    string option = Options[i];
                    
                    if(i == SelectedIndex)
                    {
                        PrintOption(option, selected: true, number: i);
                        SelectedText = option;
                    }
                    else PrintOption(option, selected: false, number: i);
                }

                // Read the key that was pressed.
                ConsoleKey keyPressed = ReadKey(true).Key;

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        if(SelectedIndex > 0) --SelectedIndex;
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedIndex < Options.Count - 1) ++SelectedIndex;
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        SelectedIndex = -1; // So nothing gets selected because we escaped
                        break;
                    case ConsoleKey.Enter:
                        running = false;
                        break;
                    default:
                        break;
                }
            }

            return SelectedIndex;
        }

        private void PrintOption(string option, bool selected, int number)
        {
            if (selected)
            {
                ForegroundColor = ConsoleColor.Blue;

                if (ShowNumbers)
                {
                    Console.WriteLine($" > {number}. {option}");
                }
                else
                {
                    Console.WriteLine($" > {option}");
                }

                ResetColor();
            }
            else
            {
                ResetColor();

                if (ShowNumbers)
                {
                    Console.WriteLine($"   {number}. {option}");
                }
                else
                {
                    Console.WriteLine($"   {option}");
                }
            }
        }

        /// <summary>
        /// Clears the screen and displays the options
        /// that can be selected.
        /// </summary>
        /// <returns>The index that was selected.</returns>
        public int Display()
        {
            return _Start(startingIndex: 0);
        }

        public int Display(int startingIndex)
        {
            return _Start(startingIndex);
        }

    }
}