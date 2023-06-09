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
            RobotTester robotTester = new(new Robot(5));
            robotTester.Giveinstructions();
            robotTester.ExecuteCommands();

        }
    }
}
