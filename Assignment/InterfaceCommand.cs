namespace Assignment.InterfaceCommand;

interface IRobotCommand
{
    void Run(Robot robot);
}

class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

class WestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}

class EastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}

class SouthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}

class NorthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}

