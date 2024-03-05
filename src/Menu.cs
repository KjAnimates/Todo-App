using System;
using static System.Console;

namespace TodoApp
{
    public class Menu
    {
        // The list of options that will be displayed.
        public List<string> Options = new();
        public string? Prompt;
        public string SelectedText { get; }

        private int SelectedIndex = 0;

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

        /// <summary>
        /// Clears the screen and displays the options
        /// that can be selected.
        /// </summary>
        public int Start()
        {
            bool running = true;
            SelectedIndex = 0;

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
                        PrintOption(option, selected: true);
                        SelectedText = option;
                    }
                    else PrintOption(option, selected: false);
                }

                // Read the key that was pressed.
                ConsoleKey keyPressed = ReadKey(true).Key;

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        if(SelectedIndex > 0) --SelectedIndex;
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedIndex <= Options.Count) ++SelectedIndex;
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

        private void PrintOption(string option, bool selected)
        {
            if (selected)
            {
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" > {0}", option);
                ResetColor();
            }
            else Console.WriteLine("   {0}", option);
        }
    }
}