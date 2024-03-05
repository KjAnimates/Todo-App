using System;

namespace TodoApp
{
    public class Task
    {
        public string? TaskName;
        public string? Description;

        public Task()
        {
            this.TaskName = "???";
            this.Description = "No Description.";
        }

        public Task(string taskName)
        {
            this.TaskName = taskName;
            this.Description = "No Description.";
        }

        public Task(string taskName, string description) : this(taskName)
        {
            this.Description = description;
        }
    }
}