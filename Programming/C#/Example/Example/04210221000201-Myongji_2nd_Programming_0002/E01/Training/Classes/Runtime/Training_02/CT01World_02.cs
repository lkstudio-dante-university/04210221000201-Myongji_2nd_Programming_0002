using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04210221000201_Myongji_2nd_Programming_0002.E01.Training.Classes.Runtime.Training_02
{
	/**
	 * 월드
	 */
	internal class CT01World_02
	{
		public int Width { get; private set; } = 0;
		public int Height { get; private set; } = 0;

		public char[,] Buffer { get; private set; } = null;
		public StringBuilder StrBuilder { get; private set; } = new StringBuilder();

		/** 생성자 */
		public CT01World_02(int a_nWidth, int a_nHeight)
		{
			this.Width = a_nWidth;
			this.Height = a_nHeight;

			this.Buffer = new char[this.Height + 2, this.Width + 2];
		}

		/** 물체를 그린다 */
		public void Draw()
		{
			this.DrawOutline();
		}

		/** 버퍼를 출력한다 */
		public void PrintBuffer()
		{
			this.StrBuilder.Clear();

			for(int i = 0; i < this.Buffer.GetLength(0); ++i)
			{
				for(int j = 0; j < this.Buffer.GetLength(1); ++j)
				{
					this.StrBuilder.Append(this.Buffer[i, j]);
				}

				this.StrBuilder.AppendLine();
			}

			Console.SetCursorPosition(0, 0);
			Console.WriteLine(this.StrBuilder.ToString());
		}

		/** 경계선을 그린다 */
		private void DrawOutline()
		{
			for(int i = 0; i < this.Height + 2; ++i)
			{
				for(int j = 0; j < this.Width + 2; ++j)
				{
					// 위쪽, 아래쪽 경계선 일 경우
					if(i <= 0 || i >= this.Height + 1)
					{
						this.Buffer[i, j] = '#';
					}
					else
					{
						bool bIsOutline = j <= 0 || j >= this.Width + 1;
						this.Buffer[i, j] = bIsOutline ? '#' : ' ';
					}
				}
			}
		}
	}
}
