using System;


namespace Rectangles
{
	public static class RectanglesTask
	{
		//В мире компьютерной графики принято, что верхний левый угол экрана имеет координаты(0, 0), а ось Y направлена вниз, 
		//	а не вверх, как принято в математике.Поэтому в этой задаче нижний край прямоугольника имеет большую координату,
		//		чем верхний. Учитывайте это при решении задачи!
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
			//if ((r1.Left < r2.Left && r1.Right<r2.Left) || (r1.Top<r2.Top && r1.Bottom<r2.Top) ||
			//	(r2.Left < r1.Left && r2.Right < r1.Left) || (r2.Top < r1.Top && r2.Bottom < r1.Top))
			//	return false;
			//else
			//	return true;//УРА!)
			return ((r1.Right >= r2.Left) && (r1.Bottom >= r2.Top) &&
				(r2.Right >= r1.Left) && (r2.Bottom >= r1.Top));
			//if (((r1.Left <r2.Left && r1.Top < r2.Top) && (r1.Bottom < r2.Top || r1.Left < r2.Right))
			//	|| (((r2.Left < r1.Left && r2.Top < r1.Top) && (r2.Bottom < r1.Top || r2.Left < r1.Right))))
			//	return false;
			//else
			//	return true;
			//if (((r1.Bottom < r2.Top & r1.Top < r2.Top) & (r1.Right < r2.Right & r1.Left < r2.Right))
			//	|| ((r2.Bottom < r1.Top & r2.Top < r1.Top) & (r2.Right < r1.Right & r2.Left < r1.Right)))
			//	return false;
			//else
			//	return true;
			// везде одна проблема. Не учитываются отрицательные координаты.
			//if ((r1.Bottom > r2.Top && r1.Top > r2.Top && r1.Right > r2.Right && r1.Left > r2.Right)
			//	|| r2.Height > r1.Top && r2.Top > r1.Top && r2.Right > r1.Right && r2.Left > r1.Right)
			//	return false;
			//else
			//	return true;
			//return r1.Bottom >= r2.Top || r1.Left >= r2.Right || r2.Bottom >= r1.Top || r2.Left >= r1.Right;// Все случаи пересечения
			//return ((r1.Bottom <= r2.Top && r2.Bottom >= r1.Top) || (r2.Left <= r1.Right && r1.Left >= r2.Right)
			//	|| (r2.Bottom <= r1.Top && r1.Bottom >= r2.Top) || (r1.Left <= r2.Right && r2.Left >= r1.Right));
			//if (r1.Left > r2.Left && r1.Top > r2.Top)
			//{
			//	if (r1.Bottom <= r2.Top || r1.Left >= r2.Right) return true;
			//	else return false;
			//}
			//else
			//{
			//	if (r2.Bottom <= r1.Top || r2.Left >= r1.Right) return true;
			//	else return false;
			//}
			//return ((Math.Max(r1.Left,r2.Left)<= Math.Min(r1.Right,r2.Right))&& (Math.Max(r1.Bottom, r2.Bottom) >= Math.Min(r1.Top, r2.Top)));//Эквиваленто первому...
			//return (r2.Top<r1.Bottom && r1.Right>=r2.Left || r1.Top <r2.Bottom && r2.Right >= r1.Left);
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1,r2))
			{
				//return (r2.Left - r1.Right) * (r2.Top - r1.Bottom);
				var left = Math.Max(r1.Left, r2.Left);
				var right = Math.Min(r1.Right, r2.Right);
				var top = Math.Min(r1.Top, r2.Top);
				var bottom = Math.Min(r1.Bottom, r2.Bottom);
				var width = Math.Max(right,left) - Math.Min(left,right);
				var height = Math.Max(top,bottom) - Math.Min(top,bottom);
				return width * height;
			}
			return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (r2.Top >= r1.Top && r2.Left >=r1.Left && r2.Right <= r1.Right && r2.Bottom <= r1.Bottom) return 1;// r2 внутри
			else if (r1.Top >= r2.Top && r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom) return 0;// r1 внутри
			else return -1;
		}
	}
}