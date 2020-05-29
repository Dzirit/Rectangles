using System;


namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
			return (r1.Bottom >r2.Top  || r2.Bottom > r1.Top || r2.Left > r1.Right || r1.Left>r2.Right );
			//return ((Math.Max(r1.Left,r2.Left)<= Math.Min(r1.Right,r2.Right))&& (Math.Max(r1.Bottom, r2.Bottom) >= Math.Min(r1.Top, r2.Top)));//Эквиваленто первому...

		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1,r2))
			{
				var maxTop = Math.Max(r1.Top, r2.Top);
				var maxRight = Math.Max(r1.Right, r2.Right);
				var maxLeft = Math.Max(r1.Left, r2.Left);
				var maxBottom= Math.Max(r1.Bottom, r2.Bottom);
				return maxBottom * maxRight;
			}
			return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			return -1;
		}
	}
}