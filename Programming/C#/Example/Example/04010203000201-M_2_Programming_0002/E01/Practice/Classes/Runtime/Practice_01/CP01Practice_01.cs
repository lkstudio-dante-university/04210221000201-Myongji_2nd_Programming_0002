using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._04010203000201_M_2_Programming_0002.E01.Practice.Classes.Runtime.Practice_01
{
	/**
	 * Practice 1
	 */
	internal class CP01Practice_01
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
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

			for(int j = 1; j < 10; ++j)
			{
				for(int i = nMinNum; i <= nMaxNum; ++i)
				{
					Console.Write("{0} * {1} = {2}\t", i, j, i * j);
				}

				Console.WriteLine();
			}
		}
	}
}
