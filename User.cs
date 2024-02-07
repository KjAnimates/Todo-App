
namespace TodoApp
{
    public class User
    {
        string Name { get; set; }

        public User () 
        {
            this.Name = "";
        }

        public User (string name)
        {
            this.Name = name;
        }
    }
}