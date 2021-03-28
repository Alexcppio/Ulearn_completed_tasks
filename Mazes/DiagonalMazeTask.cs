namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            int value1 = 0;
            if(((double)height / width) < 1.2
                && height > width)
            {
                value1 = 3;
            }
            else if(((double)height / width) < 2
                && height > width)
            {
                value1 = 2;
            }
            else if(((double)width / height) > 2
                && width > height)
            {
                value1 = 1;
            }

            Path1(robot, width, height, value1);
        }
        public static void Path1(Robot robot, int width, int height, int value)
        {
            int widthX = width;
            int heightX = height;

            int check;

            if (value == 1)
            {
                check = height;
            }
            else
                check = width;
            while (check - 2 > 0)
            {
                if (value == 1)
                {
                    robot.MoveTo(Mazes.Direction.Right);
                    robot.MoveTo(Mazes.Direction.Right);
                    robot.MoveTo(Mazes.Direction.Right);
                    if(check - 3 != 0)
                    {
                        robot.MoveTo(Mazes.Direction.Down); // work
                    }
                }
                else if (value == 2)
                {
                    robot.MoveTo(Mazes.Direction.Down);
                    robot.MoveTo(Mazes.Direction.Down);
                    if(check - 3 != 0)
                    {
                        robot.MoveTo(Mazes.Direction.Right); // work
                    }
                }
                else if (value == 3)
                {
                    robot.MoveTo(Mazes.Direction.Down);
                    if (check - 3 != 0)
                    {
                        robot.MoveTo(Mazes.Direction.Right); // work
                    }
                }
                
                check--;
            }
        }
    }
}