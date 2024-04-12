using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Practice.Classes.Practice_02
{
	/**
	 * Practice 2
	 */
	internal class CP01Practice_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			int nWidth = 35;
			int nHeight = 10;

			int nPosX = nWidth / 2;
			int nPosY = nHeight / 2;

			while(true)
			{
				Console.Clear();
				UpdateStateSnake(ref nPosX, ref nPosY, nWidth, nHeight);

				DrawBoard(nWidth, nHeight);
				DrawSnake(nPosX, nPosY);

				System.Threading.Thread.Sleep(10);
			}
		}

		/** 보드를 그린다 */
		private static void DrawBoard(int a_nWidth, int a_nHeight)
		{
			for(int i = 0; i < a_nHeight + 2; ++i)
			{
				for(int j = 0; j < a_nWidth + 2; ++j)
				{
					// 위쪽, 아래쪽 경계선 일 경우
					if(i <= 0 || i >= a_nHeight + 1)
					{
						Console.Write("#");
					}
					else
					{
						bool bIsOutside = j <= 0 || j >= a_nWidth + 1;
						Console.Write("{0}", bIsOutside ? '#' : ' ');
					}
				}

				Console.WriteLine();
			}
		}

		/** 스네이크를 그린다 */
		private static void DrawSnake(int a_nPosX, int a_nPosY)
		{
			Console.SetCursorPosition(a_nPosX, a_nPosY);
			Console.Write("@");
		}

		/** 스네이크 상태를 갱신한다 */
		private static void UpdateStateSnake(ref int a_nPosX, ref int a_nPosY, int a_nWidth, int a_nHeight)
		{
			// 방향 키를 눌렀을 경우
			if(Console.KeyAvailable)
			{
				var stInfoKey = Console.ReadKey();

				switch(stInfoKey.Key)
				{
					case ConsoleKey.UpArrow:
						a_nPosY -= 1;
						break;

					case ConsoleKey.DownArrow:
						a_nPosY += 1;
						break;

					case ConsoleKey.LeftArrow:
						a_nPosX -= 1;
						break;

					case ConsoleKey.RightArrow:
						a_nPosX += 1;
						break;
				}

				a_nPosX = Math.Clamp(a_nPosX, 1, a_nWidth);
				a_nPosY = Math.Clamp(a_nPosY, 1, a_nHeight);
			}
		}
	}
}
