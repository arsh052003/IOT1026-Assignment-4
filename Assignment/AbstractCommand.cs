namespace Assignment.AbstractCommand;

abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}
class OffCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = false;
}

class OnCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = true;
}

class WestCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}

class EastCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}

class SouthCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}

class NorthCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}
