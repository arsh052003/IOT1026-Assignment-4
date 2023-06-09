using Assignment;
using Assignment.InterfaceCommand;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        //Testing the properties and behavior of the Robot class
        public void PropertyTest()
        {
            Robot robot1 = new();
            Assert.AreEqual(robot1.NumCommands, 6);
            const int ExpectedCommands = 10;
            Robot robot2 = new(ExpectedCommands);
            Assert.AreEqual(robot2.NumCommands, ExpectedCommands);

            Assert.AreEqual(robot1.IsPowered, false);

            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);

            Assert.AreEqual(robot1.X, 0);
            // Moves the robot can move even though it is off!!
            // This is very bad! Not good encapsulation
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);

            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);
        }

        [TestMethod]
        // Testing the OnCommand class and its effect on the Robot
        public void OnCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.LoadCommand(new OnCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, true);
            // Robot executes the OnCommand again (memory isn't cleared between runs)
            testRobot.Run();
            // Verifies if a turned on Robot is turned on again, it stays powered on
            Assert.AreEqual(testRobot.IsPowered, true);
        }

        [TestMethod]
        // Testing the OffCommand class and its effect on the Robot
        public void OffCommandTest()
        {
            Robot testRobot = new();
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.IsPowered = true;
            testRobot.LoadCommand(new OffCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, false);
        }

        [TestMethod]
        // Testing the WestCommand class and its effect on the Robot's X-coordinate
        public void MoveWestCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.LoadCommand(new WestCommand());
            testRobot.Run();
            // Robot is powered off by default
            Assert.AreEqual(testRobot.X, 0); // Robot should not move if it isn't turned on
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.X, -1);
            testRobot.Run();
            Assert.AreEqual(testRobot.X, -2);
        }

        [TestMethod]
        // Testing the NorthCommand class and its effect on the Robot's Y-coordinate
        public void MoveNorthCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new NorthCommand());
            testRobot.Run();
            // Robot is powered off by default
            Assert.AreEqual(testRobot.Y, 0); // Robot should not move if it isn't turned on
            testRobot.IsPowered = true;
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 1);
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 2);
        }
        [TestMethod]
        // Testing the EastCommand class and its effect on the Robot's X-coordinate
        public void MoveEastCommandTest()
        {
            Robot testRobot = new Robot();
            //Checking if robot is set to 0 on X-coordinate.
            Assert.AreEqual(testRobot.X, 0);
            //Loading the EastCommand into robot's command list
            testRobot.LoadCommand(new EastCommand());
            // Running the loaded commands
            testRobot.Run();
            // Robot is powered off by default
            Assert.AreEqual(testRobot.X, 0); // Robot should not move if it isn't turned on
            testRobot.IsPowered = true;
            testRobot.Run();
            //Checking if the robot's X-coordinate is incremented by 1
            Assert.AreEqual(testRobot.X, 1);
        }
        [TestMethod]
        // Testing the SouthCommand class and its effect on the Robot's Y-coordinate
        public void MoveSouthCommandTest()
        {
            Robot testRobot = new Robot();
            //Checking if robot is set to 0 on Y-coordinate.
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new SouthCommand());
            testRobot.Run();
            // Robot is powered off by default
            Assert.AreEqual(testRobot.Y, 0); // Robot should not move if it isn't turned on
            testRobot.IsPowered = true;
            testRobot.Run();
            //Checking if the robot's Y-coordinate is decrease by 1
            Assert.AreEqual(testRobot.Y, -1);
        }
        [TestMethod]
        // Testing the NewCommand class and its effect on the Robot's X and Y coordinate
        public void NewCommandTest()
        {
            Robot testRobot = new Robot();
            //Checking if the robot's Y-coordinate is set to 0
            Assert.AreEqual(testRobot.Y, 0);
            //Checking if the robot's X-coordinate is set to 0
            Assert.AreEqual(testRobot.X, 0);
            testRobot.LoadCommand(new NorthEastCommand());
            testRobot.IsPowered = true;
            testRobot.Run();
            //Checking if the robot's Y-coordinate is increase by 1
            Assert.AreEqual(testRobot.Y, 1);
            //Checking if the robot's X-coordinate is increase by 1
            Assert.AreEqual(testRobot.X, 1);

            // The following code blocks test different NewCommand classes in a similar manner
            Robot testRobot1 = new Robot();
            testRobot1.LoadCommand(new NorthWestCommand());
            testRobot1.IsPowered = true;
            testRobot1.Run();
            Assert.AreEqual(testRobot1.Y, 1);
            Assert.AreEqual(testRobot1.X, -1);

            Robot testRobot2 = new Robot();
            testRobot2.LoadCommand(new SouthEastCommand());
            testRobot2.IsPowered = true;
            testRobot2.Run();
            Assert.AreEqual(testRobot2.Y, -1);
            Assert.AreEqual(testRobot2.X, 1);

            Robot testRobot3 = new Robot();
            testRobot3.LoadCommand(new SouthWestCommand());
            testRobot3.IsPowered = true;
            testRobot3.Run();
            Assert.AreEqual(testRobot3.Y, -1);
            Assert.AreEqual(testRobot3.X, -1);
        }

        [TestMethod]
        // Testing the behavior of overloading commands in the Robot class
        public void OverLoadTest()
        {
            Robot testRobot = new Robot(2);
            // Loading the OnCommand into the robot's command list
            testRobot.LoadCommand(new OnCommand());
            // Loading the OffCommand into the robot's command list
            testRobot.LoadCommand(new OffCommand());
            Assert.AreEqual(testRobot.LoadCommand(new OnCommand()), false);
        }
        [TestMethod]
        //Testing the RobotTester class
        public void RobotTesterTest()
        {
            // Creating a new Robot object
            Robot robot = new(6);
            //Loading commands manually since console.readline is not working in Test class
            robot.LoadCommand(new WestCommand());
            robot.LoadCommand(new OnCommand());
            robot.LoadCommand(new NorthCommand());
            robot.LoadCommand(new NorthCommand());
            robot.LoadCommand(new EastCommand());
            robot.LoadCommand(new OffCommand());
            RobotTester robotTester = new(robot);
            robotTester.ExecuteCommands();
            Assert.AreEqual(robotTester.Robot.X, 1);
            Assert.AreEqual(robotTester.Robot.Y, 2);
            Assert.AreEqual(robotTester.Robot.IsPowered, false);
        }

        [TestMethod]
        //Testing the defaultRobotTester class
        public void RobotTesterDefaultTest()
        {
            RobotTester robotTester = new();
            robotTester.Robot.LoadCommand(new WestCommand());
            robotTester.Robot.LoadCommand(new OnCommand());
            robotTester.Robot.LoadCommand(new NorthCommand());
            robotTester.Robot.LoadCommand(new NorthCommand());
            robotTester.Robot.LoadCommand(new EastCommand());
            robotTester.Robot.LoadCommand(new OffCommand());
            robotTester.ExecuteCommands();
            Assert.AreEqual(robotTester.Robot.X, 1);
            Assert.AreEqual(robotTester.Robot.Y, 2);
            Assert.AreEqual(robotTester.Robot.IsPowered, false);
        }
    }
}
