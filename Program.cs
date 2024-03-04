using System;
using static System.Console;

namespace TodoApp;

public class Program
{
    public static List<string> Tasks = new();

    public static void Main(String[] Args)
    {
        while(true)
        {
            // Clear the Console
            Clear();

            WriteLine("Console Todo App");
            WriteLine("Your Tasks:");

            // If the Task list's length is > 0,
            // Display the tasks.
            if(Tasks.Count > 0)
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    string Task = Tasks[i];
                    ForegroundColor = ConsoleColor.Blue;
                    Write($"  [{i + 1}] ");

                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine($"{Tasks[i]}");
                    ResetColor();
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                Write("  Woohoo! You're all done! :D");
                ResetColor();
                WriteLine();
            }

            Write(">> ");
            string? line = ReadLine();
            
            if (line != null)
            {
                if (line == "add")
                {
                    Write("Name: ");
                    string? newTask = ReadLine();

                    if (newTask != null)
                        Tasks.Add(newTask);
                }
                if(line == "rem")
                {
                    Write("#: ");
                    string? input = ReadLine();

                    _ = int.TryParse(input, out int num);

                    num--;

                    if (num >= 0 && num < Tasks.Count)
                    {
                        List<string> task_copy = new();
                        foreach(string task in Tasks)
                        {
                            if (task != Tasks[num]) task_copy.Add(task);
                        }

                        Tasks = task_copy;
                    }
                }
            }
        }
    }
}