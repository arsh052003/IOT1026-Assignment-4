namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            // Run your RobotTester class here -> RobotTester.TestRobot()
            InterfaceCommand.OnCommand onCommand = new InterfaceCommand.OnCommand();
            Robot robot1 = new(2);
            robot1.LoadCommand(new InterfaceCommand.OnCommand());
            Console.WriteLine(robot1.ToString());
            robot1.LoadCommand(new InterfaceCommand.NorthCommand());
            robot1.Run();
            Console.WriteLine(robot1.ToString());
        }
    }
}
