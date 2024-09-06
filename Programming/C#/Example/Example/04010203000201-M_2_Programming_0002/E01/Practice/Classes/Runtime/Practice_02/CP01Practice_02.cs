using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04010203000201_M_2_Programming_0002.E01.Practice.Classes.Runtime.Practice_02
{
	/**
	 * Practice 2
	 */
	internal class CP01Practice_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oRandom = new Random();

			int nWidth = 35;
			int nHeight = 10;

			int nPosX = nWidth / 2;
			int nPosY = nHeight / 2;

			int nDirection = 0; // 0 : Up, 1 : Down, 2 : Left, 3 : Right
			nDirection = oRandom.Next(0, 4);

			DateTime stPrevTime = DateTime.Now;
			double dblUpdateSkipTime = 0.0;

			while(true)
			{
				DateTime stCurTime = DateTime.Now;
				TimeSpan stDeltaTime = stCurTime - stPrevTime;

				stPrevTime = stCurTime;
				dblUpdateSkipTime += stDeltaTime.TotalSeconds;

				Console.Clear();

				UpdateStateSnake(ref nPosX,
					ref nPosY, ref nDirection, nWidth, nHeight, ref dblUpdateSkipTime);

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
		private static void UpdateStateSnake(ref int a_nPosX,
			ref int a_nPosY, ref int a_nDirection, int a_nWidth, int a_nHeight, ref double a_dblTimeUpdateSkip)
		{
			// 방향 키를 눌렀을 경우
			if(Console.KeyAvailable)
			{
				var stInfoKey = Console.ReadKey();

				switch(stInfoKey.Key)
				{
					case ConsoleKey.UpArrow:
						a_nDirection = 0;
						break;

					case ConsoleKey.DownArrow:
						a_nDirection = 1;
						break;

					case ConsoleKey.LeftArrow:
						a_nDirection = 2;
						break;

					case ConsoleKey.RightArrow:
						a_nDirection = 3;
						break;
				}
			}

			var oListOffsets = new List<(int, int)>()
			{
				(0, -1), (0, 1), (-1, 0), (1, 0)
			};

			int nOffsetX = oListOffsets[a_nDirection].Item1;
			int nOffsetY = oListOffsets[a_nDirection].Item2;

			// 일정 시간이 지났을 경우
			if(a_dblTimeUpdateSkip >= 0.15)
			{
				a_nPosX = Math.Clamp(a_nPosX + nOffsetX, 1, a_nWidth);
				a_nPosY = Math.Clamp(a_nPosY + nOffsetY, 1, a_nHeight);

				a_dblTimeUpdateSkip = 0.0;
			}
		}
	}
}
