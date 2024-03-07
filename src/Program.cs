using System;
using static System.Console;

namespace TodoApp;

public class Program
{
    public static List<Task> Tasks = new();

    public static int ListTasks ()
    {
        // for (int i = 0; i < Tasks.Count; i++)
        // {
        //     Task task = Tasks[i];
        //     int listIndex = i + 1;
        //     string? taskName = task.TaskName;

        //     ForegroundColor = ConsoleColor.Blue;
        //     Write("  [{0}] ", listIndex);

        //     ForegroundColor = ConsoleColor.Yellow;
        //     WriteLine("{0}", taskName);

        //     ResetColor();
        // }

        List<string> tasks = Task.GetNames(Tasks);

        Menu menu = new()
        {
            Options = tasks,
            Prompt = "Your Tasks:"
        };

        return menu.Display();
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

    public static void CreateNewTask()
    {
        Clear();

        WriteLine("NEW TASK");
        Write("Name: ");

        string? name = ReadLine();
        
        if (!String.IsNullOrWhiteSpace(name))
            AddTask(new Task(name));
        else
            CreateNewTask();
    }

    public static void RemoveTask(int index)
    {
        List<Task> result = new();

        for(int i = 0; i < Tasks.Count; i++)
        {
            if (i == index && i != 0) continue;
            result.Add(Tasks[i]);
        }

        Tasks = result;
    }

    public static void Main(String[] Args)
    {
        Clear();

        Tasks.Add(new Task("[ NEW ]"));
        CreateNewTask();

        while(true)
        {
            Clear();
            
            WriteLine("Console Todo App");
            WriteLine("Your Tasks:");
    
            int selection = ListTasks();
            bool selectionIsValid = (selection >= 0) && (selection < Tasks.Count);

            if (selectionIsValid == false)
                throw new IndexOutOfRangeException("Selection is out of range of the task list.");

            Task task = Tasks[selection];

            if (selection == 0) CreateNewTask();
            else
            {
                Clear();

                // Show the options for the selected task.
                TaskOperation taskOperation = task.DisplayOptions();

                switch(taskOperation)
                {
                    case TaskOperation.DELETE:
                        RemoveTask(selection);
                        break;
                    case TaskOperation.MODIFY:
                        Clear();
                        WriteLine("Sorry, Can't do that just yet :)");
                        break;
                }
            }            
        }
    }
}