namespace Assignment.InterfaceCommand;

// Define an interface for robot commands
public interface IRobotCommand
{
    // Method to execute the command on a robot
    void Run(Robot robot);
}
// Implementation of the OffCommand
public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}
// Implementation of the OnCommand
public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}
// Implementation of the WestCommand
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}
// Implementation of the EastCommand
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}
// Implementation of the SouthCommand
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}
// Implementation of the NorthCommand
public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}
// Implementation of the NorthEastCommand
public class NorthEastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; robot.X++; }
}
// Implementation of the NorthWestCommand
public class NorthWestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; robot.X--; }
}
// Implementation of the SouthEastCommand
public class SouthEastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; robot.X++; }
}
// Implementation of the SouthWestCommand
public class SouthWestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; robot.X--; }
}
