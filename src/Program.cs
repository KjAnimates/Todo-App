using System;
using static System.Console;

namespace TodoApp;

public class Program
{
    public static List<Task> Tasks = new();

    public static void ListTasks ()
    {
        for (int i = 0; i < Tasks.Count; i++)
        {
            Task task = Tasks[i];
            int listIndex = i + 1;
            string? taskName = task.TaskName;

            ForegroundColor = ConsoleColor.Blue;
            Write("  [{0}] ", listIndex);

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("{0}", taskName);

            ResetColor();
        }
    }

    public static void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public static string? Prompt(string prompt)
    {
        Write(prompt);
        return ReadLine();
    }

    public static void Main(String[] Args)
    {
        
        while(true)
        {
            // Clear the Console
            Clear();

            WriteLine("Console Todo App");
            WriteLine("Your Tasks:");

            // Checks if there are tasks in the list
            if(Tasks.Count > 0) ListTasks();
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
            string? line = Prompt("Action: ");
            
            if (line != null)
            {
                switch (line.ToUpper().Trim())
                {
                    // If the command is "add", create a new task.
                    case "ADD":
                        // Ask the user for the name of the new task.
                        string? taskName = Prompt("Name: ");

                        Task? newTask = new();

                        if (taskName != null) newTask.TaskName = taskName;
                        if (newTask != null) AddTask(newTask);
                        break;
                    // If the command is "rem", Remove a selected task.
                    case "REM":
                        // Ask the user for the number to remove.
                        string? input = Prompt("#: ");

                        // Parse the input to a number.
                        _ = int.TryParse(input, out int num);

                        // Subtract 1 from the number
                        // (To match the numbering on the list)
                        num--;

                        if (num >= 0 && num < Tasks.Count)
                        {
                            // Create a new tasks variable.
                            List<Task> newTasks = new();

                            foreach(Task task in Tasks)
                            {
                                // check if the current task matches the indexed task.
                                // If it does, don't add it to the new tasks list.
                                if (task.TaskName != Tasks[num].TaskName) newTasks.Add(task);
                            }

                            // Set the task list to the new tasks list.
                            Tasks = newTasks;
                        }
                        break;
                    case "LIST":
                        Clear();
                        
                        WriteLine("LIST:");
                        WriteLine("   add");
                        WriteLine("   rem");

                        ReadKey();
                        break;

                }
            }
        }
    }
}