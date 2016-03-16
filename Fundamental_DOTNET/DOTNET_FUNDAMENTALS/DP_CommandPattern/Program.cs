using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_CommandPattern
{
    /*
     * The Command Pattern falls under the category of Behavioural Design Patterns.
     * The Command Pattern encapsulates a request as an object and gives it a known public interface.
     * A request or action is mapped and stored as an object. 
     * The Invoker will be ultimately responsible for processing the request. This clearly decouples the request from the invoker. 
     * This is more suited for scenarios where we implement Redo, Copy, Paste and Undo operations where the action is stored as an object
     */
    //Interface (Command)
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }

    //Concrete Command
    public class StartCommand : ICommand
    {
        public string Name
        {
            get { return "Start"; }
        }

        public void Execute()
        {
            Console.WriteLine("I am executing StartCommand !");
        }
    }

    //Concrete Command
    public class StopCommand : ICommand
    {

        public string Name
        {
            get { return "Stop"; }
        }

        public void Execute()
        {
            Console.WriteLine("I am executing StopCommand !");
        }
    }

    //Invoker
    public class Invoker
    {
        ICommand cmd = null;

        public ICommand GetCommand(string action)
        {
            switch (action)
            {
                case "Start":
                    cmd = new StartCommand();
                    break;
                case "Stop":
                    cmd = new StopCommand();
                    break;
                default:
                    break;
            }
            return cmd;
        }
    }

    //Client or Receiver
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Command Pattern Demo---");
            Invoker invoker = new Invoker();

            //Execute Start Command
            // * The Command Pattern encapsulates a request as an object and gives it a known public interface.
            // * A request or action is mapped and stored as an object. 
            // * The Invoker will be ultimately responsible for processing the request. This clearly decouples the request from the invoker. 
            // * This is more suited for scenarios where we implement Redo, Copy, Paste and Undo operations where the action is stored as an object
            ICommand command = invoker.GetCommand("Start");
            command.Execute();

            //Execute Stop Command
            command = invoker.GetCommand("Stop");
            command.Execute();

            Console.ReadLine();
        }
    }
}
