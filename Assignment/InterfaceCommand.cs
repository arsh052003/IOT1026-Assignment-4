namespace Assignment.InterfaceCommand;

interface RobotCommand
{
    void Run(Robot robot); // Interfaces are public and abstract by default.
}
interface IRobotCommand
{
    void Run();
}
