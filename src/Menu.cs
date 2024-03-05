using System;
using static System.Console;

namespace TodoApp
{
    public class Menu
    {
        // The list of options that will be displayed.
        public List<string> Options = new();
        public string? Prompt;

        public int SelectedIndex = 0;
        public string SelectedText = "";

        public Menu() { }

        public Menu(List<string> options)
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
        public void Start()
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
                        SelectedIndex = -1;
                        break;
                    case ConsoleKey.Enter:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
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