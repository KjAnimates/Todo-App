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

            // Checks if there are tasks in the list
            if(Tasks.Count > 0)
            {
                // For every task, print it!
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
                // Tell the user they are all caught up.
                ForegroundColor = ConsoleColor.Green;
                Write("  Woohoo! You're all done! :D");
                ResetColor();
                WriteLine();
            }

            // Command line
            // current commands:
            //   * add
            //   * rem
            Write(">> ");
            string? line = ReadLine();
            
            if (line != null)
            {
                switch (line)
                {
                    // If the command is "add", create a new task.
                    case "add":
                        // Ask the user for the name of the new task.
                        Write("Name: ");
                        string? newTask = ReadLine();

                        // add the task to the list.
                        if (newTask != null)
                        {
                            Tasks.Add(newTask);
                        }
                        break;
                    // If the command is "rem", Remove a selected task.
                    case "rem":
                        // Ask the user for the number to remove.
                        Write("#: ");
                        string? input = ReadLine();

                        // Parse the input to a number.
                        _ = int.TryParse(input, out int num);

                        // Subtract 1 from the number
                        // (To match the numbering on the list)
                        num--;

                        if (num >= 0 && num < Tasks.Count)
                        {
                            // Create a new tasks variable.
                            List<string> newTasks = new();

                            foreach(string task in Tasks)
                            {
                                // check if the current task matches the indexed task.
                                // If it does, don't add it to the new tasks list.
                                if (task != Tasks[num]) newTasks.Add(task);
                            }

                            // Set the task list to the new tasks list.
                            Tasks = newTasks;
                        }
                        break;
                }
            }
        }
    }
}