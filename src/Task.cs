using System;

namespace TodoApp
{
    public class Task
    {
        public string? TaskName;
        public string? Description;
        public int Index;

        public Task()
        {
            this.TaskName = "???";
            this.Description = "No Description.";
            this.Index = 0;
        }

        public Task(string taskName)
        {
            this.TaskName = taskName;
            this.Description = "No Description.";
            this.Index = 0;
        }

        public Task(string taskName, string description) : this(taskName)
        {
            this.Description = description;
        }

        /// <summary>
        /// Displays the options for this task such as
        /// <br>
        /// a
        /// </summary>
        /// <returns>The index that was selected.</returns>
        public TaskOperation DisplayOptions()
        {
            Menu menu = new()
            {
                ShowNumbers = false,
                Options = new List<string>()
            };

            menu.Options.Add("Delete");
            menu.Options.Add("Edit");

            menu.Display();

            return menu.SelectedText switch
            {
                "Delete" => TaskOperation.DELETE,
                "Edit" => TaskOperation.MODIFY,
                _ => TaskOperation.NONE
            };
        }

        /// <summary>
        /// Gets the names of each task
        /// </summary>
        /// <returns>The list of names of a list of tasks./returns>
        public static List<string> GetNames(List<Task> tasks)
        {
            List<string> result = new();

            foreach(Task task in tasks)
            {
                if (task.TaskName != null)
                    result.Add(task.TaskName);
            }

            return result;
        }
    }
}