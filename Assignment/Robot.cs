// Change to 'using Assignment.InterfaceCommand' when you are ready to test your interface implementation
using Assignment.InterfaceCommand;

namespace Assignment;
public class Robot
{
    // These are properties, you can replace these with traditional getters/setters if you prefer.
    public int NumCommands { get; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    private const int DefaultCommands = 6;
    // An array is not the preferred data structure here.
    // You will get bonus marks if you replace the array with the preferred data structure
    // Hint: It is NOT a list either,
    private readonly IRobotCommand[] _commands;
    //private readonly Queue<IRobotCommand> _commands;
    private int _commandsLoaded = 0;

    public override string ToString()
    {
        return $"[{X} {Y} {IsPowered}]";
    }

    // You should not have to use any of the methods below here but you should
    // provide XML documentation for the argumented constructor, the Run method and one
    // of the LoadCommand methods.
    public Robot() : this(DefaultCommands) { }

    /// <summary>
    /// Constructor that initializes the robot with the capacity to store a user specified
    /// number of commands
    /// </summary>
    /// <param name="numCommands">The maximum number of commands the robot can store</param>
    public Robot(int numCommands)
    {
        _commands = new IRobotCommand[numCommands];
        //_commands = new Queue<IRobotCommand>(numCommands);
        NumCommands = numCommands;
    }

    /// <summary>
    /// Runs the loaded commands on the robot.
    /// </summary>
    public void Run()
    {
        for (var i = 0; i < _commandsLoaded; ++i)
        {
            _commands[i].Run(this);
            Console.WriteLine(this);
            ToString();
        }
        // if (_commands.Count == 0)
        //     throw new InvalidOperationException("No commands have been loaded!");

        // while (_commands.Count > 0)
        // {
        //     var command = _commands.Dequeue();
        //     command.Run(this);
        //     Console.WriteLine(this);
        // }

    }

    /// <summary>
    /// Loads a command into the robot.
    /// </summary>
    /// <param name="command">The command to load.</param>
    /// <returns><c>true</c> if the command was successfully loaded; otherwise, <c>false</c>.</returns>
    public bool LoadCommand(IRobotCommand command)
    {
        if (_commandsLoaded >= NumCommands)
            return false;
        _commands[_commandsLoaded++] = command;
        return true;

        //     if (_commands.Count >= NumCommands)
        //             return false;

        //         _commands.Enqueue(command);
        //         return true;
    }

}

public class RobotTester
{
    public Robot Robot { get; set; }
    //private Robot _robot;
    // to avoid null warning 
    private String? _userCommand;
    private IRobotCommand? _command;

    public RobotTester()
    {
        //make a instance of Robot
        Robot = new Robot();
    }
    public RobotTester(Robot robot)
    {
        Robot = robot;
    }
    //This method take user input and assigning commands to the robot object
    public void Giveinstructions()
    {
        //To print a message based on user input
        Console.WriteLine("Give " + Robot.NumCommands + " commands to the robot. Possible commands are: ");
        //possible commands that the user can enter
        Console.WriteLine("on\noff\nnoth\nsouth\neast\nwest");
        //Console.ReadLine();
        //The Robot.NumCommand represents the maximum number of command the robot can store
        Console.WriteLine(Robot.NumCommands);
        //To store the value
        int count = Robot.NumCommands;
        //The execution starts from 1 to robot's number of command 
        for (var i = 1; i <= Robot.NumCommands; i++)
        {
            Console.Write($"Assign Command #" + i + ": ");
            //Read the user's input command
            _userCommand = Console.ReadLine();
            //if user's input is empty or whitespace
            if (string.IsNullOrWhiteSpace(_userCommand))
            {
                //then it will print an error
                Console.WriteLine("Invalid Command - try again");
                i--; // Decrement i to repeat the current iteration
                continue; // Skip loading the command
            }
            //This statement check the user input and  assigns the appropriate command to the _command variable.
            switch (_userCommand.ToLower())
            {
                case "west":
                    _command = new WestCommand();
                    break;
                case "east":
                    _command = new EastCommand();
                    break;
                case "south":
                    _command = new SouthCommand();
                    break;
                case "north":
                    _command = new NorthCommand();
                    break;
                case "on":
                    _command = new OnCommand();
                    break;
                case "off":
                    _command = new OffCommand();
                    break;
                default:
                    Console.WriteLine("Invalid Command - try again");
                    i--; // decreasing i to repeat loop
                    continue; // Skip loading the command
            }
            // Load the created command into the robot
            Robot.LoadCommand(_command);
        }
    }

    public void ExecuteCommands()
    {
        // Run the loaded commands on the robot
        Robot.Run();
    }
}
