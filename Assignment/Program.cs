namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            //Run your RobotTester class here -> RobotTester.TestRobot()
            InterfaceCommand.OnCommand onCommand = new InterfaceCommand.OnCommand();
            //creates a new instance of the Robot class with a capacity of 2 commands 
            Robot robot1 = new(2);
            //Loads an instance of the OnCommand class into the robot1 object 
            robot1.LoadCommand(new InterfaceCommand.OnCommand());
            //Creates a new instance of the RobotTester class, passing a new instance of the Robot class with a capacity of 5 commands
            RobotTester robotTester = new(new Robot(5));
            //Calling the Giveinstructions method  and ExecuteCommand method of the robotTester object
            robotTester.Giveinstructions();
            robotTester.ExecuteCommands();
        }
    }
}
