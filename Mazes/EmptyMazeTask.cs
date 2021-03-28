namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			int steps = width + height - 6;
            while (steps > 0)
            {
                if (width - 3 > 0)
                {
					robot.MoveTo(Mazes.Direction.Right);
					width--;
				}
				else if(width - 3 <= 0 && height - 3 > 0)
                {
					robot.MoveTo(Mazes.Direction.Down);
					height--;
				}
				steps--;
			}
		}
	}
}