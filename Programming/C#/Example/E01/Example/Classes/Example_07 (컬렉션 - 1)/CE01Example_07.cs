#define E07_COLLECTION_01
#define E07_COLLECTION_02
#define E07_COLLECTION_03
#define E07_COLLECTION_04

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01.Example.Classes.Example_07
{
	/**
	 * Example 7
	 */
	internal class CE01Example_07
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if E07_COLLECTION_01
			int[] oValsA = new int[5];
			oValsA[0] = 1;
			oValsA[1] = 2;
			oValsA[2] = 3;

			int[] oValsB = new int[5]
			{
				1, 2, 3, 4, 5
			};

			int[] oValsC = new int[]
			{
				1, 2, 3
			};

			Console.WriteLine("=====> 배열 A <=====");

			for(int i = 0; i < oValsA.Length; ++i)
			{
				Console.Write("{0}, ", oValsA[i]);
			}

			Console.WriteLine("\n\n=====> 배열 B <=====");

			for(int i = 0; i < oValsB.Length; ++i)
			{
				Console.Write("{0}, ", oValsB[i]);
			}

			Console.WriteLine("\n\n=====> 배열 C <=====");

			for(int i = 0; i < oValsC.Length; ++i)
			{
				Console.Write("{0}, ", oValsC[i]);
			}

			Console.WriteLine();
#elif E07_COLLECTION_02
			int[,] oMatrixA = new int[3, 3];
			oMatrixA[0, 0] = 1;
			oMatrixA[0, 1] = 2;
			oMatrixA[0, 2] = 3;

			int[,] oMatrixB = new int[3, 3]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

			int[,] oMatrixC = new int[,]
			{
				{ 1, 2 },
				{ 3, 4 }
			};

			Console.WriteLine("=====> 행렬 A <=====");

			for(int i = 0; i < oMatrixA.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixA.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixA[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n=====> 행렬 B <=====");

			for(int i = 0; i < oMatrixB.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixB.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixB[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n=====> 행렬 C <=====");

			for(int i = 0; i < oMatrixC.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixC.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixC[i, j]);
				}

				Console.WriteLine();
			}
#elif E07_COLLECTION_03
			int[][] oVals = new int[3][];

			for(int i = 0; i < oVals.Length; ++i)
			{
				oVals[i] = new int[(i + 1) * 3];
			}

			for(int i = 0; i < oVals.Length; ++i)
			{
				for(int j = 0; j < oVals[i].Length; ++j)
				{
					oVals[i][j] = j + 1;
				}
			}

			Console.WriteLine("=====> 가변 배열 <=====");

			for(int i = 0; i < oVals.Length; ++i)
			{
				for(int j = 0; j < oVals[i].Length; ++j)
				{
					Console.Write("{0}, ", oVals[i][j]);
				}

				Console.WriteLine();
			}
#elif E07_COLLECTION_04
			List<int> oValListA = new List<int>();
			List<List<int>> oValListB = new List<List<int>>();

			for(int i = 0; i < 10; ++i)
			{
				/*
				 * 리스트와 같이 길이가 정해지지않은 컬렉션은 Add 와 같은 메서드를 통해서 데이터를 추가하는 과정을
				 * 거치고 나서야 [] (인덱스 연산자) 를 사용하는 것이 가능하다. (즉, 데이터를 추가하지 않고 특정
				 * 데이터에 접근하는 시도를 할 경우 런타임 에러가 발생한다는 것을 알 수 있다.)
				 */
				oValListA.Add(i + 1);
			}

			for(int i = 0; i < 10; ++i)
			{
				var oValList = new List<int>();

				for(int j = 0; j < 10; ++j)
				{
					int nBase = i * 10;
					oValList.Add(nBase + j);
				}

				/*
				 * 리스트의 요소로 리스트를 명시함으로서 2 차원 이상의 배열과 유사한 구조를 만들어내는 것이 가능하다.
				 * (즉, 리스트의 요소로 어떤 자료형을 명시하느냐에 따라 리스트의 용도가 달라진다는 것을 알 수 있다.)
				 */
				oValListB.Add(oValList);
			}

			Console.WriteLine("=====> 리스트 A <=====");

			for(int i = 0; i < oValListA.Count; ++i)
			{
				Console.Write("{0}, ", oValListA[i]);
			}

			Console.WriteLine("\n\n=====> 리스트 B <=====");

			for(int i = 0; i < oValListB.Count; ++i)
			{
				for(int j = 0; j < oValListB[i].Count; ++j)
				{
					Console.Write("{0}, ", oValListB[i][j]);
				}

				Console.WriteLine();
			}
#endif // E07_COLLECTION_01
		}
	}
}
