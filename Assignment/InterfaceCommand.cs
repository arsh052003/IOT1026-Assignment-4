namespace Assignment.InterfaceCommand;

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}

public class NorthEastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; robot.X++; }
}

public class NorthWestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; robot.X--; }
}
public class SouthEastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; robot.X++; }
}
public class SouthWestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; robot.X--; }
}
