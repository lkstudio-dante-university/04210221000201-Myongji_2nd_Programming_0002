#define T01_TRAINING_01
#define T01_TRAINING_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04210203000201_Myongji_2nd_Programming_0002.E01.Training.Classes.Runtime.Training_01
{
	/**
	 * Training 1
	 */
	internal class CT01Training_01
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if T01_TRAINING_01
			int nNum = 0;

			Console.Write("구구단 입력 : ");
			int.TryParse(Console.ReadLine(), out nNum);

			// 잘못된 값을 입력했을 경우
			if(nNum < 2 || nNum > 9)
			{
				return;
			}

			for(int i = 1; i < 10; ++i)
			{
				Console.WriteLine("{0} * {1} = {2}", nNum, i, nNum * i);
			}
#elif T01_TRAINING_02
			int nMinNum = 0;
			int nMaxNum = 0;

			Console.Write("구구단 입력 : ");
			string[] oTokens = Console.ReadLine().Split();

			int.TryParse(oTokens[0], out nMinNum);
			int.TryParse(oTokens[1], out nMaxNum);

			bool bIsValidMinNum = nMinNum >= 2 && nMinNum <= 9;
			bool bIsValidMaxNum = nMaxNum >= 2 && nMaxNum <= 9;

			// 잘못된 값을 입력했을 경우
			if(!bIsValidMinNum || !bIsValidMaxNum)
			{
				return;
			}

			// 순서 변경이 필요 할 경우
			if(nMinNum > nMaxNum)
			{
				int nTemp = nMinNum;
				nMinNum = nMaxNum;
				nMaxNum = nTemp;
			}

			for(int i = nMinNum; i <= nMaxNum; ++i)
			{
				for(int j = 1; j < 10; ++j)
				{
					Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
				}

				Console.WriteLine();
			}
#endif // T01_TRAINING_01
		}
	}
}
