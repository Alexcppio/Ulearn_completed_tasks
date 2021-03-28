namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			int steps = ((width - 3) * (((height - 3) / 2) + 1)) + ((height - 3) / 2);
			int widthTemp = 0;
			int heightTemp = 1;

			while(steps > 0)
            {
				if(widthTemp < width - 3
					&& heightTemp % 2 != 0)
                {
					robot.MoveTo(Mazes.Direction.Right);
					widthTemp++;
				}
				else if(widthTemp == width - 3
					&& heightTemp % 2 != 0
					|| widthTemp == 0
					&& heightTemp % 2 == 0)
                {
					robot.MoveTo(Mazes.Direction.Down);
					robot.MoveTo(Mazes.Direction.Down);
					heightTemp++;
				}
				else if(widthTemp > 0
					&& heightTemp % 2 == 0)
                {
					robot.MoveTo(Mazes.Direction.Left);
					widthTemp--;
				}

				steps--;
            }
		}
	}
}