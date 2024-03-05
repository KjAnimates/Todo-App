using System;
using System.Diagnostics.CodeAnalysis;
using static System.Console;

namespace TodoApp
{
    public class MenuOption
    {
        public string Text;

        public MenuOption()
        {
            Text = "NULL";
        }

        public MenuOption(string text)
        {
            Text = text;
        }
    }
}