using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Training.Classes.Training_02
{
	/**
	 * Training 2
	 */
	internal class CT01Training_02
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

				for(int i = 0; i < nHeight + 2; ++i)
				{
					for(int j = 0; j < nWidth + 2; ++j)
					{
						// 위쪽, 아래쪽 경계선 일 경우
						if(i <= 0 || i >= nHeight + 1)
						{
							Console.Write("#");
						}
						else
						{
							bool bIsOutside = j <= 0 || j >= nWidth + 1;
							Console.Write("{0}", bIsOutside ? '#' : ' ');
						}
					}

					Console.WriteLine();
				}

				// 방향 키를 눌렀을 경우
				if(Console.KeyAvailable)
				{
					var stInfoKey = Console.ReadKey();

					switch(stInfoKey.Key)
					{
						case ConsoleKey.UpArrow:
							nPosY -= 1;
							break;

						case ConsoleKey.DownArrow:
							nPosY += 1;
							break;

						case ConsoleKey.LeftArrow:
							nPosX -= 1;
							break;

						case ConsoleKey.RightArrow:
							nPosX += 1;
							break;
					}

					nPosX = Math.Clamp(nPosX, 1, nWidth);
					nPosY = Math.Clamp(nPosY, 1, nHeight);
				}

				Console.SetCursorPosition(nPosX, nPosY);
				Console.Write("@");

				System.Threading.Thread.Sleep(10);
			}
		}
	}
}
