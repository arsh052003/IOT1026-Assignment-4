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
    private Robot _robot;
    //     // to avoid null warning
    private String? _userCommand;
    private IRobotCommand? _command;

    public RobotTester()
    {
        _robot = new Robot();
    }
    public RobotTester(Robot robot)
    {
        _robot = robot;
    }
    public void Giveinstructions()
    {
        Console.WriteLine("Give " + _robot.NumCommands + " commands to the robot. Possible commands are: ");
        Console.WriteLine("on\noff\nnoth\nsouth\neast\nwest");
        //Console.ReadLine();
        Console.WriteLine(_robot.NumCommands);
        int count = _robot.NumCommands;
        for (var i = 1; i <= _robot.NumCommands; i++)
        {
            Console.Write($"Assign Command #" + i + ": ");

            _userCommand = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(_userCommand))
            {
                Console.WriteLine("Invalid Command - try again");
                i--; // Decrement i to repeat the current iteration
                continue; // Skip loading the command
            }

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

            _robot.LoadCommand(_command);

        }
    }

    public void ExecuteCommands()
    {
        _robot.Run();
    }
}
